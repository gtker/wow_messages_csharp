using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class DispelledSpell {
    public required uint Spell { get; set; }
    public required Wrath.DispelMethod Method { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Method, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<DispelledSpell> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var method = (Wrath.DispelMethod)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new DispelledSpell {
            Spell = spell,
            Method = method,
        };
    }

}

