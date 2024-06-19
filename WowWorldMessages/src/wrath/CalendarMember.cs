using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class CalendarMember {
    public required ulong Member { get; set; }
    public required byte Level { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Member, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CalendarMember> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var member = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CalendarMember {
            Member = member,
            Level = level,
        };
    }

    internal int Size() {
        var size = 0;

        // member: Generator.Generated.DataTypePackedGuid
        size += Member.PackedGuidLength();

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        return size;
    }

}

