using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SUMMON_RESPONSE: WrathClientMessage, IWorldMessage {
    public required ulong Summoner { get; set; }
    public required bool Agree { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Summoner, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Agree, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 13, 684, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 13, 684, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SUMMON_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var summoner = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var agree = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_SUMMON_RESPONSE {
            Summoner = summoner,
            Agree = agree,
        };
    }

}

