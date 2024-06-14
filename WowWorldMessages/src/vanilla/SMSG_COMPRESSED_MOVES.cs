using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_COMPRESSED_MOVES: VanillaServerMessage, IWorldMessage {
    public required List<CompressedMove> Moves { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        foreach (var v in Moves) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 763, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 763, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_COMPRESSED_MOVES> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var moves = new List<CompressedMove>();
        while (size <= bodySize) {
            moves.Add(await Vanilla.CompressedMove.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            size += moves[^1].Size();
        }

        return new SMSG_COMPRESSED_MOVES {
            Moves = moves,
        };
    }

    internal int Size() {
        var size = 0;

        // moves: Generator.Generated.DataTypeArray
        size += Moves.Sum(e => e.Size());

        return size;
    }

}

