using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_SET_DUNGEON_DIFFICULTY_Client: TbcClientMessage, IWorldMessage {
    public required Tbc.DungeonDifficulty Difficulty { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Difficulty, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 8, 809, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 8, 809, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_SET_DUNGEON_DIFFICULTY_Client> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var difficulty = (Tbc.DungeonDifficulty)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_SET_DUNGEON_DIFFICULTY_Client {
            Difficulty = difficulty,
        };
    }

}
