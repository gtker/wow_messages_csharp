using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class InspectTalent {
    public required Wrath.Talent Talent { get; set; }
    public required byte MaxRank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Talent, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(MaxRank, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<InspectTalent> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var talent = (Wrath.Talent)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maxRank = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new InspectTalent {
            Talent = talent,
            MaxRank = maxRank,
        };
    }

}

