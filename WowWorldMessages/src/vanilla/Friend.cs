using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using FriendStatusType = OneOf.OneOf<Friend.FriendStatusAfk, Friend.FriendStatusDnd, Friend.FriendStatusOnline, Friend.FriendStatusUnknown3, FriendStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Friend {
    public class FriendStatusAfk {
        public required Area Area { get; set; }
        public required Class ClassType { get; set; }
        public required uint Level { get; set; }
    }
    public class FriendStatusDnd {
        public required Area Area { get; set; }
        public required Class ClassType { get; set; }
        public required uint Level { get; set; }
    }
    public class FriendStatusOnline {
        public required Area Area { get; set; }
        public required Class ClassType { get; set; }
        public required uint Level { get; set; }
    }
    public class FriendStatusUnknown3 {
        public required Area Area { get; set; }
        public required Class ClassType { get; set; }
        public required uint Level { get; set; }
    }
    public required ulong Guid { get; set; }
    public required FriendStatusType Status { get; set; }
    internal FriendStatus StatusValue => Status.Match(
        _ => Vanilla.FriendStatus.Afk,
        _ => Vanilla.FriendStatus.Dnd,
        _ => Vanilla.FriendStatus.Online,
        _ => Vanilla.FriendStatus.Unknown3,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)StatusValue, cancellationToken).ConfigureAwait(false);

        if (Status.Value is Friend.FriendStatusOnline online) {
            await w.WriteUInt((uint)online.Area, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(online.Level, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)online.ClassType, cancellationToken).ConfigureAwait(false);

        }
        else if (Status.Value is Friend.FriendStatusAfk afk) {
            await w.WriteUInt((uint)afk.Area, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(afk.Level, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)afk.ClassType, cancellationToken).ConfigureAwait(false);

        }
        else if (Status.Value is Friend.FriendStatusUnknown3 unknown3) {
            await w.WriteUInt((uint)unknown3.Area, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(unknown3.Level, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)unknown3.ClassType, cancellationToken).ConfigureAwait(false);

        }
        else if (Status.Value is Friend.FriendStatusDnd dnd) {
            await w.WriteUInt((uint)dnd.Area, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(dnd.Level, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)dnd.ClassType, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<Friend> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        FriendStatusType status = (FriendStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (status.Value is Vanilla.FriendStatus.Online) {
            var area = (Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var classType = (Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            status = new FriendStatusOnline {
                Area = area,
                ClassType = classType,
                Level = level,
            };
        }
        else if (status.Value is Vanilla.FriendStatus.Afk) {
            var area = (Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var classType = (Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            status = new FriendStatusAfk {
                Area = area,
                ClassType = classType,
                Level = level,
            };
        }
        else if (status.Value is Vanilla.FriendStatus.Unknown3) {
            var area = (Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var classType = (Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            status = new FriendStatusUnknown3 {
                Area = area,
                ClassType = classType,
                Level = level,
            };
        }
        else if (status.Value is Vanilla.FriendStatus.Dnd) {
            var area = (Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var classType = (Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            status = new FriendStatusDnd {
                Area = area,
                ClassType = classType,
                Level = level,
            };
        }

        return new Friend {
            Guid = guid,
            Status = status,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: WowMessages.Generator.Generated.DataTypeGuid
        size += 8;

        // status: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        if (Status.Value is Friend.FriendStatusOnline online) {
            // area: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

            // level: WowMessages.Generator.Generated.DataTypeLevel32
            size += 4;

            // class_type: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

        }
        else if (Status.Value is Friend.FriendStatusAfk afk) {
            // area: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

            // level: WowMessages.Generator.Generated.DataTypeLevel32
            size += 4;

            // class_type: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

        }
        else if (Status.Value is Friend.FriendStatusUnknown3 unknown3) {
            // area: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

            // level: WowMessages.Generator.Generated.DataTypeLevel32
            size += 4;

            // class_type: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

        }
        else if (Status.Value is Friend.FriendStatusDnd dnd) {
            // area: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

            // level: WowMessages.Generator.Generated.DataTypeLevel32
            size += 4;

            // class_type: WowMessages.Generator.Generated.DataTypeEnum
            size += 4;

        }

        return size;
    }

}

