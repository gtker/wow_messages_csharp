using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_MODERATOR_STATUS_ALERT: WrathServerMessage, IWorldMessage {
    public required ulong Invitee { get; set; }
    public required ulong EventId { get; set; }
    public required byte Rank { get; set; }
    public required bool ShowAlert { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Invitee, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Rank, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(ShowAlert, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1093, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1093, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_MODERATOR_STATUS_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var invitee = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var showAlert = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_MODERATOR_STATUS_ALERT {
            Invitee = invitee,
            EventId = eventId,
            Rank = rank,
            ShowAlert = showAlert,
        };
    }

    internal int Size() {
        var size = 0;

        // invitee: Generator.Generated.DataTypePackedGuid
        size += Invitee.PackedGuidLength();

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // rank: Generator.Generated.DataTypeInteger
        size += 1;

        // show_alert: Generator.Generated.DataTypeBool
        size += 1;

        return size;
    }

}

