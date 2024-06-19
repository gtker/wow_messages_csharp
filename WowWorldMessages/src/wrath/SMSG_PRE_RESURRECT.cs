using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PRE_RESURRECT: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1172, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1172, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PRE_RESURRECT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SMSG_PRE_RESURRECT {
            Player = player,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        return size;
    }

}

