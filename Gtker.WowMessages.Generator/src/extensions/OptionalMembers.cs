using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class OptionalMembersExtensions
{
    public static IEnumerable<Definition> AllMembers(this OptionalMembers optional) =>
        optional.Members.SelectMany(member => member.AllMembers());
}