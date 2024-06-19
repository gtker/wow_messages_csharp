using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ItemRefundExtra {
    public required uint Item { get; set; }
    public required uint Amount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Amount, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ItemRefundExtra> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var amount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new ItemRefundExtra {
            Item = item,
            Amount = amount,
        };
    }

}

