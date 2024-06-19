using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLDISPELLOG: WrathServerMessage, IWorldMessage {
    public required ulong Victim { get; set; }
    public required ulong Caster { get; set; }
    public required uint DispellSpell { get; set; }
    /// <summary>
    /// mangosone: unused
    /// </summary>
    public required byte Unknown { get; set; }
    public required List<DispelledSpell> Spells { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Victim, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DispellSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Spells.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Spells) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 635, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 635, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLDISPELLOG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var victim = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var dispellSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSpells = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var spells = new List<DispelledSpell>();
        for (var i = 0; i < amountOfSpells; ++i) {
            spells.Add(await Wrath.DispelledSpell.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_SPELLDISPELLOG {
            Victim = victim,
            Caster = caster,
            DispellSpell = dispellSpell,
            Unknown = unknown,
            Spells = spells,
        };
    }

    internal int Size() {
        var size = 0;

        // victim: Generator.Generated.DataTypePackedGuid
        size += Victim.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // dispell_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_spells: Generator.Generated.DataTypeInteger
        size += 4;

        // spells: Generator.Generated.DataTypeArray
        size += Spells.Sum(e => 5);

        return size;
    }

}

