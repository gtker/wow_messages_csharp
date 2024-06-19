using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_LFG_COMMENT: TbcClientMessage, IWorldMessage {
    public required string Comment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Comment, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 870, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 870, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_LFG_COMMENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_LFG_COMMENT {
            Comment = comment,
        };
    }

    internal int Size() {
        var size = 0;

        // comment: Generator.Generated.DataTypeCstring
        size += Comment.Length + 1;

        return size;
    }

}

