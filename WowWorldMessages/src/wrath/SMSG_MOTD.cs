using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MOTD: WrathServerMessage, IWorldMessage {
    public required List<string> Motds { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Motds.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Motds) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 829, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 829, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MOTD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMotds = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var motds = new List<string>();
        for (var i = 0; i < amountOfMotds; ++i) {
            motds.Add(await r.ReadCString(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_MOTD {
            Motds = motds,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_motds: Generator.Generated.DataTypeInteger
        size += 4;

        // motds: Generator.Generated.DataTypeArray
        size += Motds.Sum(e => e.Length + 1);

        return size;
    }

}

