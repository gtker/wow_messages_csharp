using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuctionEnchantment {
    public required uint EnchantId { get; set; }
    public required uint EnchantDuration { get; set; }
    public required uint EnchantCharges { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(EnchantId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EnchantDuration, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EnchantCharges, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AuctionEnchantment> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var enchantId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchantDuration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchantCharges = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new AuctionEnchantment {
            EnchantId = enchantId,
            EnchantDuration = enchantDuration,
            EnchantCharges = enchantCharges,
        };
    }

}

