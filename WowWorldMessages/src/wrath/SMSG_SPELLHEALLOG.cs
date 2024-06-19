using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLHEALLOG: WrathServerMessage, IWorldMessage {
    public required ulong Victim { get; set; }
    public required ulong Caster { get; set; }
    public required uint Id { get; set; }
    public required uint Damage { get; set; }
    public required uint Overheal { get; set; }
    public required uint Absorb { get; set; }
    public required bool Critical { get; set; }
    /// <summary>
    /// mangostwo: unused in client?
    /// </summary>
    public required byte Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Victim, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Damage, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Overheal, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Absorb, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Critical, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 336, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 336, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLHEALLOG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var victim = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var damage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var overheal = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var absorb = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var critical = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_SPELLHEALLOG {
            Victim = victim,
            Caster = caster,
            Id = id,
            Damage = damage,
            Overheal = overheal,
            Absorb = absorb,
            Critical = critical,
            Unknown = unknown,
        };
    }

    internal int Size() {
        var size = 0;

        // victim: Generator.Generated.DataTypePackedGuid
        size += Victim.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // id: Generator.Generated.DataTypeSpell
        size += 4;

        // damage: Generator.Generated.DataTypeInteger
        size += 4;

        // overheal: Generator.Generated.DataTypeInteger
        size += 4;

        // absorb: Generator.Generated.DataTypeInteger
        size += 4;

        // critical: Generator.Generated.DataTypeBool
        size += 1;

        // unknown: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

