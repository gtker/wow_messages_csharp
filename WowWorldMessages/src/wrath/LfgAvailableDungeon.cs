using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgAvailableDungeon {
    public required uint DungeonEntry { get; set; }
    public required bool Done { get; set; }
    public required uint QuestReward { get; set; }
    public required uint XpReward { get; set; }
    public required uint Unknown1 { get; set; }
    public required uint Unknown2 { get; set; }
    public required List<LfgQuestReward> Rewards { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DungeonEntry, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Done, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(XpReward, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Rewards.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Rewards) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<LfgAvailableDungeon> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var dungeonEntry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var done = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var questReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var xpReward = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRewards = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var rewards = new List<LfgQuestReward>();
        for (var i = 0; i < amountOfRewards; ++i) {
            rewards.Add(await Wrath.LfgQuestReward.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new LfgAvailableDungeon {
            DungeonEntry = dungeonEntry,
            Done = done,
            QuestReward = questReward,
            XpReward = xpReward,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Rewards = rewards,
        };
    }

    internal int Size() {
        var size = 0;

        // dungeon_entry: Generator.Generated.DataTypeInteger
        size += 4;

        // done: Generator.Generated.DataTypeBool
        size += 1;

        // quest_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // xp_reward: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_rewards: Generator.Generated.DataTypeInteger
        size += 1;

        // rewards: Generator.Generated.DataTypeArray
        size += Rewards.Sum(e => 12);

        return size;
    }

}

