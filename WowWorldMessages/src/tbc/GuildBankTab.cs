using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildBankTab {
    public required string TabName { get; set; }
    public required string TabIcon { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(TabName, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(TabIcon, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GuildBankTab> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var tabName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var tabIcon = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new GuildBankTab {
            TabName = tabName,
            TabIcon = tabIcon,
        };
    }

    internal int Size() {
        var size = 0;

        // tab_name: Generator.Generated.DataTypeCstring
        size += TabName.Length + 1;

        // tab_icon: Generator.Generated.DataTypeCstring
        size += TabIcon.Length + 1;

        return size;
    }

}

