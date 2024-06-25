using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using SpellCastResultType = OneOf.OneOf<SMSG_PET_CAST_FAILED.SpellCastResultEquippedItemClass, SMSG_PET_CAST_FAILED.SpellCastResultRequiresArea, SMSG_PET_CAST_FAILED.SpellCastResultRequiresSpellFocus, SMSG_PET_CAST_FAILED.SpellCastResultTotems, SMSG_PET_CAST_FAILED.SpellCastResultTotemCategory, SpellCastResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_CAST_FAILED: TbcServerMessage, IWorldMessage {
    public class SpellCastResultEquippedItemClass {
        public required uint ItemClass { get; set; }
        public required uint ItemInventoryType { get; set; }
        public required uint ItemSubClass { get; set; }
    }
    public class SpellCastResultRequiresArea {
        public required Tbc.Area Area { get; set; }
    }
    public class SpellCastResultRequiresSpellFocus {
        public required uint SpellFocus { get; set; }
    }
    public class SpellCastResultTotems {
        public const int TotemsLength = 2;
        public required uint[] Totems { get; set; }
    }
    public class SpellCastResultTotemCategory {
        public const int TotemCategoriesLength = 2;
        public required uint[] TotemCategories { get; set; }
    }
    public required uint Id { get; set; }
    public required SpellCastResultType Result { get; set; }
    internal SpellCastResult ResultValue => Result.Match(
        _ => Tbc.SpellCastResult.EquippedItemClass,
        _ => Tbc.SpellCastResult.RequiresArea,
        _ => Tbc.SpellCastResult.RequiresSpellFocus,
        _ => Tbc.SpellCastResult.Totems,
        _ => Tbc.SpellCastResult.TotemCategory,
        v => v
    );
    public required bool MultipleCasts { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
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

            await w.WriteUInt(spellCastResultEquippedItemClass.ItemInventoryType, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 312, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 312, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_CAST_FAILED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        SpellCastResultType result = (Tbc.SpellCastResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var multipleCasts = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        if (result.Value is Tbc.SpellCastResult.RequiresSpellFocus) {
            var spellFocus = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultRequiresSpellFocus {
                SpellFocus = spellFocus,
            };
        }
        else if (result.Value is Tbc.SpellCastResult.RequiresArea) {
            var area = (Tbc.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultRequiresArea {
                Area = area,
            };
        }
        else if (result.Value is Tbc.SpellCastResult.Totems) {
            var totems = new uint[SpellCastResultTotems.TotemsLength];
            for (var i = 0; i < SpellCastResultTotems.TotemsLength; ++i) {
                totems[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            }

            result = new SpellCastResultTotems {
                Totems = totems,
            };
        }
        else if (result.Value is Tbc.SpellCastResult.TotemCategory) {
            var totemCategories = new uint[SpellCastResultTotemCategory.TotemCategoriesLength];
            for (var i = 0; i < SpellCastResultTotemCategory.TotemCategoriesLength; ++i) {
                totemCategories[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            }

            result = new SpellCastResultTotemCategory {
                TotemCategories = totemCategories,
            };
        }
        else if (result.Value is Tbc.SpellCastResult.EquippedItemClass) {
            var itemClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var itemSubClass = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var itemInventoryType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new SpellCastResultEquippedItemClass {
                ItemClass = itemClass,
                ItemInventoryType = itemInventoryType,
                ItemSubClass = itemSubClass,
            };
        }

        return new SMSG_PET_CAST_FAILED {
            Id = id,
            Result = result,
            MultipleCasts = multipleCasts,
        };
    }

    internal int Size() {
        var size = 0;

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

            // item_inventory_type: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

