using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using SpamTypeType = OneOf.OneOf<CMSG_COMPLAIN.SpamTypeChat, CMSG_COMPLAIN.SpamTypeMail, SpamType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_COMPLAIN: WrathClientMessage, IWorldMessage {
    public class SpamTypeChat {
        public required uint ChannelId { get; set; }
        public required string Description { get; set; }
        public required uint Language { get; set; }
        public required uint MessageType { get; set; }
        public required uint Time { get; set; }
    }
    public class SpamTypeMail {
        public required uint MailId { get; set; }
        public required uint Unknown1 { get; set; }
        public required uint Unknown2 { get; set; }
    }
    public required SpamTypeType ComplaintType { get; set; }
    internal SpamType ComplaintTypeValue => ComplaintType.Match(
        _ => Wrath.SpamType.Chat,
        _ => Wrath.SpamType.Mail,
        v => v
    );
    public required ulong Offender { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ComplaintTypeValue, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Offender, cancellationToken).ConfigureAwait(false);

        if (ComplaintType.Value is CMSG_COMPLAIN.SpamTypeMail spamTypeMail) {
            await w.WriteUInt(spamTypeMail.Unknown1, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spamTypeMail.MailId, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spamTypeMail.Unknown2, cancellationToken).ConfigureAwait(false);

        }
        else if (ComplaintType.Value is CMSG_COMPLAIN.SpamTypeChat spamTypeChat) {
            await w.WriteUInt(spamTypeChat.Language, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spamTypeChat.MessageType, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spamTypeChat.ChannelId, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(spamTypeChat.Time, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(spamTypeChat.Description, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 967, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 967, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_COMPLAIN> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        SpamTypeType complaintType = (Wrath.SpamType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var offender = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        if (complaintType.Value is Wrath.SpamType.Mail) {
            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var mailId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            complaintType = new SpamTypeMail {
                MailId = mailId,
                Unknown1 = unknown1,
                Unknown2 = unknown2,
            };
        }
        else if (complaintType.Value is Wrath.SpamType.Chat) {
            var language = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var messageType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var channelId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var description = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            complaintType = new SpamTypeChat {
                ChannelId = channelId,
                Description = description,
                Language = language,
                MessageType = messageType,
                Time = time,
            };
        }

        return new CMSG_COMPLAIN {
            ComplaintType = complaintType,
            Offender = offender,
        };
    }

    internal int Size() {
        var size = 0;

        // complaint_type: Generator.Generated.DataTypeEnum
        size += 1;

        // offender: Generator.Generated.DataTypeGuid
        size += 8;

        if (ComplaintType.Value is CMSG_COMPLAIN.SpamTypeMail spamTypeMail) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

            // mail_id: Generator.Generated.DataTypeInteger
            size += 4;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (ComplaintType.Value is CMSG_COMPLAIN.SpamTypeChat spamTypeChat) {
            // language: Generator.Generated.DataTypeInteger
            size += 4;

            // message_type: Generator.Generated.DataTypeInteger
            size += 4;

            // channel_id: Generator.Generated.DataTypeInteger
            size += 4;

            // time: Generator.Generated.DataTypeInteger
            size += 4;

            // description: Generator.Generated.DataTypeCstring
            size += spamTypeChat.Description.Length + 1;

        }

        return size;
    }

}

