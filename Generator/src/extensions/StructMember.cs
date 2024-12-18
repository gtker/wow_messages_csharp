using Generator.Generated;

namespace Generator.Extensions;

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
            default:
                throw new ArgumentOutOfRangeException(nameof(m));
        }
    }
}