using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CRITERIA_UPDATE: WrathServerMessage, IWorldMessage {
    public required uint Achievement { get; set; }
    /// <summary>
    /// trinitycore/azerothcore: This is a u32 passed to the `appendPackGUID` function which promotes it to u64.
    /// </summary>
    public required ulong ProgressCounter { get; set; }
    public required ulong Player { get; set; }
    /// <summary>
    /// trinitycore: this are some flags, 1 is for keeping the counter at 0 in client
    /// </summary>
    public required uint Flags { get; set; }
    public required uint Time { get; set; }
    public required uint TimeElapsed { get; set; }
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Achievement, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(ProgressCounter, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeElapsed, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1130, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1130, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CRITERIA_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var achievement = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var progressCounter = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeElapsed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CRITERIA_UPDATE {
            Achievement = achievement,
            ProgressCounter = progressCounter,
            Player = player,
            Flags = flags,
            Time = time,
            TimeElapsed = timeElapsed,
            Unknown = unknown,
        };
    }

    internal int Size() {
        var size = 0;

        // achievement: Generator.Generated.DataTypeInteger
        size += 4;

        // progress_counter: Generator.Generated.DataTypePackedGuid
        size += ProgressCounter.PackedGuidLength();

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // time: Generator.Generated.DataTypeDateTime
        size += 4;

        // time_elapsed: Generator.Generated.DataTypeSeconds
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

