using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ArenaTeamMember {
    public required ulong Guid { get; set; }
    public required bool Online { get; set; }
    public required string Name { get; set; }
    public required byte Level { get; set; }
    public required Tbc.Class ClassType { get; set; }
    public required uint GamesPlayedThisWeek { get; set; }
    public required uint WinsThisWeek { get; set; }
    public required uint GamesPlayedThisSeason { get; set; }
    public required uint WinsThisSeason { get; set; }
    public required uint PersonalRating { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Online, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ClassType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesPlayedThisWeek, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(WinsThisWeek, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesPlayedThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(WinsThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PersonalRating, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ArenaTeamMember> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var online = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var classType = (Tbc.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gamesPlayedThisWeek = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var winsThisWeek = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesPlayedThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var winsThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var personalRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new ArenaTeamMember {
            Guid = guid,
            Online = online,
            Name = name,
            Level = level,
            ClassType = classType,
            GamesPlayedThisWeek = gamesPlayedThisWeek,
            WinsThisWeek = winsThisWeek,
            GamesPlayedThisSeason = gamesPlayedThisSeason,
            WinsThisSeason = winsThisSeason,
            PersonalRating = personalRating,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // online: Generator.Generated.DataTypeBool
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // class_type: Generator.Generated.DataTypeEnum
        size += 1;

        // games_played_this_week: Generator.Generated.DataTypeInteger
        size += 4;

        // wins_this_week: Generator.Generated.DataTypeInteger
        size += 4;

        // games_played_this_season: Generator.Generated.DataTypeInteger
        size += 4;

        // wins_this_season: Generator.Generated.DataTypeInteger
        size += 4;

        // personal_rating: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

