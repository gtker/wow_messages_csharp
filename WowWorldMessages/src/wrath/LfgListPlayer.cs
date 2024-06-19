using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgListPlayer {
    public class LfgUpdateFlagType {
        public required LfgUpdateFlag Inner;
        public LfgUpdateFlagArea? Area;
        public LfgUpdateFlagCharacterInfo? CharacterInfo;
        public LfgUpdateFlagComment? Comment;
        public LfgUpdateFlagGroupGuid? GroupGuid;
        public LfgUpdateFlagGroupLeader? GroupLeader;
        public LfgUpdateFlagRoles? Roles;
        public LfgUpdateFlagStatus? Status;
    }
    public class LfgUpdateFlagArea {
        public required Wrath.Area Area { get; set; }
    }
    public class LfgUpdateFlagCharacterInfo {
        public required uint Agility { get; set; }
        public required uint Armor { get; set; }
        public required uint AttackPower { get; set; }
        public required uint AverageItemLevel { get; set; }
        public required uint BlockRating { get; set; }
        public required Wrath.Class ClassType { get; set; }
        public required uint CritRatingMelee { get; set; }
        public required uint CritRatingRanged { get; set; }
        public required uint CritRatingSpell { get; set; }
        public required uint DefenseSkill { get; set; }
        public required uint DodgeRating { get; set; }
        public required uint ExpertiseRating { get; set; }
        public required uint HasteRating { get; set; }
        public required uint Health { get; set; }
        public required byte Level { get; set; }
        public required uint Mana { get; set; }
        public required float ManaPer5Seconds { get; set; }
        public required float ManaPer5SecondsCombat { get; set; }
        /// <summary>
        /// azerothcore: talentpoints, used as online/offline marker :D
        /// </summary>
        public required bool Online { get; set; }
        public required uint ParryRating { get; set; }
        public required Wrath.Race Race { get; set; }
        public required uint SpellDamage { get; set; }
        public required uint SpellHeal { get; set; }
        public required byte Talents0 { get; set; }
        public required byte Talents1 { get; set; }
        public required byte Talents2 { get; set; }
    }
    public class LfgUpdateFlagComment {
        public required string Comment { get; set; }
    }
    public class LfgUpdateFlagGroupGuid {
        public required ulong Group { get; set; }
    }
    public class LfgUpdateFlagGroupLeader {
        /// <summary>
        /// emu sets to true.
        /// </summary>
        public required bool IsLookingForMore { get; set; }
    }
    public class LfgUpdateFlagRoles {
        public required byte Roles { get; set; }
    }
    public class LfgUpdateFlagStatus {
        /// <summary>
        /// Emus set to 0.
        /// </summary>
        public required byte Unknown1 { get; set; }
    }
    public required ulong Player { get; set; }
    public required LfgUpdateFlagType Flags { get; set; }
    public required ulong Instance { get; set; }
    public required uint EncounterMask { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        if (Flags.CharacterInfo is {} lfgUpdateFlagCharacterInfo) {
            await w.WriteByte(lfgUpdateFlagCharacterInfo.Level, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)lfgUpdateFlagCharacterInfo.ClassType, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)lfgUpdateFlagCharacterInfo.Race, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(lfgUpdateFlagCharacterInfo.Talents0, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(lfgUpdateFlagCharacterInfo.Talents1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(lfgUpdateFlagCharacterInfo.Talents2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.Armor, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.SpellDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.SpellHeal, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.CritRatingMelee, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.CritRatingRanged, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.CritRatingSpell, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(lfgUpdateFlagCharacterInfo.ManaPer5Seconds, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(lfgUpdateFlagCharacterInfo.ManaPer5SecondsCombat, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.AttackPower, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.Agility, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.Health, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.Mana, cancellationToken).ConfigureAwait(false);

            await w.WriteBool32(lfgUpdateFlagCharacterInfo.Online, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.AverageItemLevel, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.DefenseSkill, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.DodgeRating, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.BlockRating, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.ParryRating, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.HasteRating, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(lfgUpdateFlagCharacterInfo.ExpertiseRating, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Comment is {} lfgUpdateFlagComment) {
            await w.WriteCString(lfgUpdateFlagComment.Comment, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.GroupLeader is {} lfgUpdateFlagGroupLeader) {
            await w.WriteBool8(lfgUpdateFlagGroupLeader.IsLookingForMore, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.GroupGuid is {} lfgUpdateFlagGroupGuid) {
            await w.WriteULong(lfgUpdateFlagGroupGuid.Group, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Roles is {} lfgUpdateFlagRoles) {
            await w.WriteByte(lfgUpdateFlagRoles.Roles, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Area is {} lfgUpdateFlagArea) {
            await w.WriteUInt((uint)lfgUpdateFlagArea.Area, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Status is {} lfgUpdateFlagStatus) {
            await w.WriteByte(lfgUpdateFlagStatus.Unknown1, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteULong(Instance, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EncounterMask, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgListPlayer> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var flags = new LfgUpdateFlagType {
            Inner = (LfgUpdateFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.CharacterInfo)) {
            var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var classType = (Wrath.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var race = (Wrath.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var talents0 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var talents1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var talents2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var armor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var spellDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var spellHeal = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critRatingMelee = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critRatingRanged = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var critRatingSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var manaPer5Seconds = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var manaPer5SecondsCombat = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var attackPower = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var agility = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var health = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var mana = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var online = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

            var averageItemLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var defenseSkill = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var dodgeRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var blockRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var parryRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var hasteRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var expertiseRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.CharacterInfo = new LfgUpdateFlagCharacterInfo {
                Agility = agility,
                Armor = armor,
                AttackPower = attackPower,
                AverageItemLevel = averageItemLevel,
                BlockRating = blockRating,
                ClassType = classType,
                CritRatingMelee = critRatingMelee,
                CritRatingRanged = critRatingRanged,
                CritRatingSpell = critRatingSpell,
                DefenseSkill = defenseSkill,
                DodgeRating = dodgeRating,
                ExpertiseRating = expertiseRating,
                HasteRating = hasteRating,
                Health = health,
                Level = level,
                Mana = mana,
                ManaPer5Seconds = manaPer5Seconds,
                ManaPer5SecondsCombat = manaPer5SecondsCombat,
                Online = online,
                ParryRating = parryRating,
                Race = race,
                SpellDamage = spellDamage,
                SpellHeal = spellHeal,
                Talents0 = talents0,
                Talents1 = talents1,
                Talents2 = talents2,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Comment)) {
            var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            flags.Comment = new LfgUpdateFlagComment {
                Comment = comment,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.GroupLeader)) {
            var isLookingForMore = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            flags.GroupLeader = new LfgUpdateFlagGroupLeader {
                IsLookingForMore = isLookingForMore,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.GroupGuid)) {
            var group = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            flags.GroupGuid = new LfgUpdateFlagGroupGuid {
                Group = group,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Roles)) {
            var roles = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            flags.Roles = new LfgUpdateFlagRoles {
                Roles = roles,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Area)) {
            var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.Area = new LfgUpdateFlagArea {
                Area = area,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Status)) {
            var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            flags.Status = new LfgUpdateFlagStatus {
                Unknown1 = unknown1,
            };
        }

        var instance = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var encounterMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new LfgListPlayer {
            Player = player,
            Flags = flags,
            Instance = instance,
            EncounterMask = encounterMask,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // flags: Generator.Generated.DataTypeFlag
        size += 4;

        if (Flags.CharacterInfo is {} lfgUpdateFlagCharacterInfo) {
            // level: Generator.Generated.DataTypeLevel
            size += 1;

            // class_type: Generator.Generated.DataTypeEnum
            size += 1;

            // race: Generator.Generated.DataTypeEnum
            size += 1;

            // talents0: Generator.Generated.DataTypeInteger
            size += 1;

            // talents1: Generator.Generated.DataTypeInteger
            size += 1;

            // talents2: Generator.Generated.DataTypeInteger
            size += 1;

            // armor: Generator.Generated.DataTypeInteger
            size += 4;

            // spell_damage: Generator.Generated.DataTypeInteger
            size += 4;

            // spell_heal: Generator.Generated.DataTypeInteger
            size += 4;

            // crit_rating_melee: Generator.Generated.DataTypeInteger
            size += 4;

            // crit_rating_ranged: Generator.Generated.DataTypeInteger
            size += 4;

            // crit_rating_spell: Generator.Generated.DataTypeInteger
            size += 4;

            // mana_per_5_seconds: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // mana_per_5_seconds_combat: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // attack_power: Generator.Generated.DataTypeInteger
            size += 4;

            // agility: Generator.Generated.DataTypeInteger
            size += 4;

            // health: Generator.Generated.DataTypeInteger
            size += 4;

            // mana: Generator.Generated.DataTypeInteger
            size += 4;

            // online: Generator.Generated.DataTypeBool
            size += 4;

            // average_item_level: Generator.Generated.DataTypeInteger
            size += 4;

            // defense_skill: Generator.Generated.DataTypeInteger
            size += 4;

            // dodge_rating: Generator.Generated.DataTypeInteger
            size += 4;

            // block_rating: Generator.Generated.DataTypeInteger
            size += 4;

            // parry_rating: Generator.Generated.DataTypeInteger
            size += 4;

            // haste_rating: Generator.Generated.DataTypeInteger
            size += 4;

            // expertise_rating: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Flags.Comment is {} lfgUpdateFlagComment) {
            // comment: Generator.Generated.DataTypeCstring
            size += lfgUpdateFlagComment.Comment.Length + 1;

        }

        if (Flags.GroupLeader is {} lfgUpdateFlagGroupLeader) {
            // is_looking_for_more: Generator.Generated.DataTypeBool
            size += 1;

        }

        if (Flags.GroupGuid is {} lfgUpdateFlagGroupGuid) {
            // group: Generator.Generated.DataTypeGuid
            size += 8;

        }

        if (Flags.Roles is {} lfgUpdateFlagRoles) {
            // roles: Generator.Generated.DataTypeInteger
            size += 1;

        }

        if (Flags.Area is {} lfgUpdateFlagArea) {
            // area: Generator.Generated.DataTypeEnum
            size += 4;

        }

        if (Flags.Status is {} lfgUpdateFlagStatus) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 1;

        }

        // instance: Generator.Generated.DataTypeGuid
        size += 8;

        // encounter_mask: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

