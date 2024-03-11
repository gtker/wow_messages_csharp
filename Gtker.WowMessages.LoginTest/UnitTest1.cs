using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.LoginTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var data = new byte[]
        {
            0, // opcode (0)
            3, // protocol_version: ProtocolVersion THREE (3)
            31, 0, // size: u16
            87, 111, 87, 0, // game_name: u32
            1, // Version.major: u8
            12, // Version.minor: u8
            1, // Version.patch: u8
            243, 22, // Version.build: u16
            54, 56, 120, 0, // platform: Platform X86 ("\0x86")
            110, 105, 87, 0, // os: Os WINDOWS ("\0Win")
            66, 71, 110, 101, // locale: Locale EN_GB ("enGB")
            60, 0, 0, 0, // utc_timezone_offset: u32
            127, 0, 0, 1, // client_ip_address: IpAddress
            65 // account_name: String
        };
        var stream = new MemoryStream(data);

        var c = await CMD_AUTH_LOGON_CHALLENGE_Client.Read(stream);
        Assert.That(stream.Position, Is.EqualTo(stream.Length));
    }
}