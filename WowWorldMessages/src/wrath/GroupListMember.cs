using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GroupListMember {
    public required string Name { get; set; }
    public required ulong Guid { get; set; }
    public required bool IsOnline { get; set; }
    public required byte GroupId { get; set; }
    /// <summary>
    /// mangosone: 0x2 main assist, 0x4 main tank
    /// </summary>
    public required byte Flags { get; set; }
    public required byte LfgRoles { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(IsOnline, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(GroupId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(LfgRoles, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GroupListMember> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var isOnline = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var groupId = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var lfgRoles = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new GroupListMember {
            Name = name,
            Guid = guid,
            IsOnline = isOnline,
            GroupId = groupId,
            Flags = flags,
            LfgRoles = lfgRoles,
        };
    }

    internal int Size() {
        var size = 0;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // is_online: Generator.Generated.DataTypeBool
        size += 1;

        // group_id: Generator.Generated.DataTypeInteger
        size += 1;

        // flags: Generator.Generated.DataTypeInteger
        size += 1;

        // lfg_roles: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

