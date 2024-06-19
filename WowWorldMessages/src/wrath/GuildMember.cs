using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using GuildMemberStatusType = OneOf.OneOf<GuildMember.GuildMemberStatusOffline, GuildMemberStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildMember {
    public class GuildMemberStatusOffline {
        public required float TimeOffline { get; set; }
    }
    public required ulong Guid { get; set; }
    /// <summary>
    /// arcemu: high guid
    /// </summary>
    public required uint Unknown { get; set; }
    public required GuildMemberStatusType Status { get; set; }
    internal GuildMemberStatus StatusValue => Status.Match(
        _ => Wrath.GuildMemberStatus.Offline,
        v => v
    );
    public required string Name { get; set; }
    public required uint Rank { get; set; }
    public required byte Level { get; set; }
    public required Wrath.Class ClassType { get; set; }
    public required Wrath.Gender Gender { get; set; }
    public required Wrath.Area Area { get; set; }
    public required string PublicNote { get; set; }
    public required string OfficerNote { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)StatusValue, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rank, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ClassType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        if (Status.Value is GuildMember.GuildMemberStatusOffline guildMemberStatusOffline) {
            await w.WriteFloat(guildMemberStatusOffline.TimeOffline, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteCString(PublicNote, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(OfficerNote, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GuildMember> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        GuildMemberStatusType status = (Wrath.GuildMemberStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var classType = (Wrath.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Wrath.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (status.Value is Wrath.GuildMemberStatus.Offline) {
            var timeOffline = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            status = new GuildMemberStatusOffline {
                TimeOffline = timeOffline,
            };
        }

        var publicNote = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var officerNote = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new GuildMember {
            Guid = guid,
            Unknown = unknown,
            Status = status,
            Name = name,
            Rank = rank,
            Level = level,
            ClassType = classType,
            Gender = gender,
            Area = area,
            PublicNote = publicNote,
            OfficerNote = officerNote,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        // status: Generator.Generated.DataTypeEnum
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // rank: Generator.Generated.DataTypeInteger
        size += 4;

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // class_type: Generator.Generated.DataTypeEnum
        size += 1;

        // gender: Generator.Generated.DataTypeEnum
        size += 1;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        if (Status.Value is GuildMember.GuildMemberStatusOffline guildMemberStatusOffline) {
            // time_offline: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        // public_note: Generator.Generated.DataTypeCstring
        size += PublicNote.Length + 1;

        // officer_note: Generator.Generated.DataTypeCstring
        size += OfficerNote.Length + 1;

        return size;
    }

}

