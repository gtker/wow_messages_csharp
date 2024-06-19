using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Aura {
    public required uint AuraValue { get; set; }
    public required byte Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(AuraValue, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Aura> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auraValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new Aura {
            AuraValue = auraValue,
            Unknown = unknown,
        };
    }

}

