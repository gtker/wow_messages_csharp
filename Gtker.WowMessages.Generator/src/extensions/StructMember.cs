using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class StructMemberExtensions
{
    public static IEnumerable<Definition> AllDefinitions(this StructMember m)
    {
        switch (m)
        {
            case StructMemberDefinition structMemberDefinition:
                yield return structMemberDefinition.StructMemberContent;
                break;
            case StructMemberIfStatement statement:
                foreach (var d in statement.StructMemberContent.AllDefinitions())
                {
                    yield return d;
                }

                break;
            case StructMemberOptional optional:
                foreach (var member in optional.StructMemberContent.AllDefinitions())
                {
                    yield return member;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(m));
        }
    }
}