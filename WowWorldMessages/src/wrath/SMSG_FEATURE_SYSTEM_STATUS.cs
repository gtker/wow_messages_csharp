using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_FEATURE_SYSTEM_STATUS: WrathServerMessage, IWorldMessage {
    public required Wrath.ComplaintStatus ComplaintStatus { get; set; }
    public required bool VoiceChatEnabled { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ComplaintStatus, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(VoiceChatEnabled, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 4, 969, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 4, 969, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_FEATURE_SYSTEM_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var complaintStatus = (Wrath.ComplaintStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var voiceChatEnabled = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_FEATURE_SYSTEM_STATUS {
            ComplaintStatus = complaintStatus,
            VoiceChatEnabled = voiceChatEnabled,
        };
    }

}

