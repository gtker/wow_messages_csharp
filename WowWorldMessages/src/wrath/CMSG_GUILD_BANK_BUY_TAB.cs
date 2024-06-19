using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_BANK_BUY_TAB: WrathClientMessage, IWorldMessage {
    public required ulong Banker { get; set; }
    public required byte Tab { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Banker, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Tab, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 13, 1002, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 13, 1002, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_BANK_BUY_TAB> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var banker = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var tab = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_GUILD_BANK_BUY_TAB {
            Banker = banker,
            Tab = tab,
        };
    }

}

