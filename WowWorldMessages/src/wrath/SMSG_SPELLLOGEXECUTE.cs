using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLLOGEXECUTE: WrathServerMessage, IWorldMessage {
    public required ulong Caster { get; set; }
    public required uint Spell { get; set; }
    public required List<SpellLog> Logs { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Logs.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Logs) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 588, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 588, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLLOGEXECUTE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEffects = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var logs = new List<SpellLog>();
        for (var i = 0; i < amountOfEffects; ++i) {
            logs.Add(await Wrath.SpellLog.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_SPELLLOGEXECUTE {
            Caster = caster,
            Spell = spell,
            Logs = logs,
        };
    }

    internal int Size() {
        var size = 0;

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // amount_of_effects: Generator.Generated.DataTypeInteger
        size += 4;

        // logs: Generator.Generated.DataTypeArray
        size += Logs.Sum(e => e.Size());

        return size;
    }

}

