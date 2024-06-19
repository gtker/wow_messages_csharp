using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_OFFER_PETITION: WrathClientMessage, IWorldMessage {
    public required uint Unknown0 { get; set; }
    public required ulong Petition { get; set; }
    public required ulong Target { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown0, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Petition, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Target, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 24, 451, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 24, 451, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_OFFER_PETITION> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown0 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var petition = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new CMSG_OFFER_PETITION {
            Unknown0 = unknown0,
            Petition = petition,
            Target = target,
        };
    }

}

