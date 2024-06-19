using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_QUERY_RESPONSE: TbcServerMessage, IWorldMessage {
    public required uint ArenaTeam { get; set; }
    public required string TeamName { get; set; }
    public required Tbc.ArenaType TeamType { get; set; }
    public required uint BackgroundColor { get; set; }
    public required uint EmblemStyle { get; set; }
    public required uint EmblemColor { get; set; }
    public required uint BorderStyle { get; set; }
    public required uint BorderColor { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(TeamName, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)TeamType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BackgroundColor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EmblemStyle, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EmblemColor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BorderStyle, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BorderColor, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 844, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 844, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var teamName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var teamType = (Tbc.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var backgroundColor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emblemStyle = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emblemColor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var borderStyle = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var borderColor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ARENA_TEAM_QUERY_RESPONSE {
            ArenaTeam = arenaTeam,
            TeamName = teamName,
            TeamType = teamType,
            BackgroundColor = backgroundColor,
            EmblemStyle = emblemStyle,
            EmblemColor = emblemColor,
            BorderStyle = borderStyle,
            BorderColor = borderColor,
        };
    }

    internal int Size() {
        var size = 0;

        // arena_team: Generator.Generated.DataTypeInteger
        size += 4;

        // team_name: Generator.Generated.DataTypeCstring
        size += TeamName.Length + 1;

        // team_type: Generator.Generated.DataTypeEnum
        size += 1;

        // background_color: Generator.Generated.DataTypeInteger
        size += 4;

        // emblem_style: Generator.Generated.DataTypeInteger
        size += 4;

        // emblem_color: Generator.Generated.DataTypeInteger
        size += 4;

        // border_style: Generator.Generated.DataTypeInteger
        size += 4;

        // border_color: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

