using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_WORLD_TELEPORT: WrathClientMessage, IWorldMessage {
    public required uint Time { get; set; }
    public required Wrath.Map Map { get; set; }
    public required ulong Unknown { get; set; }
    public required Vector3d Position { get; set; }
    public required float Orientation { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Unknown, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Orientation, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 36, 8, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 36, 8, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_WORLD_TELEPORT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var orientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new CMSG_WORLD_TELEPORT {
            Time = time,
            Map = map,
            Unknown = unknown,
            Position = position,
            Orientation = orientation,
        };
    }

}

