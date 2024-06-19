using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_SET_DUNGEON_DIFFICULTY_Server: TbcServerMessage, IWorldMessage {
    public required Tbc.DungeonDifficulty Difficulty { get; set; }
    /// <summary>
    /// ArcEmu hardcodes this to 1
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required bool IsInGroup { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(IsInGroup, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 809, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 14, 809, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_SET_DUNGEON_DIFFICULTY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var difficulty = (Tbc.DungeonDifficulty)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var isInGroup = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new MSG_SET_DUNGEON_DIFFICULTY_Server {
            Difficulty = difficulty,
            Unknown1 = unknown1,
            IsInGroup = isInGroup,
        };
    }

}

