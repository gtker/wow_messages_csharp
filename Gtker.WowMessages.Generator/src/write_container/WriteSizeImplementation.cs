using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public class WriteSizeImplementation
{
    public static void WriteSize(Writer s, Container e, ushort manualSizeSubtraction)
    {
        s.Body("private int Size()", s =>
        {
            s.Wln("var size = 0;");
            s.Newline();

            foreach (var member in e.Members)
            {
                switch (member)
                {
                    case StructMemberDefinition d:
                        s.Wln($"// {d.StructMemberContent.Name}: {d.StructMemberContent.DataType}");
                        s.Wln($"size += {d.StructMemberContent.Size()};");
                        s.Newline();
                        break;
                    case StructMemberIfStatement structMemberIfStatement:
                        throw new NotImplementedException();
                    case StructMemberOptional structMemberOptional:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(member));
                }
            }

            s.Wln(manualSizeSubtraction == 0 ? "return size;" : $"return size - {manualSizeSubtraction};");
        });
    }
}