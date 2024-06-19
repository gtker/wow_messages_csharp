using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_SEND_NUM_PENDING: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Number of calendar items that require attention, e.g. pending invites
    /// </summary>
    public required uint PendingEvents { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(PendingEvents, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 1096, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 1096, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_SEND_NUM_PENDING> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var pendingEvents = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_SEND_NUM_PENDING {
            PendingEvents = pendingEvents,
        };
    }

}

