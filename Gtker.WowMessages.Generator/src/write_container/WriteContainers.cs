using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteContainers
{
    public static Writer? WriteContainer(Container e, string module, string project)
    {
        if (e.ShouldSkip())
        {
            return null;
        }

        var s = new Writer();
        s.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        s.Newline();

        s.Body($"public class {e.Name}", s =>
        {
            foreach (var member in e.Members)
            {
                if (member is StructMemberDefinition definition)
                {
                    var d = definition.StructMemberContent;
                    var name = Utils.CamelCaseToPascalCase(d.Name);
                    s.Wln($"public {d.DataType.CsType()} {name} {{ get; set; }}");
                }
                else if (member is StructMemberIfStatement)
                {
                    throw new NotImplementedException();
                }
                else if (member is StructMemberOptional)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(member));
                }
            }
        });

        return s;
    }
}