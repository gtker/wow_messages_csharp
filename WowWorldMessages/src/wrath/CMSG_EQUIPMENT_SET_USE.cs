using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_EQUIPMENT_SET_USE: WrathClientMessage, IWorldMessage {
    public const int SetsLength = 19;
    public required EquipmentSet[] Sets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        foreach (var v in Sets) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 194, 1237, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 194, 1237, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_EQUIPMENT_SET_USE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var sets = new EquipmentSet[SetsLength];
        for (var i = 0; i < SetsLength; ++i) {
            sets[i] = await Wrath.EquipmentSet.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new CMSG_EQUIPMENT_SET_USE {
            Sets = sets,
        };
    }

}

