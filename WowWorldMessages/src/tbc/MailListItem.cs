using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MailListItem {
    public required byte ItemIndex { get; set; }
    public required uint LowGuid { get; set; }
    public required uint Item { get; set; }
    public const int EnchantsLength = 6;
    public required MailListItemEnchant[] Enchants { get; set; }
    public required uint ItemRandomPropertyId { get; set; }
    public required uint ItemSuffixFactor { get; set; }
    public required byte ItemAmount { get; set; }
    public required uint Charges { get; set; }
    public required uint MaxDurability { get; set; }
    public required uint Durability { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(ItemIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LowGuid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        foreach (var v in Enchants) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(ItemRandomPropertyId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemSuffixFactor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ItemAmount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Charges, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxDurability, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Durability, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<MailListItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var itemIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var lowGuid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchants = new MailListItemEnchant[EnchantsLength];
        for (var i = 0; i < EnchantsLength; ++i) {
            enchants[i] = await Tbc.MailListItemEnchant.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var itemRandomPropertyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemSuffixFactor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemAmount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var charges = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maxDurability = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var durability = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MailListItem {
            ItemIndex = itemIndex,
            LowGuid = lowGuid,
            Item = item,
            Enchants = enchants,
            ItemRandomPropertyId = itemRandomPropertyId,
            ItemSuffixFactor = itemSuffixFactor,
            ItemAmount = itemAmount,
            Charges = charges,
            MaxDurability = maxDurability,
            Durability = durability,
        };
    }

}

