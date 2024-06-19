using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_GUILD_BANK_MONEY_WITHDRAWN_Server: WrathServerMessage, IWorldMessage {
    public required uint RemainingWithdrawAmount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RemainingWithdrawAmount, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 1022, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 1022, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_GUILD_BANK_MONEY_WITHDRAWN_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var remainingWithdrawAmount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_GUILD_BANK_MONEY_WITHDRAWN_Server {
            RemainingWithdrawAmount = remainingWithdrawAmount,
        };
    }

}

