using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AddonInfo {
    public required string AddonName { get; set; }
    public required byte AddonHasSignature { get; set; }
    public required uint AddonCrc { get; set; }
    public required uint AddonExtraCrc { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteCString(w, AddonName, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, AddonHasSignature, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, AddonCrc, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, AddonExtraCrc, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AddonInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var addonName = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);

        var addonHasSignature = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var addonCrc = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var addonExtraCrc = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        return new AddonInfo {
            AddonName = addonName,
            AddonHasSignature = addonHasSignature,
            AddonCrc = addonCrc,
            AddonExtraCrc = addonExtraCrc,
        };
    }

    internal int Size() {
        var size = 0;

        // addon_name: WowMessages.Generator.Generated.DataTypeCstring
        size += AddonName.Length + 1;

        // addon_has_signature: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // addon_crc: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // addon_extra_crc: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

