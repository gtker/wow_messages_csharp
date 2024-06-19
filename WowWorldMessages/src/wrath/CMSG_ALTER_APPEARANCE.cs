using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_ALTER_APPEARANCE: WrathClientMessage, IWorldMessage {
    public required uint Hair { get; set; }
    public required uint HairColor { get; set; }
    public required uint FacialHair { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Hair, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HairColor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(FacialHair, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 1062, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 16, 1062, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_ALTER_APPEARANCE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var hair = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var hairColor = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var facialHair = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_ALTER_APPEARANCE {
            Hair = hair,
            HairColor = hairColor,
            FacialHair = facialHair,
        };
    }

}

