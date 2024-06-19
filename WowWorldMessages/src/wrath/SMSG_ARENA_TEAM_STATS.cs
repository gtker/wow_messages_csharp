using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_STATS: WrathServerMessage, IWorldMessage {
    public required uint ArenaTeam { get; set; }
    public required uint Rating { get; set; }
    public required uint GamesPlayedThisWeek { get; set; }
    public required uint GamesWonThisWeek { get; set; }
    public required uint GamesPlayedThisSeason { get; set; }
    public required uint GamesWonThisSeason { get; set; }
    public required uint Ranking { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rating, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesPlayedThisWeek, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesWonThisWeek, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesPlayedThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GamesWonThisSeason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Ranking, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 30, 859, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 30, 859, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_STATS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rating = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesPlayedThisWeek = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesWonThisWeek = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesPlayedThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gamesWonThisSeason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var ranking = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ARENA_TEAM_STATS {
            ArenaTeam = arenaTeam,
            Rating = rating,
            GamesPlayedThisWeek = gamesPlayedThisWeek,
            GamesWonThisWeek = gamesWonThisWeek,
            GamesPlayedThisSeason = gamesPlayedThisSeason,
            GamesWonThisSeason = gamesWonThisSeason,
            Ranking = ranking,
        };
    }

}

