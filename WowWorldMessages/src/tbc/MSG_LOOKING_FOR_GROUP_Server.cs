using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_LOOKING_FOR_GROUP_Server: TbcServerMessage, IWorldMessage {
    public required Tbc.LfgType LfgType { get; set; }
    /// <summary>
    /// entry from LfgDunggeons.dbc
    /// </summary>
    public required uint Entry { get; set; }
    public required uint AmountOfPlayersFound { get; set; }
    public required List<LfgPlayer> PlayersDisplayed { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)LfgType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Entry, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)PlayersDisplayed.Count, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfPlayersFound, cancellationToken).ConfigureAwait(false);

        foreach (var v in PlayersDisplayed) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_LOOKING_FOR_GROUP_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var lfgType = (Tbc.LfgType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var entry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPlayersDisplayed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var amountOfPlayersFound = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var playersDisplayed = new List<LfgPlayer>();
        for (var i = 0; i < amountOfPlayersDisplayed; ++i) {
            playersDisplayed.Add(await Tbc.LfgPlayer.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new MSG_LOOKING_FOR_GROUP_Server {
            LfgType = lfgType,
            Entry = entry,
            AmountOfPlayersFound = amountOfPlayersFound,
            PlayersDisplayed = playersDisplayed,
        };
    }

    internal int Size() {
        var size = 0;

        // lfg_type: Generator.Generated.DataTypeEnum
        size += 4;

        // entry: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_players_displayed: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_players_found: Generator.Generated.DataTypeInteger
        size += 4;

        // players_displayed: Generator.Generated.DataTypeArray
        size += PlayersDisplayed.Sum(e => e.Size());

        return size;
    }

}

