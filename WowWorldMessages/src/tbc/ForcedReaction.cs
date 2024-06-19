using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ForcedReaction {
    public required Tbc.Faction Faction { get; set; }
    public required uint ReputationRank { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort((ushort)Faction, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ReputationRank, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ForcedReaction> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var faction = (Tbc.Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var reputationRank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new ForcedReaction {
            Faction = faction,
            ReputationRank = reputationRank,
        };
    }

}

