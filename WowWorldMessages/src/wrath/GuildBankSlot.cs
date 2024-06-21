using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildBankSlot {
    public required byte Slot { get; set; }
    public required uint Item { get; set; }
    /// <summary>
    /// 3.3.0 (0x8000, 0x8020)
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required VariableItemRandomProperty ItemRandomPropertyId { get; set; }
    public required uint AmountOfItems { get; set; }
    public required uint Unknown2 { get; set; }
    public required byte Unknown3 { get; set; }
    public required List<GuildBankSocket> Sockets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Slot, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await ItemRandomPropertyId.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfItems, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown3, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Sockets.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Sockets) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<GuildBankSlot> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRandomPropertyId = await VariableItemRandomProperty.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        var amountOfItems = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown3 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSockets = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var sockets = new List<GuildBankSocket>();
        for (var i = 0; i < amountOfSockets; ++i) {
            sockets.Add(await Wrath.GuildBankSocket.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new GuildBankSlot {
            Slot = slot,
            Item = item,
            Unknown1 = unknown1,
            ItemRandomPropertyId = itemRandomPropertyId,
            AmountOfItems = amountOfItems,
            Unknown2 = unknown2,
            Unknown3 = unknown3,
            Sockets = sockets,
        };
    }

    internal int Size() {
        var size = 0;

        // slot: Generator.Generated.DataTypeInteger
        size += 1;

        // item: Generator.Generated.DataTypeItem
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // item_random_property_id: Generator.Generated.DataTypeVariableItemRandomProperty
        size += ItemRandomPropertyId.Length();

        // amount_of_items: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown3: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_sockets: Generator.Generated.DataTypeInteger
        size += 1;

        // sockets: Generator.Generated.DataTypeArray
        size += Sockets.Sum(e => 5);

        return size;
    }

}

