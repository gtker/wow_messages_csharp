using Version = WowMessages.Login.All.Version;
namespace WowMessages.Login.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Client: AllClientMessage, ILoginMessage {
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

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var protocolVersion = (ProtocolVersion)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var gameName = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var version = await Version.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        var platform = (Platform)await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var os = (Os)await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var locale = (Locale)await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var utcTimezoneOffset = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var clientIpAddress = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var accountName = await ReadUtils.ReadString(r, cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_LOGON_CHALLENGE_Client {
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

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)ProtocolVersion, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUShort(w, (ushort)Size(), cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, 5730135, cancellationToken).ConfigureAwait(false);

        await Version.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, (uint)Platform, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, (uint)Os, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, (uint)Locale, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, UtcTimezoneOffset, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, ClientIpAddress, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteString(w, AccountName, cancellationToken).ConfigureAwait(false);

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

