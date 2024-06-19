using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_COMPLAIN: WrathClientMessage, IWorldMessage {
    public required ulong ResponsiblePlayer { get; set; }
    public required ulong EventValue { get; set; }
    public required ulong InviteId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(ResponsiblePlayer, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventValue, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 28, 1094, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 28, 1094, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_COMPLAIN> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var responsiblePlayer = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var eventValue = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new CMSG_CALENDAR_COMPLAIN {
            ResponsiblePlayer = responsiblePlayer,
            EventValue = eventValue,
            InviteId = inviteId,
        };
    }

}

