using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using RaidTargetIndexType = OneOf.OneOf<MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown0, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown1, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown2, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown3, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown4, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown5, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown6, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown7, MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown8, RaidTargetIndex>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_RAID_TARGET_UPDATE_Client: VanillaClientMessage, IWorldMessage {
    public class RaidTargetIndexUnknown0 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown1 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown2 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown3 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown4 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown5 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown6 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown7 {
        public required ulong Target { get; set; }
    }
    public class RaidTargetIndexUnknown8 {
        public required ulong Target { get; set; }
    }
    public required RaidTargetIndexType TargetIndex { get; set; }
    internal RaidTargetIndex TargetIndexValue => TargetIndex.Match(
        _ => Vanilla.RaidTargetIndex.Unknown0,
        _ => Vanilla.RaidTargetIndex.Unknown1,
        _ => Vanilla.RaidTargetIndex.Unknown2,
        _ => Vanilla.RaidTargetIndex.Unknown3,
        _ => Vanilla.RaidTargetIndex.Unknown4,
        _ => Vanilla.RaidTargetIndex.Unknown5,
        _ => Vanilla.RaidTargetIndex.Unknown6,
        _ => Vanilla.RaidTargetIndex.Unknown7,
        _ => Vanilla.RaidTargetIndex.Unknown8,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)TargetIndexValue, cancellationToken).ConfigureAwait(false);

        if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown0 unknown0) {
            await w.WriteULong(unknown0.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown1 unknown1) {
            await w.WriteULong(unknown1.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown2 unknown2) {
            await w.WriteULong(unknown2.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown3 unknown3) {
            await w.WriteULong(unknown3.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown4 unknown4) {
            await w.WriteULong(unknown4.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown5 unknown5) {
            await w.WriteULong(unknown5.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown6 unknown6) {
            await w.WriteULong(unknown6.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown7 unknown7) {
            await w.WriteULong(unknown7.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown8 unknown8) {
            await w.WriteULong(unknown8.Target, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 801, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 801, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_RAID_TARGET_UPDATE_Client> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        RaidTargetIndexType targetIndex = (RaidTargetIndex)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown0) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown0 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown1) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown1 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown2) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown2 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown3) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown3 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown4) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown4 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown5) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown5 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown6) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown6 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown7) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown7 {
                Target = target,
            };
        }
        else if (targetIndex.Value is Vanilla.RaidTargetIndex.Unknown8) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            targetIndex = new RaidTargetIndexUnknown8 {
                Target = target,
            };
        }

        return new MSG_RAID_TARGET_UPDATE_Client {
            TargetIndex = targetIndex,
        };
    }

    internal int Size() {
        var size = 0;

        // target_index: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown0 unknown0) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown1 unknown1) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown2 unknown2) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown3 unknown3) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown4 unknown4) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown5 unknown5) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown6 unknown6) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown7 unknown7) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (TargetIndex.Value is MSG_RAID_TARGET_UPDATE_Client.RaidTargetIndexUnknown8 unknown8) {
            // target: WowMessages.Generator.Generated.DataTypeGuid
            size += 8;

        }

        return size;
    }

}

