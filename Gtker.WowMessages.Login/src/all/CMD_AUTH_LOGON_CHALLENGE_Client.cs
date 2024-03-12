using Version = Gtker.WowMessages.Login.All.Version;
namespace Gtker.WowMessages.Login.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Client: ILoginMessage {
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

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Client> ReadAsync(Stream r) {
        var protocolVersion = (ProtocolVersion)await ReadUtils.ReadByte(r);

        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r);

        // ReSharper disable once UnusedVariable.Compiler
        var gameName = await ReadUtils.ReadUInt(r);

        var version = await Version.ReadAsync(r);

        var platform = (Platform)await ReadUtils.ReadUInt(r);

        var os = (Os)await ReadUtils.ReadUInt(r);

        var locale = (Locale)await ReadUtils.ReadUInt(r);

        var utcTimezoneOffset = await ReadUtils.ReadUInt(r);

        var clientIpAddress = await ReadUtils.ReadUInt(r);

        var accountName = await ReadUtils.ReadString(r);

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

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 0);

        await WriteUtils.WriteByte(w, (byte)ProtocolVersion);

        await WriteUtils.WriteUShort(w, (ushort)Size());

        await WriteUtils.WriteUInt(w, 5730135);

        await Version.WriteAsync(w);

        await WriteUtils.WriteUInt(w, (uint)Platform);

        await WriteUtils.WriteUInt(w, (uint)Os);

        await WriteUtils.WriteUInt(w, (uint)Locale);

        await WriteUtils.WriteUInt(w, UtcTimezoneOffset);

        await WriteUtils.WriteUInt(w, ClientIpAddress);

        await WriteUtils.WriteString(w, AccountName);

    }

    public int Size() {
        var size = 0;

        // protocol_version: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // size: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        // game_name: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // version: Gtker.WowMessages.Generator.Generated.DataTypeStruct
        size += 5;

        // platform: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // os: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // locale: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // utc_timezone_offset: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // client_ip_address: Gtker.WowMessages.Generator.Generated.DataTypeIpAddress
        size += 4;

        // account_name: Gtker.WowMessages.Generator.Generated.DataTypeString
        size += AccountName.Length + 1;

        return size - 3;
    }

}

