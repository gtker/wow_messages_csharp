using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MAIL_CREATE_TEXT_ITEM: TbcClientMessage, IWorldMessage {
    public required ulong Mailbox { get; set; }
    public required uint MailId { get; set; }
    /// <summary>
    /// mangoszero/cmangos/vmangos: mailTemplateId, non need, Mail store own 100% correct value anyway
    /// </summary>
    public required uint MailTemplateId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Mailbox, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MailId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MailTemplateId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 20, 586, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 20, 586, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MAIL_CREATE_TEXT_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var mailbox = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var mailId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var mailTemplateId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_MAIL_CREATE_TEXT_ITEM {
            Mailbox = mailbox,
            MailId = mailId,
            MailTemplateId = mailTemplateId,
        };
    }

}

