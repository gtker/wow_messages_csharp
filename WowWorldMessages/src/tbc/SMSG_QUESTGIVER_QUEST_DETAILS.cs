using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUESTGIVER_QUEST_DETAILS: TbcServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required uint QuestId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public required string Objectives { get; set; }
    public required bool AutoFinish { get; set; }
    public required uint SuggestedPlayers { get; set; }
    public required List<QuestItemReward> ChoiceItemRewards { get; set; }
    public required List<QuestItemReward> ItemRewards { get; set; }
    public required uint MoneyReward { get; set; }
    public required uint HonorReward { get; set; }
    /// <summary>
    /// mangosone: reward spell, this spell will display (icon) (casted if RewSpellCast==0)
    /// </summary>
    public required uint RewardSpell { get; set; }
    public required uint CastedSpell { get; set; }
    /// <summary>
    /// mangosone: CharTitle, new 2.4.0, player gets this title (bit index from CharTitles)
    /// </summary>
    public required uint TitleReward { get; set; }
    public required List<QuestDetailsEmote> Emotes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Details, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Objectives, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(AutoFinish, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SuggestedPlayers, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)ChoiceItemRewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in ChoiceItemRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)ItemRewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in ItemRewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(MoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RewardSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(CastedSpell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TitleReward, cancellationToken).ConfigureAwait(false);

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
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 392, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUESTGIVER_QUEST_DETAILS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var details = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var objectives = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var autoFinish = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        var suggestedPlayers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfChoiceItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var choiceItemRewards = new List<QuestItemReward>();
        for (var i = 0; i < amountOfChoiceItemRewards; ++i) {
            choiceItemRewards.Add(await Tbc.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfItemRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRewards = new List<QuestItemReward>();
        for (var i = 0; i < amountOfItemRewards; ++i) {
            itemRewards.Add(await Tbc.QuestItemReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var castedSpell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var titleReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEmotes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emotes = new List<QuestDetailsEmote>();
        for (var i = 0; i < amountOfEmotes; ++i) {
            emotes.Add(await Tbc.QuestDetailsEmote.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUESTGIVER_QUEST_DETAILS {
            Guid = guid,
            QuestId = questId,
            Title = title,
            Details = details,
            Objectives = objectives,
            AutoFinish = autoFinish,
            SuggestedPlayers = suggestedPlayers,
            ChoiceItemRewards = choiceItemRewards,
            ItemRewards = itemRewards,
            MoneyReward = moneyReward,
            HonorReward = honorReward,
            RewardSpell = rewardSpell,
            CastedSpell = castedSpell,
            TitleReward = titleReward,
            Emotes = emotes,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
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
        size += 4;

        // suggested_players: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_choice_item_rewards: Generator.Generated.DataTypeInteger
        size += 4;

        // choice_item_rewards: Generator.Generated.DataTypeArray
        size += ChoiceItemRewards.Sum(e => 8);

        // amount_of_item_rewards: Generator.Generated.DataTypeInteger
        size += 4;

        // item_rewards: Generator.Generated.DataTypeArray
        size += ItemRewards.Sum(e => 8);

        // money_reward: Generator.Generated.DataTypeGold
        size += 4;

        // honor_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // casted_spell: Generator.Generated.DataTypeSpell
        size += 4;

        // title_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_emotes: Generator.Generated.DataTypeInteger
        size += 4;

        // emotes: Generator.Generated.DataTypeArray
        size += Emotes.Sum(e => 8);

        return size;
    }

}

