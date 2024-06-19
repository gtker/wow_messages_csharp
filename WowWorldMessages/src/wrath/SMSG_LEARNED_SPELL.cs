using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LEARNED_SPELL: WrathServerMessage, IWorldMessage {
    public required uint Id { get; set; }
    /// <summary>
    /// mangostwo: 3.3.3 unk
    /// </summary>
    public required ushort Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 8, 299, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 8, 299, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LEARNED_SPELL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        return new SMSG_LEARNED_SPELL {
            Id = id,
            Unknown = unknown,
        };
    }

}

