using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_INVITE_ALERT: WrathServerMessage, IWorldMessage {
    public required ulong EventId { get; set; }
    public required string Title { get; set; }
    public required uint EventTime { get; set; }
    public required uint Flags { get; set; }
    public required uint EventType { get; set; }
    public required uint DungeonId { get; set; }
    public required ulong InviteId { get; set; }
    public required byte Status { get; set; }
    public required byte Rank { get; set; }
    public required ulong EventCreator { get; set; }
    public required ulong InviteSender { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(EventCreator, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(InviteSender, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1088, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1088, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_INVITE_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var eventType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var eventCreator = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var inviteSender = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_INVITE_ALERT {
            EventId = eventId,
            Title = title,
            EventTime = eventTime,
            Flags = flags,
            EventType = eventType,
            DungeonId = dungeonId,
            InviteId = inviteId,
            Status = status,
            Rank = rank,
            EventCreator = eventCreator,
            InviteSender = inviteSender,
        };
    }

    internal int Size() {
        var size = 0;

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // event_type: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // status: Generator.Generated.DataTypeInteger
        size += 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        // event_creator: Generator.Generated.DataTypePackedGuid
        size += EventCreator.PackedGuidLength();

        // invite_sender: Generator.Generated.DataTypePackedGuid
        size += InviteSender.PackedGuidLength();

        return size;
    }

}

