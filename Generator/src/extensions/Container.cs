using System.Diagnostics;
using Generator.Generated;

namespace Generator.Extensions;

public static class ContainerExtensions
{
    public static string FileName(this Container e) => e.Name + ".cs";

    public static bool ShouldSkip(this Container e)
    {
        bool hasUnimplementedStatements;
        try
        {
            hasUnimplementedStatements = e.Members.Any(HasInvalidMember);
        }
        catch
        {
            hasUnimplementedStatements = true;
        }

        if (hasUnimplementedStatements)
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
            _ => d.DataType.CsType() == ""
        };


        bool HasInvalidMember(StructMember c) =>
            c switch
            {
                StructMemberDefinition d => HasInvalidDefinition(d.StructMemberContent),
                StructMemberIfStatement statement => statement.AllDefinitions().Any(HasInvalidDefinition) ||
                                                     statement.StructMemberContent.IsElseIfFlag ||
                                                     statement.StructMemberContent.PartOfSeparateIfStatement,
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            };
    }

    public static bool NeedsBodySize(this Container e) =>
        (e.IsWorld() && e.AllDefinitions().Any(d => d.IsCompressed() || d.IsEndlessArray())) || e.Optional is not null;

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
    }

    public static IEnumerable<PreparedObject> AllEnumsWithMembers(this Container e)
    {
        var existingEnums = new HashSet<string>();

        foreach (var po in e.AllPreparedObjects())
        {
            var d = e.FindDefinitionByName(po.Name);
            if (po.Enumerators == null || d.DataType is not DataTypeEnum ||
                po.Enumerators.Count == 0)
            {
                continue;
            }

            if (!po.Enumerators.Any(enumerator =>
                    enumerator.Value.Any(d => e.FindDefinitionByName(d.Name).IsInType())))
            {
                continue;
            }

            if (existingEnums.Add(po.Name))
            {
                yield return po;
            }
        }
    }

    public static IEnumerable<PreparedObject> AllFlagsWithMembers(this Container e)
    {
        foreach (var po in e.AllPreparedObjects())
        {
            var d = e.FindDefinitionByName(po.Name);
            if (po.Enumerators == null || d.DataType is not DataTypeFlag ||
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
                return preparedObject;
            }
        }

        throw new UnreachableException();
    }

    public static string GetPrefixForPreparedObject(this Container e, string variableName)
    {
        foreach (var preparedObject in e.PreparedObjects)
        {
            if (GetPrefix(e, preparedObject, "") is { } ret)
            {
                return ret;
            }
        }

        throw new UnreachableException();

        string? GetPrefix(Container e, PreparedObject po, string prefix)
        {
            if (po.Name == variableName)
            {
                return prefix;
            }

            var d = e.FindDefinitionByName(po.Name);
            if (po.Enumerators is { } enumerators)
            {
                foreach (var (enumerator, members) in enumerators)
                {
                    foreach (var member in members)
                    {
                        if (GetPrefix(e, member, $"{prefix}{d.PreparedObjectTypeName(enumerator)}.") is
                            { } ret)
                        {
                            return ret;
                        }
                    }
                }
            }

            return null;
        }
    }
}