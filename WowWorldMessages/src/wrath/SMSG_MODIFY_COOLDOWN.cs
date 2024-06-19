using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MODIFY_COOLDOWN: WrathServerMessage, IWorldMessage {
    public required uint Spell { get; set; }
    public required ulong Player { get; set; }
    public required uint Cooldown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Cooldown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 18, 1169, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 18, 1169, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MODIFY_COOLDOWN> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var cooldown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_MODIFY_COOLDOWN {
            Spell = spell,
            Player = player,
            Cooldown = cooldown,
        };
    }

}

