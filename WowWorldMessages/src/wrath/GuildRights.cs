using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildRights {
    public required uint Rights { get; set; }
    public required uint MoneyPerDay { get; set; }
    public const int BankTabRightsLength = 6;
    public required GuildBankRights[] BankTabRights { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Rights, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyPerDay, cancellationToken).ConfigureAwait(false);

        foreach (var v in BankTabRights) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<GuildRights> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var rights = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var moneyPerDay = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bankTabRights = new GuildBankRights[BankTabRightsLength];
        for (var i = 0; i < BankTabRightsLength; ++i) {
            bankTabRights[i] = await Wrath.GuildBankRights.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new GuildRights {
            Rights = rights,
            MoneyPerDay = moneyPerDay,
            BankTabRights = bankTabRights,
        };
    }

}

