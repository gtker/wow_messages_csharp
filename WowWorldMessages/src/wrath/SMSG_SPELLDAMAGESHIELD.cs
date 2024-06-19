using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLDAMAGESHIELD: WrathServerMessage, IWorldMessage {
    public required ulong Victim { get; set; }
    public required ulong Caster { get; set; }
    public required uint Spell { get; set; }
    public required uint Damage { get; set; }
    public required uint Overkill { get; set; }
    public required Wrath.SpellSchool School { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Victim, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Damage, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Overkill, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)School, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 34, 591, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 34, 591, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLDAMAGESHIELD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var victim = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var damage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var overkill = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var school = (Wrath.SpellSchool)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_SPELLDAMAGESHIELD {
            Victim = victim,
            Caster = caster,
            Spell = spell,
            Damage = damage,
            Overkill = overkill,
            School = school,
        };
    }

}

