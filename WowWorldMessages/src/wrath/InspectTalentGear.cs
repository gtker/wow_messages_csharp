using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class InspectTalentGear {
    public required uint Item { get; set; }
    public required EnchantMask EnchantMask { get; set; }
    public required ushort Unknown1 { get; set; }
    public required ulong Creator { get; set; }
    public required uint Unknown2 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await EnchantMask.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Creator, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<InspectTalentGear> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var enchantMask = await EnchantMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var creator = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new InspectTalentGear {
            Item = item,
            EnchantMask = enchantMask,
            Unknown1 = unknown1,
            Creator = creator,
            Unknown2 = unknown2,
        };
    }

    internal int Size() {
        var size = 0;

        // item: Generator.Generated.DataTypeItem
        size += 4;

        // enchant_mask: Generator.Generated.DataTypeEnchantMask
        size += EnchantMask.Length();;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 2;

        // creator: Generator.Generated.DataTypePackedGuid
        size += Creator.PackedGuidLength();

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

