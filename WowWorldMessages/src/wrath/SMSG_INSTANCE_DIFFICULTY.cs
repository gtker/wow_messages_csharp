using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSTANCE_DIFFICULTY: WrathServerMessage, IWorldMessage {
    public required uint Difficulty { get; set; }
    public required bool DynamicDifficulty { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(DynamicDifficulty, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 827, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 10, 827, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSTANCE_DIFFICULTY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var difficulty = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dynamicDifficulty = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new SMSG_INSTANCE_DIFFICULTY {
            Difficulty = difficulty,
            DynamicDifficulty = dynamicDifficulty,
        };
    }

}

