using System.Diagnostics;
using Generator.Generated;

namespace Generator.Extensions;

public static class ContainerExtensions
{
    public static string FileName(this Container e) => e.Name + ".cs";

    public static bool ShouldSkip(this Container e)
    {
        if (e.AllMembers().Any(HasInvalidMember))
        {
            Console.WriteLine($"Skipping {e.Name} because it has unimplemented statements");
            return true;
        }

        if (e.AllPreparedObjects().Any(po =>
            {
                if (po.Enumerators is { } enumerators)
                {
                    return enumerators.Count > 32;
                }

                return false;
            }))
        {
            Console.WriteLine($"Skipping {e.Name} because it has too many enumerators");
            return true;
        }

        return false;

        bool HasInvalidDefinition(Definition d) => d.DataType switch
        {
            DataTypeArray array => array.InnerType switch
            {
                ArrayTypeCstring => false,
                ArrayTypeGuid => false,
                ArrayTypeInteger => false,
                ArrayTypePackedGuid => false,
                ArrayTypeSpell => false,
                ArrayTypeStruct s => s.StructData.ShouldSkip(),
                _ => throw new ArgumentOutOfRangeException()
            },
            DataTypeStruct s => s.StructData.ShouldSkip(),
            _ => false
        };


        bool HasInvalidMember(StructMember c) =>
            c switch
            {
                StructMemberDefinition d => HasInvalidDefinition(d.StructMemberContent),
                StructMemberIfStatement statement => statement.AllDefinitions().Any(HasInvalidDefinition),
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            };
    }

    public static bool RequiresAllModule(this Container e)
    {
        if (e.Tags.Version_.IsVersionAll())
        {
            return true;
        }

        foreach (var d in e.AllDefinitions())
        {
            switch (d.DataType)
            {
                case DataTypeArray array:
                    switch (array.InnerType)
                    {
                        case ArrayTypeStruct arrayTypeStruct:
                            if (arrayTypeStruct.StructData.Tags.Version_.IsVersionAll())
                            {
                                return true;
                            }

                            break;
                    }

                    break;
                case DataTypeStruct s:
                    if (s.StructData.Tags.Version_.IsVersionAll())
                    {
                        return true;
                    }

                    break;
            }
        }

        return false;
    }

    public static bool NeedsBodySize(this Container e) =>
        (e.IsWorld() && e.AllDefinitions().Any(d => d.IsCompressed() || d.IsEndlessArray())) ||
        e.Optional is not null || e.Tags.Compressed is true;

    public static IEnumerable<StructMember> AllMembers(this Container e)
    {
        foreach (var m in e.Members)
        {
            yield return m;

            switch (m)
            {
                case StructMemberDefinition:
                    break;
                case StructMemberIfStatement statement:
                    foreach (var member in statement.StructMemberContent.AllMembers())
                    {
                        yield return member;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m));
            }
        }

        if (e.Optional is { } optional)
        {
            foreach (var m in optional.AllMembers())
            {
                yield return m;
            }
        }
    }

    public static IEnumerable<string> EnumSeparateIfStatementVariables(this Container e)
    {
        foreach (var m in e.AllMembers())
        {
            switch (m)
            {
                case StructMemberDefinition:
                    break;
                case StructMemberIfStatement statement:
                    if (statement.StructMemberContent is
                        { PartOfSeparateIfStatement: true, OriginalType: DataTypeEnum })
                    {
                        foreach (var d in statement.AllDefinitions())
                        {
                            yield return
                                $"{d.DataType.CsType()} {statement.StructMemberContent.SeparateIfStatementNamePrefix()}{d.Name.ToMemberName()} = default;";
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m));
            }
        }
    }

    public static IEnumerable<Definition> AllDefinitions(this Container e)
    {
        foreach (var member in e.Members)
        {
            switch (member)
            {
                case StructMemberDefinition structMemberDefinition:
                    yield return structMemberDefinition.StructMemberContent;
                    break;
                case StructMemberIfStatement statement:
                    foreach (var d in statement.AllDefinitions())
                    {
                        yield return d;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(member));
            }
        }

        if (e.Optional is { } optional)
        {
            foreach (var m in optional.Members)
            {
                foreach (var d in m.AllDefinitions())
                {
                    yield return d;
                }
            }
        }
    }

    public static Definition FindDefinitionByName(this Container e, string name)
    {
        foreach (var d in e.AllDefinitions())
        {
            if (d.Name == name)
            {
                return d;
            }
        }

        throw new UnreachableException($"definition {name} not in container {e.Name}");
    }

    public static IEnumerable<PreparedObject> AllPreparedObjects(this Container e)
    {
        foreach (var preparedObject in e.PreparedObjects)
        {
            yield return preparedObject;
            foreach (var po in preparedObject.AllPreparedObjects())
            {
                yield return po;
            }
        }

        if (e.Optional is { } optional)
        {
            foreach (var po in optional.PreparedObjects)
            {
                yield return po;
            }
        }
    }

    public static IEnumerable<PreparedObject> AllEnumsWithMembers(this Container e)
    {
        var existingEnums = new HashSet<string>();

        foreach (var po in e.AllPreparedObjects())
        {
            if (po.Enumerators == null || po.DefinerType is not DefinerType.Enum_ ||
                po.Enumerators.Count == 0)
            {
                continue;
            }

            if (!po.Enumerators.Any(enumerator =>
                    enumerator.Value.Any(d => e.FindDefinitionByName(d.Name).IsInType())))
            {
                continue;
            }

            if (existingEnums.Add(po.UniqueString()))
            {
                yield return po;
            }
        }
    }

    public static IEnumerable<PreparedObject> AllFlagsWithMembers(this Container e)
    {
        foreach (var po in e.AllPreparedObjects())
        {
            if (po.Enumerators == null || po.DefinerType is not DefinerType.Flag ||
                po.Enumerators.Count == 0)
            {
                continue;
            }

            if (!po.Enumerators.Any(enumerator =>
                    enumerator.Value.Any(d => e.FindDefinitionByName(d.Name).IsInType())))
            {
                continue;
            }

            yield return po;
        }
    }

    public static ushort Opcode(this Container e) => e.ObjectType switch
    {
        ObjectTypeClogin objectTypeClogin => objectTypeClogin.Opcode,
        ObjectTypeCmsg objectTypeCmsg => objectTypeCmsg.Opcode,
        ObjectTypeMsg objectTypeMsg => objectTypeMsg.Opcode,
        ObjectTypeSlogin objectTypeSlogin => objectTypeSlogin.Opcode,
        ObjectTypeSmsg objectTypeSmsg => objectTypeSmsg.Opcode,
        ObjectTypeStruct => throw new UnreachableException(),
        _ => throw new ArgumentOutOfRangeException()
    };

    public static bool IsWorld(this Container e) => e.Tags.Version_.IsWorld();

    public static ushort HeaderSize(this Container e, bool isServer) => !isServer ? (ushort)4 : (ushort)2;

    public static PreparedObject FindPreparedObject(this Container e, string variableName)
    {
        foreach (var preparedObject in e.AllPreparedObjects())
        {
            if (preparedObject.Name == variableName)
            {
                if (preparedObject is { IsElseifFlag: true, Enumerators: { Count: 1 } enumerators })
                {
                    return enumerators.First().Value[0];
                }

                return preparedObject;
            }
        }

        throw new UnreachableException();
    }
}