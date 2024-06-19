using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ITEM_NAME_QUERY_RESPONSE: TbcServerMessage, IWorldMessage {
    public required uint Item { get; set; }
    public required string ItemName { get; set; }
    public required Tbc.InventoryType InventoryType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(ItemName, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)InventoryType, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 709, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 709, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ITEM_NAME_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var inventoryType = (Tbc.InventoryType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_ITEM_NAME_QUERY_RESPONSE {
            Item = item,
            ItemName = itemName,
            InventoryType = inventoryType,
        };
    }

    internal int Size() {
        var size = 0;

        // item: Generator.Generated.DataTypeItem
        size += 4;

        // item_name: Generator.Generated.DataTypeCstring
        size += ItemName.Length + 1;

        // inventory_type: Generator.Generated.DataTypeEnum
        size += 1;

        return size;
    }

}

