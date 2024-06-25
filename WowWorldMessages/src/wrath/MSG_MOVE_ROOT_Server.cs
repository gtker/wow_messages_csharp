using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_MOVE_ROOT_Server: WrathServerMessage, IWorldMessage {
    public required MovementInfo Info { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 236, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 236, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_MOVE_ROOT_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new MSG_MOVE_ROOT_Server {
            Info = info,
        };
    }

    internal int Size() {
        var size = 0;

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        return size;
    }

}

