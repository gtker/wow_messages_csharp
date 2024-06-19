using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class EquipmentSet {
    public required ulong Item { get; set; }
    public required byte SourceBag { get; set; }
    public required byte SourceSlot { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SourceBag, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SourceSlot, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<EquipmentSet> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var sourceBag = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var sourceSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new EquipmentSet {
            Item = item,
            SourceBag = sourceBag,
            SourceSlot = sourceSlot,
        };
    }

}

