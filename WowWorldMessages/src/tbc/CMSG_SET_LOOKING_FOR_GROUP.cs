using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_LOOKING_FOR_GROUP: TbcClientMessage, IWorldMessage {
    public required uint Slot { get; set; }
    public required LfgData Data { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Slot, cancellationToken).ConfigureAwait(false);

        await Data.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 12, 512, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 12, 512, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_LOOKING_FOR_GROUP> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var slot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var data = await LfgData.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_LOOKING_FOR_GROUP {
            Slot = slot,
            Data = data,
        };
    }

}

