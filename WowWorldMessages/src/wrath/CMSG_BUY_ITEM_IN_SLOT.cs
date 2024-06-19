using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BUY_ITEM_IN_SLOT: WrathClientMessage, IWorldMessage {
    public required ulong Vendor { get; set; }
    public required uint Item { get; set; }
    /// <summary>
    /// arcemu: VLack: 3.1.2 This is the slot's number on the vendor's panel, starts from 1
    /// </summary>
    public required uint VendorSlot { get; set; }
    public required ulong Bag { get; set; }
    public required byte BagSlot { get; set; }
    public required byte Amount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Vendor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(VendorSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Bag, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(BagSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Amount, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 30, 419, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 30, 419, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BUY_ITEM_IN_SLOT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var vendor = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var vendorSlot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bag = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var bagSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var amount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_BUY_ITEM_IN_SLOT {
            Vendor = vendor,
            Item = item,
            VendorSlot = vendorSlot,
            Bag = bag,
            BagSlot = bagSlot,
            Amount = amount,
        };
    }

}

