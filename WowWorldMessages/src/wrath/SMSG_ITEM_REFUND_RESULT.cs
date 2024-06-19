using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ItemRefundResultType = OneOf.OneOf<SMSG_ITEM_REFUND_RESULT.ItemRefundResultSuccess, ItemRefundResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ITEM_REFUND_RESULT: WrathServerMessage, IWorldMessage {
    public class ItemRefundResultSuccess {
        public required uint ArenaPointCost { get; set; }
        public required uint Cost { get; set; }
        public const int ExtraItemsLength = 5;
        public required ItemRefundExtra[] ExtraItems { get; set; }
        public required uint HonorPointCost { get; set; }
    }
    public required ulong Item { get; set; }
    public required ItemRefundResultType Result { get; set; }
    internal ItemRefundResult ResultValue => Result.Match(
        _ => Wrath.ItemRefundResult.Success,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_ITEM_REFUND_RESULT.ItemRefundResultSuccess itemRefundResultSuccess) {
            await w.WriteUInt(itemRefundResultSuccess.Cost, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(itemRefundResultSuccess.HonorPointCost, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(itemRefundResultSuccess.ArenaPointCost, cancellationToken).ConfigureAwait(false);

            foreach (var v in itemRefundResultSuccess.ExtraItems) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1205, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1205, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ITEM_REFUND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        ItemRefundResultType result = (Wrath.ItemRefundResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.ItemRefundResult.Success) {
            var cost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var honorPointCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var arenaPointCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var extraItems = new ItemRefundExtra[ItemRefundResultSuccess.ExtraItemsLength];
            for (var i = 0; i < ItemRefundResultSuccess.ExtraItemsLength; ++i) {
                extraItems[i] = await Wrath.ItemRefundExtra.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
            }

            result = new ItemRefundResultSuccess {
                ArenaPointCost = arenaPointCost,
                Cost = cost,
                ExtraItems = extraItems,
                HonorPointCost = honorPointCost,
            };
        }

        return new SMSG_ITEM_REFUND_RESULT {
            Item = item,
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // item: Generator.Generated.DataTypeGuid
        size += 8;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is SMSG_ITEM_REFUND_RESULT.ItemRefundResultSuccess itemRefundResultSuccess) {
            // cost: Generator.Generated.DataTypeGold
            size += 4;

            // honor_point_cost: Generator.Generated.DataTypeInteger
            size += 4;

            // arena_point_cost: Generator.Generated.DataTypeInteger
            size += 4;

            // extra_items: Generator.Generated.DataTypeArray
            size += itemRefundResultSuccess.ExtraItems.Sum(e => 8);

        }

        return size;
    }

}

