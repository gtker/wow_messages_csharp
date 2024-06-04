using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PAUSE_MIRROR_TIMER: VanillaServerMessage, IWorldMessage {
    public required TimerType Timer { get; set; }
    public required bool IsFrozen { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Timer, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(IsFrozen, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 7, 474, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 7, 474, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PAUSE_MIRROR_TIMER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var timer = (TimerType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var isFrozen = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_PAUSE_MIRROR_TIMER {
            Timer = timer,
            IsFrozen = isFrozen,
        };
    }

}

