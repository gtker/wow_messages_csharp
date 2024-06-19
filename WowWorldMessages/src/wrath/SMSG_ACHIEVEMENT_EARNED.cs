using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ACHIEVEMENT_EARNED: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required uint Achievement { get; set; }
    public required uint EarnTime { get; set; }
    /// <summary>
    /// All emus set to 0.
    /// </summary>
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Achievement, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EarnTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1128, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1128, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ACHIEVEMENT_EARNED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var achievement = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var earnTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ACHIEVEMENT_EARNED {
            Player = player,
            Achievement = achievement,
            EarnTime = earnTime,
            Unknown = unknown,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // achievement: Generator.Generated.DataTypeInteger
        size += 4;

        // earn_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

