using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CALENDAR_EVENT_INVITE: WrathClientMessage, IWorldMessage {
    public required ulong EventValue { get; set; }
    public required ulong InviteId { get; set; }
    public required string Name { get; set; }
    public required bool PreEvent { get; set; }
    public required bool GuildEvent { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(EventValue, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InviteId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(PreEvent, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(GuildEvent, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1073, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1073, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CALENDAR_EVENT_INVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var eventValue = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var inviteId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var preEvent = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var guildEvent = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_CALENDAR_EVENT_INVITE {
            EventValue = eventValue,
            InviteId = inviteId,
            Name = name,
            PreEvent = preEvent,
            GuildEvent = guildEvent,
        };
    }

    internal int Size() {
        var size = 0;

        // event_value: Generator.Generated.DataTypeGuid
        size += 8;

        // invite_id: Generator.Generated.DataTypeGuid
        size += 8;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // pre_event: Generator.Generated.DataTypeBool
        size += 1;

        // guild_event: Generator.Generated.DataTypeBool
        size += 1;

        return size;
    }

}

