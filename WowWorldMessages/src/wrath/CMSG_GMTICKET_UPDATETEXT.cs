using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GMTICKET_UPDATETEXT: WrathClientMessage, IWorldMessage {
    public required string Message { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Message, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 519, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 519, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GMTICKET_UPDATETEXT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var message = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_GMTICKET_UPDATETEXT {
            Message = message,
        };
    }

    internal int Size() {
        var size = 0;

        // message: Generator.Generated.DataTypeCstring
        size += Message.Length + 1;

        return size;
    }

}

