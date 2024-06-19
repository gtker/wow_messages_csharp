using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MailItem {
    public required ulong Item { get; set; }
    public required byte Slot { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Slot, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<MailItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new MailItem {
            Item = item,
            Slot = slot,
        };
    }

}

