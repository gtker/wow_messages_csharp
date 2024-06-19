using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuctionListItem {
    public required uint Id { get; set; }
    public required uint Item { get; set; }
    public const int EnchantmentsLength = 6;
    public required AuctionEnchantment[] Enchantments { get; set; }
    public required uint ItemRandomPropertyId { get; set; }
    public required uint ItemSuffixFactor { get; set; }
    public required uint ItemCount { get; set; }
    public required uint ItemCharges { get; set; }
    /// <summary>
    /// mangosone: item flags (dynamic?) (0x04 no lockId?)
    /// </summary>
    public required uint ItemFlags { get; set; }
    public required ulong ItemOwner { get; set; }
    public required uint StartBid { get; set; }
    public required uint MinimumBid { get; set; }
    public required uint BuyoutAmount { get; set; }
    public required uint TimeLeft { get; set; }
    public required ulong HighestBidder { get; set; }
    public required uint HighestBid { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        foreach (var v in Enchantments) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(ItemRandomPropertyId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemSuffixFactor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemCharges, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(ItemOwner, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(StartBid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MinimumBid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BuyoutAmount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeLeft, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(HighestBidder, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HighestBid, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AuctionListItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchantments = new AuctionEnchantment[EnchantmentsLength];
        for (var i = 0; i < EnchantmentsLength; ++i) {
            enchantments[i] = await Tbc.AuctionEnchantment.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var itemRandomPropertyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemSuffixFactor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemCount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemCharges = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemOwner = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var startBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var minimumBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var buyoutAmount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeLeft = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var highestBidder = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var highestBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new AuctionListItem {
            Id = id,
            Item = item,
            Enchantments = enchantments,
            ItemRandomPropertyId = itemRandomPropertyId,
            ItemSuffixFactor = itemSuffixFactor,
            ItemCount = itemCount,
            ItemCharges = itemCharges,
            ItemFlags = itemFlags,
            ItemOwner = itemOwner,
            StartBid = startBid,
            MinimumBid = minimumBid,
            BuyoutAmount = buyoutAmount,
            TimeLeft = timeLeft,
            HighestBidder = highestBidder,
            HighestBid = highestBid,
        };
    }

}

