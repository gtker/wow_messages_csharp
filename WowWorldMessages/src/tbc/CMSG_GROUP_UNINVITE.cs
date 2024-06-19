using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GROUP_UNINVITE: TbcClientMessage, IWorldMessage {
    public required string Name { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 117, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 117, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GROUP_UNINVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_GROUP_UNINVITE {
            Name = name,
        };
    }

    internal int Size() {
        var size = 0;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        return size;
    }

}

