using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_REMOVED_ALERT: WrathServerMessage, IWorldMessage {
    public required bool ShowAlert { get; set; }
    public required ulong EventId { get; set; }
    public required uint EventTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(ShowAlert, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EventTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 15, 1091, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 15, 1091, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_REMOVED_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var showAlert = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var eventTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_REMOVED_ALERT {
            ShowAlert = showAlert,
            EventId = eventId,
            EventTime = eventTime,
        };
    }

}

