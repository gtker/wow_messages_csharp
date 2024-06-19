using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class PendingAuctionSale {
    /// <summary>
    /// mangostwo: string '%d:%d:%d:%d:%d' -> itemId, ItemRandomPropertyId, 2, auctionId, unk1 (stack size?, unused)
    /// </summary>
    public required string String1 { get; set; }
    /// <summary>
    /// mangostwo: string '%16I64X:%d:%d:%d:%d' -> bidderGuid, bid, buyout, deposit, auctionCut
    /// </summary>
    public required string String2 { get; set; }
    /// <summary>
    /// mangostwo sets to 97250.
    /// </summary>
    public required uint Unknown1 { get; set; }
    /// <summary>
    /// mangostwo sets to 68.
    /// </summary>
    public required uint Unknown2 { get; set; }
    public required float TimeLeft { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(String1, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(String2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(TimeLeft, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<PendingAuctionSale> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var string1 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var string2 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeLeft = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new PendingAuctionSale {
            String1 = string1,
            String2 = string2,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            TimeLeft = timeLeft,
        };
    }

    internal int Size() {
        var size = 0;

        // string1: Generator.Generated.DataTypeCstring
        size += String1.Length + 1;

        // string2: Generator.Generated.DataTypeCstring
        size += String2.Length + 1;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // time_left: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        return size;
    }

}

