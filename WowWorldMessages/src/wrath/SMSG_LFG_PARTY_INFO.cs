using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_PARTY_INFO: WrathServerMessage, IWorldMessage {
    public required List<LfgPartyInfo> Infos { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Infos.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Infos) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 882, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 882, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_PARTY_INFO> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfInfos = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var infos = new List<LfgPartyInfo>();
        for (var i = 0; i < amountOfInfos; ++i) {
            infos.Add(await Wrath.LfgPartyInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_LFG_PARTY_INFO {
            Infos = infos,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_infos: Generator.Generated.DataTypeInteger
        size += 1;

        // infos: Generator.Generated.DataTypeArray
        size += Infos.Sum(e => e.Size());

        return size;
    }

}

