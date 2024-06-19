using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Addon {
    /// <summary>
    /// Other emus hardcode this to 2. More research is required
    /// </summary>
    public required byte AddonType { get; set; }
    /// <summary>
    /// Other emus hardcode this to 1.
    /// </summary>
    public required byte UsesCrc { get; set; }
    public required bool UsesDiffentPublicKey { get; set; }
    /// <summary>
    /// Other emus hardcode this to 0
    /// </summary>
    public required uint Unknown1 { get; set; }
    /// <summary>
    /// Other emus hardcode this to 0
    /// </summary>
    public required byte Unknown2 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(AddonType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(UsesCrc, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(UsesDiffentPublicKey, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown2, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Addon> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var addonType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var usesCrc = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var usesDiffentPublicKey = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new Addon {
            AddonType = addonType,
            UsesCrc = usesCrc,
            UsesDiffentPublicKey = usesDiffentPublicKey,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
        };
    }

}

