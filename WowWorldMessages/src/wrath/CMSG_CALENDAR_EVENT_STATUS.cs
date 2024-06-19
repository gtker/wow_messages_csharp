using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_EVENT_STATUS: WrathClientMessage, IWorldMessage {
    public required ulong EventValue { get; set; }
    public required ulong InviteId { get; set; }
    public required ulong SenderInviteId { get; set; }
    public required Wrath.CalendarStatus Status { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventValue, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(SenderInviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Status, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 29, 1076, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 29, 1076, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_EVENT_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventValue = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var senderInviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var status = (Wrath.CalendarStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_CALENDAR_EVENT_STATUS {
            EventValue = eventValue,
            InviteId = inviteId,
            SenderInviteId = senderInviteId,
            Status = status,
        };
    }

}

