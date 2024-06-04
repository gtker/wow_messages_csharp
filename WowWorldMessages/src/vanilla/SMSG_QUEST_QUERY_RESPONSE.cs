using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUEST_QUERY_RESPONSE: VanillaServerMessage, IWorldMessage {
    public required uint QuestId { get; set; }
    /// <summary>
    /// Accepted values: 0, 1 or 2. 0==IsAutoComplete() (skip objectives/details)
    /// </summary>
    public required uint QuestMethod { get; set; }
    public required uint QuestLevel { get; set; }
    public required uint ZoneOrSort { get; set; }
    public required uint QuestType { get; set; }
    /// <summary>
    /// cmangos: shown in quest log as part of quest objective
    /// </summary>
    public required Faction ReputationObjectiveFaction { get; set; }
    /// <summary>
    /// cmangos: shown in quest log as part of quest objective
    /// </summary>
    public required uint ReputationObjectiveValue { get; set; }
    /// <summary>
    /// cmangos: RequiredOpositeRepFaction, required faction value with another (oposite) faction (objective). cmangos sets to 0
    /// </summary>
    public required Faction RequiredOppositeFaction { get; set; }
    /// <summary>
    /// cmangos: RequiredOpositeRepValue, required faction value with another (oposite) faction (objective). cmangos sets to 0
    /// </summary>
    public required uint RequiredOppositeReputationValue { get; set; }
    public required uint NextQuestInChain { get; set; }
    public required uint MoneyReward { get; set; }
    /// <summary>
    /// cmangos: used in XP calculation at client
    /// </summary>
    public required uint MaxLevelMoneyReward { get; set; }
    /// <summary>
    /// cmangos: reward spell, this spell will display (icon) (casted if RewSpellCast==0)
    /// </summary>
    public required uint RewardSpell { get; set; }
    public required uint SourceItemId { get; set; }
    public required uint QuestFlags { get; set; }
    public required List<QuestItemReward> Rewards { get; set; }
    public required List<QuestItemReward> ChoiceRewards { get; set; }
    public required uint PointMapId { get; set; }
    public required Vector2d Position { get; set; }
    public required uint PointOpt { get; set; }
    public required string Title { get; set; }
    public required string ObjectiveText { get; set; }
    public required string Details { get; set; }
    public required string EndText { get; set; }
    public required List<QuestObjective> Objectives { get; set; }
    public required List<string> ObjectiveTexts { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestMethod, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ZoneOrSort, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestType, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)ReputationObjectiveFaction, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ReputationObjectiveValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)RequiredOppositeFaction, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RequiredOppositeReputationValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(NextQuestInChain, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxLevelMoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SourceItemId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestFlags, cancellationToken).ConfigureAwait(false);

        foreach (var v in Rewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ChoiceRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(PointMapId, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PointOpt, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(ObjectiveText, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Details, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(EndText, cancellationToken).ConfigureAwait(false);

        foreach (var v in Objectives) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ObjectiveTexts) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 93, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 93, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUEST_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questMethod = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var zoneOrSort = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var reputationObjectiveFaction = (Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var reputationObjectiveValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var requiredOppositeFaction = (Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var requiredOppositeReputationValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var nextQuestInChain = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maxLevelMoneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var sourceItemId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewards = new List<QuestItemReward>();
        for (var i = 0; i < 4; ++i) {
            rewards.Add(await Vanilla.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var choiceRewards = new List<QuestItemReward>();
        for (var i = 0; i < 6; ++i) {
            choiceRewards.Add(await Vanilla.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var pointMapId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector2d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var pointOpt = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectiveText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var details = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var endText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectives = new List<QuestObjective>();
        for (var i = 0; i < 4; ++i) {
            objectives.Add(await Vanilla.QuestObjective.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var objectiveTexts = new List<string>();
        for (var i = 0; i < 4; ++i) {
            objectiveTexts.Add(await r.ReadCString(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUEST_QUERY_RESPONSE {
            QuestId = questId,
            QuestMethod = questMethod,
            QuestLevel = questLevel,
            ZoneOrSort = zoneOrSort,
            QuestType = questType,
            ReputationObjectiveFaction = reputationObjectiveFaction,
            ReputationObjectiveValue = reputationObjectiveValue,
            RequiredOppositeFaction = requiredOppositeFaction,
            RequiredOppositeReputationValue = requiredOppositeReputationValue,
            NextQuestInChain = nextQuestInChain,
            MoneyReward = moneyReward,
            MaxLevelMoneyReward = maxLevelMoneyReward,
            RewardSpell = rewardSpell,
            SourceItemId = sourceItemId,
            QuestFlags = questFlags,
            Rewards = rewards,
            ChoiceRewards = choiceRewards,
            PointMapId = pointMapId,
            Position = position,
            PointOpt = pointOpt,
            Title = title,
            ObjectiveText = objectiveText,
            Details = details,
            EndText = endText,
            Objectives = objectives,
            ObjectiveTexts = objectiveTexts,
        };
    }

    internal int Size() {
        var size = 0;

        // quest_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // quest_method: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // quest_level: WowMessages.Generator.Generated.DataTypeLevel32
        size += 4;

        // zone_or_sort: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // quest_type: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // reputation_objective_faction: WowMessages.Generator.Generated.DataTypeEnum
        size += 2;

        // reputation_objective_value: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // required_opposite_faction: WowMessages.Generator.Generated.DataTypeEnum
        size += 2;

        // required_opposite_reputation_value: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // next_quest_in_chain: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // money_reward: WowMessages.Generator.Generated.DataTypeGold
        size += 4;

        // max_level_money_reward: WowMessages.Generator.Generated.DataTypeGold
        size += 4;

        // reward_spell: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // source_item_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // quest_flags: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // rewards: WowMessages.Generator.Generated.DataTypeArray
        size += Rewards.Sum(e => 8);

        // choice_rewards: WowMessages.Generator.Generated.DataTypeArray
        size += ChoiceRewards.Sum(e => 8);

        // point_map_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // position: WowMessages.Generator.Generated.DataTypeStruct
        size += 8;

        // point_opt: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // title: WowMessages.Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // objective_text: WowMessages.Generator.Generated.DataTypeCstring
        size += ObjectiveText.Length + 1;

        // details: WowMessages.Generator.Generated.DataTypeCstring
        size += Details.Length + 1;

        // end_text: WowMessages.Generator.Generated.DataTypeCstring
        size += EndText.Length + 1;

        // objectives: WowMessages.Generator.Generated.DataTypeArray
        size += Objectives.Sum(e => 16);

        // objective_texts: WowMessages.Generator.Generated.DataTypeArray
        size += ObjectiveTexts.Sum(e => e.Length);

        return size;
    }

}

