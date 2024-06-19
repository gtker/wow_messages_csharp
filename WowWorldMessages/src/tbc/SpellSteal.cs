using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SpellSteal {
    public required uint Spell { get; set; }
    public required Tbc.SpellStealAction Action { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Action, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SpellSteal> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var action = (Tbc.SpellStealAction)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SpellSteal {
            Spell = spell,
            Action = action,
        };
    }

}

