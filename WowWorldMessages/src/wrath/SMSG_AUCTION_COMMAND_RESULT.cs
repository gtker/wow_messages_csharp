using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using AuctionCommandResultType = OneOf.OneOf<SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory, AuctionCommandResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUCTION_COMMAND_RESULT: WrathServerMessage, IWorldMessage {
    public class AuctionCommandResultErrInventory {
        public required Wrath.InventoryResult InventoryResult { get; set; }
    }
    public required uint AuctionId { get; set; }
    public required Wrath.AuctionCommandAction Action { get; set; }
    public required AuctionCommandResultType Result { get; set; }
    internal AuctionCommandResult ResultValue => Result.Match(
        _ => Wrath.AuctionCommandResult.ErrInventory,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(AuctionId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Action, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory auctionCommandResultErrInventory) {
            await w.WriteByte((byte)auctionCommandResultErrInventory.InventoryResult, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 603, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 603, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUCTION_COMMAND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var action = (Wrath.AuctionCommandAction)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        AuctionCommandResultType result = (Wrath.AuctionCommandResult)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.AuctionCommandResult.ErrInventory) {
            var inventoryResult = (Wrath.InventoryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            result = new AuctionCommandResultErrInventory {
                InventoryResult = inventoryResult,
            };
        }

        return new SMSG_AUCTION_COMMAND_RESULT {
            AuctionId = auctionId,
            Action = action,
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // auction_id: Generator.Generated.DataTypeInteger
        size += 4;

        // action: Generator.Generated.DataTypeEnum
        size += 4;

        // result: Generator.Generated.DataTypeEnum
        size += 4;

        if (Result.Value is SMSG_AUCTION_COMMAND_RESULT.AuctionCommandResultErrInventory auctionCommandResultErrInventory) {
            // inventory_result: Generator.Generated.DataTypeEnum
            size += 1;

        }

        return size;
    }

}

