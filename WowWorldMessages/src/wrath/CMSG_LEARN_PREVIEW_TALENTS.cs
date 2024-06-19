using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LEARN_PREVIEW_TALENTS: WrathClientMessage, IWorldMessage {
    public required List<PreviewTalent> Talents { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Talents.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Talents) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1217, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1217, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LEARN_PREVIEW_TALENTS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfTalents = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var talents = new List<PreviewTalent>();
        for (var i = 0; i < amountOfTalents; ++i) {
            talents.Add(await Wrath.PreviewTalent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new CMSG_LEARN_PREVIEW_TALENTS {
            Talents = talents,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_talents: Generator.Generated.DataTypeInteger
        size += 4;

        // talents: Generator.Generated.DataTypeArray
        size += Talents.Sum(e => 8);

        return size;
    }

}

