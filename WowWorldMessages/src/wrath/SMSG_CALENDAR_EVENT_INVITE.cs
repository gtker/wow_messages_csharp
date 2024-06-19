using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using CalendarStatusTimeType = OneOf.OneOf<SMSG_CALENDAR_EVENT_INVITE.CalendarStatusTimePresent, CalendarStatusTime>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_INVITE: WrathServerMessage, IWorldMessage {
    public class CalendarStatusTimePresent {
        public required uint StatusTime { get; set; }
    }
    public required ulong Invitee { get; set; }
    public required ulong EventId { get; set; }
    public required ulong InviteId { get; set; }
    public required byte Level { get; set; }
    public required byte InviteStatus { get; set; }
    public required CalendarStatusTimeType Time { get; set; }
    internal CalendarStatusTime TimeValue => Time.Match(
        _ => Wrath.CalendarStatusTime.Present,
        v => v
    );
    public required bool IsSignUp { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Invitee, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(InviteStatus, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)TimeValue, cancellationToken).ConfigureAwait(false);

        if (Time.Value is SMSG_CALENDAR_EVENT_INVITE.CalendarStatusTimePresent calendarStatusTimePresent) {
            await w.WriteUInt(calendarStatusTimePresent.StatusTime, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteBool8(IsSignUp, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1082, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1082, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_INVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var invitee = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var inviteStatus = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        CalendarStatusTimeType time = (Wrath.CalendarStatusTime)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (time.Value is Wrath.CalendarStatusTime.Present) {
            var statusTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            time = new CalendarStatusTimePresent {
                StatusTime = statusTime,
            };
        }

        var isSignUp = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_INVITE {
            Invitee = invitee,
            EventId = eventId,
            InviteId = inviteId,
            Level = level,
            InviteStatus = inviteStatus,
            Time = time,
            IsSignUp = isSignUp,
        };
    }

    internal int Size() {
        var size = 0;

        // invitee: Generator.Generated.DataTypePackedGuid
        size += Invitee.PackedGuidLength();

        // event_id: Generator.Generated.DataTypeGuid
        size += 8;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // invite_status: Generator.Generated.DataTypeInteger
        size += 1;

        // time: Generator.Generated.DataTypeEnum
        size += 1;

        if (Time.Value is SMSG_CALENDAR_EVENT_INVITE.CalendarStatusTimePresent calendarStatusTimePresent) {
            // status_time: Generator.Generated.DataTypeDateTime
            size += 4;

        }

        // is_sign_up: Generator.Generated.DataTypeBool
        size += 1;

        return size;
    }

}

