using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgListGroup {
    public class LfgUpdateFlagType {
        public required LfgUpdateFlag Inner;
        public LfgUpdateFlagComment? Comment;
        public LfgUpdateFlagRoles? Roles;
    }
    public class LfgUpdateFlagComment {
        public required string Comment { get; set; }
    }
    public class LfgUpdateFlagRoles {
        /// <summary>
        /// Emu just sets all to 0.
        /// </summary>
        public const int RolesLength = 3;
        public required byte[] Roles { get; set; }
    }
    public required ulong Group { get; set; }
    public required LfgUpdateFlagType Flags { get; set; }
    public required ulong Instance { get; set; }
    public required uint EncounterMask { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Group, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        if (Flags.Comment is {} lfgUpdateFlagComment) {
            await w.WriteCString(lfgUpdateFlagComment.Comment, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Roles is {} lfgUpdateFlagRoles) {
            foreach (var v in lfgUpdateFlagRoles.Roles) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

        }

        await w.WriteULong(Instance, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EncounterMask, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgListGroup> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var group = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var flags = new LfgUpdateFlagType {
            Inner = (LfgUpdateFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Comment)) {
            var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            flags.Comment = new LfgUpdateFlagComment {
                Comment = comment,
            };
        }

        if (flags.Inner.HasFlag(Wrath.LfgUpdateFlag.Roles)) {
            var roles = new byte[LfgUpdateFlagRoles.RolesLength];
            for (var i = 0; i < LfgUpdateFlagRoles.RolesLength; ++i) {
                roles[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            flags.Roles = new LfgUpdateFlagRoles {
                Roles = roles,
            };
        }

        var instance = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var encounterMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new LfgListGroup {
            Group = group,
            Flags = flags,
            Instance = instance,
            EncounterMask = encounterMask,
        };
    }

    internal int Size() {
        var size = 0;

        // group: Generator.Generated.DataTypeGuid
        size += 8;

        // flags: Generator.Generated.DataTypeFlag
        size += 4;

        if (Flags.Comment is {} lfgUpdateFlagComment) {
            // comment: Generator.Generated.DataTypeCstring
            size += lfgUpdateFlagComment.Comment.Length + 1;

        }

        if (Flags.Roles is {} lfgUpdateFlagRoles) {
            // roles: Generator.Generated.DataTypeArray
            size += lfgUpdateFlagRoles.Roles.Sum(e => 1);

        }

        // instance: Generator.Generated.DataTypeGuid
        size += 8;

        // encounter_mask: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

