using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MAIL_TAKE_ITEM: WrathClientMessage, IWorldMessage {
    public required ulong Mailbox { get; set; }
    public required uint MailId { get; set; }
    public required uint Item { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Mailbox, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MailId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 20, 582, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 20, 582, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MAIL_TAKE_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var mailbox = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var mailId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_MAIL_TAKE_ITEM {
            Mailbox = mailbox,
            MailId = mailId,
            Item = item,
        };
    }

}

