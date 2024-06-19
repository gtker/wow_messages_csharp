using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUESTGIVER_QUEST_DETAILS: WrathServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    /// <summary>
    /// arcemu also sends guid2 if guid is a player. Otherwise sends 0.
    /// </summary>
    public required ulong Guid2 { get; set; }
    public required uint QuestId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public required string Objectives { get; set; }
    public required bool AutoFinish { get; set; }
    public required uint QuestFlags { get; set; }
    public required uint SuggestedPlayers { get; set; }
    /// <summary>
    /// arcemu: MANGOS: IsFinished? value is sent back to server in quest accept packet
    /// </summary>
    public required byte IsFinished { get; set; }
    public required List<QuestGiverReward> ChoiceItemRewards { get; set; }
    public required List<QuestGiverReward> ItemRewards { get; set; }
    public required uint MoneyReward { get; set; }
    /// <summary>
    /// arcemu: New 3.3 - this is the XP you'll see on the quest reward panel too, but I think it is fine not to show it, because it can change if the player levels up before completing the quest.
    /// </summary>
    public required uint ExperienceReward { get; set; }
    public required uint HonorReward { get; set; }
    /// <summary>
    /// arcemu: new 3.3
    /// </summary>
    public required float HonorRewardMultiplier { get; set; }
    /// <summary>
    /// mangosone: reward spell, this spell will display (icon) (casted if RewSpellCast==0)
    /// </summary>
    public required uint RewardSpell { get; set; }
    public required uint CastedSpell { get; set; }
    /// <summary>
    /// mangosone: CharTitle, new 2.4.0, player gets this title (bit index from CharTitles)
    /// </summary>
    public required uint TitleReward { get; set; }
    public required uint TalentReward { get; set; }
    public required uint ArenaPointReward { get; set; }
    /// <summary>
    /// arcemu: new 3.3.0
    /// </summary>
    public required uint Unknown2 { get; set; }
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
    public required List<QuestDetailsEmote> Emotes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Guid2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Details, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Objectives, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(AutoFinish, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SuggestedPlayers, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(IsFinished, cancellationToken).ConfigureAwait(false);

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

        await w.WriteUInt(RewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(CastedSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TitleReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TalentReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ArenaPointReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        foreach (var v in RewardFactions) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in RewardReputations) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in RewardReputationsOverride) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)Emotes.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Emotes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 392, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 392, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUESTGIVER_QUEST_DETAILS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var guid2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var details = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectives = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var autoFinish = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var questFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var suggestedPlayers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var isFinished = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfChoiceItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var choiceItemRewards = new List<QuestGiverReward>();
        for (var i = 0; i < amountOfChoiceItemRewards; ++i) {
            choiceItemRewards.Add(await Wrath.QuestGiverReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRewards = new List<QuestGiverReward>();
        for (var i = 0; i < amountOfItemRewards; ++i) {
            itemRewards.Add(await Wrath.QuestGiverReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var experienceReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorRewardMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var rewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var castedSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var titleReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var talentReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaPointReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

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

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEmotes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emotes = new List<QuestDetailsEmote>();
        for (var i = 0; i < amountOfEmotes; ++i) {
            emotes.Add(await Wrath.QuestDetailsEmote.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUESTGIVER_QUEST_DETAILS {
            Guid = guid,
            Guid2 = guid2,
            QuestId = questId,
            Title = title,
            Details = details,
            Objectives = objectives,
            AutoFinish = autoFinish,
            QuestFlags = questFlags,
            SuggestedPlayers = suggestedPlayers,
            IsFinished = isFinished,
            ChoiceItemRewards = choiceItemRewards,
            ItemRewards = itemRewards,
            MoneyReward = moneyReward,
            ExperienceReward = experienceReward,
            HonorReward = honorReward,
            HonorRewardMultiplier = honorRewardMultiplier,
            RewardSpell = rewardSpell,
            CastedSpell = castedSpell,
            TitleReward = titleReward,
            TalentReward = talentReward,
            ArenaPointReward = arenaPointReward,
            Unknown2 = unknown2,
            RewardFactions = rewardFactions,
            RewardReputations = rewardReputations,
            RewardReputationsOverride = rewardReputationsOverride,
            Emotes = emotes,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // guid2: Generator.Generated.DataTypeGuid
        size += 8;

        // quest_id: Generator.Generated.DataTypeInteger
        size += 4;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        // details: Generator.Generated.DataTypeCstring
        size += Details.Length + 1;

        // objectives: Generator.Generated.DataTypeCstring
        size += Objectives.Length + 1;

        // auto_finish: Generator.Generated.DataTypeBool
        size += 1;

        // quest_flags: Generator.Generated.DataTypeInteger
        size += 4;

        // suggested_players: Generator.Generated.DataTypeInteger
        size += 4;

        // is_finished: Generator.Generated.DataTypeInteger
        size += 1;

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

        // reward_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // casted_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // title_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // talent_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // arena_point_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_factions: Generator.Generated.DataTypeArray
        size += RewardFactions.Sum(e => 4);

        // reward_reputations: Generator.Generated.DataTypeArray
        size += RewardReputations.Sum(e => 4);

        // reward_reputations_override: Generator.Generated.DataTypeArray
        size += RewardReputationsOverride.Sum(e => 4);

        // amount_of_emotes: Generator.Generated.DataTypeInteger
        size += 4;

        // emotes: Generator.Generated.DataTypeArray
        size += Emotes.Sum(e => 8);

        return size;
    }

}

