using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using SpellCastResultType = OneOf.OneOf<SMSG_PET_CAST_FAILED.SpellCastResultCustomError, SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClass, SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassMainhand, SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassOffhand, SMSG_PET_CAST_FAILED.SpellCastResultFishingTooLow, SMSG_PET_CAST_FAILED.SpellCastResultMinSkill, SMSG_PET_CAST_FAILED.SpellCastResultNeedExoticAmmo, SMSG_PET_CAST_FAILED.SpellCastResultNeedMoreItems, SMSG_PET_CAST_FAILED.SpellCastResultPreventedByMechanic, SMSG_PET_CAST_FAILED.SpellCastResultReagents, SMSG_PET_CAST_FAILED.SpellCastResultRequiresArea, SMSG_PET_CAST_FAILED.SpellCastResultRequiresSpellFocus, SMSG_PET_CAST_FAILED.SpellCastResultTooManyOfItem, SMSG_PET_CAST_FAILED.SpellCastResultTotems, SMSG_PET_CAST_FAILED.SpellCastResultTotemCategory, SpellCastResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_CAST_FAILED: WrathServerMessage, IWorldMessage {
    public class SpellCastResultCustomError {
        public required uint CustomError { get; set; }
    }
    public class SpellCastResultEquippedItemClass {
        public required uint ItemClass { get; set; }
        public required uint ItemSubClass { get; set; }
    }
    public class SpellCastResultEquippedItemClassMainhand {
        public required uint ItemClass { get; set; }
        public required uint ItemSubClass { get; set; }
    }
    public class SpellCastResultEquippedItemClassOffhand {
        public required uint ItemClass { get; set; }
        public required uint ItemSubClass { get; set; }
    }
    public class SpellCastResultFishingTooLow {
        public required uint FishingSkillRequired { get; set; }
    }
    public class SpellCastResultMinSkill {
        public required Wrath.Skill Skill { get; set; }
        public required uint SkillRequired { get; set; }
    }
    public class SpellCastResultNeedExoticAmmo {
        public required uint EquippedItemSubClass { get; set; }
    }
    public class SpellCastResultNeedMoreItems {
        public required uint Count { get; set; }
        public required uint Item { get; set; }
    }
    public class SpellCastResultPreventedByMechanic {
        public required uint Mechanic { get; set; }
    }
    public class SpellCastResultReagents {
        public required uint MissingItem { get; set; }
    }
    public class SpellCastResultRequiresArea {
        public required Wrath.Area Area { get; set; }
    }
    public class SpellCastResultRequiresSpellFocus {
        public required uint SpellFocus { get; set; }
    }
    public class SpellCastResultTooManyOfItem {
        public required uint ItemLimitCategory { get; set; }
    }
    public class SpellCastResultTotems {
        public const int TotemsLength = 2;
        public required uint[] Totems { get; set; }
    }
    public class SpellCastResultTotemCategory {
        public const int TotemCategoriesLength = 2;
        public required uint[] TotemCategories { get; set; }
    }
    public required byte CastCount { get; set; }
    public required uint Id { get; set; }
    public required SpellCastResultType Result { get; set; }
    internal SpellCastResult ResultValue => Result.Match(
        _ => Wrath.SpellCastResult.CustomError,
        _ => Wrath.SpellCastResult.EquippedItemClass,
        _ => Wrath.SpellCastResult.EquippedItemClassMainhand,
        _ => Wrath.SpellCastResult.EquippedItemClassOffhand,
        _ => Wrath.SpellCastResult.FishingTooLow,
        _ => Wrath.SpellCastResult.MinSkill,
        _ => Wrath.SpellCastResult.NeedExoticAmmo,
        _ => Wrath.SpellCastResult.NeedMoreItems,
        _ => Wrath.SpellCastResult.PreventedByMechanic,
        _ => Wrath.SpellCastResult.Reagents,
        _ => Wrath.SpellCastResult.RequiresArea,
        _ => Wrath.SpellCastResult.RequiresSpellFocus,
        _ => Wrath.SpellCastResult.TooManyOfItem,
        _ => Wrath.SpellCastResult.Totems,
        _ => Wrath.SpellCastResult.TotemCategory,
        v => v
    );
    public required bool MultipleCasts { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(CastCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(MultipleCasts, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultRequiresSpellFocus spellCastResultRequiresSpellFocus) {
            await w.WriteUInt(spellCastResultRequiresSpellFocus.SpellFocus, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultRequiresArea spellCastResultRequiresArea) {
            await w.WriteUInt((uint)spellCastResultRequiresArea.Area, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTotems spellCastResultTotems) {
            foreach (var v in spellCastResultTotems.Totems) {
                await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
            }

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTotemCategory spellCastResultTotemCategory) {
            foreach (var v in spellCastResultTotemCategory.TotemCategories) {
                await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
            }

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClass spellCastResultEquippedItemClass) {
            await w.WriteUInt(spellCastResultEquippedItemClass.ItemClass, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellCastResultEquippedItemClass.ItemSubClass, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassOffhand spellCastResultEquippedItemClassOffhand) {
            await w.WriteUInt(spellCastResultEquippedItemClassOffhand.ItemClass, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellCastResultEquippedItemClassOffhand.ItemSubClass, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassMainhand spellCastResultEquippedItemClassMainhand) {
            await w.WriteUInt(spellCastResultEquippedItemClassMainhand.ItemClass, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellCastResultEquippedItemClassMainhand.ItemSubClass, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTooManyOfItem spellCastResultTooManyOfItem) {
            await w.WriteUInt(spellCastResultTooManyOfItem.ItemLimitCategory, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultCustomError spellCastResultCustomError) {
            await w.WriteUInt(spellCastResultCustomError.CustomError, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultReagents spellCastResultReagents) {
            await w.WriteUInt(spellCastResultReagents.MissingItem, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultPreventedByMechanic spellCastResultPreventedByMechanic) {
            await w.WriteUInt(spellCastResultPreventedByMechanic.Mechanic, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultNeedExoticAmmo spellCastResultNeedExoticAmmo) {
            await w.WriteUInt(spellCastResultNeedExoticAmmo.EquippedItemSubClass, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultNeedMoreItems spellCastResultNeedMoreItems) {
            await w.WriteUInt(spellCastResultNeedMoreItems.Item, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellCastResultNeedMoreItems.Count, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultMinSkill spellCastResultMinSkill) {
            await w.WriteUInt((uint)spellCastResultMinSkill.Skill, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellCastResultMinSkill.SkillRequired, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultFishingTooLow spellCastResultFishingTooLow) {
            await w.WriteUInt(spellCastResultFishingTooLow.FishingSkillRequired, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 312, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 312, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_CAST_FAILED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var castCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        SpellCastResultType result = (Wrath.SpellCastResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var multipleCasts = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.SpellCastResult.RequiresSpellFocus) {
            var spellFocus = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultRequiresSpellFocus {
                SpellFocus = spellFocus,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.RequiresArea) {
            var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultRequiresArea {
                Area = area,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.Totems) {
            var totems = new uint[SpellCastResultTotems.TotemsLength];
            for (var i = 0; i < SpellCastResultTotems.TotemsLength; ++i) {
                totems[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            }

            result = new SpellCastResultTotems {
                Totems = totems,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.TotemCategory) {
            var totemCategories = new uint[SpellCastResultTotemCategory.TotemCategoriesLength];
            for (var i = 0; i < SpellCastResultTotemCategory.TotemCategoriesLength; ++i) {
                totemCategories[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            }

            result = new SpellCastResultTotemCategory {
                TotemCategories = totemCategories,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.EquippedItemClass) {
            var itemClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var itemSubClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultEquippedItemClass {
                ItemClass = itemClass,
                ItemSubClass = itemSubClass,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.EquippedItemClassOffhand) {
            var itemClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var itemSubClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultEquippedItemClassOffhand {
                ItemClass = itemClass,
                ItemSubClass = itemSubClass,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.EquippedItemClassMainhand) {
            var itemClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var itemSubClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultEquippedItemClassMainhand {
                ItemClass = itemClass,
                ItemSubClass = itemSubClass,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.TooManyOfItem) {
            var itemLimitCategory = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultTooManyOfItem {
                ItemLimitCategory = itemLimitCategory,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.CustomError) {
            var customError = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultCustomError {
                CustomError = customError,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.Reagents) {
            var missingItem = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultReagents {
                MissingItem = missingItem,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.PreventedByMechanic) {
            var mechanic = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultPreventedByMechanic {
                Mechanic = mechanic,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.NeedExoticAmmo) {
            var equippedItemSubClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultNeedExoticAmmo {
                EquippedItemSubClass = equippedItemSubClass,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.NeedMoreItems) {
            var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var count = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultNeedMoreItems {
                Count = count,
                Item = item,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.MinSkill) {
            var skill = (Wrath.Skill)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var skillRequired = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultMinSkill {
                Skill = skill,
                SkillRequired = skillRequired,
            };
        }
        else if (result.Value is Wrath.SpellCastResult.FishingTooLow) {
            var fishingSkillRequired = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultFishingTooLow {
                FishingSkillRequired = fishingSkillRequired,
            };
        }

        return new SMSG_PET_CAST_FAILED {
            CastCount = castCount,
            Id = id,
            Result = result,
            MultipleCasts = multipleCasts,
        };
    }

    internal int Size() {
        var size = 0;

        // cast_count: Generator.Generated.DataTypeInteger
        size += 1;

        // id: Generator.Generated.DataTypeSpell
        size += 4;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        // multiple_casts: Generator.Generated.DataTypeBool
        size += 1;

        if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultRequiresSpellFocus spellCastResultRequiresSpellFocus) {
            // spell_focus: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultRequiresArea spellCastResultRequiresArea) {
            // area: Generator.Generated.DataTypeEnum
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTotems spellCastResultTotems) {
            // totems: Generator.Generated.DataTypeArray
            size += spellCastResultTotems.Totems.Sum(e => 4);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTotemCategory spellCastResultTotemCategory) {
            // totem_categories: Generator.Generated.DataTypeArray
            size += spellCastResultTotemCategory.TotemCategories.Sum(e => 4);

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClass spellCastResultEquippedItemClass) {
            // item_class: Generator.Generated.DataTypeInteger
            size += 4;

            // item_sub_class: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassOffhand spellCastResultEquippedItemClassOffhand) {
            // item_class: Generator.Generated.DataTypeInteger
            size += 4;

            // item_sub_class: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClassMainhand spellCastResultEquippedItemClassMainhand) {
            // item_class: Generator.Generated.DataTypeInteger
            size += 4;

            // item_sub_class: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultTooManyOfItem spellCastResultTooManyOfItem) {
            // item_limit_category: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultCustomError spellCastResultCustomError) {
            // custom_error: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultReagents spellCastResultReagents) {
            // missing_item: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultPreventedByMechanic spellCastResultPreventedByMechanic) {
            // mechanic: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultNeedExoticAmmo spellCastResultNeedExoticAmmo) {
            // equipped_item_sub_class: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultNeedMoreItems spellCastResultNeedMoreItems) {
            // item: Generator.Generated.DataTypeItem
            size += 4;

            // count: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultMinSkill spellCastResultMinSkill) {
            // skill: Generator.Generated.DataTypeEnum
            size += 4;

            // skill_required: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_PET_CAST_FAILED.SpellCastResultFishingTooLow spellCastResultFishingTooLow) {
            // fishing_skill_required: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

