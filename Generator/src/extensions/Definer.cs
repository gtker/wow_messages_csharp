using Generator.Generated;

namespace Generator.Extensions;

public static class DefinerExtensions
{
    public static string FileName(this Definer e) => e.Name + ".cs";
}