using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_PET_LEARN_TALENT: WrathClientMessage, IWorldMessage {
    public required ulong Pet { get; set; }
    public required uint Talent { get; set; }
    public required uint Rank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Pet, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Talent, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rank, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 20, 1146, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 20, 1146, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_PET_LEARN_TALENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var pet = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var talent = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_PET_LEARN_TALENT {
            Pet = pet,
            Talent = talent,
            Rank = rank,
        };
    }

}

