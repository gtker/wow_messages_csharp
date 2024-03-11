using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator;

public static class WriteEnumAndFlag
{
    public static Writer WriteEnum(Definer e, string module, string project, bool isFlag)
    {
        var s = new Writer();

        s.Wln($"namespace Gtker.WowMessages.{project}.{module};");
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