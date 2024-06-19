using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class CalendarInvitee {
    public required ulong Guid { get; set; }
    public required byte Status { get; set; }
    public required byte Rank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CalendarInvitee> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CalendarInvitee {
            Guid = guid,
            Status = status,
            Rank = rank,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // status: Generator.Generated.DataTypeInteger
        size += 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

