using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using RandomBgType = OneOf.OneOf<SMSG_BATTLEFIELD_LIST.RandomBgRandom, RandomBg>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_LIST: WrathServerMessage, IWorldMessage {
    public class RandomBgRandom {
        public required uint HonorLost { get; set; }
        public required uint RewardArena { get; set; }
        public required uint RewardHonor { get; set; }
        public required byte WinRandom { get; set; }
    }
    public required ulong Battlemaster { get; set; }
    public required Wrath.BattlegroundType BattlegroundType { get; set; }
    public required byte Unknown1 { get; set; }
    public required byte Unknown2 { get; set; }
    public required byte HasWin { get; set; }
    public required uint WinHonor { get; set; }
    public required uint WinArena { get; set; }
    public required uint LossHonor { get; set; }
    public required RandomBgType Random { get; set; }
    internal RandomBg RandomValue => Random.Match(
        _ => Wrath.RandomBg.Random,
        v => v
    );
    public required List<uint> Battlegrounds { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Battlemaster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)BattlegroundType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HasWin, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(WinHonor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(WinArena, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LossHonor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)RandomValue, cancellationToken).ConfigureAwait(false);

        if (Random.Value is SMSG_BATTLEFIELD_LIST.RandomBgRandom randomBgRandom) {
            await w.WriteByte(randomBgRandom.WinRandom, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(randomBgRandom.RewardHonor, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(randomBgRandom.RewardArena, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(randomBgRandom.HonorLost, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteUInt((uint)Battlegrounds.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Battlegrounds) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 573, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 573, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battlemaster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var battlegroundType = (Wrath.BattlegroundType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hasWin = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var winHonor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var winArena = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var lossHonor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        RandomBgType random = (Wrath.RandomBg)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (random.Value is Wrath.RandomBg.Random) {
            var winRandom = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var rewardHonor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var rewardArena = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var honorLost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            random = new RandomBgRandom {
                HonorLost = honorLost,
                RewardArena = rewardArena,
                RewardHonor = rewardHonor,
                WinRandom = winRandom,
            };
        }

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfBattlegrounds = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var battlegrounds = new List<uint>();
        for (var i = 0; i < numberOfBattlegrounds; ++i) {
            battlegrounds.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_BATTLEFIELD_LIST {
            Battlemaster = battlemaster,
            BattlegroundType = battlegroundType,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            HasWin = hasWin,
            WinHonor = winHonor,
            WinArena = winArena,
            LossHonor = lossHonor,
            Random = random,
            Battlegrounds = battlegrounds,
        };
    }

    internal int Size() {
        var size = 0;

        // battlemaster: Generator.Generated.DataTypeGuid
        size += 8;

        // battleground_type: Generator.Generated.DataTypeEnum
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 1;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 1;

        // has_win: Generator.Generated.DataTypeInteger
        size += 1;

        // win_honor: Generator.Generated.DataTypeInteger
        size += 4;

        // win_arena: Generator.Generated.DataTypeInteger
        size += 4;

        // loss_honor: Generator.Generated.DataTypeInteger
        size += 4;

        // random: Generator.Generated.DataTypeEnum
        size += 1;

        if (Random.Value is SMSG_BATTLEFIELD_LIST.RandomBgRandom randomBgRandom) {
            // win_random: Generator.Generated.DataTypeInteger
            size += 1;

            // reward_honor: Generator.Generated.DataTypeInteger
            size += 4;

            // reward_arena: Generator.Generated.DataTypeInteger
            size += 4;

            // honor_lost: Generator.Generated.DataTypeInteger
            size += 4;

        }

        // number_of_battlegrounds: Generator.Generated.DataTypeInteger
        size += 4;

        // battlegrounds: Generator.Generated.DataTypeArray
        size += Battlegrounds.Sum(e => 4);

        return size;
    }

}

