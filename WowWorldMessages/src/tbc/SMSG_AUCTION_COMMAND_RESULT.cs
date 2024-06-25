using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using AuctionCommandActionType = OneOf.OneOf<SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionBidPlaced, SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionRemoved, SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionStarted, AuctionCommandAction>;
using AuctionCommandResultType = OneOf.OneOf<SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrHigherBid, SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory, SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultOk, AuctionCommandResult>;
using AuctionCommandResultTwoType = OneOf.OneOf<SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrHigherBid, SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrInventory, AuctionCommandResultTwo>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUCTION_COMMAND_RESULT: TbcServerMessage, IWorldMessage {
    public class AuctionCommandActionBidPlaced {
        public required AuctionCommandResultType Result { get; set; }
        internal AuctionCommandResult ResultValue => Result.Match(
            _ => Tbc.AuctionCommandResult.ErrHigherBid,
            _ => Tbc.AuctionCommandResult.ErrInventory,
            _ => Tbc.AuctionCommandResult.Ok,
            v => v
        );
    }
    public class AuctionCommandActionRemoved {
        public required AuctionCommandResultTwoType Result2 { get; set; }
        internal AuctionCommandResultTwo Result2Value => Result2.Match(
            _ => Tbc.AuctionCommandResultTwo.ErrHigherBid,
            _ => Tbc.AuctionCommandResultTwo.ErrInventory,
            v => v
        );
    }
    public class AuctionCommandActionStarted {
        public required AuctionCommandResultTwoType Result2 { get; set; }
        internal AuctionCommandResultTwo Result2Value => Result2.Match(
            _ => Tbc.AuctionCommandResultTwo.ErrHigherBid,
            _ => Tbc.AuctionCommandResultTwo.ErrInventory,
            v => v
        );
    }
    public class AuctionCommandResultErrHigherBid {
        public required uint AuctionOutbid2 { get; set; }
        public required ulong HigherBidder { get; set; }
        public required uint NewBid { get; set; }
    }
    public class AuctionCommandResultErrInventory {
        public required Tbc.InventoryResult InventoryResult { get; set; }
    }
    public class AuctionCommandResultOk {
        public required uint AuctionOutbid1 { get; set; }
    }
    public class AuctionCommandResultTwoErrHigherBid {
        public required uint AuctionOutbid3 { get; set; }
        public required ulong HigherBidder2 { get; set; }
        public required uint NewBid2 { get; set; }
    }
    public class AuctionCommandResultTwoErrInventory {
        public required Tbc.InventoryResult InventoryResult2 { get; set; }
    }
    public required uint AuctionId { get; set; }
    public required AuctionCommandActionType Action { get; set; }
    internal AuctionCommandAction ActionValue => Action.Match(
        _ => Tbc.AuctionCommandAction.BidPlaced,
        _ => Tbc.AuctionCommandAction.Removed,
        _ => Tbc.AuctionCommandAction.Started,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(AuctionId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)ActionValue, cancellationToken).ConfigureAwait(false);

        if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionBidPlaced auctionCommandActionBidPlaced) {
            await w.WriteUInt((uint)auctionCommandActionBidPlaced.ResultValue, cancellationToken).ConfigureAwait(false);

            if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultOk auctionCommandResultOk) {
                await w.WriteUInt(auctionCommandResultOk.AuctionOutbid1, cancellationToken).ConfigureAwait(false);

            }
            else if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory auctionCommandResultErrInventory) {
                await w.WriteByte((byte)auctionCommandResultErrInventory.InventoryResult, cancellationToken).ConfigureAwait(false);

            }
            else if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrHigherBid auctionCommandResultErrHigherBid) {
                await w.WriteULong(auctionCommandResultErrHigherBid.HigherBidder, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultErrHigherBid.NewBid, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultErrHigherBid.AuctionOutbid2, cancellationToken).ConfigureAwait(false);

            }

        }
        else if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionStarted auctionCommandActionStarted) {
            await w.WriteUInt((uint)auctionCommandActionStarted.Result2Value, cancellationToken).ConfigureAwait(false);

            if (auctionCommandActionStarted.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrInventory auctionCommandResultTwoErrInventory) {
                await w.WriteByte((byte)auctionCommandResultTwoErrInventory.InventoryResult2, cancellationToken).ConfigureAwait(false);

            }
            else if (auctionCommandActionStarted.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrHigherBid auctionCommandResultTwoErrHigherBid) {
                await w.WriteULong(auctionCommandResultTwoErrHigherBid.HigherBidder2, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultTwoErrHigherBid.NewBid2, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultTwoErrHigherBid.AuctionOutbid3, cancellationToken).ConfigureAwait(false);

            }

        }
        else if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionRemoved auctionCommandActionRemoved) {
            await w.WriteUInt((uint)auctionCommandActionRemoved.Result2Value, cancellationToken).ConfigureAwait(false);

            if (auctionCommandActionRemoved.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrInventory auctionCommandResultTwoErrInventory) {
                await w.WriteByte((byte)auctionCommandResultTwoErrInventory.InventoryResult2, cancellationToken).ConfigureAwait(false);

            }
            else if (auctionCommandActionRemoved.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrHigherBid auctionCommandResultTwoErrHigherBid) {
                await w.WriteULong(auctionCommandResultTwoErrHigherBid.HigherBidder2, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultTwoErrHigherBid.NewBid2, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(auctionCommandResultTwoErrHigherBid.AuctionOutbid3, cancellationToken).ConfigureAwait(false);

            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 603, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 603, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUCTION_COMMAND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        AuctionCommandActionType action = (Tbc.AuctionCommandAction)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (action.Value is Tbc.AuctionCommandAction.BidPlaced) {
            AuctionCommandResultType result = (Tbc.AuctionCommandResult)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            if (result.Value is Tbc.AuctionCommandResult.Ok) {
                var auctionOutbid1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                result = new AuctionCommandResultOk {
                    AuctionOutbid1 = auctionOutbid1,
                };
            }
            else if (result.Value is Tbc.AuctionCommandResult.ErrInventory) {
                var inventoryResult = (Tbc.InventoryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

                result = new AuctionCommandResultErrInventory {
                    InventoryResult = inventoryResult,
                };
            }
            else if (result.Value is Tbc.AuctionCommandResult.ErrHigherBid) {
                var higherBidder = await r.ReadULong(cancellationToken).ConfigureAwait(false);

                var newBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var auctionOutbid2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                result = new AuctionCommandResultErrHigherBid {
                    AuctionOutbid2 = auctionOutbid2,
                    HigherBidder = higherBidder,
                    NewBid = newBid,
                };
            }

            action = new AuctionCommandActionBidPlaced {
                Result = result,
            };
        }
        else if (action.Value is Tbc.AuctionCommandAction.Started) {
            AuctionCommandResultTwoType result2 = (Tbc.AuctionCommandResultTwo)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            if (result2.Value is Tbc.AuctionCommandResultTwo.ErrInventory) {
                var inventoryResult2 = (Tbc.InventoryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

                result2 = new AuctionCommandResultTwoErrInventory {
                    InventoryResult2 = inventoryResult2,
                };
            }
            else if (result2.Value is Tbc.AuctionCommandResultTwo.ErrHigherBid) {
                var higherBidder2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

                var newBid2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var auctionOutbid3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                result2 = new AuctionCommandResultTwoErrHigherBid {
                    AuctionOutbid3 = auctionOutbid3,
                    HigherBidder2 = higherBidder2,
                    NewBid2 = newBid2,
                };
            }

            action = new AuctionCommandActionStarted {
                Result2 = result2,
            };
        }
        else if (action.Value is Tbc.AuctionCommandAction.Removed) {
            AuctionCommandResultTwoType result2 = (Tbc.AuctionCommandResultTwo)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            if (result2.Value is Tbc.AuctionCommandResultTwo.ErrInventory) {
                var inventoryResult2 = (Tbc.InventoryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

                result2 = new AuctionCommandResultTwoErrInventory {
                    InventoryResult2 = inventoryResult2,
                };
            }
            else if (result2.Value is Tbc.AuctionCommandResultTwo.ErrHigherBid) {
                var higherBidder2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

                var newBid2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var auctionOutbid3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                result2 = new AuctionCommandResultTwoErrHigherBid {
                    AuctionOutbid3 = auctionOutbid3,
                    HigherBidder2 = higherBidder2,
                    NewBid2 = newBid2,
                };
            }

            action = new AuctionCommandActionRemoved {
                Result2 = result2,
            };
        }

        return new SMSG_AUCTION_COMMAND_RESULT {
            AuctionId = auctionId,
            Action = action,
        };
    }

    internal int Size() {
        var size = 0;

        // auction_id: Generator.Generated.DataTypeInteger
        size += 4;

        // action: Generator.Generated.DataTypeEnum
        size += 4;

        if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionBidPlaced auctionCommandActionBidPlaced) {
            // result: Generator.Generated.DataTypeEnum
            size += 4;

            if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultOk auctionCommandResultOk) {
                // auction_outbid1: Generator.Generated.DataTypeInteger
                size += 4;

            }
            else if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory auctionCommandResultErrInventory) {
                // inventory_result: Generator.Generated.DataTypeEnum
                size += 1;

            }
            else if (auctionCommandActionBidPlaced.Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrHigherBid auctionCommandResultErrHigherBid) {
                // higher_bidder: Generator.Generated.DataTypeGuid
                size += 8;

                // new_bid: Generator.Generated.DataTypeInteger
                size += 4;

                // auction_outbid2: Generator.Generated.DataTypeInteger
                size += 4;

            }

        }
        else if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionStarted auctionCommandActionStarted) {
            // result2: Generator.Generated.DataTypeEnum
            size += 4;

            if (auctionCommandActionStarted.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrInventory auctionCommandResultTwoErrInventory) {
                // inventory_result2: Generator.Generated.DataTypeEnum
                size += 1;

            }
            else if (auctionCommandActionStarted.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrHigherBid auctionCommandResultTwoErrHigherBid) {
                // higher_bidder2: Generator.Generated.DataTypeGuid
                size += 8;

                // new_bid2: Generator.Generated.DataTypeInteger
                size += 4;

                // auction_outbid3: Generator.Generated.DataTypeInteger
                size += 4;

            }

        }
        else if (Action.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandActionRemoved auctionCommandActionRemoved) {
            // result2: Generator.Generated.DataTypeEnum
            size += 4;

            if (auctionCommandActionRemoved.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrInventory auctionCommandResultTwoErrInventory) {
                // inventory_result2: Generator.Generated.DataTypeEnum
                size += 1;

            }
            else if (auctionCommandActionRemoved.Result2.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultTwoErrHigherBid auctionCommandResultTwoErrHigherBid) {
                // higher_bidder2: Generator.Generated.DataTypeGuid
                size += 8;

                // new_bid2: Generator.Generated.DataTypeInteger
                size += 4;

                // auction_outbid3: Generator.Generated.DataTypeInteger
                size += 4;

            }

        }

        return size;
    }

}

