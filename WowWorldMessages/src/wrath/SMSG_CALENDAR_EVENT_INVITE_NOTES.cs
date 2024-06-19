using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_INVITE_NOTES: WrathServerMessage, IWorldMessage {
    public required ulong Invitee { get; set; }
    public required ulong InviteId { get; set; }
    public required string Text { get; set; }
    public required bool Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Invitee, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Text, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1120, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1120, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_INVITE_NOTES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var invitee = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_INVITE_NOTES {
            Invitee = invitee,
            InviteId = inviteId,
            Text = text,
            Unknown = unknown,
        };
    }

    internal int Size() {
        var size = 0;

        // invitee: Generator.Generated.DataTypePackedGuid
        size += Invitee.PackedGuidLength();

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // text: Generator.Generated.DataTypeCstring
        size += Text.Length + 1;

        // unknown: Generator.Generated.DataTypeBool
        size += 1;

        return size;
    }

}

