using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class CalendarSendInvitee {
    public required ulong Invitee { get; set; }
    public required byte Level { get; set; }
    public required byte Status { get; set; }
    public required byte Rank { get; set; }
    public required byte GuildMember { get; set; }
    public required ulong InviteId { get; set; }
    public required uint StatusTime { get; set; }
    public required string Text { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Invitee, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(GuildMember, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(StatusTime, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Text, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CalendarSendInvitee> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var invitee = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var guildMember = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var statusTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CalendarSendInvitee {
            Invitee = invitee,
            Level = level,
            Status = status,
            Rank = rank,
            GuildMember = guildMember,
            InviteId = inviteId,
            StatusTime = statusTime,
            Text = text,
        };
    }

    internal int Size() {
        var size = 0;

        // invitee: Generator.Generated.DataTypePackedGuid
        size += Invitee.PackedGuidLength();

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // status: Generator.Generated.DataTypeInteger
        size += 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        // guild_member: Generator.Generated.DataTypeInteger
        size += 1;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // status_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // text: Generator.Generated.DataTypeCstring
        size += Text.Length + 1;

        return size;
    }

}

