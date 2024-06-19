using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SendCalendarEvent {
    public required ulong EventId { get; set; }
    public required string Title { get; set; }
    public required uint EventType { get; set; }
    public required uint EventTime { get; set; }
    public required uint Flags { get; set; }
    public required uint DungeonId { get; set; }
    public required ulong Creator { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Creator, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SendCalendarEvent> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var eventType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var creator = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SendCalendarEvent {
            EventId = eventId,
            Title = title,
            EventType = eventType,
            EventTime = eventTime,
            Flags = flags,
            DungeonId = dungeonId,
            Creator = creator,
        };
    }

    internal int Size() {
        var size = 0;

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // event_type: Generator.Generated.DataTypeInteger
        size += 4;

        // event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // creator: Generator.Generated.DataTypePackedGuid
        size += Creator.PackedGuidLength();

        return size;
    }

}

