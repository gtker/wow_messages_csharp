using Generator.Extensions;
using Generator.Generated;

namespace Generator;

public static class WriteEnumAndFlag
{
    public static Writer WriteEnum(Definer e, string module, string project, bool isFlag)
    {
        var s = new Writer();

        s.Wln($"namespace Wow{project}Messages.{module};");
        s.Newline();

        if (isFlag)
        {
            s.Wln("[Flags]");
        }

        s.Body($"public enum {e.Name} : {e.IntegerType.CsType()}", s =>
        {
            foreach (var enumerator in e.Enumerators)
            {
                s.Wln($"{enumerator.CsName()} = {enumerator.Value.value},");
            }
        });
        s.Newline();

        return s;
    }
}