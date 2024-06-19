using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_GUILD_BANK_LOG_QUERY_Server: TbcServerMessage, IWorldMessage {
    public required uint UnixTime { get; set; }
    public required byte Slot { get; set; }
    public required List<MoneyLogItem> MoneyLogs { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(UnixTime, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Slot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)MoneyLogs.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in MoneyLogs) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1005, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1005, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_GUILD_BANK_LOG_QUERY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unixTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMoneyLogs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var moneyLogs = new List<MoneyLogItem>();
        for (var i = 0; i < amountOfMoneyLogs; ++i) {
            moneyLogs.Add(await Tbc.MoneyLogItem.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new MSG_GUILD_BANK_LOG_QUERY_Server {
            UnixTime = unixTime,
            Slot = slot,
            MoneyLogs = moneyLogs,
        };
    }

    internal int Size() {
        var size = 0;

        // unix_time: Generator.Generated.DataTypeInteger
        size += 4;

        // slot: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_money_logs: Generator.Generated.DataTypeInteger
        size += 1;

        // money_logs: Generator.Generated.DataTypeArray
        size += MoneyLogs.Sum(e => 17);

        return size;
    }

}

