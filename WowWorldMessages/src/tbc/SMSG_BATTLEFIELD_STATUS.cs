using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using StatusIdType = OneOf.OneOf<SMSG_BATTLEFIELD_STATUS.StatusIdInProgress, SMSG_BATTLEFIELD_STATUS.StatusIdWaitJoin, SMSG_BATTLEFIELD_STATUS.StatusIdWaitQueue, StatusId>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_STATUS: TbcServerMessage, IWorldMessage {
    public class StatusIdInProgress {
        public required uint TimeToBgAutoleaveInMs { get; set; }
        public required uint TimeToBgStartInMs { get; set; }
    }
    public class StatusIdWaitJoin {
        public required uint TimeToRemoveInQueueInMs { get; set; }
    }
    public class StatusIdWaitQueue {
        public required uint AverageWaitTimeInMs { get; set; }
        public required uint TimeInQueueInMs { get; set; }
    }
    /// <summary>
    /// vmangos: players can be in 3 queues at the same time (0..2)
    /// </summary>
    public required uint QueueSlot { get; set; }
    public required Tbc.ArenaType ArenaType { get; set; }
    /// <summary>
    /// mangosone sets to 0x0D.
    /// </summary>
    public required byte Unknown1 { get; set; }
    public required Tbc.BattlegroundType BattlegroundType { get; set; }
    /// <summary>
    /// mangosone sets to 0x1F90
    /// </summary>
    public required ushort Unknown2 { get; set; }
    public required uint ClientInstanceId { get; set; }
    public required bool Rated { get; set; }
    public required StatusIdType StatusId { get; set; }
    internal StatusId StatusIdValue => StatusId.Match(
        _ => Tbc.StatusId.InProgress,
        _ => Tbc.StatusId.WaitJoin,
        _ => Tbc.StatusId.WaitQueue,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QueueSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ArenaType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)BattlegroundType, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ClientInstanceId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Rated, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)StatusIdValue, cancellationToken).ConfigureAwait(false);

        if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitQueue statusIdWaitQueue) {
            await w.WriteUInt(statusIdWaitQueue.AverageWaitTimeInMs, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdWaitQueue.TimeInQueueInMs, cancellationToken).ConfigureAwait(false);

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdWaitJoin statusIdWaitJoin) {
            await w.WriteUInt(statusIdWaitJoin.TimeToRemoveInQueueInMs, cancellationToken).ConfigureAwait(false);

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdInProgress statusIdInProgress) {
            await w.WriteUInt(statusIdInProgress.TimeToBgAutoleaveInMs, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(statusIdInProgress.TimeToBgStartInMs, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 724, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 724, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var queueSlot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaType = (Tbc.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var battlegroundType = (Tbc.BattlegroundType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var clientInstanceId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rated = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        StatusIdType statusId = (Tbc.StatusId)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (statusId.Value is Tbc.StatusId.WaitQueue) {
            var averageWaitTimeInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var timeInQueueInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdWaitQueue {
                AverageWaitTimeInMs = averageWaitTimeInMs,
                TimeInQueueInMs = timeInQueueInMs,
            };
        }
        else if (statusId.Value is Tbc.StatusId.WaitJoin) {
            var timeToRemoveInQueueInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdWaitJoin {
                TimeToRemoveInQueueInMs = timeToRemoveInQueueInMs,
            };
        }
        else if (statusId.Value is Tbc.StatusId.InProgress) {
            var timeToBgAutoleaveInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var timeToBgStartInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            statusId = new StatusIdInProgress {
                TimeToBgAutoleaveInMs = timeToBgAutoleaveInMs,
                TimeToBgStartInMs = timeToBgStartInMs,
            };
        }

        return new SMSG_BATTLEFIELD_STATUS {
            QueueSlot = queueSlot,
            ArenaType = arenaType,
            Unknown1 = unknown1,
            BattlegroundType = battlegroundType,
            Unknown2 = unknown2,
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

        // unknown1: Generator.Generated.DataTypeInteger
        size += 1;

        // battleground_type: Generator.Generated.DataTypeEnum
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 2;

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
            // time_to_remove_in_queue_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (StatusId.Value is SMSG_BATTLEFIELD_STATUS.StatusIdInProgress statusIdInProgress) {
            // time_to_bg_autoleave_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

            // time_to_bg_start_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

