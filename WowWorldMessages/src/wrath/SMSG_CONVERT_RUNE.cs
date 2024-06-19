using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CONVERT_RUNE: WrathServerMessage, IWorldMessage {
    public required byte Index { get; set; }
    public required byte NewType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Index, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(NewType, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 4, 1158, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 4, 1158, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CONVERT_RUNE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var index = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var newType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_CONVERT_RUNE {
            Index = index,
            NewType = newType,
        };
    }

}

