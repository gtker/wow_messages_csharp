using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUESTGIVER_OFFER_REWARD: WrathServerMessage, IWorldMessage {
    public required ulong Npc { get; set; }
    public required uint QuestId { get; set; }
    public required string Title { get; set; }
    public required string OfferRewardText { get; set; }
    public required bool AutoFinish { get; set; }
    public required uint Flags1 { get; set; }
    public required uint SuggestedPlayers { get; set; }
    public required List<NpcTextUpdateEmote> Emotes { get; set; }
    public required List<QuestItemRequirement> ChoiceItemRewards { get; set; }
    public required List<QuestItemRequirement> ItemRewards { get; set; }
    public required uint MoneyReward { get; set; }
    public required uint ExperienceReward { get; set; }
    public required uint HonorReward { get; set; }
    public required float HonorRewardMultiplier { get; set; }
    /// <summary>
    /// mangostwo: unused by client?
    /// mangostwo sets to 0x08.
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint RewardSpell { get; set; }
    /// <summary>
    /// mangoszero and cmangos disagree about which field is _cast, although they both agree that the _cast field should not be in zero (vanilla). They still both include both fields in the code though.
    /// </summary>
    public required uint RewardSpellCast { get; set; }
    public required uint TitleReward { get; set; }
    public required uint RewardTalents { get; set; }
    public required uint RewardArenaPoints { get; set; }
    public required uint RewardReputationMask { get; set; }
    public const int RewardFactionsLength = 5;
    public required uint[] RewardFactions { get; set; }
    /// <summary>
    /// mangostwo: columnid in QuestFactionReward.dbc (if negative, from second row)
    /// </summary>
    public const int RewardReputationsLength = 5;
    public required uint[] RewardReputations { get; set; }
    /// <summary>
    /// mangostwo: reward reputation override. No diplomacy bonus is expected given, reward also does not display in chat window
    /// </summary>
    public const int RewardReputationsOverrideLength = 5;
    public required uint[] RewardReputationsOverride { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Npc, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(OfferRewardText, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(AutoFinish, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SuggestedPlayers, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Emotes.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Emotes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)ChoiceItemRewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in ChoiceItemRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)ItemRewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in ItemRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(MoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ExperienceReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorReward, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(HonorRewardMultiplier, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardSpellCast, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TitleReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardTalents, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardArenaPoints, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardReputationMask, cancellationToken).ConfigureAwait(false);

        foreach (var v in RewardFactions) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in RewardReputations) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in RewardReputationsOverride) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 397, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 397, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUESTGIVER_OFFER_REWARD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var npc = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var offerRewardText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var autoFinish = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        var flags1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var suggestedPlayers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEmotes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emotes = new List<NpcTextUpdateEmote>();
        for (var i = 0; i < amountOfEmotes; ++i) {
            emotes.Add(await Wrath.NpcTextUpdateEmote.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfChoiceItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var choiceItemRewards = new List<QuestItemRequirement>();
        for (var i = 0; i < amountOfChoiceItemRewards; ++i) {
            choiceItemRewards.Add(await Wrath.QuestItemRequirement.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRewards = new List<QuestItemRequirement>();
        for (var i = 0; i < amountOfItemRewards; ++i) {
            itemRewards.Add(await Wrath.QuestItemRequirement.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var experienceReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorRewardMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardSpellCast = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var titleReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardTalents = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardArenaPoints = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardReputationMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardFactions = new uint[RewardFactionsLength];
        for (var i = 0; i < RewardFactionsLength; ++i) {
            rewardFactions[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var rewardReputations = new uint[RewardReputationsLength];
        for (var i = 0; i < RewardReputationsLength; ++i) {
            rewardReputations[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var rewardReputationsOverride = new uint[RewardReputationsOverrideLength];
        for (var i = 0; i < RewardReputationsOverrideLength; ++i) {
            rewardReputationsOverride[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_QUESTGIVER_OFFER_REWARD {
            Npc = npc,
            QuestId = questId,
            Title = title,
            OfferRewardText = offerRewardText,
            AutoFinish = autoFinish,
            Flags1 = flags1,
            SuggestedPlayers = suggestedPlayers,
            Emotes = emotes,
            ChoiceItemRewards = choiceItemRewards,
            ItemRewards = itemRewards,
            MoneyReward = moneyReward,
            ExperienceReward = experienceReward,
            HonorReward = honorReward,
            HonorRewardMultiplier = honorRewardMultiplier,
            Unknown1 = unknown1,
            RewardSpell = rewardSpell,
            RewardSpellCast = rewardSpellCast,
            TitleReward = titleReward,
            RewardTalents = rewardTalents,
            RewardArenaPoints = rewardArenaPoints,
            RewardReputationMask = rewardReputationMask,
            RewardFactions = rewardFactions,
            RewardReputations = rewardReputations,
            RewardReputationsOverride = rewardReputationsOverride,
        };
    }

    internal int Size() {
        var size = 0;

        // npc: Generator.Generated.DataTypeGuid
        size += 8;

        // quest_id: Generator.Generated.DataTypeInteger
        size += 4;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // offer_reward_text: Generator.Generated.DataTypeCstring
        size += OfferRewardText.Length + 1;

        // auto_finish: Generator.Generated.DataTypeBool
        size += 4;

        // flags1: Generator.Generated.DataTypeInteger
        size += 4;

        // suggested_players: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_emotes: Generator.Generated.DataTypeInteger
        size += 4;

        // emotes: Generator.Generated.DataTypeArray
        size += Emotes.Sum(e => 8);

        // amount_of_choice_item_rewards: Generator.Generated.DataTypeInteger
        size += 4;

        // choice_item_rewards: Generator.Generated.DataTypeArray
        size += ChoiceItemRewards.Sum(e => 12);

        // amount_of_item_rewards: Generator.Generated.DataTypeInteger
        size += 4;

        // item_rewards: Generator.Generated.DataTypeArray
        size += ItemRewards.Sum(e => 12);

        // money_reward: Generator.Generated.DataTypeGold
        size += 4;

        // experience_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // honor_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // honor_reward_multiplier: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // reward_spell_cast: Generator.Generated.DataTypeSpell
        size += 4;

        // title_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_talents: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_arena_points: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_reputation_mask: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_factions: Generator.Generated.DataTypeArray
        size += RewardFactions.Sum(e => 4);

        // reward_reputations: Generator.Generated.DataTypeArray
        size += RewardReputations.Sum(e => 4);

        // reward_reputations_override: Generator.Generated.DataTypeArray
        size += RewardReputationsOverride.Sum(e => 4);

        return size;
    }

}

