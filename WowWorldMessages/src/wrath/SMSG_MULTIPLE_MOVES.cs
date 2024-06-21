using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MULTIPLE_MOVES: WrathServerMessage, IWorldMessage {
    public required List<MiniMoveMessage> Moves { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Size(), cancellationToken).ConfigureAwait(false);

        foreach (var v in Moves) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1310, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1310, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MULTIPLE_MOVES> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var moves = new List<MiniMoveMessage>();
        while (__size < bodySize) {
            moves.Add(await Wrath.MiniMoveMessage.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            __size += moves[^1].Size();
        }

        return new SMSG_MULTIPLE_MOVES {
            Moves = moves,
        };
    }

    internal int Size() {
        var size = 0;

        // size: Generator.Generated.DataTypeInteger
        size += 4;

        // moves: Generator.Generated.DataTypeArray
        size += Moves.Sum(e => e.Size());

        return size;
    }

}

