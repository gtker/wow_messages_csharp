using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using MailTypeType = OneOf.OneOf<Mail.MailTypeAuction, Mail.MailTypeCreature, Mail.MailTypeGameobject, Mail.MailTypeItem, Mail.MailTypeNormal, MailType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Mail {
    public class MailTypeAuction {
        public required uint AuctionId { get; set; }
    }
    public class MailTypeCreature {
        public required uint SenderId { get; set; }
    }
    public class MailTypeGameobject {
        public required uint SenderId { get; set; }
    }
    public class MailTypeItem {
        public required uint Item { get; set; }
    }
    public class MailTypeNormal {
        public required ulong Sender { get; set; }
    }
    public required uint MessageId { get; set; }
    public required MailTypeType MessageType { get; set; }
    internal MailType MessageTypeValue => MessageType.Match(
        _ => Wrath.MailType.Auction,
        _ => Wrath.MailType.Creature,
        _ => Wrath.MailType.Gameobject,
        _ => Wrath.MailType.Item,
        _ => Wrath.MailType.Normal,
        v => v
    );
    public required uint CashOnDelivery { get; set; }
    public required uint Unknown { get; set; }
    public required uint Stationery { get; set; }
    public required uint Money { get; set; }
    public required uint Flags { get; set; }
    public required float ExpirationTime { get; set; }
    /// <summary>
    /// cmangos/vmangos/mangoszero: mail template (MailTemplate.dbc)
    /// </summary>
    public required uint MailTemplateId { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }
    public required List<MailListItem> Items { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort((ushort)Size(), cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MessageId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)MessageTypeValue, cancellationToken).ConfigureAwait(false);

        if (MessageType.Value is Mail.MailTypeNormal mailTypeNormal) {
            await w.WriteULong(mailTypeNormal.Sender, cancellationToken).ConfigureAwait(false);

        }
        else if (MessageType.Value is Mail.MailTypeCreature mailTypeCreature) {
            await w.WriteUInt(mailTypeCreature.SenderId, cancellationToken).ConfigureAwait(false);

        }
        else if (MessageType.Value is Mail.MailTypeGameobject mailTypeGameobject) {
            await w.WriteUInt(mailTypeGameobject.SenderId, cancellationToken).ConfigureAwait(false);

        }

        else if (MessageType.Value is Mail.MailTypeAuction mailTypeAuction) {
            await w.WriteUInt(mailTypeAuction.AuctionId, cancellationToken).ConfigureAwait(false);

        }

        else if (MessageType.Value is Mail.MailTypeItem mailTypeItem) {
            await w.WriteUInt(mailTypeItem.Item, cancellationToken).ConfigureAwait(false);

        }


        await w.WriteUInt(CashOnDelivery, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Stationery, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Money, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(ExpirationTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MailTemplateId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Subject, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Message, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Items.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Items) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<Mail> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var messageId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        MailTypeType messageType = (Wrath.MailType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (messageType.Value is Wrath.MailType.Normal) {
            var sender = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            messageType = new MailTypeNormal {
                Sender = sender,
            };
        }
        else if (messageType.Value is Wrath.MailType.Creature) {
            var senderId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            messageType = new MailTypeCreature {
                SenderId = senderId,
            };
        }
        else if (messageType.Value is Wrath.MailType.Gameobject) {
            var senderId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            messageType = new MailTypeGameobject {
                SenderId = senderId,
            };
        }

        else if (messageType.Value is Wrath.MailType.Auction) {
            var auctionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            messageType = new MailTypeAuction {
                AuctionId = auctionId,
            };
        }

        else if (messageType.Value is Wrath.MailType.Item) {
            var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            messageType = new MailTypeItem {
                Item = item,
            };
        }


        var cashOnDelivery = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var stationery = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var money = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var expirationTime = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var mailTemplateId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var subject = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var message = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfItems = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var items = new List<MailListItem>();
        for (var i = 0; i < amountOfItems; ++i) {
            items.Add(await Wrath.MailListItem.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new Mail {
            MessageId = messageId,
            MessageType = messageType,
            CashOnDelivery = cashOnDelivery,
            Unknown = unknown,
            Stationery = stationery,
            Money = money,
            Flags = flags,
            ExpirationTime = expirationTime,
            MailTemplateId = mailTemplateId,
            Subject = subject,
            Message = message,
            Items = items,
        };
    }

    internal int Size() {
        var size = 0;

        // size: Generator.Generated.DataTypeInteger
        size += 2;

        // message_id: Generator.Generated.DataTypeInteger
        size += 4;

        // message_type: Generator.Generated.DataTypeEnum
        size += 1;

        if (MessageType.Value is Mail.MailTypeNormal mailTypeNormal) {
            // sender: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (MessageType.Value is Mail.MailTypeCreature mailTypeCreature) {
            // sender_id: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (MessageType.Value is Mail.MailTypeGameobject mailTypeGameobject) {
            // sender_id: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (MessageType.Value is Mail.MailTypeAuction mailTypeAuction) {
            // auction_id: Generator.Generated.DataTypeInteger
            size += 4;

        }

        else if (MessageType.Value is Mail.MailTypeItem mailTypeItem) {
            // item: Generator.Generated.DataTypeItem
            size += 4;

        }


        // cash_on_delivery: Generator.Generated.DataTypeGold
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        // stationery: Generator.Generated.DataTypeInteger
        size += 4;

        // money: Generator.Generated.DataTypeGold
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // expiration_time: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // mail_template_id: Generator.Generated.DataTypeInteger
        size += 4;

        // subject: Generator.Generated.DataTypeCstring
        size += Subject.Length + 1;

        // message: Generator.Generated.DataTypeCstring
        size += Message.Length + 1;

        // amount_of_items: Generator.Generated.DataTypeInteger
        size += 1;

        // items: Generator.Generated.DataTypeArray
        size += Items.Sum(e => 115);

        return size;
    }

}

