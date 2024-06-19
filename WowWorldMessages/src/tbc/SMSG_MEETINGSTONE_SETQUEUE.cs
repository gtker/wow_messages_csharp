using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MEETINGSTONE_SETQUEUE: TbcServerMessage, IWorldMessage {
    public required Tbc.Area Area { get; set; }
    public required Tbc.MeetingStoneStatus Status { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Status, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 7, 661, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 7, 661, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MEETINGSTONE_SETQUEUE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var area = (Tbc.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var status = (Tbc.MeetingStoneStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_MEETINGSTONE_SETQUEUE {
            Area = area,
            Status = status,
        };
    }

}
