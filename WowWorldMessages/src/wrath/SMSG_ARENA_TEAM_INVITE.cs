using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_INVITE: WrathServerMessage, IWorldMessage {
    public required string PlayerName { get; set; }
    public required string TeamName { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(PlayerName, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(TeamName, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 848, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 848, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_INVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var playerName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var teamName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_ARENA_TEAM_INVITE {
            PlayerName = playerName,
            TeamName = teamName,
        };
    }

    internal int Size() {
        var size = 0;

        // player_name: Generator.Generated.DataTypeCstring
        size += PlayerName.Length + 1;

        // team_name: Generator.Generated.DataTypeCstring
        size += TeamName.Length + 1;

        return size;
    }

}

