using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GAMEOBJECT_QUERY: TbcClientMessage, IWorldMessage {
    public required uint EntryId { get; set; }
    public required ulong Guid { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(EntryId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 94, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 16, 94, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GAMEOBJECT_QUERY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var entryId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new CMSG_GAMEOBJECT_QUERY {
            EntryId = entryId,
            Guid = guid,
        };
    }

}

