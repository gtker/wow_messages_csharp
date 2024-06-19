using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class PreviewTalent {
    public required Wrath.Talent Talent { get; set; }
    public required uint Rank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Talent, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rank, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<PreviewTalent> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var talent = (Wrath.Talent)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new PreviewTalent {
            Talent = talent,
            Rank = rank,
        };
    }

}

