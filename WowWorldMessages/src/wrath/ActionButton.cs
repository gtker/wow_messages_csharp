using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ActionButton {
    public required ushort Action { get; set; }
    public required byte ActionType { get; set; }
    public required byte Misc { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort(Action, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ActionType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Misc, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ActionButton> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var action = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var actionType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var misc = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new ActionButton {
            Action = action,
            ActionType = actionType,
            Misc = misc,
        };
    }

}

