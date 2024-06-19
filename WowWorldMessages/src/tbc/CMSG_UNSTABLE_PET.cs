using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_UNSTABLE_PET: TbcClientMessage, IWorldMessage {
    public required ulong StableMaster { get; set; }
    public required uint PetNumber { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(StableMaster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetNumber, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 625, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 16, 625, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_UNSTABLE_PET> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var stableMaster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var petNumber = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_UNSTABLE_PET {
            StableMaster = stableMaster,
            PetNumber = petNumber,
        };
    }

}
