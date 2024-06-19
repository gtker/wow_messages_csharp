using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_PLAYER_REWARD: WrathServerMessage, IWorldMessage {
    public required uint RandomDungeonEntry { get; set; }
    public required uint DungeonFinishedEntry { get; set; }
    public required bool Done { get; set; }
    /// <summary>
    /// emus set to 1.
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint MoneyReward { get; set; }
    public required uint ExperienceReward { get; set; }
    /// <summary>
    /// emus set to 0.
    /// </summary>
    public required uint Unknown2 { get; set; }
    /// <summary>
    /// emus set to 0.
    /// </summary>
    public required uint Unknown3 { get; set; }
    public required List<QuestGiverReward> Rewards { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RandomDungeonEntry, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonFinishedEntry, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Done, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ExperienceReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown3, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Rewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Rewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_PLAYER_REWARD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var randomDungeonEntry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonFinishedEntry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var done = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var moneyReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var experienceReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRewards = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rewards = new List<QuestGiverReward>();
        for (var i = 0; i < amountOfRewards; ++i) {
            rewards.Add(await Wrath.QuestGiverReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_LFG_PLAYER_REWARD {
            RandomDungeonEntry = randomDungeonEntry,
            DungeonFinishedEntry = dungeonFinishedEntry,
            Done = done,
            Unknown1 = unknown1,
            MoneyReward = moneyReward,
            ExperienceReward = experienceReward,
            Unknown2 = unknown2,
            Unknown3 = unknown3,
            Rewards = rewards,
        };
    }

    internal int Size() {
        var size = 0;

        // random_dungeon_entry: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeon_finished_entry: Generator.Generated.DataTypeInteger
        size += 4;

        // done: Generator.Generated.DataTypeBool
        size += 1;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // money_reward: Generator.Generated.DataTypeGold
        size += 4;

        // experience_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown3: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_rewards: Generator.Generated.DataTypeInteger
        size += 1;

        // rewards: Generator.Generated.DataTypeArray
        size += Rewards.Sum(e => 12);

        return size;
    }

}

