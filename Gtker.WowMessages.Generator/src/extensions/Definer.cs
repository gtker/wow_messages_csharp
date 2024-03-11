using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class DefinerExtensions
{
    public static string FileName(this Definer e) => e.Name + ".cs";
}