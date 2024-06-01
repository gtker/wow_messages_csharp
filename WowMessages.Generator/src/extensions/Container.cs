using System.Diagnostics;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

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

        if (e.ObjectType is ObjectTypeMsg)
        {
            Console.WriteLine($"Skipping {e.Name} because is MSG type");
            return true;
        }

        if (e.IsWorld() && e.Name is not ("CMSG_AUTH_SESSION" or "SMSG_AUTH_CHALLENGE"))
        {
            Console.WriteLine($"Skipping {e.Name} because is world");
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
                ArrayTypePackedGuid => true,
                ArrayTypeSpell => true,
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
                                                     statement.StructMemberContent.ElseIfStatements.Count != 0,
                StructMemberOptional optional => true,
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            };
    }

    public static bool NeedsBodySize(this Container e) => e.IsWorld() && e.AllDefinitions().Any(d => d.IsCompressed());

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
                case StructMemberOptional optional:
                {
                    foreach (var m in optional.StructMemberContent.Members)
                    {
                        foreach (var d in m.AllDefinitions())
                        {
                            yield return d;
                        }
                    }
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(member));
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