using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_CHANNEL_WATCH: TbcClientMessage, IWorldMessage {
    public required string Channel { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Channel, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1006, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1006, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_CHANNEL_WATCH> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var channel = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_CHANNEL_WATCH {
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

