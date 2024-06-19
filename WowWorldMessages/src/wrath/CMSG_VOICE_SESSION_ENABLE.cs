using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_VOICE_SESSION_ENABLE: WrathClientMessage, IWorldMessage {
    public required bool VoiceEnabled { get; set; }
    public required bool MicrophoneEnabled { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(VoiceEnabled, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(MicrophoneEnabled, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 6, 943, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 6, 943, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_VOICE_SESSION_ENABLE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var voiceEnabled = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var microphoneEnabled = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_VOICE_SESSION_ENABLE {
            VoiceEnabled = voiceEnabled,
            MicrophoneEnabled = microphoneEnabled,
        };
    }

}

