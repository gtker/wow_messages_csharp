using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_OVERRIDE_LIGHT: TbcServerMessage, IWorldMessage {
    public required uint DefaultId { get; set; }
    public required uint IdOverride { get; set; }
    public required uint FadeInTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DefaultId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(IdOverride, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(FadeInTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 1041, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 14, 1041, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_OVERRIDE_LIGHT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var defaultId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var idOverride = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var fadeInTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_OVERRIDE_LIGHT {
            DefaultId = defaultId,
            IdOverride = idOverride,
            FadeInTime = fadeInTime,
        };
    }

}

