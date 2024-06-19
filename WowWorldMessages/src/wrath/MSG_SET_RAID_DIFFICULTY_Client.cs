using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_SET_RAID_DIFFICULTY_Client: WrathClientMessage, IWorldMessage {
    public required Wrath.RaidDifficulty Difficulty { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Difficulty, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 8, 1259, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 8, 1259, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_SET_RAID_DIFFICULTY_Client> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var difficulty = (Wrath.RaidDifficulty)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_SET_RAID_DIFFICULTY_Client {
            Difficulty = difficulty,
        };
    }

}

