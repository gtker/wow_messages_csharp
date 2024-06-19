using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_TITLE_EARNED: WrathServerMessage, IWorldMessage {
    public required uint Title { get; set; }
    public required Wrath.TitleEarnStatus Status { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Title, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Status, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 883, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 10, 883, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_TITLE_EARNED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var title = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var status = (Wrath.TitleEarnStatus)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_TITLE_EARNED {
            Title = title,
            Status = status,
        };
    }

}

