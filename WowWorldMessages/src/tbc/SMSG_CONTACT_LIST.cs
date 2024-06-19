using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CONTACT_LIST: TbcServerMessage, IWorldMessage {
    /// <summary>
    /// Indicates which kinds of relations are being sent in this list
    /// </summary>
    public required Tbc.RelationType ListMask { get; set; }
    public required List<Relation> Relations { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)ListMask, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Relations.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Relations) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 103, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 103, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CONTACT_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var listMask = (RelationType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRelations = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var relations = new List<Relation>();
        for (var i = 0; i < amountOfRelations; ++i) {
            relations.Add(await Tbc.Relation.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_CONTACT_LIST {
            ListMask = listMask,
            Relations = relations,
        };
    }

    internal int Size() {
        var size = 0;

        // list_mask: Generator.Generated.DataTypeFlag
        size += 4;

        // amount_of_relations: Generator.Generated.DataTypeInteger
        size += 4;

        // relations: Generator.Generated.DataTypeArray
        size += Relations.Sum(e => e.Size());

        return size;
    }

}

