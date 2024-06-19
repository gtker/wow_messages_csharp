using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_SEND_EVENT: WrathServerMessage, IWorldMessage {
    public required byte SendType { get; set; }
    public required ulong Creator { get; set; }
    public required ulong EventId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required byte EventType { get; set; }
    public required byte Repeatable { get; set; }
    public required uint MaxInvitees { get; set; }
    public required uint DungeonId { get; set; }
    public required uint Flags { get; set; }
    public required uint EventTime { get; set; }
    public required uint TimeZoneTime { get; set; }
    public required uint GuildId { get; set; }
    public required List<CalendarSendInvitee> Invitees { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(SendType, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Creator, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Description, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(EventType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Repeatable, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxInvitees, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeZoneTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GuildId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Invitees.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Invitees) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1079, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1079, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_SEND_EVENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var sendType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var creator = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var description = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var eventType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var repeatable = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var maxInvitees = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeZoneTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var guildId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfInvitees = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var invitees = new List<CalendarSendInvitee>();
        for (var i = 0; i < amountOfInvitees; ++i) {
            invitees.Add(await Wrath.CalendarSendInvitee.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_CALENDAR_SEND_EVENT {
            SendType = sendType,
            Creator = creator,
            EventId = eventId,
            Title = title,
            Description = description,
            EventType = eventType,
            Repeatable = repeatable,
            MaxInvitees = maxInvitees,
            DungeonId = dungeonId,
            Flags = flags,
            EventTime = eventTime,
            TimeZoneTime = timeZoneTime,
            GuildId = guildId,
            Invitees = invitees,
        };
    }

    internal int Size() {
        var size = 0;

        // send_type: Generator.Generated.DataTypeInteger
        size += 1;

        // creator: Generator.Generated.DataTypePackedGuid
        size += Creator.PackedGuidLength();

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // description: Generator.Generated.DataTypeCstring
        size += Description.Length + 1;

        // event_type: Generator.Generated.DataTypeInteger
        size += 1;

        // repeatable: Generator.Generated.DataTypeInteger
        size += 1;

        // max_invitees: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // time_zone_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // guild_id: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_invitees: Generator.Generated.DataTypeInteger
        size += 4;

        // invitees: Generator.Generated.DataTypeArray
        size += Invitees.Sum(e => e.Size());

        return size;
    }

}

