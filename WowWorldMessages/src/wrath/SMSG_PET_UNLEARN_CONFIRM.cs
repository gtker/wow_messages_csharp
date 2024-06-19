using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_UNLEARN_CONFIRM: WrathServerMessage, IWorldMessage {
    public required ulong Pet { get; set; }
    public required uint TalentResetCost { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Pet, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TalentResetCost, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 753, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 14, 753, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_UNLEARN_CONFIRM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var pet = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var talentResetCost = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_PET_UNLEARN_CONFIRM {
            Pet = pet,
            TalentResetCost = talentResetCost,
        };
    }

}

