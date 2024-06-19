using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_AUTOEQUIP_ITEM: TbcClientMessage, IWorldMessage {
    public required byte SourceBag { get; set; }
    public required byte SourceSlot { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(SourceBag, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SourceSlot, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 6, 266, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 6, 266, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_AUTOEQUIP_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var sourceBag = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var sourceSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_AUTOEQUIP_ITEM {
            SourceBag = sourceBag,
            SourceSlot = sourceSlot,
        };
    }

}

