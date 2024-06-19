using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ITEM_REFUND_INFO_RESPONSE: WrathServerMessage, IWorldMessage {
    public required ulong Item { get; set; }
    public required uint MoneyCost { get; set; }
    public required uint HonorPointCost { get; set; }
    public required uint ArenaPointCost { get; set; }
    public const int ExtraItemsLength = 5;
    public required ItemRefundExtra[] ExtraItems { get; set; }
    /// <summary>
    /// Emus set to 0.
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint TimeSinceLoss { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyCost, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorPointCost, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ArenaPointCost, cancellationToken).ConfigureAwait(false);

        foreach (var v in ExtraItems) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeSinceLoss, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 70, 1202, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 70, 1202, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ITEM_REFUND_INFO_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var moneyCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorPointCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaPointCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var extraItems = new ItemRefundExtra[ExtraItemsLength];
        for (var i = 0; i < ExtraItemsLength; ++i) {
            extraItems[i] = await Wrath.ItemRefundExtra.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeSinceLoss = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ITEM_REFUND_INFO_RESPONSE {
            Item = item,
            MoneyCost = moneyCost,
            HonorPointCost = honorPointCost,
            ArenaPointCost = arenaPointCost,
            ExtraItems = extraItems,
            Unknown1 = unknown1,
            TimeSinceLoss = timeSinceLoss,
        };
    }

}

