using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSTANCE_RESET: WrathServerMessage, IWorldMessage {
    public required Wrath.Map Map { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 798, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 798, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSTANCE_RESET> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_INSTANCE_RESET {
            Map = map,
        };
    }

}

