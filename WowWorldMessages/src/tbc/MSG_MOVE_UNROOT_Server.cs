using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_MOVE_UNROOT_Server: TbcServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required MovementInfo Info { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 237, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 237, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_MOVE_UNROOT_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new MSG_MOVE_UNROOT_Server {
            Player = player,
            Info = info,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        return size;
    }

}

