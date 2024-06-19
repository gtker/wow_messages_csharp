using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgData {
    public required ushort Entry { get; set; }
    public required Tbc.LfgType LfgType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort(Entry, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)LfgType, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgData> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var entry = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var lfgType = (Tbc.LfgType)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        return new LfgData {
            Entry = entry,
            LfgType = lfgType,
        };
    }

}

