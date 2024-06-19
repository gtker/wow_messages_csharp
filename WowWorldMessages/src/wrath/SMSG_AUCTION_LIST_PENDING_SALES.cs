using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUCTION_LIST_PENDING_SALES: WrathServerMessage, IWorldMessage {
    public required List<PendingAuctionSale> PendingSales { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)PendingSales.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in PendingSales) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1168, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1168, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUCTION_LIST_PENDING_SALES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPendingSales = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var pendingSales = new List<PendingAuctionSale>();
        for (var i = 0; i < amountOfPendingSales; ++i) {
            pendingSales.Add(await Wrath.PendingAuctionSale.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_AUCTION_LIST_PENDING_SALES {
            PendingSales = pendingSales,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_pending_sales: Generator.Generated.DataTypeInteger
        size += 4;

        // pending_sales: Generator.Generated.DataTypeArray
        size += PendingSales.Sum(e => e.Size());

        return size;
    }

}

