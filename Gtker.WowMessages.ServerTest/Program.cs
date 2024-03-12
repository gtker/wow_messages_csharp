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
        }.WriteAsync(client.GetStream());

        await Task.Delay(2000);
    }
}