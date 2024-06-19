using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_AUCTION_LIST_ITEMS: WrathClientMessage, IWorldMessage {
    public required ulong Auctioneer { get; set; }
    public required uint ListStartItem { get; set; }
    public required string SearchedName { get; set; }
    public required byte MinimumLevel { get; set; }
    public required byte MaximumLevel { get; set; }
    public required uint AuctionSlotId { get; set; }
    public required uint AuctionMainCategory { get; set; }
    public required uint AuctionSubCategory { get; set; }
    public required Wrath.ItemQuality AuctionQuality { get; set; }
    public required byte Usable { get; set; }
    public required byte IsFull { get; set; }
    public required List<AuctionSort> SortedAuctions { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Auctioneer, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ListStartItem, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(SearchedName, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(MinimumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(MaximumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AuctionSlotId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AuctionMainCategory, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AuctionSubCategory, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)AuctionQuality, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Usable, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(IsFull, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)SortedAuctions.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in SortedAuctions) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 600, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 600, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_AUCTION_LIST_ITEMS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auctioneer = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var listStartItem = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var searchedName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var minimumLevel = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var maximumLevel = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var auctionSlotId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionMainCategory = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionSubCategory = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auctionQuality = (Wrath.ItemQuality)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var usable = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var isFull = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSortedAuctions = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var sortedAuctions = new List<AuctionSort>();
        for (var i = 0; i < amountOfSortedAuctions; ++i) {
            sortedAuctions.Add(await Wrath.AuctionSort.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new CMSG_AUCTION_LIST_ITEMS {
            Auctioneer = auctioneer,
            ListStartItem = listStartItem,
            SearchedName = searchedName,
            MinimumLevel = minimumLevel,
            MaximumLevel = maximumLevel,
            AuctionSlotId = auctionSlotId,
            AuctionMainCategory = auctionMainCategory,
            AuctionSubCategory = auctionSubCategory,
            AuctionQuality = auctionQuality,
            Usable = usable,
            IsFull = isFull,
            SortedAuctions = sortedAuctions,
        };
    }

    internal int Size() {
        var size = 0;

        // auctioneer: Generator.Generated.DataTypeGuid
        size += 8;

        // list_start_item: Generator.Generated.DataTypeInteger
        size += 4;

        // searched_name: Generator.Generated.DataTypeCstring
        size += SearchedName.Length + 1;

        // minimum_level: Generator.Generated.DataTypeInteger
        size += 1;

        // maximum_level: Generator.Generated.DataTypeInteger
        size += 1;

        // auction_slot_id: Generator.Generated.DataTypeInteger
        size += 4;

        // auction_main_category: Generator.Generated.DataTypeInteger
        size += 4;

        // auction_sub_category: Generator.Generated.DataTypeInteger
        size += 4;

        // auction_quality: Generator.Generated.DataTypeEnum
        size += 4;

        // usable: Generator.Generated.DataTypeInteger
        size += 1;

        // is_full: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_sorted_auctions: Generator.Generated.DataTypeInteger
        size += 1;

        // sorted_auctions: Generator.Generated.DataTypeArray
        size += SortedAuctions.Sum(e => 2);

        return size;
    }

}

