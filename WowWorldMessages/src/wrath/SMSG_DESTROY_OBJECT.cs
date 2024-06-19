using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_DESTROY_OBJECT: WrathServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required bool TargetDied { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(TargetDied, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 11, 170, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 11, 170, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_DESTROY_OBJECT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var targetDied = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_DESTROY_OBJECT {
            Guid = guid,
            TargetDied = targetDied,
        };
    }

}
