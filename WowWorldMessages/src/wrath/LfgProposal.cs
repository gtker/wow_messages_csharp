using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgProposal {
    public required uint RoleMask { get; set; }
    public required byte IsCurrentPlayer { get; set; }
    public required byte InDungeon { get; set; }
    public required byte InSameGroup { get; set; }
    public required byte HasAnswered { get; set; }
    public required byte HasAccepted { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RoleMask, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(IsCurrentPlayer, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(InDungeon, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(InSameGroup, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HasAnswered, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HasAccepted, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgProposal> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var roleMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var isCurrentPlayer = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var inDungeon = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var inSameGroup = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hasAnswered = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hasAccepted = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new LfgProposal {
            RoleMask = roleMask,
            IsCurrentPlayer = isCurrentPlayer,
            InDungeon = inDungeon,
            InSameGroup = inSameGroup,
            HasAnswered = hasAnswered,
            HasAccepted = hasAccepted,
        };
    }

}

