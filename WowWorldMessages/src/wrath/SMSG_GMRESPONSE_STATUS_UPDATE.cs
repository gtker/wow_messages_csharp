using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GMRESPONSE_STATUS_UPDATE: WrathServerMessage, IWorldMessage {
    public required bool ShowSurvey { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(ShowSurvey, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 3, 1265, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 3, 1265, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GMRESPONSE_STATUS_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var showSurvey = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_GMRESPONSE_STATUS_UPDATE {
            ShowSurvey = showSurvey,
        };
    }

}

