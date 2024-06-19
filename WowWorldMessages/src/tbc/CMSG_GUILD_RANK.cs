using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_RANK: TbcClientMessage, IWorldMessage {
    public required uint RankId { get; set; }
    public required uint Rights { get; set; }
    public required string RankName { get; set; }
    public required uint MoneyPerDay { get; set; }
    public const int BankTabRightsLength = 6;
    public required GuildBankRights[] BankTabRights { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RankId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Rights, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(RankName, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MoneyPerDay, cancellationToken).ConfigureAwait(false);

        foreach (var v in BankTabRights) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 561, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 561, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_RANK> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var rankId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rights = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rankName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var moneyPerDay = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var bankTabRights = new GuildBankRights[BankTabRightsLength];
        for (var i = 0; i < BankTabRightsLength; ++i) {
            bankTabRights[i] = await Tbc.GuildBankRights.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new CMSG_GUILD_RANK {
            RankId = rankId,
            Rights = rights,
            RankName = rankName,
            MoneyPerDay = moneyPerDay,
            BankTabRights = bankTabRights,
        };
    }

    internal int Size() {
        var size = 0;

        // rank_id: Generator.Generated.DataTypeInteger
        size += 4;

        // rights: Generator.Generated.DataTypeInteger
        size += 4;

        // rank_name: Generator.Generated.DataTypeCstring
        size += RankName.Length + 1;

        // money_per_day: Generator.Generated.DataTypeGold
        size += 4;

        // bank_tab_rights: Generator.Generated.DataTypeArray
        size += BankTabRights.Sum(e => 8);

        return size;
    }

}

