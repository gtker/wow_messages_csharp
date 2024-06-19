using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUERY_TIME_RESPONSE: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Seconds since 1970, 1st of January (Unix Time).
    /// </summary>
    public required uint Time { get; set; }
    /// <summary>
    /// Units need confirmation, but it's likely in seconds, since many other time related things are also seconds.
    /// </summary>
    public required uint TimeUntilDailyQuestReset { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeUntilDailyQuestReset, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 463, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 10, 463, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUERY_TIME_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeUntilDailyQuestReset = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_QUERY_TIME_RESPONSE {
            Time = time,
            TimeUntilDailyQuestReset = timeUntilDailyQuestReset,
        };
    }

}
