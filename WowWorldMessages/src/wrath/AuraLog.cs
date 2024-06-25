using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using AuraTypeType = OneOf.OneOf<AuraLog.AuraTypeObsModHealth, AuraLog.AuraTypeObsModPower, AuraLog.AuraTypePeriodicDamage, AuraLog.AuraTypePeriodicDamagePercent, AuraLog.AuraTypePeriodicEnergize, AuraLog.AuraTypePeriodicHeal, AuraLog.AuraTypePeriodicManaLeech, AuraType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuraLog {
    public class AuraTypeObsModHealth {
        public required uint Absorb2 { get; set; }
        /// <summary>
        /// new 3.1.2 critical tick
        /// </summary>
        public required bool Critical2 { get; set; }
        public required uint Damage2 { get; set; }
        public required uint OverDamage { get; set; }
    }
    public class AuraTypeObsModPower {
        public required uint Damage3 { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue1 { get; set; }
    }
    public class AuraTypePeriodicDamage {
        public required uint Absorb1 { get; set; }
        /// <summary>
        /// new 3.1.2 critical tick
        /// </summary>
        public required bool Critical1 { get; set; }
        public required uint Damage1 { get; set; }
        public required uint OverkillDamage { get; set; }
        /// <summary>
        /// vmangos: Sent as int32
        /// </summary>
        public required uint Resisted { get; set; }
        public required Wrath.SpellSchool School { get; set; }
    }
    public class AuraTypePeriodicDamagePercent {
        public required uint Absorb1 { get; set; }
        /// <summary>
        /// new 3.1.2 critical tick
        /// </summary>
        public required bool Critical1 { get; set; }
        public required uint Damage1 { get; set; }
        public required uint OverkillDamage { get; set; }
        /// <summary>
        /// vmangos: Sent as int32
        /// </summary>
        public required uint Resisted { get; set; }
        public required Wrath.SpellSchool School { get; set; }
    }
    public class AuraTypePeriodicEnergize {
        public required uint Damage3 { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue1 { get; set; }
    }
    public class AuraTypePeriodicHeal {
        public required uint Absorb2 { get; set; }
        /// <summary>
        /// new 3.1.2 critical tick
        /// </summary>
        public required bool Critical2 { get; set; }
        public required uint Damage2 { get; set; }
        public required uint OverDamage { get; set; }
    }
    public class AuraTypePeriodicManaLeech {
        public required uint Damage4 { get; set; }
        public required float GainMultiplier { get; set; }
        /// <summary>
        /// vmangos: A miscvalue that is dependent on what the aura will do, this is usually decided by the AuraType, ie: with AuraType::SPELL_AURA_MOD_BASE_RESISTANCE_PCT this value could be SpellSchoolMask::SPELL_SCHOOL_MASK_NORMAL which would tell the aura that it should change armor.  If Modifier::m_auraname would have been AuraType::SPELL_AURA_MOUNTED then m_miscvalue would have decided which model the mount should have
        /// </summary>
        public required uint MiscValue2 { get; set; }
    }
    public required AuraTypeType AuraType { get; set; }
    internal AuraType AuraTypeValue => AuraType.Match(
        _ => Wrath.AuraType.ObsModHealth,
        _ => Wrath.AuraType.ObsModPower,
        _ => Wrath.AuraType.PeriodicDamage,
        _ => Wrath.AuraType.PeriodicDamagePercent,
        _ => Wrath.AuraType.PeriodicEnergize,
        _ => Wrath.AuraType.PeriodicHeal,
        _ => Wrath.AuraType.PeriodicManaLeech,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)AuraTypeValue, cancellationToken).ConfigureAwait(false);

        if (AuraType.Value is AuraLog.AuraTypePeriodicDamage auraTypePeriodicDamage) {
            await w.WriteUInt(auraTypePeriodicDamage.Damage1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamage.OverkillDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)auraTypePeriodicDamage.School, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamage.Absorb1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamage.Resisted, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(auraTypePeriodicDamage.Critical1, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicDamagePercent auraTypePeriodicDamagePercent) {
            await w.WriteUInt(auraTypePeriodicDamagePercent.Damage1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamagePercent.OverkillDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)auraTypePeriodicDamagePercent.School, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamagePercent.Absorb1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicDamagePercent.Resisted, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(auraTypePeriodicDamagePercent.Critical1, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicHeal auraTypePeriodicHeal) {
            await w.WriteUInt(auraTypePeriodicHeal.Damage2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicHeal.OverDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicHeal.Absorb2, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(auraTypePeriodicHeal.Critical2, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModHealth auraTypeObsModHealth) {
            await w.WriteUInt(auraTypeObsModHealth.Damage2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypeObsModHealth.OverDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypeObsModHealth.Absorb2, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(auraTypeObsModHealth.Critical2, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModPower auraTypeObsModPower) {
            await w.WriteUInt(auraTypeObsModPower.MiscValue1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypeObsModPower.Damage3, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicEnergize auraTypePeriodicEnergize) {
            await w.WriteUInt(auraTypePeriodicEnergize.MiscValue1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicEnergize.Damage3, cancellationToken).ConfigureAwait(false);

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicManaLeech auraTypePeriodicManaLeech) {
            await w.WriteUInt(auraTypePeriodicManaLeech.MiscValue2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraTypePeriodicManaLeech.Damage4, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(auraTypePeriodicManaLeech.GainMultiplier, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<AuraLog> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        AuraTypeType auraType = (Wrath.AuraType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (auraType.Value is Wrath.AuraType.PeriodicDamage) {
            var damage1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var overkillDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var school = (Wrath.SpellSchool)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var absorb1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var resisted = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critical1 = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicDamage {
                Absorb1 = absorb1,
                Critical1 = critical1,
                Damage1 = damage1,
                OverkillDamage = overkillDamage,
                Resisted = resisted,
                School = school,
            };
        }
        else if (auraType.Value is Wrath.AuraType.PeriodicDamagePercent) {
            var damage1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var overkillDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var school = (Wrath.SpellSchool)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var absorb1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var resisted = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critical1 = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicDamagePercent {
                Absorb1 = absorb1,
                Critical1 = critical1,
                Damage1 = damage1,
                OverkillDamage = overkillDamage,
                Resisted = resisted,
                School = school,
            };
        }
        else if (auraType.Value is Wrath.AuraType.PeriodicHeal) {
            var damage2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var overDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var absorb2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critical2 = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicHeal {
                Absorb2 = absorb2,
                Critical2 = critical2,
                Damage2 = damage2,
                OverDamage = overDamage,
            };
        }
        else if (auraType.Value is Wrath.AuraType.ObsModHealth) {
            var damage2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var overDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var absorb2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critical2 = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypeObsModHealth {
                Absorb2 = absorb2,
                Critical2 = critical2,
                Damage2 = damage2,
                OverDamage = overDamage,
            };
        }
        else if (auraType.Value is Wrath.AuraType.ObsModPower) {
            var miscValue1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypeObsModPower {
                Damage3 = damage3,
                MiscValue1 = miscValue1,
            };
        }
        else if (auraType.Value is Wrath.AuraType.PeriodicEnergize) {
            var miscValue1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicEnergize {
                Damage3 = damage3,
                MiscValue1 = miscValue1,
            };
        }
        else if (auraType.Value is Wrath.AuraType.PeriodicManaLeech) {
            var miscValue2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var damage4 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var gainMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            auraType = new AuraTypePeriodicManaLeech {
                Damage4 = damage4,
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

        if (AuraType.Value is AuraLog.AuraTypePeriodicDamage auraTypePeriodicDamage) {
            // damage1: Generator.Generated.DataTypeInteger
            size += 4;

            // overkill_damage: Generator.Generated.DataTypeInteger
            size += 4;

            // school: Generator.Generated.DataTypeEnum
            size += 1;

            // absorb1: Generator.Generated.DataTypeInteger
            size += 4;

            // resisted: Generator.Generated.DataTypeInteger
            size += 4;

            // critical1: Generator.Generated.DataTypeBool
            size += 1;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicDamagePercent auraTypePeriodicDamagePercent) {
            // damage1: Generator.Generated.DataTypeInteger
            size += 4;

            // overkill_damage: Generator.Generated.DataTypeInteger
            size += 4;

            // school: Generator.Generated.DataTypeEnum
            size += 1;

            // absorb1: Generator.Generated.DataTypeInteger
            size += 4;

            // resisted: Generator.Generated.DataTypeInteger
            size += 4;

            // critical1: Generator.Generated.DataTypeBool
            size += 1;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicHeal auraTypePeriodicHeal) {
            // damage2: Generator.Generated.DataTypeInteger
            size += 4;

            // over_damage: Generator.Generated.DataTypeInteger
            size += 4;

            // absorb2: Generator.Generated.DataTypeInteger
            size += 4;

            // critical2: Generator.Generated.DataTypeBool
            size += 1;

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModHealth auraTypeObsModHealth) {
            // damage2: Generator.Generated.DataTypeInteger
            size += 4;

            // over_damage: Generator.Generated.DataTypeInteger
            size += 4;

            // absorb2: Generator.Generated.DataTypeInteger
            size += 4;

            // critical2: Generator.Generated.DataTypeBool
            size += 1;

        }
        else if (AuraType.Value is AuraLog.AuraTypeObsModPower auraTypeObsModPower) {
            // misc_value1: Generator.Generated.DataTypeInteger
            size += 4;

            // damage3: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicEnergize auraTypePeriodicEnergize) {
            // misc_value1: Generator.Generated.DataTypeInteger
            size += 4;

            // damage3: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (AuraType.Value is AuraLog.AuraTypePeriodicManaLeech auraTypePeriodicManaLeech) {
            // misc_value2: Generator.Generated.DataTypeInteger
            size += 4;

            // damage4: Generator.Generated.DataTypeInteger
            size += 4;

            // gain_multiplier: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        return size;
    }

}

