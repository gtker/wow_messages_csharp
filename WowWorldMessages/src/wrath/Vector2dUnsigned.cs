using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Vector2dUnsigned {
    public required uint X { get; set; }
    public required uint Y { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(X, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Y, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Vector2dUnsigned> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var x = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var y = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new Vector2dUnsigned {
            X = x,
            Y = y,
        };
    }

}

