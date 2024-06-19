using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLSTEALLOG: TbcServerMessage, IWorldMessage {
    public required ulong Victim { get; set; }
    public required ulong Caster { get; set; }
    public required uint Spell { get; set; }
    public required byte Unknown { get; set; }
    public required List<SpellSteal> SpellSteals { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Victim, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)SpellSteals.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in SpellSteals) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 819, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 819, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLSTEALLOG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var victim = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSpellSteals = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var spellSteals = new List<SpellSteal>();
        for (var i = 0; i < amountOfSpellSteals; ++i) {
            spellSteals.Add(await Tbc.SpellSteal.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_SPELLSTEALLOG {
            Victim = victim,
            Caster = caster,
            Spell = spell,
            Unknown = unknown,
            SpellSteals = spellSteals,
        };
    }

    internal int Size() {
        var size = 0;

        // victim: Generator.Generated.DataTypePackedGuid
        size += Victim.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_spell_steals: Generator.Generated.DataTypeInteger
        size += 4;

        // spell_steals: Generator.Generated.DataTypeArray
        size += SpellSteals.Sum(e => 5);

        return size;
    }

}

