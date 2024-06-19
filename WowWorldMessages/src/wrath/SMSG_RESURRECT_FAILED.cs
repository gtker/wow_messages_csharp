using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_RESURRECT_FAILED: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// arcemu is the only emulator that has this.
    /// arcemu sets to 1.
    /// </summary>
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 594, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 594, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_RESURRECT_FAILED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_RESURRECT_FAILED {
            Unknown = unknown,
        };
    }

}

