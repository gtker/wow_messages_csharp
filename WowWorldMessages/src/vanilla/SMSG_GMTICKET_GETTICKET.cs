using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using GmTicketStatusType = OneOf.OneOf<SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText, GmTicketStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GMTICKET_GETTICKET: VanillaServerMessage, IWorldMessage {
    public class GmTicketStatusHasText {
        public required float DaysSinceLastUpdated { get; set; }
        public required float DaysSinceOldestTicketCreation { get; set; }
        public required float DaysSinceTicketCreation { get; set; }
        public required GmTicketEscalationStatus EscalationStatus { get; set; }
        public required bool ReadByGm { get; set; }
        /// <summary>
        /// cmangos: Ticket text: data, should never exceed 1999 bytes
        /// </summary>
        public required string Text { get; set; }
        public required GmTicketType TicketType { get; set; }
    }
    public required GmTicketStatusType Status { get; set; }
    internal GmTicketStatus StatusValue => Status.Match(
        _ => Vanilla.GmTicketStatus.HasText,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)StatusValue, cancellationToken).ConfigureAwait(false);

        if (Status.Value is SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText hasText) {
            await w.WriteCString(hasText.Text, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)hasText.TicketType, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hasText.DaysSinceTicketCreation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hasText.DaysSinceOldestTicketCreation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hasText.DaysSinceLastUpdated, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)hasText.EscalationStatus, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(hasText.ReadByGm, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 530, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 530, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GMTICKET_GETTICKET> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        GmTicketStatusType status = (GmTicketStatus)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (status.Value is Vanilla.GmTicketStatus.HasText) {
            var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var ticketType = (GmTicketType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var daysSinceTicketCreation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var daysSinceOldestTicketCreation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var daysSinceLastUpdated = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var escalationStatus = (GmTicketEscalationStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var readByGm = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            status = new GmTicketStatusHasText {
                DaysSinceLastUpdated = daysSinceLastUpdated,
                DaysSinceOldestTicketCreation = daysSinceOldestTicketCreation,
                DaysSinceTicketCreation = daysSinceTicketCreation,
                EscalationStatus = escalationStatus,
                ReadByGm = readByGm,
                Text = text,
                TicketType = ticketType,
            };
        }

        return new SMSG_GMTICKET_GETTICKET {
            Status = status,
        };
    }

    internal int Size() {
        var size = 0;

        // status: Generator.Generated.DataTypeEnum
        size += 4;

        if (Status.Value is SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText hasText) {
            // text: Generator.Generated.DataTypeCstring
            size += hasText.Text.Length + 1;

            // ticket_type: Generator.Generated.DataTypeEnum
            size += 1;

            // days_since_ticket_creation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // days_since_oldest_ticket_creation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // days_since_last_updated: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // escalation_status: Generator.Generated.DataTypeEnum
            size += 1;

            // read_by_gm: Generator.Generated.DataTypeBool
            size += 1;

        }

        return size;
    }

}

