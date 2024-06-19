using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_UPDATED_ALERT: WrathServerMessage, IWorldMessage {
    public required bool ShowAlert { get; set; }
    public required ulong EventId { get; set; }
    public required uint OldEventTime { get; set; }
    public required uint Flags { get; set; }
    public required uint NewEventTime { get; set; }
    public required byte EventType { get; set; }
    public required uint DungeonId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required byte Repeatable { get; set; }
    public required uint MaxInvitees { get; set; }
    public required uint UnknownTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(ShowAlert, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(OldEventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(NewEventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(EventType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Description, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Repeatable, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxInvitees, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(UnknownTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1092, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1092, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_UPDATED_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var showAlert = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var oldEventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var newEventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var eventType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var description = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var repeatable = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var maxInvitees = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknownTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_UPDATED_ALERT {
            ShowAlert = showAlert,
            EventId = eventId,
            OldEventTime = oldEventTime,
            Flags = flags,
            NewEventTime = newEventTime,
            EventType = eventType,
            DungeonId = dungeonId,
            Title = title,
            Description = description,
            Repeatable = repeatable,
            MaxInvitees = maxInvitees,
            UnknownTime = unknownTime,
        };
    }

    internal int Size() {
        var size = 0;

        // show_alert: Generator.Generated.DataTypeBool
        size += 1;

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // old_event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // new_event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // event_type: Generator.Generated.DataTypeInteger
        size += 1;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // description: Generator.Generated.DataTypeCstring
        size += Description.Length + 1;

        // repeatable: Generator.Generated.DataTypeInteger
        size += 1;

        // max_invitees: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown_time: Generator.Generated.DataTypeDateTime
        size += 4;

        return size;
    }

}

