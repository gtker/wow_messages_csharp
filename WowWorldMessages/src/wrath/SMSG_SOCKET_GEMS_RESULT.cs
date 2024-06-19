using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SOCKET_GEMS_RESULT: WrathServerMessage, IWorldMessage {
    public required ulong Item { get; set; }
    public const int SocketsLength = 3;
    public required uint[] Sockets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        foreach (var v in Sockets) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 22, 1291, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 22, 1291, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SOCKET_GEMS_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var sockets = new uint[SocketsLength];
        for (var i = 0; i < SocketsLength; ++i) {
            sockets[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_SOCKET_GEMS_RESULT {
            Item = item,
            Sockets = sockets,
        };
    }

}

