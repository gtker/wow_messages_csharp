using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CHANNEL_DISPLAY_LIST: WrathClientMessage, IWorldMessage {
    public required string Channel { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Channel, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 978, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 978, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CHANNEL_DISPLAY_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var channel = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_CHANNEL_DISPLAY_LIST {
            Channel = channel,
        };
    }

    internal int Size() {
        var size = 0;

        // channel: Generator.Generated.DataTypeCstring
        size += Channel.Length + 1;

        return size;
    }

}

