using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT: WrathServerMessage, IWorldMessage {
    public required ulong InviteId { get; set; }
    public required string Text { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Text, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1121, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1121, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT {
            InviteId = inviteId,
            Text = text,
        };
    }

    internal int Size() {
        var size = 0;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // text: Generator.Generated.DataTypeCstring
        size += Text.Length + 1;

        return size;
    }

}

