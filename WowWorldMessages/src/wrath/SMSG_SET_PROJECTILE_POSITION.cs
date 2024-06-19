using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SET_PROJECTILE_POSITION: WrathServerMessage, IWorldMessage {
    public required ulong Caster { get; set; }
    public required byte AmountOfCasts { get; set; }
    public required Vector3d Position { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(AmountOfCasts, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 23, 1215, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 23, 1215, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SET_PROJECTILE_POSITION> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var caster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var amountOfCasts = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_SET_PROJECTILE_POSITION {
            Caster = caster,
            AmountOfCasts = amountOfCasts,
            Position = position,
        };
    }

}

