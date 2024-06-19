using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ThreatUpdateUnit {
    public required ulong Unit { get; set; }
    public required uint Threat { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Threat, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ThreatUpdateUnit> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var threat = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new ThreatUpdateUnit {
            Unit = unit,
            Threat = threat,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // threat: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

