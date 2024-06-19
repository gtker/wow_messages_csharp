using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_UPDATE_MISSILE_TRAJECTORY: WrathClientMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required uint Spell { get; set; }
    public required float Elevation { get; set; }
    public required float Speed { get; set; }
    public required Vector3d Position { get; set; }
    public required Vector3d Target { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Elevation, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Speed, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await Target.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 48, 1122, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 48, 1122, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_UPDATE_MISSILE_TRAJECTORY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var elevation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var speed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var target = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_UPDATE_MISSILE_TRAJECTORY {
            Guid = guid,
            Spell = spell,
            Elevation = elevation,
            Speed = speed,
            Position = position,
            Target = target,
        };
    }

}

