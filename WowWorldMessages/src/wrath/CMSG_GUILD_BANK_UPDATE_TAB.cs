using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_BANK_UPDATE_TAB: WrathClientMessage, IWorldMessage {
    public required ulong Bank { get; set; }
    public required byte Tab { get; set; }
    public required string Name { get; set; }
    public required string Icon { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Bank, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Tab, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Icon, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1003, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1003, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_BANK_UPDATE_TAB> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var bank = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var tab = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var icon = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_GUILD_BANK_UPDATE_TAB {
            Bank = bank,
            Tab = tab,
            Name = name,
            Icon = icon,
        };
    }

    internal int Size() {
        var size = 0;

        // bank: Generator.Generated.DataTypeGuid
        size += 8;

        // tab: Generator.Generated.DataTypeInteger
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // icon: Generator.Generated.DataTypeCstring
        size += Icon.Length + 1;

        return size;
    }

}

