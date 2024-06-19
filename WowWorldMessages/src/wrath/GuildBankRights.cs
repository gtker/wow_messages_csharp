using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildBankRights {
    public required uint Rights { get; set; }
    public required uint SlotsPerDay { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Rights, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SlotsPerDay, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GuildBankRights> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var rights = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var slotsPerDay = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new GuildBankRights {
            Rights = rights,
            SlotsPerDay = slotsPerDay,
        };
    }

}

