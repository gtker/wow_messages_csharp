using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELL_START: WrathServerMessage, IWorldMessage {
    public class CastFlagsType {
        public required CastFlags Inner;
        public CastFlagsAmmo? Ammo;
        public CastFlagsPowerLeftSelf? PowerLeftSelf;
        public CastFlagsUnknown23? Unknown23;
    }
    public class CastFlagsAmmo {
        public required uint AmmoDisplayId { get; set; }
        public required uint AmmoInventoryType { get; set; }
    }
    public class CastFlagsPowerLeftSelf {
        public required Wrath.Power Power { get; set; }
    }
    public class CastFlagsUnknown23 {
        public required uint Unknown1 { get; set; }
        public required uint Unknown2 { get; set; }
    }
    /// <summary>
    /// cmangos/vmangos/mangoszero: if cast item is used, set this to guid of cast item, otherwise set it to same as caster.
    /// </summary>
    public required ulong CastItem { get; set; }
    public required ulong Caster { get; set; }
    public required byte CastCount { get; set; }
    public required uint Spell { get; set; }
    public required CastFlagsType Flags { get; set; }
    public required uint Timer { get; set; }
    public required SpellCastTargets Targets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(CastItem, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(CastCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timer, cancellationToken).ConfigureAwait(false);

        await Targets.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        if (Flags.PowerLeftSelf is {} castFlagsPowerLeftSelf) {
            await w.WriteUInt((uint)castFlagsPowerLeftSelf.Power, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Ammo is {} castFlagsAmmo) {
            await w.WriteUInt(castFlagsAmmo.AmmoDisplayId, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(castFlagsAmmo.AmmoInventoryType, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Unknown23 is {} castFlagsUnknown23) {
            await w.WriteUInt(castFlagsUnknown23.Unknown1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(castFlagsUnknown23.Unknown2, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 305, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 305, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELL_START> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var castItem = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var castCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = new CastFlagsType {
            Inner = (CastFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var timer = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var targets = await SpellCastTargets.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Wrath.CastFlags.PowerLeftSelf)) {
            var power = (Wrath.Power)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.PowerLeftSelf = new CastFlagsPowerLeftSelf {
                Power = power,
            };
        }

        if (flags.Inner.HasFlag(Wrath.CastFlags.Ammo)) {
            var ammoDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var ammoInventoryType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.Ammo = new CastFlagsAmmo {
                AmmoDisplayId = ammoDisplayId,
                AmmoInventoryType = ammoInventoryType,
            };
        }

        if (flags.Inner.HasFlag(Wrath.CastFlags.Unknown23)) {
            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.Unknown23 = new CastFlagsUnknown23 {
                Unknown1 = unknown1,
                Unknown2 = unknown2,
            };
        }

        return new SMSG_SPELL_START {
            CastItem = castItem,
            Caster = caster,
            CastCount = castCount,
            Spell = spell,
            Flags = flags,
            Timer = timer,
            Targets = targets,
        };
    }

    internal int Size() {
        var size = 0;

        // cast_item: Generator.Generated.DataTypePackedGuid
        size += CastItem.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // cast_count: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // flags: Generator.Generated.DataTypeFlag
        size += 4;

        // timer: Generator.Generated.DataTypeInteger
        size += 4;

        // targets: Generator.Generated.DataTypeStruct
        size += Targets.Size();

        if (Flags.PowerLeftSelf is {} castFlagsPowerLeftSelf) {
            // power: Generator.Generated.DataTypeEnum
            size += 4;

        }

        if (Flags.Ammo is {} castFlagsAmmo) {
            // ammo_display_id: Generator.Generated.DataTypeInteger
            size += 4;

            // ammo_inventory_type: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Flags.Unknown23 is {} castFlagsUnknown23) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

