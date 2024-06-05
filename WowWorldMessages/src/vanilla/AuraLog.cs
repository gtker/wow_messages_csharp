using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using AuraTypeType = OneOf.OneOf<AuraLog.AuraTypeObsModHealth, AuraLog.AuraTypeObsModMana, AuraLog.AuraTypePeriodicDamage, AuraLog.AuraTypePeriodicDamagePercent, AuraLog.AuraTypePeriodicEnergize, AuraLog.AuraTypePeriodicHeal, AuraLog.AuraTypePeriodicManaLeech, AuraType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuraLog {
    public class AuraTypeObsModHealth {
        public required uint Damage2 { get; set; }
    }
    public class AuraTypeObsModMana {
        public required uint Damage3 { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue1 { get; set; }
    }
    public class AuraTypePeriodicDamage {
        public required uint Absorbed { get; set; }
        public required uint Damage1 { get; set; }
        /// <summary>
        /// vmangos: Sent as int32
        /// </summary>
        public required uint Resisted { get; set; }
        public required SpellSchool School { get; set; }
    }
    public class AuraTypePeriodicDamagePercent {
        public required uint Absorbed { get; set; }
        public required uint Damage1 { get; set; }
        /// <summary>
        /// vmangos: Sent as int32
        /// </summary>
        public required uint Resisted { get; set; }
        public required SpellSchool School { get; set; }
    }
    public class AuraTypePeriodicEnergize {
        public required uint Damage3 { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue1 { get; set; }
    }
    public class AuraTypePeriodicHeal {
        public required uint Damage2 { get; set; }
    }
    public class AuraTypePeriodicManaLeech {
        public required uint Damage { get; set; }
        public required float GainMultiplier { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue2 { get; set; }
    }
    public required AuraTypeType AuraType { get; set; }
    internal AuraType AuraTypeValue => AuraType.Match(
        _ => Vanilla.AuraType.ObsModHealth,
        _ => Vanilla.AuraType.ObsModMana,
        _ => Vanilla.AuraType.PeriodicDamage,
        _ => Vanilla.AuraType.PeriodicDamagePercent,
        _ => Vanilla.AuraType.PeriodicEnergize,
        _ => Vanilla.AuraType.PeriodicHeal,
        _ => Vanilla.AuraType.PeriodicManaLeech,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)AuraTypeValue, cancellationToken).ConfigureAwait(false);

        if (AuraType.Value is AuraLog.AuraTypePeriodicDamage periodicDamage) {
            await w.WriteUInt(periodicDamage.Damage1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)periodicDamage.School, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicDamage.Absorbed, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicDamage.Resisted, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicDamagePercent periodicDamagePercent) {
            await w.WriteUInt(periodicDamagePercent.Damage1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)periodicDamagePercent.School, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicDamagePercent.Absorbed, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicDamagePercent.Resisted, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicHeal periodicHeal) {
            await w.WriteUInt(periodicHeal.Damage2, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModHealth obsModHealth) {
            await w.WriteUInt(obsModHealth.Damage2, cancellationToken).ConfigureAwait(false);

        }

        else if (AuraType.Value is AuraLog.AuraTypeObsModMana obsModMana) {
            await w.WriteUInt(obsModMana.MiscValue1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(obsModMana.Damage3, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicEnergize periodicEnergize) {
            await w.WriteUInt(periodicEnergize.MiscValue1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicEnergize.Damage3, cancellationToken).ConfigureAwait(false);

        }

        else if (AuraType.Value is AuraLog.AuraTypePeriodicManaLeech periodicManaLeech) {
            await w.WriteUInt(periodicManaLeech.MiscValue2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(periodicManaLeech.Damage, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(periodicManaLeech.GainMultiplier, cancellationToken).ConfigureAwait(false);

        }


    }

    public static async Task<AuraLog> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        AuraTypeType auraType = (AuraType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (auraType.Value is Vanilla.AuraType.PeriodicDamage) {
            var damage1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var school = (SpellSchool)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var absorbed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var resisted = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicDamage {
                Absorbed = absorbed,
                Damage1 = damage1,
                Resisted = resisted,
                School = school,
            };
        }
        else if (auraType.Value is Vanilla.AuraType.PeriodicDamagePercent) {
            var damage1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var school = (SpellSchool)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var absorbed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var resisted = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicDamagePercent {
                Absorbed = absorbed,
                Damage1 = damage1,
                Resisted = resisted,
                School = school,
            };
        }
        else if (auraType.Value is Vanilla.AuraType.PeriodicHeal) {
            var damage2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicHeal {
                Damage2 = damage2,
            };
        }
        else if (auraType.Value is Vanilla.AuraType.ObsModHealth) {
            var damage2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypeObsModHealth {
                Damage2 = damage2,
            };
        }

        else if (auraType.Value is Vanilla.AuraType.ObsModMana) {
            var miscValue1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypeObsModMana {
                Damage3 = damage3,
                MiscValue1 = miscValue1,
            };
        }
        else if (auraType.Value is Vanilla.AuraType.PeriodicEnergize) {
            var miscValue1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicEnergize {
                Damage3 = damage3,
                MiscValue1 = miscValue1,
            };
        }

        else if (auraType.Value is Vanilla.AuraType.PeriodicManaLeech) {
            var miscValue2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var gainMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicManaLeech {
                Damage = damage,
                GainMultiplier = gainMultiplier,
                MiscValue2 = miscValue2,
            };
        }


        return new AuraLog {
            AuraType = auraType,
        };
    }

    internal int Size() {
        var size = 0;

        // aura_type: Generator.Generated.DataTypeEnum
        size += 4;

        if (AuraType.Value is AuraLog.AuraTypePeriodicDamage periodicDamage) {
            // damage1: Generator.Generated.DataTypeInteger
            size += 4;

            // school: Generator.Generated.DataTypeEnum
            size += 1;

            // absorbed: Generator.Generated.DataTypeInteger
            size += 4;

            // resisted: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicDamagePercent periodicDamagePercent) {
            // damage1: Generator.Generated.DataTypeInteger
            size += 4;

            // school: Generator.Generated.DataTypeEnum
            size += 1;

            // absorbed: Generator.Generated.DataTypeInteger
            size += 4;

            // resisted: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicHeal periodicHeal) {
            // damage2: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModHealth obsModHealth) {
            // damage2: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (AuraType.Value is AuraLog.AuraTypeObsModMana obsModMana) {
            // misc_value1: Generator.Generated.DataTypeInteger
            size += 4;

            // damage3: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicEnergize periodicEnergize) {
            // misc_value1: Generator.Generated.DataTypeInteger
            size += 4;

            // damage3: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (AuraType.Value is AuraLog.AuraTypePeriodicManaLeech periodicManaLeech) {
            // misc_value2: Generator.Generated.DataTypeInteger
            size += 4;

            // damage: Generator.Generated.DataTypeInteger
            size += 4;

            // gain_multiplier: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }


        return size;
    }

}

