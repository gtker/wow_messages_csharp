using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELLINSTAKILLLOG: WrathServerMessage, IWorldMessage {
    public required ulong Caster { get; set; }
    public required ulong Target { get; set; }
    public required uint Spell { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Target, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 22, 815, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 22, 815, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELLINSTAKILLLOG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var caster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_SPELLINSTAKILLLOG {
            Caster = caster,
            Target = target,
            Spell = spell,
        };
    }

}

