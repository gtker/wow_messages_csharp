using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_GUILD_PERMISSIONS_Server: TbcServerMessage, IWorldMessage {
    public required uint Id { get; set; }
    public required uint Rights { get; set; }
    public required uint GoldLimitPerDay { get; set; }
    public required byte PurchasedBankTabs { get; set; }
    public const int BankTabsLength = 6;
    public required BankTab[] BankTabs { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rights, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GoldLimitPerDay, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(PurchasedBankTabs, cancellationToken).ConfigureAwait(false);

        foreach (var v in BankTabs) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 63, 1020, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 63, 1020, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_GUILD_PERMISSIONS_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rights = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var goldLimitPerDay = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var purchasedBankTabs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var bankTabs = new BankTab[BankTabsLength];
        for (var i = 0; i < BankTabsLength; ++i) {
            bankTabs[i] = await Tbc.BankTab.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new MSG_GUILD_PERMISSIONS_Server {
            Id = id,
            Rights = rights,
            GoldLimitPerDay = goldLimitPerDay,
            PurchasedBankTabs = purchasedBankTabs,
            BankTabs = bankTabs,
        };
    }

}

