using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CAMERA_SHAKE: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// SpellEffectCameraShakes.dbc
    /// </summary>
    public required uint CameraShakeId { get; set; }
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(CameraShakeId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 1290, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 10, 1290, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CAMERA_SHAKE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var cameraShakeId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CAMERA_SHAKE {
            CameraShakeId = cameraShakeId,
            Unknown = unknown,
        };
    }

}

