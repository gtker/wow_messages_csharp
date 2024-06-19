using Generator.Generated;

namespace Generator.Extensions;

public static class OptionalMembersExtensions
{
    public static IEnumerable<Definition> AllDefinitions(this OptionalMembers optional) =>
        optional.Members.SelectMany(member => member.AllDefinitions());

    public static IEnumerable<StructMember> AllMembers(this OptionalMembers optional)
    {
        foreach (var m in optional.Members)
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
    }
}