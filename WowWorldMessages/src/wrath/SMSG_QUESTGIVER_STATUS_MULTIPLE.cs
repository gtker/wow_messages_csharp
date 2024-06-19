using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUESTGIVER_STATUS_MULTIPLE: WrathServerMessage, IWorldMessage {
    public required List<QuestGiverStatusReport> Statuses { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Statuses.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Statuses) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1048, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1048, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUESTGIVER_STATUS_MULTIPLE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfStatuses = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var statuses = new List<QuestGiverStatusReport>();
        for (var i = 0; i < amountOfStatuses; ++i) {
            statuses.Add(await Wrath.QuestGiverStatusReport.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_QUESTGIVER_STATUS_MULTIPLE {
            Statuses = statuses,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_statuses: Generator.Generated.DataTypeInteger
        size += 4;

        // statuses: Generator.Generated.DataTypeArray
        size += Statuses.Sum(e => 9);

        return size;
    }

}

