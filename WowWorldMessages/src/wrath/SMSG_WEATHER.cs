using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_WEATHER: WrathServerMessage, IWorldMessage {
    public required Wrath.WeatherType WeatherType { get; set; }
    public required float Grade { get; set; }
    public required Wrath.WeatherChangeType Change { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)WeatherType, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Grade, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Change, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 11, 756, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 11, 756, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_WEATHER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var weatherType = (Wrath.WeatherType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var grade = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var change = (Wrath.WeatherChangeType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_WEATHER {
            WeatherType = weatherType,
            Grade = grade,
            Change = change,
        };
    }

}

