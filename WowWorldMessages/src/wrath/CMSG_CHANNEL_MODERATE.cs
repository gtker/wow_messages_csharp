using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CHANNEL_MODERATE: WrathClientMessage, IWorldMessage {
    public required string ChannelName { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(ChannelName, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 168, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 168, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CHANNEL_MODERATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var channelName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_CHANNEL_MODERATE {
            ChannelName = channelName,
        };
    }

    internal int Size() {
        var size = 0;

        // channel_name: Generator.Generated.DataTypeCstring
        size += ChannelName.Length + 1;

        return size;
    }

}

