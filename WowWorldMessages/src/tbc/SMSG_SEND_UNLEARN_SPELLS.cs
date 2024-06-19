using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SEND_UNLEARN_SPELLS: TbcServerMessage, IWorldMessage {
    public required List<uint> Spells { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Spells.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Spells) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1053, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1053, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SEND_UNLEARN_SPELLS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSpells = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var spells = new List<uint>();
        for (var i = 0; i < amountOfSpells; ++i) {
            spells.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_SEND_UNLEARN_SPELLS {
            Spells = spells,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_spells: Generator.Generated.DataTypeInteger
        size += 4;

        // spells: Generator.Generated.DataTypeArray
        size += Spells.Sum(e => 4);

        return size;
    }

}

