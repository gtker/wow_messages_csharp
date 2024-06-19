using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ReceivedMail {
    public required ulong Sender { get; set; }
    public required Wrath.AuctionHouse AuctionHouse { get; set; }
    public required Wrath.MailMessageType MessageType { get; set; }
    public required uint Stationery { get; set; }
    /// <summary>
    /// mangosone sets to `0xC6000000`
    /// mangosone: float unk, time or something
    /// </summary>
    public required float Time { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Sender, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)AuctionHouse, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)MessageType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Stationery, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Time, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ReceivedMail> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var sender = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var auctionHouse = (Wrath.AuctionHouse)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var messageType = (Wrath.MailMessageType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var stationery = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var time = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new ReceivedMail {
            Sender = sender,
            AuctionHouse = auctionHouse,
            MessageType = messageType,
            Stationery = stationery,
            Time = time,
        };
    }

}

