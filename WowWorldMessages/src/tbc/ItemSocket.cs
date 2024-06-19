using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ItemSocket {
    public required uint Color { get; set; }
    public required uint Content { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Color, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Content, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ItemSocket> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var color = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var content = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new ItemSocket {
            Color = color,
            Content = content,
        };
    }

}

