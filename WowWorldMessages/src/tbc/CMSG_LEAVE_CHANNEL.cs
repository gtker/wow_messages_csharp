using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LEAVE_CHANNEL: TbcClientMessage, IWorldMessage {
    public required uint ChannelId { get; set; }
    public required string ChannelName { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ChannelId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(ChannelName, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 152, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 152, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LEAVE_CHANNEL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var channelId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var channelName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_LEAVE_CHANNEL {
            ChannelId = channelId,
            ChannelName = channelName,
        };
    }

    internal int Size() {
        var size = 0;

        // channel_id: Generator.Generated.DataTypeInteger
        size += 4;

        // channel_name: Generator.Generated.DataTypeCstring
        size += ChannelName.Length + 1;

        return size;
    }

}

