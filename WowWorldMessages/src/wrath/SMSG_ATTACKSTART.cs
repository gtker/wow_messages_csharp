using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ATTACKSTART: WrathServerMessage, IWorldMessage {
    public required ulong Attacker { get; set; }
    public required ulong Victim { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Attacker, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Victim, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 18, 323, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 18, 323, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ATTACKSTART> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var attacker = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var victim = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new SMSG_ATTACKSTART {
            Attacker = attacker,
            Victim = victim,
        };
    }

}

