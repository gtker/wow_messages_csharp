using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ALL_ACHIEVEMENT_DATA: WrathServerMessage, IWorldMessage {
    public required List<AchievementDone> Done { get; set; }
    public required List<AchievementInProgress> InProgress { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await ReadUtils.WriteAchievementDoneArray(Done, w, cancellationToken).ConfigureAwait(false);

        await ReadUtils.WriteAchievementInProgressArray(InProgress, w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1149, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1149, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ALL_ACHIEVEMENT_DATA> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var done = await ReadUtils.ReadAchievementDoneArray(r, cancellationToken).ConfigureAwait(false);

        var inProgress = await ReadUtils.ReadAchievementInProgressArray(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_ALL_ACHIEVEMENT_DATA {
            Done = done,
            InProgress = inProgress,
        };
    }

    internal int Size() {
        var size = 0;

        // done: Generator.Generated.DataTypeAchievementDoneArray
        size += Done.Count * 2;

        // in_progress: Generator.Generated.DataTypeAchievementInProgressArray
        size += InProgress.Sum(e => e.Size());

        return size;
    }

}

