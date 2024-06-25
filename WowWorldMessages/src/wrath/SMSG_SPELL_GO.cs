using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELL_GO: WrathServerMessage, IWorldMessage {
    public class GameobjectCastFlagsType {
        public required GameobjectCastFlags Inner;
        public GameobjectCastFlagsAdjustMissile? AdjustMissile;
        public GameobjectCastFlagsAmmo? Ammo;
        public GameobjectCastFlagsDestLocation? DestLocation;
        public GameobjectCastFlagsPowerUpdate? PowerUpdate;
        public GameobjectCastFlagsRuneUpdate? RuneUpdate;
        public GameobjectCastFlagsVisualChain? VisualChain;
    }
    public class GameobjectCastFlagsAdjustMissile {
        public required uint DelayTrajectory { get; set; }
        public required float Elevation { get; set; }
    }
    public class GameobjectCastFlagsAmmo {
        public required uint AmmoDisplayId { get; set; }
        public required uint AmmoInventoryType { get; set; }
    }
    public class GameobjectCastFlagsDestLocation {
        public required byte Unknown3 { get; set; }
    }
    public class GameobjectCastFlagsPowerUpdate {
        public required Wrath.Power Power { get; set; }
    }
    public class GameobjectCastFlagsRuneUpdate {
        public const int RuneCooldownsLength = 6;
        public required byte[] RuneCooldowns { get; set; }
        public required byte RuneMaskAfterCast { get; set; }
        public required byte RuneMaskInitial { get; set; }
    }
    public class GameobjectCastFlagsVisualChain {
        public required uint Unknown1 { get; set; }
        public required uint Unknown2 { get; set; }
    }
    /// <summary>
    /// cmangos/vmangos/mangoszero: if cast item is used, set this to guid of cast item, otherwise set it to same as caster.
    /// </summary>
    public required ulong CastItem { get; set; }
    public required ulong Caster { get; set; }
    public required byte ExtraCasts { get; set; }
    public required uint Spell { get; set; }
    public required GameobjectCastFlagsType Flags { get; set; }
    public required uint Timestamp { get; set; }
    public required List<ulong> Hits { get; set; }
    public required List<SpellMiss> Misses { get; set; }
    public required SpellCastTargets Targets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(CastItem, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ExtraCasts, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timestamp, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Hits.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Hits) {
            await w.WriteULong(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Misses.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Misses) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await Targets.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        if (Flags.PowerUpdate is {} gameobjectCastFlagsPowerUpdate) {
            await w.WriteUInt((uint)gameobjectCastFlagsPowerUpdate.Power, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.RuneUpdate is {} gameobjectCastFlagsRuneUpdate) {
            await w.WriteByte(gameobjectCastFlagsRuneUpdate.RuneMaskInitial, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(gameobjectCastFlagsRuneUpdate.RuneMaskAfterCast, cancellationToken).ConfigureAwait(false);

            foreach (var v in gameobjectCastFlagsRuneUpdate.RuneCooldowns) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

        }

        if (Flags.AdjustMissile is {} gameobjectCastFlagsAdjustMissile) {
            await w.WriteFloat(gameobjectCastFlagsAdjustMissile.Elevation, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(gameobjectCastFlagsAdjustMissile.DelayTrajectory, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Ammo is {} gameobjectCastFlagsAmmo) {
            await w.WriteUInt(gameobjectCastFlagsAmmo.AmmoDisplayId, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(gameobjectCastFlagsAmmo.AmmoInventoryType, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.VisualChain is {} gameobjectCastFlagsVisualChain) {
            await w.WriteUInt(gameobjectCastFlagsVisualChain.Unknown1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(gameobjectCastFlagsVisualChain.Unknown2, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.DestLocation is {} gameobjectCastFlagsDestLocation) {
            await w.WriteByte(gameobjectCastFlagsDestLocation.Unknown3, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 306, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 306, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELL_GO> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var castItem = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var extraCasts = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = new GameobjectCastFlagsType {
            Inner = (GameobjectCastFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var timestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfHits = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hits = new List<ulong>();
        for (var i = 0; i < amountOfHits; ++i) {
            hits.Add(await r.ReadULong(cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMisses = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var misses = new List<SpellMiss>();
        for (var i = 0; i < amountOfMisses; ++i) {
            misses.Add(await Wrath.SpellMiss.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var targets = await SpellCastTargets.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.PowerUpdate)) {
            var power = (Wrath.Power)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.PowerUpdate = new GameobjectCastFlagsPowerUpdate {
                Power = power,
            };
        }

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.RuneUpdate)) {
            var runeMaskInitial = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var runeMaskAfterCast = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var runeCooldowns = new byte[GameobjectCastFlagsRuneUpdate.RuneCooldownsLength];
            for (var i = 0; i < GameobjectCastFlagsRuneUpdate.RuneCooldownsLength; ++i) {
                runeCooldowns[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            flags.RuneUpdate = new GameobjectCastFlagsRuneUpdate {
                RuneCooldowns = runeCooldowns,
                RuneMaskAfterCast = runeMaskAfterCast,
                RuneMaskInitial = runeMaskInitial,
            };
        }

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.AdjustMissile)) {
            var elevation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var delayTrajectory = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.AdjustMissile = new GameobjectCastFlagsAdjustMissile {
                DelayTrajectory = delayTrajectory,
                Elevation = elevation,
            };
        }

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.Ammo)) {
            var ammoDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var ammoInventoryType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.Ammo = new GameobjectCastFlagsAmmo {
                AmmoDisplayId = ammoDisplayId,
                AmmoInventoryType = ammoInventoryType,
            };
        }

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.VisualChain)) {
            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.VisualChain = new GameobjectCastFlagsVisualChain {
                Unknown1 = unknown1,
                Unknown2 = unknown2,
            };
        }

        if (flags.Inner.HasFlag(Wrath.GameobjectCastFlags.DestLocation)) {
            var unknown3 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            flags.DestLocation = new GameobjectCastFlagsDestLocation {
                Unknown3 = unknown3,
            };
        }

        return new SMSG_SPELL_GO {
            CastItem = castItem,
            Caster = caster,
            ExtraCasts = extraCasts,
            Spell = spell,
            Flags = flags,
            Timestamp = timestamp,
            Hits = hits,
            Misses = misses,
            Targets = targets,
        };
    }

    internal int Size() {
        var size = 0;

        // cast_item: Generator.Generated.DataTypePackedGuid
        size += CastItem.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // extra_casts: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // flags: Generator.Generated.DataTypeFlag
        size += 4;

        // timestamp: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_hits: Generator.Generated.DataTypeInteger
        size += 1;

        // hits: Generator.Generated.DataTypeArray
        size += Hits.Sum(e => 8);

        // amount_of_misses: Generator.Generated.DataTypeInteger
        size += 1;

        // misses: Generator.Generated.DataTypeArray
        size += Misses.Sum(e => e.Size());

        // targets: Generator.Generated.DataTypeStruct
        size += Targets.Size();

        if (Flags.PowerUpdate is {} gameobjectCastFlagsPowerUpdate) {
            // power: Generator.Generated.DataTypeEnum
            size += 4;

        }

        if (Flags.RuneUpdate is {} gameobjectCastFlagsRuneUpdate) {
            // rune_mask_initial: Generator.Generated.DataTypeInteger
            size += 1;

            // rune_mask_after_cast: Generator.Generated.DataTypeInteger
            size += 1;

            // rune_cooldowns: Generator.Generated.DataTypeArray
            size += gameobjectCastFlagsRuneUpdate.RuneCooldowns.Sum(e => 1);

        }

        if (Flags.AdjustMissile is {} gameobjectCastFlagsAdjustMissile) {
            // elevation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // delay_trajectory: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Flags.Ammo is {} gameobjectCastFlagsAmmo) {
            // ammo_display_id: Generator.Generated.DataTypeInteger
            size += 4;

            // ammo_inventory_type: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Flags.VisualChain is {} gameobjectCastFlagsVisualChain) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Flags.DestLocation is {} gameobjectCastFlagsDestLocation) {
            // unknown3: Generator.Generated.DataTypeInteger
            size += 1;

        }

        return size;
    }

}

