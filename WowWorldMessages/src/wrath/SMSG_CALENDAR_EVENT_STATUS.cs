using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_STATUS: WrathServerMessage, IWorldMessage {
    public required ulong Invitee { get; set; }
    public required ulong EventId { get; set; }
    public required uint EventTime { get; set; }
    public required uint Flags { get; set; }
    public required byte Status { get; set; }
    public required byte Rank { get; set; }
    public required uint StatusTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Invitee, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(StatusTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1084, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1084, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var invitee = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var statusTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_STATUS {
            Invitee = invitee,
            EventId = eventId,
            EventTime = eventTime,
            Flags = flags,
            Status = status,
            Rank = rank,
            StatusTime = statusTime,
        };
    }

    internal int Size() {
        var size = 0;

        // invitee: Generator.Generated.DataTypePackedGuid
        size += Invitee.PackedGuidLength();

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // event_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // status: Generator.Generated.DataTypeInteger
        size += 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        // status_time: Generator.Generated.DataTypeDateTime
        size += 4;

        return size;
    }

}

