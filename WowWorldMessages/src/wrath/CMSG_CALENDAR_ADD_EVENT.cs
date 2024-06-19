using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_ADD_EVENT: WrathClientMessage, IWorldMessage {
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required byte EventType { get; set; }
    public required bool Repeatable { get; set; }
    public required uint MaximumInvites { get; set; }
    public required uint DungeonId { get; set; }
    public required uint EventTime { get; set; }
    public required uint TimeZoneTime { get; set; }
    public required uint Flags { get; set; }
    public required List<CalendarInvitee> Invitees { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Description, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(EventType, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Repeatable, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaximumInvites, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeZoneTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Invitees.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Invitees) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1069, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1069, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_ADD_EVENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var description = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var eventType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var repeatable = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var maximumInvites = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeZoneTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfInvitees = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var invitees = new List<CalendarInvitee>();
        for (var i = 0; i < amountOfInvitees; ++i) {
            invitees.Add(await Wrath.CalendarInvitee.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new CMSG_CALENDAR_ADD_EVENT {
            Title = title,
            Description = description,
            EventType = eventType,
            Repeatable = repeatable,
            MaximumInvites = maximumInvites,
            DungeonId = dungeonId,
            EventTime = eventTime,
            TimeZoneTime = timeZoneTime,
            Flags = flags,
            Invitees = invitees,
        };
    }

    internal int Size() {
        var size = 0;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // description: Generator.Generated.DataTypeCstring
        size += Description.Length + 1;

        // event_type: Generator.Generated.DataTypeInteger
        size += 1;

        // repeatable: Generator.Generated.DataTypeBool
        size += 1;

        // maximum_invites: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // time_zone_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_invitees: Generator.Generated.DataTypeInteger
        size += 4;

        // invitees: Generator.Generated.DataTypeArray
        size += Invitees.Sum(e => e.Size());

        return size;
    }

}

