using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_TIME_SYNC_RESP: TbcClientMessage, IWorldMessage {
    /// <summary>
    /// Can be used to check if the client is still properly in sync
    /// This should be the same as the counter sent in [SMSG_TIME_SYNC_REQ].
    /// </summary>
    public required uint TimeSync { get; set; }
    /// <summary>
    /// You can check this against expected values to estimate client latency
    /// </summary>
    public required uint ClientTicks { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(TimeSync, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ClientTicks, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 12, 913, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 12, 913, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_TIME_SYNC_RESP> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var timeSync = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var clientTicks = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_TIME_SYNC_RESP {
            TimeSync = timeSync,
            ClientTicks = clientTicks,
        };
    }

}

