using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MailListItemEnchant {
    public required uint Charges { get; set; }
    public required uint Duration { get; set; }
    public required uint EnchantId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Charges, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Duration, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EnchantId, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<MailListItemEnchant> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var charges = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchantId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MailListItemEnchant {
            Charges = charges,
            Duration = duration,
            EnchantId = enchantId,
        };
    }

}

