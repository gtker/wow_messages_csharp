using Version = WowLoginMessages.All.Version;
namespace WowLoginMessages.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_CHALLENGE_Client: AllClientMessage, ILoginMessage {
    /// <summary>
    /// Determines which version of messages are used for further communication.
    /// </summary>
    public required ProtocolVersion ProtocolVersion { get; set; }
    public required Version Version { get; set; }
    public required Platform Platform { get; set; }
    public required Os Os { get; set; }
    public required Locale Locale { get; set; }
    /// <summary>
    /// Offset in minutes from UTC time. 180 would be UTC+3
    /// </summary>
    public required uint UtcTimezoneOffset { get; set; }
    public required uint ClientIpAddress { get; set; }
    /// <summary>
    /// Real clients can send a maximum of 16 UTF-8 characters. This is not necessarily 16 bytes since one character can be more than one byte.
    /// Real clients will send a fully uppercased username, and will perform authentication calculations on the uppercased version.
    /// Uppercasing in regards to non-ASCII values is little weird. See `https://docs.rs/wow_srp/latest/wow_srp/normalized_string/index.html` for more info.
    /// </summary>
    public required string AccountName { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ProtocolVersion, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Size(), cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(5730135, cancellationToken).ConfigureAwait(false);

        await Version.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Platform, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Os, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Locale, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(UtcTimezoneOffset, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ClientIpAddress, cancellationToken).ConfigureAwait(false);

        await w.WriteString(AccountName, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_AUTH_RECONNECT_CHALLENGE_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var protocolVersion = (ProtocolVersion)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var gameName = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var version = await Version.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        var platform = (Platform)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var os = (Os)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var locale = (Locale)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var utcTimezoneOffset = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var clientIpAddress = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var accountName = await r.ReadString(cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_CHALLENGE_Client {
            ProtocolVersion = protocolVersion,
            Version = version,
            Platform = platform,
            Os = os,
            Locale = locale,
            UtcTimezoneOffset = utcTimezoneOffset,
            ClientIpAddress = clientIpAddress,
            AccountName = accountName,
        };
    }

    internal int Size() {
        var size = 0;

        // protocol_version: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // size: WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        // game_name: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // version: WowMessages.Generator.Generated.DataTypeStruct
        size += 5;

        // platform: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // os: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // locale: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // utc_timezone_offset: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // client_ip_address: WowMessages.Generator.Generated.DataTypeIpAddress
        size += 4;

        // account_name: WowMessages.Generator.Generated.DataTypeString
        size += AccountName.Length + 1;

        return size - 3;
    }

}

