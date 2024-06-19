using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_AUCTION_SELL_ITEM: WrathClientMessage, IWorldMessage {
    public required ulong Auctioneer { get; set; }
    public required uint Unknown1 { get; set; }
    public required ulong Item { get; set; }
    public required uint Unknown2 { get; set; }
    public required uint StartingBid { get; set; }
    public required uint Buyout { get; set; }
    public required uint AuctionDurationInMinutes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Auctioneer, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(StartingBid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Buyout, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AuctionDurationInMinutes, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 40, 598, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 40, 598, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_AUCTION_SELL_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctioneer = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var startingBid = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var buyout = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionDurationInMinutes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_AUCTION_SELL_ITEM {
            Auctioneer = auctioneer,
            Unknown1 = unknown1,
            Item = item,
            Unknown2 = unknown2,
            StartingBid = startingBid,
            Buyout = buyout,
            AuctionDurationInMinutes = auctionDurationInMinutes,
        };
    }

}

