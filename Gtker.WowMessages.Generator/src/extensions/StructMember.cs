using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class StructMemberExtensions
{
    public static IEnumerable<Definition> AllMembers(this StructMember m)
    {
        switch (m)
        {
            case StructMemberDefinition structMemberDefinition:
                yield return structMemberDefinition.StructMemberContent;
                break;
            case StructMemberIfStatement statement:
                foreach (var d in statement.AllMembers())
                {
                    yield return d;
                }

                break;
            case StructMemberOptional optional:
                foreach (var member in optional.StructMemberContent.AllMembers())
                {
                    yield return member;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(m));
        }
    }
}