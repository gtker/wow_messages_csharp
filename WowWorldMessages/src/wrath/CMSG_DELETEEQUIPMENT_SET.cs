using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_DELETEEQUIPMENT_SET: WrathClientMessage, IWorldMessage {
    public required ulong Set { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Set, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 318, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 318, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_DELETEEQUIPMENT_SET> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var set = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new CMSG_DELETEEQUIPMENT_SET {
            Set = set,
        };
    }

    internal int Size() {
        var size = 0;

        // set: Generator.Generated.DataTypePackedGuid
        size += Set.PackedGuidLength();

        return size;
    }

}

