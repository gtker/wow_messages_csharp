using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT: WrathServerMessage, IWorldMessage {
    public required ulong EventId { get; set; }
    public required uint EventTime { get; set; }
    public required uint Flags { get; set; }
    public required byte Status { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Status, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 19, 1089, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 19, 1089, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var status = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT {
            EventId = eventId,
            EventTime = eventTime,
            Flags = flags,
            Status = status,
        };
    }

}

