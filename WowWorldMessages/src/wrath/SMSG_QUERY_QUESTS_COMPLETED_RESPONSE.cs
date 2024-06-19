using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUERY_QUESTS_COMPLETED_RESPONSE: WrathServerMessage, IWorldMessage {
    public required List<uint> RewardQuests { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)RewardQuests.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in RewardQuests) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1281, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1281, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUERY_QUESTS_COMPLETED_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRewardQuests = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rewardQuests = new List<uint>();
        for (var i = 0; i < amountOfRewardQuests; ++i) {
            rewardQuests.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUERY_QUESTS_COMPLETED_RESPONSE {
            RewardQuests = rewardQuests,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_reward_quests: Generator.Generated.DataTypeInteger
        size += 4;

        // reward_quests: Generator.Generated.DataTypeArray
        size += RewardQuests.Sum(e => 4);

        return size;
    }

}

