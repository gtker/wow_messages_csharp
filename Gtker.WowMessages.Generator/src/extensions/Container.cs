using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class ContainerExtensions
{
    public static string FileName(this Container e) => e.Name + ".cs";

    public static bool ShouldSkip(this Container e)
    {
        bool hasUnimplementedStatements;
        try
        {
            hasUnimplementedStatements = e.Members.Any(c => c switch
            {
                StructMemberDefinition d => d.StructMemberContent.DataType.CsType() == "",
                StructMemberIfStatement statement => true,
                StructMemberOptional optional => true,
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            });
        }
        catch
        {
            hasUnimplementedStatements = true;
        }

        return hasUnimplementedStatements;
    }
}