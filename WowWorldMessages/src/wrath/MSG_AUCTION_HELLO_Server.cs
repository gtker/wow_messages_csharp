using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_AUCTION_HELLO_Server: WrathServerMessage, IWorldMessage {
    public required ulong Auctioneer { get; set; }
    public required Wrath.AuctionHouse AuctionHouse { get; set; }
    public required bool AuctionHouseEnabled { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Auctioneer, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)AuctionHouse, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(AuctionHouseEnabled, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 15, 597, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 15, 597, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_AUCTION_HELLO_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctioneer = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var auctionHouse = (Wrath.AuctionHouse)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionHouseEnabled = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new MSG_AUCTION_HELLO_Server {
            Auctioneer = auctioneer,
            AuctionHouse = auctionHouse,
            AuctionHouseEnabled = auctionHouseEnabled,
        };
    }

}

