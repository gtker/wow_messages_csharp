using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUCTION_BIDDER_NOTIFICATION: WrathServerMessage, IWorldMessage {
    public required Wrath.AuctionHouse AuctionHouse { get; set; }
    public required uint AuctionId { get; set; }
    public required ulong Bidder { get; set; }
    public required uint BidSum { get; set; }
    public required uint NewHighestBid { get; set; }
    public required uint OutBidAmount { get; set; }
    public required uint ItemTemplate { get; set; }
    public required uint ItemRandomPropertyId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)AuctionHouse, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AuctionId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Bidder, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BidSum, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(NewHighestBid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(OutBidAmount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemTemplate, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemRandomPropertyId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 38, 606, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 38, 606, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUCTION_BIDDER_NOTIFICATION> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctionHouse = (Wrath.AuctionHouse)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bidder = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var bidSum = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var newHighestBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var outBidAmount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemTemplate = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRandomPropertyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_AUCTION_BIDDER_NOTIFICATION {
            AuctionHouse = auctionHouse,
            AuctionId = auctionId,
            Bidder = bidder,
            BidSum = bidSum,
            NewHighestBid = newHighestBid,
            OutBidAmount = outBidAmount,
            ItemTemplate = itemTemplate,
            ItemRandomPropertyId = itemRandomPropertyId,
        };
    }

}

