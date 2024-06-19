using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuctionSort {
    public required byte Column { get; set; }
    public required byte Reversed { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Column, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Reversed, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AuctionSort> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var column = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var reversed = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new AuctionSort {
            Column = column,
            Reversed = reversed,
        };
    }

}

