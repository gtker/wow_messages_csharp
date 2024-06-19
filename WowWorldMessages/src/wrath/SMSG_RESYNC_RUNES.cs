using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_RESYNC_RUNES: WrathServerMessage, IWorldMessage {
    public required List<ResyncRune> Runes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Runes.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Runes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1159, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1159, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_RESYNC_RUNES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRunes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var runes = new List<ResyncRune>();
        for (var i = 0; i < amountOfRunes; ++i) {
            runes.Add(await Wrath.ResyncRune.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_RESYNC_RUNES {
            Runes = runes,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_runes: Generator.Generated.DataTypeInteger
        size += 4;

        // runes: Generator.Generated.DataTypeArray
        size += Runes.Sum(e => 2);

        return size;
    }

}

