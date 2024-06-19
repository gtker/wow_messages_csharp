using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ADD_RUNE_POWER: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Emus bitshifts 1 by the rune index instead of directly sending the index.
    /// mangostwo: mask (0x00-0x3F probably)
    /// </summary>
    public required uint Rune { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Rune, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 1160, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 1160, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ADD_RUNE_POWER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var rune = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ADD_RUNE_POWER {
            Rune = rune,
        };
    }

}

