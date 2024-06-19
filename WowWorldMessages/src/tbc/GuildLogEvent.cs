using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using GuildEventType = OneOf.OneOf<GuildLogEvent.GuildEventDemotion, GuildLogEvent.GuildEventJoined, GuildLogEvent.GuildEventLeft, GuildLogEvent.GuildEventPromotion, GuildEvent>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildLogEvent {
    public class GuildEventDemotion {
        public required byte NewRank { get; set; }
    }
    public class GuildEventJoined {
        public required ulong Player2 { get; set; }
    }
    public class GuildEventLeft {
        public required ulong Player2 { get; set; }
    }
    public class GuildEventPromotion {
        public required byte NewRank { get; set; }
    }
    public required GuildEventType EventType { get; set; }
    internal GuildEvent EventTypeValue => EventType.Match(
        _ => Tbc.GuildEvent.Demotion,
        _ => Tbc.GuildEvent.Joined,
        _ => Tbc.GuildEvent.Left,
        _ => Tbc.GuildEvent.Promotion,
        v => v
    );
    public required ulong Player1 { get; set; }
    public required uint UnixTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)EventTypeValue, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player1, cancellationToken).ConfigureAwait(false);

        if (EventType.Value is GuildLogEvent.GuildEventJoined guildEventJoined) {
            await w.WriteULong(guildEventJoined.Player2, cancellationToken).ConfigureAwait(false);

        }
        else if (EventType.Value is GuildLogEvent.GuildEventLeft guildEventLeft) {
            await w.WriteULong(guildEventLeft.Player2, cancellationToken).ConfigureAwait(false);

        }
        else if (EventType.Value is GuildLogEvent.GuildEventPromotion guildEventPromotion) {
            await w.WriteByte(guildEventPromotion.NewRank, cancellationToken).ConfigureAwait(false);

        }
        else if (EventType.Value is GuildLogEvent.GuildEventDemotion guildEventDemotion) {
            await w.WriteByte(guildEventDemotion.NewRank, cancellationToken).ConfigureAwait(false);

        }


        await w.WriteUInt(UnixTime, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GuildLogEvent> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        GuildEventType eventType = (Tbc.GuildEvent)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var player1 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        if (eventType.Value is Tbc.GuildEvent.Joined) {
            var player2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            eventType = new GuildEventJoined {
                Player2 = player2,
            };
        }
        else if (eventType.Value is Tbc.GuildEvent.Left) {
            var player2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            eventType = new GuildEventLeft {
                Player2 = player2,
            };
        }
        else if (eventType.Value is Tbc.GuildEvent.Promotion) {
            var newRank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            eventType = new GuildEventPromotion {
                NewRank = newRank,
            };
        }
        else if (eventType.Value is Tbc.GuildEvent.Demotion) {
            var newRank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            eventType = new GuildEventDemotion {
                NewRank = newRank,
            };
        }


        var unixTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new GuildLogEvent {
            EventType = eventType,
            Player1 = player1,
            UnixTime = unixTime,
        };
    }

    internal int Size() {
        var size = 0;

        // event_type: Generator.Generated.DataTypeEnum
        size += 1;

        // player1: Generator.Generated.DataTypeGuid
        size += 8;

        if (EventType.Value is GuildLogEvent.GuildEventJoined guildEventJoined) {
            // player2: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (EventType.Value is GuildLogEvent.GuildEventLeft guildEventLeft) {
            // player2: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (EventType.Value is GuildLogEvent.GuildEventPromotion guildEventPromotion) {
            // new_rank: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (EventType.Value is GuildLogEvent.GuildEventDemotion guildEventDemotion) {
            // new_rank: Generator.Generated.DataTypeInteger
            size += 1;

        }


        // unix_time: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

