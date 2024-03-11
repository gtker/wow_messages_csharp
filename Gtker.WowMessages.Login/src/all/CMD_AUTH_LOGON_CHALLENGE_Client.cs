namespace Gtker.WowMessages.Login.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class CMD_AUTH_LOGON_CHALLENGE_Client
{
    public required ProtocolVersion ProtocolVersion { get; set; }
    public required Version Version { get; set; }
    public required Platform Platform { get; set; }
    public required Os Os { get; set; }
    public required Locale Locale { get; set; }
    public required uint UtcTimezoneOffset { get; set; }
    public required uint IpAddress { get; set; }
    public required string AccountName { get; set; }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Client> Read(Stream r)
    {
        var protocolVersion = (ProtocolVersion)await Utils.ReadByte(r);

        var size = await Utils.ReadUShort(r);

        var gameName = await Utils.ReadUInt(r);

        var version = await Version.Read(r);

        var platform = (Platform)await Utils.ReadUInt(r);

        var os = (Os)await Utils.ReadUInt(r);

        var locale = (Locale)await Utils.ReadUInt(r);

        var utcTimezoneOffset = await Utils.ReadUInt(r);

        var ipAddress = await Utils.ReadUInt(r);

        var accountName = await Utils.ReadString(r);

        return new CMD_AUTH_LOGON_CHALLENGE_Client
        {
            ProtocolVersion = protocolVersion,
            Version = version,
            Platform = platform,
            Os = os,
            Locale = locale,
            UtcTimezoneOffset = utcTimezoneOffset,
            IpAddress = ipAddress,
            AccountName = accountName
        };
    }
}