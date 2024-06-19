using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ResyncRune {
    public required byte CurrentRune { get; set; }
    public required byte RuneCooldown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(CurrentRune, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(RuneCooldown, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ResyncRune> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var currentRune = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var runeCooldown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new ResyncRune {
            CurrentRune = currentRune,
            RuneCooldown = runeCooldown,
        };
    }

}

