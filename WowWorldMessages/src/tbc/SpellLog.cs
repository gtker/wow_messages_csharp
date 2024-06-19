using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using SpellEffectType = OneOf.OneOf<SpellLog.SpellEffectAddExtraAttacks, SpellLog.SpellEffectCreateHouse, SpellLog.SpellEffectCreateItem, SpellLog.SpellEffectDismissPet, SpellLog.SpellEffectDuel, SpellLog.SpellEffectDurabilityDamage, SpellLog.SpellEffectFeedPet, SpellLog.SpellEffectInterruptCast, SpellLog.SpellEffectOpenLock, SpellLog.SpellEffectOpenLockItem, SpellLog.SpellEffectPowerDrain, SpellLog.SpellEffectSummon, SpellLog.SpellEffectSummonObjectSlot1, SpellLog.SpellEffectSummonObjectSlot2, SpellLog.SpellEffectSummonObjectSlot3, SpellLog.SpellEffectSummonObjectSlot4, SpellLog.SpellEffectSummonObjectWild, SpellLog.SpellEffectSummonPet, SpellLog.SpellEffectTransDoor, SpellEffect>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SpellLog {
    public class SpellEffectAddExtraAttacks {
        public required uint ExtraAttacks { get; set; }
        public required ulong Target4 { get; set; }
    }
    public class SpellEffectCreateHouse {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectCreateItem {
        public required uint Item { get; set; }
    }
    public class SpellEffectDismissPet {
        public required ulong PetDismissGuid { get; set; }
    }
    public class SpellEffectDuel {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectDurabilityDamage {
        public required uint ItemToDamage { get; set; }
        public required ulong Target6 { get; set; }
        public required uint Unknown5 { get; set; }
    }
    public class SpellEffectFeedPet {
        public required ulong PetFeedGuid { get; set; }
    }
    public class SpellEffectInterruptCast {
        public required uint InterruptedSpell { get; set; }
        public required ulong Target5 { get; set; }
    }
    public class SpellEffectOpenLock {
        public required ulong LockTarget { get; set; }
    }
    public class SpellEffectOpenLockItem {
        public required ulong LockTarget { get; set; }
    }
    public class SpellEffectPowerDrain {
        public required uint Amount { get; set; }
        public required float Multiplier { get; set; }
        public required Tbc.Power Power { get; set; }
        public required ulong Target1 { get; set; }
    }
    public class SpellEffectSummon {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonObjectSlot1 {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonObjectSlot2 {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonObjectSlot3 {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonObjectSlot4 {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonObjectWild {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectSummonPet {
        public required ulong SummonTarget { get; set; }
    }
    public class SpellEffectTransDoor {
        public required ulong SummonTarget { get; set; }
    }
    public required SpellEffectType Effect { get; set; }
    internal SpellEffect EffectValue => Effect.Match(
        _ => Tbc.SpellEffect.AddExtraAttacks,
        _ => Tbc.SpellEffect.CreateHouse,
        _ => Tbc.SpellEffect.CreateItem,
        _ => Tbc.SpellEffect.DismissPet,
        _ => Tbc.SpellEffect.Duel,
        _ => Tbc.SpellEffect.DurabilityDamage,
        _ => Tbc.SpellEffect.FeedPet,
        _ => Tbc.SpellEffect.InterruptCast,
        _ => Tbc.SpellEffect.OpenLock,
        _ => Tbc.SpellEffect.OpenLockItem,
        _ => Tbc.SpellEffect.PowerDrain,
        _ => Tbc.SpellEffect.Summon,
        _ => Tbc.SpellEffect.SummonObjectSlot1,
        _ => Tbc.SpellEffect.SummonObjectSlot2,
        _ => Tbc.SpellEffect.SummonObjectSlot3,
        _ => Tbc.SpellEffect.SummonObjectSlot4,
        _ => Tbc.SpellEffect.SummonObjectWild,
        _ => Tbc.SpellEffect.SummonPet,
        _ => Tbc.SpellEffect.TransDoor,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)EffectValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(1, cancellationToken).ConfigureAwait(false);

        if (Effect.Value is SpellLog.SpellEffectPowerDrain spellEffectPowerDrain) {
            await w.WritePackedGuid(spellEffectPowerDrain.Target1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellEffectPowerDrain.Amount, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)spellEffectPowerDrain.Power, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(spellEffectPowerDrain.Multiplier, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectAddExtraAttacks spellEffectAddExtraAttacks) {
            await w.WritePackedGuid(spellEffectAddExtraAttacks.Target4, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellEffectAddExtraAttacks.ExtraAttacks, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectInterruptCast spellEffectInterruptCast) {
            await w.WritePackedGuid(spellEffectInterruptCast.Target5, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellEffectInterruptCast.InterruptedSpell, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectDurabilityDamage spellEffectDurabilityDamage) {
            await w.WritePackedGuid(spellEffectDurabilityDamage.Target6, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellEffectDurabilityDamage.ItemToDamage, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spellEffectDurabilityDamage.Unknown5, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectOpenLock spellEffectOpenLock) {
            await w.WritePackedGuid(spellEffectOpenLock.LockTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectOpenLockItem spellEffectOpenLockItem) {
            await w.WritePackedGuid(spellEffectOpenLockItem.LockTarget, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectCreateItem spellEffectCreateItem) {
            await w.WriteUInt(spellEffectCreateItem.Item, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectSummon spellEffectSummon) {
            await w.WritePackedGuid(spellEffectSummon.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectTransDoor spellEffectTransDoor) {
            await w.WritePackedGuid(spellEffectTransDoor.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonPet spellEffectSummonPet) {
            await w.WritePackedGuid(spellEffectSummonPet.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectWild spellEffectSummonObjectWild) {
            await w.WritePackedGuid(spellEffectSummonObjectWild.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectCreateHouse spellEffectCreateHouse) {
            await w.WritePackedGuid(spellEffectCreateHouse.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectDuel spellEffectDuel) {
            await w.WritePackedGuid(spellEffectDuel.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot1 spellEffectSummonObjectSlot1) {
            await w.WritePackedGuid(spellEffectSummonObjectSlot1.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot2 spellEffectSummonObjectSlot2) {
            await w.WritePackedGuid(spellEffectSummonObjectSlot2.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot3 spellEffectSummonObjectSlot3) {
            await w.WritePackedGuid(spellEffectSummonObjectSlot3.SummonTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot4 spellEffectSummonObjectSlot4) {
            await w.WritePackedGuid(spellEffectSummonObjectSlot4.SummonTarget, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectFeedPet spellEffectFeedPet) {
            await w.WritePackedGuid(spellEffectFeedPet.PetFeedGuid, cancellationToken).ConfigureAwait(false);

        }

        else if (Effect.Value is SpellLog.SpellEffectDismissPet spellEffectDismissPet) {
            await w.WritePackedGuid(spellEffectDismissPet.PetDismissGuid, cancellationToken).ConfigureAwait(false);

        }


    }

    public static async Task<SpellLog> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        SpellEffectType effect = (Tbc.SpellEffect)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfLogs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (effect.Value is Tbc.SpellEffect.PowerDrain) {
            var target1 = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var amount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var power = (Tbc.Power)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var multiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectPowerDrain {
                Amount = amount,
                Multiplier = multiplier,
                Power = power,
                Target1 = target1,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.AddExtraAttacks) {
            var target4 = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var extraAttacks = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectAddExtraAttacks {
                ExtraAttacks = extraAttacks,
                Target4 = target4,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.InterruptCast) {
            var target5 = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var interruptedSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectInterruptCast {
                InterruptedSpell = interruptedSpell,
                Target5 = target5,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.DurabilityDamage) {
            var target6 = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var itemToDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown5 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectDurabilityDamage {
                ItemToDamage = itemToDamage,
                Target6 = target6,
                Unknown5 = unknown5,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.OpenLock) {
            var lockTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectOpenLock {
                LockTarget = lockTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.OpenLockItem) {
            var lockTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectOpenLockItem {
                LockTarget = lockTarget,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.CreateItem) {
            var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectCreateItem {
                Item = item,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.Summon) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummon {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.TransDoor) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectTransDoor {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonPet) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonPet {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonObjectWild) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonObjectWild {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.CreateHouse) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectCreateHouse {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.Duel) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectDuel {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonObjectSlot1) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonObjectSlot1 {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonObjectSlot2) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonObjectSlot2 {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonObjectSlot3) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonObjectSlot3 {
                SummonTarget = summonTarget,
            };
        }
        else if (effect.Value is Tbc.SpellEffect.SummonObjectSlot4) {
            var summonTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectSummonObjectSlot4 {
                SummonTarget = summonTarget,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.FeedPet) {
            var petFeedGuid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectFeedPet {
                PetFeedGuid = petFeedGuid,
            };
        }

        else if (effect.Value is Tbc.SpellEffect.DismissPet) {
            var petDismissGuid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            effect = new SpellEffectDismissPet {
                PetDismissGuid = petDismissGuid,
            };
        }


        return new SpellLog {
            Effect = effect,
        };
    }

    internal int Size() {
        var size = 0;

        // effect: Generator.Generated.DataTypeEnum
        size += 4;

        // amount_of_logs: Generator.Generated.DataTypeInteger
        size += 4;

        if (Effect.Value is SpellLog.SpellEffectPowerDrain spellEffectPowerDrain) {
            // target1: Generator.Generated.DataTypePackedGuid
            size += spellEffectPowerDrain.Target1.PackedGuidLength();

            // amount: Generator.Generated.DataTypeInteger
            size += 4;

            // power: Generator.Generated.DataTypeEnum
            size += 4;

            // multiplier: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (Effect.Value is SpellLog.SpellEffectAddExtraAttacks spellEffectAddExtraAttacks) {
            // target4: Generator.Generated.DataTypePackedGuid
            size += spellEffectAddExtraAttacks.Target4.PackedGuidLength();

            // extra_attacks: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (Effect.Value is SpellLog.SpellEffectInterruptCast spellEffectInterruptCast) {
            // target5: Generator.Generated.DataTypePackedGuid
            size += spellEffectInterruptCast.Target5.PackedGuidLength();

            // interrupted_spell: Generator.Generated.DataTypeSpell
            size += 4;

        }

        else if (Effect.Value is SpellLog.SpellEffectDurabilityDamage spellEffectDurabilityDamage) {
            // target6: Generator.Generated.DataTypePackedGuid
            size += spellEffectDurabilityDamage.Target6.PackedGuidLength();

            // item_to_damage: Generator.Generated.DataTypeItem
            size += 4;

            // unknown5: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (Effect.Value is SpellLog.SpellEffectOpenLock spellEffectOpenLock) {
            // lock_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectOpenLock.LockTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectOpenLockItem spellEffectOpenLockItem) {
            // lock_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectOpenLockItem.LockTarget.PackedGuidLength();

        }

        else if (Effect.Value is SpellLog.SpellEffectCreateItem spellEffectCreateItem) {
            // item: Generator.Generated.DataTypeItem
            size += 4;

        }

        else if (Effect.Value is SpellLog.SpellEffectSummon spellEffectSummon) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummon.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectTransDoor spellEffectTransDoor) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectTransDoor.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonPet spellEffectSummonPet) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonPet.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectWild spellEffectSummonObjectWild) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonObjectWild.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectCreateHouse spellEffectCreateHouse) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectCreateHouse.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectDuel spellEffectDuel) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectDuel.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot1 spellEffectSummonObjectSlot1) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonObjectSlot1.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot2 spellEffectSummonObjectSlot2) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonObjectSlot2.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot3 spellEffectSummonObjectSlot3) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonObjectSlot3.SummonTarget.PackedGuidLength();

        }
        else if (Effect.Value is SpellLog.SpellEffectSummonObjectSlot4 spellEffectSummonObjectSlot4) {
            // summon_target: Generator.Generated.DataTypePackedGuid
            size += spellEffectSummonObjectSlot4.SummonTarget.PackedGuidLength();

        }

        else if (Effect.Value is SpellLog.SpellEffectFeedPet spellEffectFeedPet) {
            // pet_feed_guid: Generator.Generated.DataTypePackedGuid
            size += spellEffectFeedPet.PetFeedGuid.PackedGuidLength();

        }

        else if (Effect.Value is SpellLog.SpellEffectDismissPet spellEffectDismissPet) {
            // pet_dismiss_guid: Generator.Generated.DataTypePackedGuid
            size += spellEffectDismissPet.PetDismissGuid.PackedGuidLength();

        }


        return size;
    }

}

