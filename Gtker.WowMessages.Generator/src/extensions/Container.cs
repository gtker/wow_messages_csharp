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
                StructMemberDefinition d => d.StructMemberContent.DataType switch
                {
                    DataTypeArray array => array.Content.InnerType switch
                    {
                        ArrayTypeCstring => false,
                        ArrayTypeGuid => false,
                        ArrayTypeInteger => false,
                        ArrayTypePackedGuid => true,
                        ArrayTypeSpell => true,
                        ArrayTypeStruct s => s.Content.StructData.ShouldSkip(),
                        _ => throw new ArgumentOutOfRangeException()
                    },
                    DataTypeStruct s => s.Content.StructData.ShouldSkip(),
                    _ => d.StructMemberContent.DataType.CsType() == ""
                },
                StructMemberIfStatement statement => true,
                StructMemberOptional optional => true,
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            });
        }
        catch
        {
            hasUnimplementedStatements = true;
        }

        if (hasUnimplementedStatements)
        {
            Console.WriteLine($"Skipping {e.Name} because it has unimplemented statements");
        }

        return hasUnimplementedStatements;
    }

    public static IEnumerable<Definition> AllMembers(this Container e)
    {
        foreach (var member in e.Members)
        {
            switch (member)
            {
                case StructMemberDefinition structMemberDefinition:
                    yield return structMemberDefinition.StructMemberContent;
                    break;
                case StructMemberIfStatement statement:
                    break;
                case StructMemberOptional optional:
                {
                    foreach (var m in optional.StructMemberContent.Members)
                    {
                    }
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(member));
            }
        }
    }
}