using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_JOIN_RESULT: WrathServerMessage, IWorldMessage {
    public required uint Result { get; set; }
    public required uint State { get; set; }
    public required List<LfgJoinPlayer> Players { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Result, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(State, cancellationToken).ConfigureAwait(false);

        foreach (var v in Players) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 868, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 868, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_JOIN_RESULT> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var result = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var state = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var players = new List<LfgJoinPlayer>();
        while (__size < bodySize) {
            players.Add(await Wrath.LfgJoinPlayer.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            __size += players[^1].Size();
        }

        return new SMSG_LFG_JOIN_RESULT {
            Result = result,
            State = state,
            Players = players,
        };
    }

    internal int Size() {
        var size = 0;

        // result: Generator.Generated.DataTypeInteger
        size += 4;

        // state: Generator.Generated.DataTypeInteger
        size += 4;

        // players: Generator.Generated.DataTypeArray
        size += Players.Sum(e => e.Size());

        return size;
    }

}

