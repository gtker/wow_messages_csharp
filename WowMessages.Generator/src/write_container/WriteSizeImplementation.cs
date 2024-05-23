using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

public class WriteSizeImplementation
{
    public static void WriteSize(Writer s, Container e, ushort manualSizeSubtraction)
    {
        s.Body("internal int Size()", s =>
        {
            s.Wln("var size = 0;");
            s.Newline();

            foreach (var member in e.Members)
            {
                WriteSizeMember(s, e, member);
            }

            s.Wln(manualSizeSubtraction == 0 ? "return size;" : $"return size - {manualSizeSubtraction};");
        });
    }

    private static void WriteSizeMember(Writer s, Container e, StructMember member)
    {
        switch (member)
        {
            case StructMemberDefinition d:
                s.Wln($"// {d.StructMemberContent.Name}: {d.StructMemberContent.DataType}");
                s.Wln($"size += {d.StructMemberContent.Size()};");
                s.Newline();
                break;
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, WriteSizeMember, true);

                break;
            case StructMemberOptional structMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }
}