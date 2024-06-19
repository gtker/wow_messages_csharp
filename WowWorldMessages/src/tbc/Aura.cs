using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Aura {
    public required ushort AuraValue { get; set; }
    public required byte Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort(AuraValue, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Aura> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var auraValue = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new Aura {
            AuraValue = auraValue,
            Unknown = unknown,
        };
    }

}

