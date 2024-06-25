using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using StatusIdType = OneOf.OneOf<SMSG_BATTLEFIELD_STATUS.StatusIdInProgress, SMSG_BATTLEFIELD_STATUS.StatusIdWaitJoin, SMSG_BATTLEFIELD_STATUS.StatusIdWaitQueue, StatusId>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_STATUS: WrathServerMessage, IWorldMessage {
    public class StatusIdInProgress {
        public required Wrath.ArenaFaction Faction { get; set; }
        public required Wrath.Map Map2 { get; set; }
        public required uint TimeToBgAutoleaveInMs { get; set; }
        public required uint TimeToBgStartInMs { get; set; }
        /// <summary>
        /// azerothcore: 3.3.5 unknown
        /// </summary>
        public required ulong Unknown3 { get; set; }
    }
    public class StatusIdWaitJoin {
        public required Wrath.Map Map1 { get; set; }
        public required uint TimeToRemoveInQueueInMs { get; set; }
        /// <summary>
        /// azerothcore: 3.3.5 unknown
        /// </summary>
        public required ulong Unknown2 { get; set; }
    }
    public class StatusIdWaitQueue {
        public required uint AverageWaitTimeInMs { get; set; }
        public required uint TimeInQueueInMs { get; set; }
    }
    /// <summary>
    /// vmangos: players can be in 3 queues at the same time (0..2)
    /// </summary>
    public required uint QueueSlot { get; set; }
    public required Wrath.ArenaType ArenaType { get; set; }
    /// <summary>
    /// azerothcore sets to 0x0E if it is arena, 0 otherwise.
    /// </summary>
    public required byte IsArena { get; set; }
    public required Wrath.BattlegroundType BattlegroundType { get; set; }
    /// <summary>
    /// azerothcore sets to 0x1F90
    /// </summary>
    public required ushort Unknown1 { get; set; }
    public required byte MinimumLevel { get; set; }
    public required byte MaximumLevel { get; set; }
    public required uint ClientInstanceId { get; set; }
    public required bool Rated { get; set; }
    public required StatusIdType StatusId { get; set; }
    internal StatusId StatusIdValue => StatusId.Match(
        _ => Wrath.StatusId.InProgress,
        _ => Wrath.StatusId.WaitJoin,
        _ => Wrath.StatusId.WaitQueue,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QueueSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ArenaType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(IsArena, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)BattlegroundType, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(MinimumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(MaximumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ClientInstanceId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Rated, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)StatusIdValue, cancellationToken).ConfigureAwait(false);

        if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitQueue statusIdWaitQueue) {
            await w.WriteUInt(statusIdWaitQueue.AverageWaitTimeInMs, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdWaitQueue.TimeInQueueInMs, cancellationToken).ConfigureAwait(false);

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitJoin statusIdWaitJoin) {
            await w.WriteUInt((uint)statusIdWaitJoin.Map1, cancellationToken).ConfigureAwait(false);

            await w.WriteULong(statusIdWaitJoin.Unknown2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdWaitJoin.TimeToRemoveInQueueInMs, cancellationToken).ConfigureAwait(false);

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdInProgress statusIdInProgress) {
            await w.WriteUInt((uint)statusIdInProgress.Map2, cancellationToken).ConfigureAwait(false);

            await w.WriteULong(statusIdInProgress.Unknown3, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdInProgress.TimeToBgAutoleaveInMs, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdInProgress.TimeToBgStartInMs, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)statusIdInProgress.Faction, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 724, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 724, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var queueSlot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaType = (Wrath.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var isArena = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var battlegroundType = (Wrath.BattlegroundType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var minimumLevel = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var maximumLevel = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var clientInstanceId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rated = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        StatusIdType statusId = (Wrath.StatusId)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (statusId.Value is Wrath.StatusId.WaitQueue) {
            var averageWaitTimeInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var timeInQueueInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdWaitQueue {
                AverageWaitTimeInMs = averageWaitTimeInMs,
                TimeInQueueInMs = timeInQueueInMs,
            };
        }
        else if (statusId.Value is Wrath.StatusId.WaitJoin) {
            var map1 = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            var timeToRemoveInQueueInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdWaitJoin {
                Map1 = map1,
                TimeToRemoveInQueueInMs = timeToRemoveInQueueInMs,
                Unknown2 = unknown2,
            };
        }
        else if (statusId.Value is Wrath.StatusId.InProgress) {
            var map2 = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown3 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            var timeToBgAutoleaveInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var timeToBgStartInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var faction = (Wrath.ArenaFaction)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdInProgress {
                Faction = faction,
                Map2 = map2,
                TimeToBgAutoleaveInMs = timeToBgAutoleaveInMs,
                TimeToBgStartInMs = timeToBgStartInMs,
                Unknown3 = unknown3,
            };
        }

        return new SMSG_BATTLEFIELD_STATUS {
            QueueSlot = queueSlot,
            ArenaType = arenaType,
            IsArena = isArena,
            BattlegroundType = battlegroundType,
            Unknown1 = unknown1,
            MinimumLevel = minimumLevel,
            MaximumLevel = maximumLevel,
            ClientInstanceId = clientInstanceId,
            Rated = rated,
            StatusId = statusId,
        };
    }

    internal int Size() {
        var size = 0;

        // queue_slot: Generator.Generated.DataTypeInteger
        size += 4;

        // arena_type: Generator.Generated.DataTypeEnum
        size += 1;

        // is_arena: Generator.Generated.DataTypeInteger
        size += 1;

        // battleground_type: Generator.Generated.DataTypeEnum
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 2;

        // minimum_level: Generator.Generated.DataTypeInteger
        size += 1;

        // maximum_level: Generator.Generated.DataTypeInteger
        size += 1;

        // client_instance_id: Generator.Generated.DataTypeInteger
        size += 4;

        // rated: Generator.Generated.DataTypeBool
        size += 1;

        // status_id: Generator.Generated.DataTypeEnum
        size += 1;

        if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitQueue statusIdWaitQueue) {
            // average_wait_time_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

            // time_in_queue_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitJoin statusIdWaitJoin) {
            // map1: Generator.Generated.DataTypeEnum
            size += 4;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 8;

            // time_to_remove_in_queue_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdInProgress statusIdInProgress) {
            // map2: Generator.Generated.DataTypeEnum
            size += 4;

            // unknown3: Generator.Generated.DataTypeInteger
            size += 8;

            // time_to_bg_autoleave_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

            // time_to_bg_start_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

            // faction: Generator.Generated.DataTypeEnum
            size += 1;

        }

        return size;
    }

}

