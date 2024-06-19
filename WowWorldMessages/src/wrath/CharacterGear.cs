using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class CharacterGear {
    public required uint EquipmentDisplayId { get; set; }
    public required Wrath.InventoryType InventoryType { get; set; }
    public required uint Enchantment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(EquipmentDisplayId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)InventoryType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Enchantment, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CharacterGear> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var equipmentDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var inventoryType = (Wrath.InventoryType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var enchantment = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CharacterGear {
            EquipmentDisplayId = equipmentDisplayId,
            InventoryType = inventoryType,
            Enchantment = enchantment,
        };
    }

}

