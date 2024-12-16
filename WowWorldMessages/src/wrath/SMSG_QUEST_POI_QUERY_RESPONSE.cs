using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUEST_POI_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public required List<QuestPoiList> Quests { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Quests.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Quests) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 484, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 484, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUEST_POI_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfQuests = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var quests = new List<QuestPoiList>();
        for (var i = 0; i < amountOfQuests; ++i) {
            quests.Add(await Wrath.QuestPoiList.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUEST_POI_QUERY_RESPONSE {
            Quests = quests,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_quests: Generator.Generated.DataTypeInteger
        size += 4;

        // quests: Generator.Generated.DataTypeArray
        size += Quests.Sum(e => e.Size());

        return size;
    }

}

