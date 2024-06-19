using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_GUILD_FILTER: WrathClientMessage, IWorldMessage {
    public required uint MinimumLevel { get; set; }
    public required uint MaximumLevel { get; set; }
    public required uint MinimumRank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(MinimumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaximumLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MinimumRank, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 1067, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 16, 1067, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_GUILD_FILTER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var minimumLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maximumLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var minimumRank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_CALENDAR_GUILD_FILTER {
            MinimumLevel = minimumLevel,
            MaximumLevel = maximumLevel,
            MinimumRank = minimumRank,
        };
    }

}

