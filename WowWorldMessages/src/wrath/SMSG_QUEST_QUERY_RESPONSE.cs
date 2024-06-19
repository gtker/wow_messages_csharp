using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUEST_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public required uint QuestId { get; set; }
    /// <summary>
    /// Accepted values: 0, 1 or 2. 0==IsAutoComplete() (skip objectives/details)
    /// </summary>
    public required uint QuestMethod { get; set; }
    public required uint QuestLevel { get; set; }
    /// <summary>
    /// min required level to obtain (added for 3.3).
    /// Assumed allowed (database) range is -1 to 255 (still using uint32, since negative value would not be of any known use for client)
    /// </summary>
    public required uint MinimumQuestLevel { get; set; }
    public required uint ZoneOrSort { get; set; }
    public required uint QuestType { get; set; }
    public required uint SuggestPlayerAmount { get; set; }
    /// <summary>
    /// cmangos: shown in quest log as part of quest objective
    /// </summary>
    public required Wrath.Faction ReputationObjectiveFaction { get; set; }
    /// <summary>
    /// cmangos: shown in quest log as part of quest objective
    /// </summary>
    public required uint ReputationObjectiveValue { get; set; }
    /// <summary>
    /// cmangos: RequiredOpositeRepFaction, required faction value with another (oposite) faction (objective). cmangos sets to 0
    /// </summary>
    public required Wrath.Faction RequiredOppositeFaction { get; set; }
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
    /// <summary>
    /// mangosone: casted spell
    /// </summary>
    public required uint CastedRewardSpell { get; set; }
    public required uint HonorReward { get; set; }
    /// <summary>
    /// new reward honor (multiplied by around 62 at client side)
    /// </summary>
    public required float HonorRewardMultiplier { get; set; }
    public required uint SourceItemId { get; set; }
    public required uint QuestFlags { get; set; }
    /// <summary>
    /// CharTitleId, new 2.4.0, player gets this title (id from CharTitles)
    /// </summary>
    public required uint TitleReward { get; set; }
    public required uint PlayersSlain { get; set; }
    public required uint BonusTalents { get; set; }
    public required uint BonusArenaPoints { get; set; }
    public required uint Unknown1 { get; set; }
    public const int RewardsLength = 4;
    public required QuestItemReward[] Rewards { get; set; }
    public const int ChoiceRewardsLength = 6;
    public required QuestItemReward[] ChoiceRewards { get; set; }
    public const int ReputationRewardsLength = 5;
    public required uint[] ReputationRewards { get; set; }
    public const int ReputationRewardAmountsLength = 5;
    public required uint[] ReputationRewardAmounts { get; set; }
    public const int ReputationRewardOverridesLength = 5;
    public required uint[] ReputationRewardOverrides { get; set; }
    public required uint PointMapId { get; set; }
    public required Vector2d Position { get; set; }
    public required uint PointOpt { get; set; }
    public required string Title { get; set; }
    public required string ObjectiveText { get; set; }
    public required string Details { get; set; }
    public required string EndText { get; set; }
    public required string CompletedText { get; set; }
    public const int ObjectivesLength = 4;
    public required QuestObjective[] Objectives { get; set; }
    public const int ItemRequirementsLength = 6;
    public required QuestItemRequirement[] ItemRequirements { get; set; }
    public const int ObjectiveTextsLength = 4;
    public required string[] ObjectiveTexts { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestMethod, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MinimumQuestLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ZoneOrSort, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SuggestPlayerAmount, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)ReputationObjectiveFaction, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ReputationObjectiveValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)RequiredOppositeFaction, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RequiredOppositeReputationValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(NextQuestInChain, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxLevelMoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(CastedRewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorReward, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(HonorRewardMultiplier, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SourceItemId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TitleReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PlayersSlain, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BonusTalents, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BonusArenaPoints, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        foreach (var v in Rewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ChoiceRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ReputationRewards) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ReputationRewardAmounts) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ReputationRewardOverrides) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(PointMapId, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PointOpt, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(ObjectiveText, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Details, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(EndText, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(CompletedText, cancellationToken).ConfigureAwait(false);

        foreach (var v in Objectives) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ItemRequirements) {
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
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 93, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUEST_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questMethod = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var minimumQuestLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var zoneOrSort = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var suggestPlayerAmount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var reputationObjectiveFaction = (Wrath.Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var reputationObjectiveValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var requiredOppositeFaction = (Wrath.Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var requiredOppositeReputationValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var nextQuestInChain = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maxLevelMoneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var castedRewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorRewardMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var sourceItemId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var titleReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var playersSlain = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bonusTalents = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bonusArenaPoints = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewards = new QuestItemReward[RewardsLength];
        for (var i = 0; i < RewardsLength; ++i) {
            rewards[i] = await Wrath.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var choiceRewards = new QuestItemReward[ChoiceRewardsLength];
        for (var i = 0; i < ChoiceRewardsLength; ++i) {
            choiceRewards[i] = await Wrath.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var reputationRewards = new uint[ReputationRewardsLength];
        for (var i = 0; i < ReputationRewardsLength; ++i) {
            reputationRewards[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var reputationRewardAmounts = new uint[ReputationRewardAmountsLength];
        for (var i = 0; i < ReputationRewardAmountsLength; ++i) {
            reputationRewardAmounts[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var reputationRewardOverrides = new uint[ReputationRewardOverridesLength];
        for (var i = 0; i < ReputationRewardOverridesLength; ++i) {
            reputationRewardOverrides[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var pointMapId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector2d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var pointOpt = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectiveText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var details = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var endText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var completedText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectives = new QuestObjective[ObjectivesLength];
        for (var i = 0; i < ObjectivesLength; ++i) {
            objectives[i] = await Wrath.QuestObjective.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var itemRequirements = new QuestItemRequirement[ItemRequirementsLength];
        for (var i = 0; i < ItemRequirementsLength; ++i) {
            itemRequirements[i] = await Wrath.QuestItemRequirement.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        var objectiveTexts = new string[ObjectiveTextsLength];
        for (var i = 0; i < ObjectiveTextsLength; ++i) {
            objectiveTexts[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_QUEST_QUERY_RESPONSE {
            QuestId = questId,
            QuestMethod = questMethod,
            QuestLevel = questLevel,
            MinimumQuestLevel = minimumQuestLevel,
            ZoneOrSort = zoneOrSort,
            QuestType = questType,
            SuggestPlayerAmount = suggestPlayerAmount,
            ReputationObjectiveFaction = reputationObjectiveFaction,
            ReputationObjectiveValue = reputationObjectiveValue,
            RequiredOppositeFaction = requiredOppositeFaction,
            RequiredOppositeReputationValue = requiredOppositeReputationValue,
            NextQuestInChain = nextQuestInChain,
            MoneyReward = moneyReward,
            MaxLevelMoneyReward = maxLevelMoneyReward,
            RewardSpell = rewardSpell,
            CastedRewardSpell = castedRewardSpell,
            HonorReward = honorReward,
            HonorRewardMultiplier = honorRewardMultiplier,
            SourceItemId = sourceItemId,
            QuestFlags = questFlags,
            TitleReward = titleReward,
            PlayersSlain = playersSlain,
            BonusTalents = bonusTalents,
            BonusArenaPoints = bonusArenaPoints,
            Unknown1 = unknown1,
            Rewards = rewards,
            ChoiceRewards = choiceRewards,
            ReputationRewards = reputationRewards,
            ReputationRewardAmounts = reputationRewardAmounts,
            ReputationRewardOverrides = reputationRewardOverrides,
            PointMapId = pointMapId,
            Position = position,
            PointOpt = pointOpt,
            Title = title,
            ObjectiveText = objectiveText,
            Details = details,
            EndText = endText,
            CompletedText = completedText,
            Objectives = objectives,
            ItemRequirements = itemRequirements,
            ObjectiveTexts = objectiveTexts,
        };
    }

    internal int Size() {
        var size = 0;

        // quest_id: Generator.Generated.DataTypeInteger
        size += 4;

        // quest_method: Generator.Generated.DataTypeInteger
        size += 4;

        // quest_level: Generator.Generated.DataTypeLevel32
        size += 4;

        // minimum_quest_level: Generator.Generated.DataTypeLevel32
        size += 4;

        // zone_or_sort: Generator.Generated.DataTypeInteger
        size += 4;

        // quest_type: Generator.Generated.DataTypeInteger
        size += 4;

        // suggest_player_amount: Generator.Generated.DataTypeInteger
        size += 4;

        // reputation_objective_faction: Generator.Generated.DataTypeEnum
        size += 2;

        // reputation_objective_value: Generator.Generated.DataTypeInteger
        size += 4;

        // required_opposite_faction: Generator.Generated.DataTypeEnum
        size += 2;

        // required_opposite_reputation_value: Generator.Generated.DataTypeInteger
        size += 4;

        // next_quest_in_chain: Generator.Generated.DataTypeInteger
        size += 4;

        // money_reward: Generator.Generated.DataTypeGold
        size += 4;

        // max_level_money_reward: Generator.Generated.DataTypeGold
        size += 4;

        // reward_spell: Generator.Generated.DataTypeInteger
        size += 4;

        // casted_reward_spell: Generator.Generated.DataTypeInteger
        size += 4;

        // honor_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // honor_reward_multiplier: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // source_item_id: Generator.Generated.DataTypeInteger
        size += 4;

        // quest_flags: Generator.Generated.DataTypeInteger
        size += 4;

        // title_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // players_slain: Generator.Generated.DataTypeInteger
        size += 4;

        // bonus_talents: Generator.Generated.DataTypeInteger
        size += 4;

        // bonus_arena_points: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // rewards: Generator.Generated.DataTypeArray
        size += Rewards.Sum(e => 8);

        // choice_rewards: Generator.Generated.DataTypeArray
        size += ChoiceRewards.Sum(e => 8);

        // reputation_rewards: Generator.Generated.DataTypeArray
        size += ReputationRewards.Sum(e => 4);

        // reputation_reward_amounts: Generator.Generated.DataTypeArray
        size += ReputationRewardAmounts.Sum(e => 4);

        // reputation_reward_overrides: Generator.Generated.DataTypeArray
        size += ReputationRewardOverrides.Sum(e => 4);

        // point_map_id: Generator.Generated.DataTypeInteger
        size += 4;

        // position: Generator.Generated.DataTypeStruct
        size += 8;

        // point_opt: Generator.Generated.DataTypeInteger
        size += 4;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // objective_text: Generator.Generated.DataTypeCstring
        size += ObjectiveText.Length + 1;

        // details: Generator.Generated.DataTypeCstring
        size += Details.Length + 1;

        // end_text: Generator.Generated.DataTypeCstring
        size += EndText.Length + 1;

        // completed_text: Generator.Generated.DataTypeCstring
        size += CompletedText.Length + 1;

        // objectives: Generator.Generated.DataTypeArray
        size += Objectives.Sum(e => 16);

        // item_requirements: Generator.Generated.DataTypeArray
        size += ItemRequirements.Sum(e => 12);

        // objective_texts: Generator.Generated.DataTypeArray
        size += ObjectiveTexts.Sum(e => e.Length + 1);

        return size;
    }

}

