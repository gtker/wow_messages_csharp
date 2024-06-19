using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_RAID_LOCKOUT_UPDATED: WrathServerMessage, IWorldMessage {
    public required uint CurrentTime { get; set; }
    public required Wrath.Map Map { get; set; }
    public required uint Difficulty { get; set; }
    public required uint OldTimeToUpdate { get; set; }
    public required uint NewTimeToUpdate { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(CurrentTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(OldTimeToUpdate, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(NewTimeToUpdate, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 22, 1137, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 22, 1137, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_RAID_LOCKOUT_UPDATED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var currentTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var difficulty = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var oldTimeToUpdate = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var newTimeToUpdate = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_RAID_LOCKOUT_UPDATED {
            CurrentTime = currentTime,
            Map = map,
            Difficulty = difficulty,
            OldTimeToUpdate = oldTimeToUpdate,
            NewTimeToUpdate = newTimeToUpdate,
        };
    }

}

