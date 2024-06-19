using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_COMMAND_RESULT: TbcServerMessage, IWorldMessage {
    public required Tbc.ArenaTeamCommand Command { get; set; }
    public required string Team { get; set; }
    public required string Player { get; set; }
    public required Tbc.ArenaTeamCommandError Error { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Command, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Team, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Error, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 841, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 841, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_COMMAND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var command = (Tbc.ArenaTeamCommand)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var team = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var error = (Tbc.ArenaTeamCommandError)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ARENA_TEAM_COMMAND_RESULT {
            Command = command,
            Team = team,
            Player = player,
            Error = error,
        };
    }

    internal int Size() {
        var size = 0;

        // command: Generator.Generated.DataTypeEnum
        size += 4;

        // team: Generator.Generated.DataTypeCstring
        size += Team.Length + 1;

        // player: Generator.Generated.DataTypeCstring
        size += Player.Length + 1;

        // error: Generator.Generated.DataTypeEnum
        size += 4;

        return size;
    }

}

