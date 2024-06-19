using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_SET_RAID_DIFFICULTY_Server: WrathServerMessage, IWorldMessage {
    public required Wrath.RaidDifficulty Difficulty { get; set; }
    /// <summary>
    /// Emus set to 1.
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required bool InGroup { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(InGroup, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 1259, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 14, 1259, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_SET_RAID_DIFFICULTY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var difficulty = (Wrath.RaidDifficulty)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var inGroup = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new MSG_SET_RAID_DIFFICULTY_Server {
            Difficulty = difficulty,
            Unknown1 = unknown1,
            InGroup = inGroup,
        };
    }

}

