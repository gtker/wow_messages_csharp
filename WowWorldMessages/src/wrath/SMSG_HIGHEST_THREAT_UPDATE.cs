using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_HIGHEST_THREAT_UPDATE: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required ulong NewVictim { get; set; }
    public required List<ThreatUpdateUnit> Units { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(NewVictim, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Units.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Units) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1154, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1154, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_HIGHEST_THREAT_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var newVictim = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfUnits = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var units = new List<ThreatUpdateUnit>();
        for (var i = 0; i < amountOfUnits; ++i) {
            units.Add(await Wrath.ThreatUpdateUnit.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_HIGHEST_THREAT_UPDATE {
            Unit = unit,
            NewVictim = newVictim,
            Units = units,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // new_victim: Generator.Generated.DataTypePackedGuid
        size += NewVictim.PackedGuidLength();

        // amount_of_units: Generator.Generated.DataTypeInteger
        size += 4;

        // units: Generator.Generated.DataTypeArray
        size += Units.Sum(e => e.Size());

        return size;
    }

}

