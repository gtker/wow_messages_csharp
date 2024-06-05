using Generator.Generated;

namespace Generator.Extensions;

public static class OptionalMembersExtensions
{
    public static IEnumerable<Definition> AllDefinitions(this OptionalMembers optional) =>
        optional.Members.SelectMany(member => member.AllDefinitions());
}