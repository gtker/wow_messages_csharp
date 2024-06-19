using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_INSPECT_ARENA_TEAMS_Server: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required byte Slot { get; set; }
    public required uint ArenaTeam { get; set; }
    public required uint Rating { get; set; }
    public required uint GamesPlayedThisSeason { get; set; }
    public required uint WinsThisSeason { get; set; }
    public required uint TotalGamesPlayed { get; set; }
    public required uint PersonalRating { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Slot, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rating, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesPlayedThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(WinsThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TotalGamesPlayed, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PersonalRating, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 35, 887, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 35, 887, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_INSPECT_ARENA_TEAMS_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesPlayedThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var winsThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var totalGamesPlayed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var personalRating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_INSPECT_ARENA_TEAMS_Server {
            Player = player,
            Slot = slot,
            ArenaTeam = arenaTeam,
            Rating = rating,
            GamesPlayedThisSeason = gamesPlayedThisSeason,
            WinsThisSeason = winsThisSeason,
            TotalGamesPlayed = totalGamesPlayed,
            PersonalRating = personalRating,
        };
    }

}

