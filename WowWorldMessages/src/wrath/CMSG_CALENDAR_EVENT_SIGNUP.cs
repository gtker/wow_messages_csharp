using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_EVENT_SIGNUP: WrathClientMessage, IWorldMessage {
    public required ulong EventId { get; set; }
    public required bool Tentative { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Tentative, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 13, 1210, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 13, 1210, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_EVENT_SIGNUP> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var tentative = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_CALENDAR_EVENT_SIGNUP {
            EventId = eventId,
            Tentative = tentative,
        };
    }

}

