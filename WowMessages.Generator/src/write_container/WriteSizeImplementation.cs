using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

public class WriteSizeImplementation
{
    public static void WriteSize(Writer s, Container e, string module, ushort manualSizeSubtraction)
    {
        s.Body("internal int Size()", s =>
        {
            if (!e.AllDefinitions().Any(d => d.IsCompressed()))
            {
                s.Wln("var size = 0;");
                s.Newline();

                foreach (var member in e.Members)
                {
                    WriteSizeMember(s, e, member, module);
                }

                s.Wln(manualSizeSubtraction == 0 ? "return size;" : $"return size - {manualSizeSubtraction};");
            }
            else
            {
                s.Wln("var memory = new MemoryStream();");
                s.Wln("Task.WaitAll(WriteBodyAsync(memory));");
                s.Wln("return (int)memory.Position;");
            }
        });
    }

    private static void WriteSizeMember(Writer s, Container e, StructMember member, string module)
    {
        switch (member)
        {
            case StructMemberDefinition d:
                s.Wln($"// {d.StructMemberContent.Name}: {d.StructMemberContent.DataType}");
                s.Wln($"size += {d.StructMemberContent.Size()};");
                s.Newline();
                break;
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, _) => { WriteSizeMember(s, e, member, module); },
                    (_, _, _, _) => { },
                    true, "");

                break;
            case StructMemberOptional structMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }
}