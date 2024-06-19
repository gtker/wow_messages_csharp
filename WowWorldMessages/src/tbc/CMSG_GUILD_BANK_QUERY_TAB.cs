using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_BANK_QUERY_TAB: TbcClientMessage, IWorldMessage {
    public required ulong Bank { get; set; }
    public required byte Tab { get; set; }
    public required bool FullUpdate { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Bank, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Tab, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(FullUpdate, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 14, 998, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 14, 998, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_BANK_QUERY_TAB> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var bank = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var tab = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var fullUpdate = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_GUILD_BANK_QUERY_TAB {
            Bank = bank,
            Tab = tab,
            FullUpdate = fullUpdate,
        };
    }

}

