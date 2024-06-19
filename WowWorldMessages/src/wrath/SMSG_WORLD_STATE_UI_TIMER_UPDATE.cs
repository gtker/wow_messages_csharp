using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_WORLD_STATE_UI_TIMER_UPDATE: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Seconds since Unix Epoch
    /// </summary>
    public required uint Time { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 1271, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 1271, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_WORLD_STATE_UI_TIMER_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_WORLD_STATE_UI_TIMER_UPDATE {
            Time = time,
        };
    }

}

