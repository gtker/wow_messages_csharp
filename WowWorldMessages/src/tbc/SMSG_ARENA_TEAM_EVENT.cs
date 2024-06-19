using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using ArenaTeamEventType = OneOf.OneOf<SMSG_ARENA_TEAM_EVENT.ArenaTeamEventDisbanded, SMSG_ARENA_TEAM_EVENT.ArenaTeamEventJoin, SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderChanged, SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderIs, SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeave, SMSG_ARENA_TEAM_EVENT.ArenaTeamEventRemove, ArenaTeamEvent>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_EVENT: TbcServerMessage, IWorldMessage {
    public class ArenaTeamEventDisbanded {
        public required string ArenaTeamName3 { get; set; }
        public required string LeaderName { get; set; }
    }
    public class ArenaTeamEventJoin {
        public required string ArenaTeamName1 { get; set; }
        public required ulong Joiner { get; set; }
        public required string JoinerName { get; set; }
    }
    public class ArenaTeamEventLeaderChanged {
        public required string NewLeader { get; set; }
        public required string OldLeader { get; set; }
    }
    public class ArenaTeamEventLeaderIs {
        public required string ArenaTeamName3 { get; set; }
        public required string LeaderName { get; set; }
    }
    public class ArenaTeamEventLeave {
        public required ulong Leaver { get; set; }
        public required string LeaverName { get; set; }
    }
    public class ArenaTeamEventRemove {
        public required string ArenaTeamName2 { get; set; }
        public required string KickedPlayerName { get; set; }
        public required string KickerName { get; set; }
    }
    public required ArenaTeamEventType EventType { get; set; }
    internal ArenaTeamEvent EventTypeValue => EventType.Match(
        _ => Tbc.ArenaTeamEvent.Disbanded,
        _ => Tbc.ArenaTeamEvent.Join,
        _ => Tbc.ArenaTeamEvent.LeaderChanged,
        _ => Tbc.ArenaTeamEvent.LeaderIs,
        _ => Tbc.ArenaTeamEvent.Leave,
        _ => Tbc.ArenaTeamEvent.Remove,
        v => v
    );
    public required List<string> StringValue { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)EventTypeValue, cancellationToken).ConfigureAwait(false);

        if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventJoin arenaTeamEventJoin) {
            await w.WriteCString(arenaTeamEventJoin.JoinerName, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventJoin.ArenaTeamName1, cancellationToken).ConfigureAwait(false);

            await w.WriteULong(arenaTeamEventJoin.Joiner, cancellationToken).ConfigureAwait(false);

        }
        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeave arenaTeamEventLeave) {
            await w.WriteCString(arenaTeamEventLeave.LeaverName, cancellationToken).ConfigureAwait(false);

            await w.WriteULong(arenaTeamEventLeave.Leaver, cancellationToken).ConfigureAwait(false);

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventRemove arenaTeamEventRemove) {
            await w.WriteCString(arenaTeamEventRemove.KickedPlayerName, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventRemove.ArenaTeamName2, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventRemove.KickerName, cancellationToken).ConfigureAwait(false);

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderIs arenaTeamEventLeaderIs) {
            await w.WriteCString(arenaTeamEventLeaderIs.LeaderName, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventLeaderIs.ArenaTeamName3, cancellationToken).ConfigureAwait(false);

        }
        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventDisbanded arenaTeamEventDisbanded) {
            await w.WriteCString(arenaTeamEventDisbanded.LeaderName, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventDisbanded.ArenaTeamName3, cancellationToken).ConfigureAwait(false);

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderChanged arenaTeamEventLeaderChanged) {
            await w.WriteCString(arenaTeamEventLeaderChanged.OldLeader, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(arenaTeamEventLeaderChanged.NewLeader, cancellationToken).ConfigureAwait(false);

        }


        await w.WriteByte((byte)StringValue.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in StringValue) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 855, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 855, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_EVENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        ArenaTeamEventType eventType = (Tbc.ArenaTeamEvent)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (eventType.Value is Tbc.ArenaTeamEvent.Join) {
            var joinerName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var arenaTeamName1 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var joiner = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventJoin {
                ArenaTeamName1 = arenaTeamName1,
                Joiner = joiner,
                JoinerName = joinerName,
            };
        }
        else if (eventType.Value is Tbc.ArenaTeamEvent.Leave) {
            var leaverName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var leaver = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventLeave {
                Leaver = leaver,
                LeaverName = leaverName,
            };
        }

        else if (eventType.Value is Tbc.ArenaTeamEvent.Remove) {
            var kickedPlayerName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var arenaTeamName2 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var kickerName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventRemove {
                ArenaTeamName2 = arenaTeamName2,
                KickedPlayerName = kickedPlayerName,
                KickerName = kickerName,
            };
        }

        else if (eventType.Value is Tbc.ArenaTeamEvent.LeaderIs) {
            var leaderName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var arenaTeamName3 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventLeaderIs {
                ArenaTeamName3 = arenaTeamName3,
                LeaderName = leaderName,
            };
        }
        else if (eventType.Value is Tbc.ArenaTeamEvent.Disbanded) {
            var leaderName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var arenaTeamName3 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventDisbanded {
                ArenaTeamName3 = arenaTeamName3,
                LeaderName = leaderName,
            };
        }

        else if (eventType.Value is Tbc.ArenaTeamEvent.LeaderChanged) {
            var oldLeader = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var newLeader = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            eventType = new ArenaTeamEventLeaderChanged {
                NewLeader = newLeader,
                OldLeader = oldLeader,
            };
        }


        // ReSharper disable once UnusedVariable.Compiler
        var amountOfStrings = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var stringValue = new List<string>();
        for (var i = 0; i < amountOfStrings; ++i) {
            stringValue.Add(await r.ReadCString(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_ARENA_TEAM_EVENT {
            EventType = eventType,
            StringValue = stringValue,
        };
    }

    internal int Size() {
        var size = 0;

        // event_type: Generator.Generated.DataTypeEnum
        size += 1;

        if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventJoin arenaTeamEventJoin) {
            // joiner_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventJoin.JoinerName.Length + 1;

            // arena_team_name1: Generator.Generated.DataTypeCstring
            size += arenaTeamEventJoin.ArenaTeamName1.Length + 1;

            // joiner: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeave arenaTeamEventLeave) {
            // leaver_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventLeave.LeaverName.Length + 1;

            // leaver: Generator.Generated.DataTypeGuid
            size += 8;

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventRemove arenaTeamEventRemove) {
            // kicked_player_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventRemove.KickedPlayerName.Length + 1;

            // arena_team_name2: Generator.Generated.DataTypeCstring
            size += arenaTeamEventRemove.ArenaTeamName2.Length + 1;

            // kicker_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventRemove.KickerName.Length + 1;

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderIs arenaTeamEventLeaderIs) {
            // leader_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventLeaderIs.LeaderName.Length + 1;

            // arena_team_name3: Generator.Generated.DataTypeCstring
            size += arenaTeamEventLeaderIs.ArenaTeamName3.Length + 1;

        }
        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventDisbanded arenaTeamEventDisbanded) {
            // leader_name: Generator.Generated.DataTypeCstring
            size += arenaTeamEventDisbanded.LeaderName.Length + 1;

            // arena_team_name3: Generator.Generated.DataTypeCstring
            size += arenaTeamEventDisbanded.ArenaTeamName3.Length + 1;

        }

        else if (EventType.Value is SMSG_ARENA_TEAM_EVENT.ArenaTeamEventLeaderChanged arenaTeamEventLeaderChanged) {
            // old_leader: Generator.Generated.DataTypeCstring
            size += arenaTeamEventLeaderChanged.OldLeader.Length + 1;

            // new_leader: Generator.Generated.DataTypeCstring
            size += arenaTeamEventLeaderChanged.NewLeader.Length + 1;

        }


        // amount_of_strings: Generator.Generated.DataTypeInteger
        size += 1;

        // string_value: Generator.Generated.DataTypeArray
        size += StringValue.Sum(e => e.Length + 1);

        return size;
    }

}

