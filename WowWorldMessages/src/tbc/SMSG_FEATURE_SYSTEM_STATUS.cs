using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_FEATURE_SYSTEM_STATUS: TbcServerMessage, IWorldMessage {
    public required Tbc.ComplaintStatus ComplaintStatus { get; set; }
    public required bool VoiceChatEnabled { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ComplaintStatus, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(VoiceChatEnabled, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 4, 968, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 4, 968, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_FEATURE_SYSTEM_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var complaintStatus = (Tbc.ComplaintStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var voiceChatEnabled = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_FEATURE_SYSTEM_STATUS {
            ComplaintStatus = complaintStatus,
            VoiceChatEnabled = voiceChatEnabled,
        };
    }

}

