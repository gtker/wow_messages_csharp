using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PLAYED_TIME: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Time played in total (seconds)
    /// </summary>
    public required uint TotalPlayedTime { get; set; }
    /// <summary>
    /// Time played on this level (seconds)
    /// </summary>
    public required uint LevelPlayedTime { get; set; }
    /// <summary>
    /// Whether this is a silent query or the client should show it on the UI (chat box).
    /// Send back the value received in [CMSG_PLAYED_TIME]
    /// </summary>
    public required bool ShowOnUi { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(TotalPlayedTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LevelPlayedTime, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(ShowOnUi, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 11, 461, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 11, 461, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PLAYED_TIME> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var totalPlayedTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var levelPlayedTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var showOnUi = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_PLAYED_TIME {
            TotalPlayedTime = totalPlayedTime,
            LevelPlayedTime = levelPlayedTime,
            ShowOnUi = showOnUi,
        };
    }

}

