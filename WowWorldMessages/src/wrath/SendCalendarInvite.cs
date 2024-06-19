using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SendCalendarInvite {
    public required ulong EventId { get; set; }
    public required ulong InviteId { get; set; }
    public required byte Status { get; set; }
    public required byte Rank { get; set; }
    public required bool IsGuildEvent { get; set; }
    public required ulong Creator { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(IsGuildEvent, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Creator, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SendCalendarInvite> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var isGuildEvent = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var creator = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SendCalendarInvite {
            EventId = eventId,
            InviteId = inviteId,
            Status = status,
            Rank = rank,
            IsGuildEvent = isGuildEvent,
            Creator = creator,
        };
    }

    internal int Size() {
        var size = 0;

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // status: Generator.Generated.DataTypeInteger
        size += 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        // is_guild_event: Generator.Generated.DataTypeBool
        size += 1;

        // creator: Generator.Generated.DataTypePackedGuid
        size += Creator.PackedGuidLength();

        return size;
    }

}

