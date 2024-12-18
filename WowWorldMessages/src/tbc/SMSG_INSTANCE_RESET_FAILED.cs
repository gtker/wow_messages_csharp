using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSTANCE_RESET_FAILED: TbcServerMessage, IWorldMessage {
    public required Tbc.InstanceResetFailedReason Reason { get; set; }
    public required Tbc.Map Map { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Reason, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 799, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 10, 799, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSTANCE_RESET_FAILED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var reason = (Tbc.InstanceResetFailedReason)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Tbc.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_INSTANCE_RESET_FAILED {
            Reason = reason,
            Map = map,
        };
    }

}

