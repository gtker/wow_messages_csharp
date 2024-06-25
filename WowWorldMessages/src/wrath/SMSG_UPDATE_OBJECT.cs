using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_UPDATE_OBJECT: WrathServerMessage, IWorldMessage {
    public required List<Object> Objects { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Objects.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Objects) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 169, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 169, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_UPDATE_OBJECT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfObjects = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var objects = new List<Object>();
        for (var i = 0; i < amountOfObjects; ++i) {
            objects.Add(await Wrath.Object.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_UPDATE_OBJECT {
            Objects = objects,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_objects: Generator.Generated.DataTypeInteger
        size += 4;

        // objects: Generator.Generated.DataTypeArray
        size += Objects.Sum(e => e.Size());

        return size;
    }

}

