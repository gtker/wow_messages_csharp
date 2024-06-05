using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using TradeStatusType = OneOf.OneOf<SMSG_TRADE_STATUS.TradeStatusBeginTrade, SMSG_TRADE_STATUS.TradeStatusCloseWindow, SMSG_TRADE_STATUS.TradeStatusNotOnTaplist, SMSG_TRADE_STATUS.TradeStatusOnlyConjured, TradeStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_TRADE_STATUS: VanillaServerMessage, IWorldMessage {
    public class TradeStatusBeginTrade {
        /// <summary>
        /// Set to 0 in vmangos.
        /// </summary>
        public required ulong Unknown1 { get; set; }
    }
    public class TradeStatusCloseWindow {
        public required InventoryResult InventoryResult { get; set; }
        /// <summary>
        /// ItemLimitCategory.dbc entry
        /// </summary>
        public required uint ItemLimitCategoryId { get; set; }
        /// <summary>
        /// used for: EQUIP_ERR_BAG_FULL, EQUIP_ERR_CANT_CARRY_MORE_OF_THIS, EQUIP_ERR_MISSING_REAGENT, EQUIP_ERR_ITEM_MAX_LIMIT_CATEGORY_COUNT_EXCEEDED
        /// </summary>
        public required bool TargetError { get; set; }
    }
    public class TradeStatusNotOnTaplist {
        /// <summary>
        /// Trade slot -1 here clears CGTradeInfo::m_tradeMoney
        /// </summary>
        public required byte Slot { get; set; }
    }
    public class TradeStatusOnlyConjured {
        /// <summary>
        /// Trade slot -1 here clears CGTradeInfo::m_tradeMoney
        /// </summary>
        public required byte Slot { get; set; }
    }
    public required TradeStatusType Status { get; set; }
    internal TradeStatus StatusValue => Status.Match(
        _ => Vanilla.TradeStatus.BeginTrade,
        _ => Vanilla.TradeStatus.CloseWindow,
        _ => Vanilla.TradeStatus.NotOnTaplist,
        _ => Vanilla.TradeStatus.OnlyConjured,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)StatusValue, cancellationToken).ConfigureAwait(false);

        if (Status.Value is SMSG_TRADE_STATUS.TradeStatusBeginTrade beginTrade) {
            await w.WriteULong(beginTrade.Unknown1, cancellationToken).ConfigureAwait(false);

        }
        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusCloseWindow closeWindow) {
            await w.WriteUInt((uint)closeWindow.InventoryResult, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(closeWindow.TargetError, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(closeWindow.ItemLimitCategoryId, cancellationToken).ConfigureAwait(false);

        }

        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusOnlyConjured onlyConjured) {
            await w.WriteByte(onlyConjured.Slot, cancellationToken).ConfigureAwait(false);

        }
        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusNotOnTaplist notOnTaplist) {
            await w.WriteByte(notOnTaplist.Slot, cancellationToken).ConfigureAwait(false);

        }


    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 288, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 288, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_TRADE_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        TradeStatusType status = (TradeStatus)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (status.Value is Vanilla.TradeStatus.BeginTrade) {
            var unknown1 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            status = new TradeStatusBeginTrade {
                Unknown1 = unknown1,
            };
        }
        else if (status.Value is Vanilla.TradeStatus.CloseWindow) {
            var inventoryResult = (InventoryResult)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var targetError = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            var itemLimitCategoryId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            status = new TradeStatusCloseWindow {
                InventoryResult = inventoryResult,
                ItemLimitCategoryId = itemLimitCategoryId,
                TargetError = targetError,
            };
        }

        else if (status.Value is Vanilla.TradeStatus.OnlyConjured) {
            var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            status = new TradeStatusOnlyConjured {
                Slot = slot,
            };
        }
        else if (status.Value is Vanilla.TradeStatus.NotOnTaplist) {
            var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            status = new TradeStatusNotOnTaplist {
                Slot = slot,
            };
        }


        return new SMSG_TRADE_STATUS {
            Status = status,
        };
    }

    internal int Size() {
        var size = 0;

        // status: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        if (Status.Value is SMSG_TRADE_STATUS.TradeStatusBeginTrade beginTrade) {
            // unknown1: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusCloseWindow closeWindow) {
            // inventory_result: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

            // target_error: WowMessages.Generator.Generated.DataTypeBool
            size += 1;

            // item_limit_category_id: WowMessages.Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusOnlyConjured onlyConjured) {
            // slot: WowMessages.Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Status.Value is SMSG_TRADE_STATUS.TradeStatusNotOnTaplist notOnTaplist) {
            // slot: WowMessages.Generator.Generated.DataTypeInteger
            size += 1;

        }


        return size;
    }

}
