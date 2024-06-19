using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BUY_ITEM: WrathClientMessage, IWorldMessage {
    public required ulong Vendor { get; set; }
    public required uint Item { get; set; }
    public required uint Slot { get; set; }
    public required byte Amount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Vendor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Slot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Amount, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 21, 418, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 21, 418, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BUY_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var vendor = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var slot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var amount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_BUY_ITEM {
            Vendor = vendor,
            Item = item,
            Slot = slot,
            Amount = amount,
        };
    }

}

