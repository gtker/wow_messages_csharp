using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_MOVE_TELEPORT_CHEAT_Server: WrathServerMessage, IWorldMessage {
    public required Vector3d Position { get; set; }
    public required float Orientation { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Orientation, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 18, 198, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 18, 198, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_MOVE_TELEPORT_CHEAT_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var orientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new MSG_MOVE_TELEPORT_CHEAT_Server {
            Position = position,
            Orientation = orientation,
        };
    }

}

