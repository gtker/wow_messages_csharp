using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using GmTicketStatusType = OneOf.OneOf<SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText, GmTicketStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GMTICKET_GETTICKET: WrathServerMessage, IWorldMessage {
    public class GmTicketStatusHasText {
        public required float DaysSinceLastUpdated { get; set; }
        public required float DaysSinceOldestTicketCreation { get; set; }
        public required float DaysSinceTicketCreation { get; set; }
        public required Wrath.GmTicketEscalationStatus EscalationStatus { get; set; }
        public required uint Id { get; set; }
        public required bool NeedMoreHelp { get; set; }
        public required bool ReadByGm { get; set; }
        /// <summary>
        /// cmangos: Ticket text: data, should never exceed 1999 bytes
        /// </summary>
        public required string Text { get; set; }
    }
    public required GmTicketStatusType Status { get; set; }
    internal GmTicketStatus StatusValue => Status.Match(
        _ => Wrath.GmTicketStatus.HasText,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)StatusValue, cancellationToken).ConfigureAwait(false);

        if (Status.Value is SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText gmTicketStatusHasText) {
            await w.WriteUInt(gmTicketStatusHasText.Id, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(gmTicketStatusHasText.Text, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(gmTicketStatusHasText.NeedMoreHelp, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(gmTicketStatusHasText.DaysSinceTicketCreation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(gmTicketStatusHasText.DaysSinceOldestTicketCreation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(gmTicketStatusHasText.DaysSinceLastUpdated, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)gmTicketStatusHasText.EscalationStatus, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(gmTicketStatusHasText.ReadByGm, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 530, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 530, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GMTICKET_GETTICKET> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        GmTicketStatusType status = (Wrath.GmTicketStatus)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (status.Value is Wrath.GmTicketStatus.HasText) {
            var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var needMoreHelp = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            var daysSinceTicketCreation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var daysSinceOldestTicketCreation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var daysSinceLastUpdated = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var escalationStatus = (Wrath.GmTicketEscalationStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var readByGm = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            status = new GmTicketStatusHasText {
                DaysSinceLastUpdated = daysSinceLastUpdated,
                DaysSinceOldestTicketCreation = daysSinceOldestTicketCreation,
                DaysSinceTicketCreation = daysSinceTicketCreation,
                EscalationStatus = escalationStatus,
                Id = id,
                NeedMoreHelp = needMoreHelp,
                ReadByGm = readByGm,
                Text = text,
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

        if (Status.Value is SMSG_GMTICKET_GETTICKET.GmTicketStatusHasText gmTicketStatusHasText) {
            // id: Generator.Generated.DataTypeInteger
            size += 4;

            // text: Generator.Generated.DataTypeCstring
            size += gmTicketStatusHasText.Text.Length + 1;

            // need_more_help: Generator.Generated.DataTypeBool
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

