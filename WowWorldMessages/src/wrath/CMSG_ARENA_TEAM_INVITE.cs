using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_ARENA_TEAM_INVITE: WrathClientMessage, IWorldMessage {
    public required uint ArenaTeam { get; set; }
    public required string Player { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Player, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 847, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 847, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_ARENA_TEAM_INVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_ARENA_TEAM_INVITE {
            ArenaTeam = arenaTeam,
            Player = player,
        };
    }

    internal int Size() {
        var size = 0;

        // arena_team: Generator.Generated.DataTypeInteger
        size += 4;

        // player: Generator.Generated.DataTypeCstring
        size += Player.Length + 1;

        return size;
    }

}

