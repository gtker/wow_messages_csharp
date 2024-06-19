using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GM_REPORT_LAG: WrathClientMessage, IWorldMessage {
    public required uint LagType { get; set; }
    public required Wrath.Map Map { get; set; }
    public required Vector3d Position { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(LagType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 24, 1282, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 24, 1282, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GM_REPORT_LAG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var lagType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_GM_REPORT_LAG {
            LagType = lagType,
            Map = map,
            Position = position,
        };
    }

}

