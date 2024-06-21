using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ADDON_INFO: WrathServerMessage, IWorldMessage {
    public required AddonArray Addons { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await Addons.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 751, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 751, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ADDON_INFO> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var addons = await AddonArray.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfBannedAddons = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_ADDON_INFO {
            Addons = addons,
        };
    }

    internal int Size() {
        var size = 0;

        // addons: Generator.Generated.DataTypeAddonArray
        size += Addons.Length();

        // number_of_banned_addons: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

