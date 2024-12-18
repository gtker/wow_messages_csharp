using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SWAP_INV_ITEM: TbcClientMessage, IWorldMessage {
    public required Tbc.ItemSlot SourceSlot { get; set; }
    public required Tbc.ItemSlot DestinationSlot { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)SourceSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)DestinationSlot, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 6, 269, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 6, 269, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SWAP_INV_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var sourceSlot = (Tbc.ItemSlot)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var destinationSlot = (Tbc.ItemSlot)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_SWAP_INV_ITEM {
            SourceSlot = sourceSlot,
            DestinationSlot = destinationSlot,
        };
    }

}

