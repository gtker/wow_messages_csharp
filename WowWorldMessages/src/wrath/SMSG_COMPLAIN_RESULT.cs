using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_COMPLAIN_RESULT: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// All emulators set to 0.
    /// </summary>
    public required byte Unknown { get; set; }
    public required Wrath.ComplainResultWindow WindowResult { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)WindowResult, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 4, 968, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 4, 968, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_COMPLAIN_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var windowResult = (Wrath.ComplainResultWindow)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_COMPLAIN_RESULT {
            Unknown = unknown,
            WindowResult = windowResult,
        };
    }

}

