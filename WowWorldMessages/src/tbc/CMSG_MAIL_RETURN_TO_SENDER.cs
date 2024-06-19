using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MAIL_RETURN_TO_SENDER: TbcClientMessage, IWorldMessage {
    public required ulong MailboxId { get; set; }
    public required uint MailId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(MailboxId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MailId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 584, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 16, 584, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MAIL_RETURN_TO_SENDER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var mailboxId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var mailId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_MAIL_RETURN_TO_SENDER {
            MailboxId = mailboxId,
            MailId = mailId,
        };
    }

}

