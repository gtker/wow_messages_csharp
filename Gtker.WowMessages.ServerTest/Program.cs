using System.Net;
using System.Net.Sockets;
using Gtker.WowMessages.Login.All;
using Gtker.WowMessages.Login.Version3;
using ClientOpcodeReader = Gtker.WowMessages.Login.All.ClientOpcodeReader;

namespace Gtker.WowMessages.ServerTest;

public static class Server
{
    public static async Task Main()
    {
        TcpListener? server = null;
        try
        {
            const int port = 3724;
            var localAddr = IPAddress.Parse("0.0.0.0");

            server = new TcpListener(localAddr, port);

            server.Start();

            while (true)
            {
                var client = await server.AcceptTcpClientAsync().ConfigureAwait(false);
                await Task.Run(() => RunClient(client));
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine($"SocketException: {e}");
        }
        finally
        {
            server?.Stop();
        }
    }

    private static async Task RunClient(TcpClient client)
    {
        using (client)
        {
            var c = await ClientOpcodeReader.ReadAsync(client.GetStream());
            switch (c)
            {
                case CMD_AUTH_LOGON_CHALLENGE_Client l:
                    await Login(client, l);
                    break;
                case CMD_AUTH_RECONNECT_CHALLENGE_Client r:
                    break;
            }
        }
    }

    private static async Task Login(TcpClient client, CMD_AUTH_LOGON_CHALLENGE_Client l)
    {
        if (l.ProtocolVersion != ProtocolVersion.Three)
        {
            return;
        }

        await new CMD_AUTH_LOGON_CHALLENGE_Server
        {
            Result = LoginResult.Success,
            ServerPublicKey =
            [
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
                29, 30, 31, 32
            ],
            Generator = [7],
            LargeSafePrime =
            [
                0xb7, 0x9b, 0x3e, 0x2a, 0x87, 0x82, 0x3c, 0xab,
                0x8f, 0x5e, 0xbf, 0xbf, 0x8e, 0xb1, 0x01, 0x08,
                0x53, 0x50, 0x06, 0x29, 0x8b, 0x5b, 0xad, 0xbd,
                0x5b, 0x53, 0xe1, 0x89, 0x5e, 0x64, 0x4b, 0x89
            ],
            Salt =
            [
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            ],
            CrcSalt =
            [
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            ],
            SecurityFlag = SecurityFlag.None
        }.WriteAsync(client.GetStream());

        var c = await ClientOpcodeReader.ExpectOpcode<CMD_AUTH_LOGON_PROOF_Client>(client.GetStream());


        await Task.Delay(2000);
    }
}