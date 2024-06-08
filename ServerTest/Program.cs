using System.Net;
using System.Net.Sockets;

namespace ServerTest;

public static class Server
{
    public static async Task Main()
    {
        var sessionKeys = new Dictionary<string, byte[]>();

        TcpListener? auth = null;
        TcpListener? world = null;
        try
        {
            const int worldPort = 8085;
            const int authPort = 3724;
            var localAddr = IPAddress.Parse("0.0.0.0");

            world = new TcpListener(localAddr, worldPort);
            auth = new TcpListener(localAddr, authPort);

            auth.Start();
            world.Start();

            Task.Run(async () =>
            {
                while (true)
                {
                    var authClient = await auth.AcceptTcpClientAsync().ConfigureAwait(false);
                    await Task.Run(() => Auth.RunClient(authClient, sessionKeys));
                }
            });
            Task.Run(async () =>
            {
                while (true)
                {
                    var worldClient = await world.AcceptTcpClientAsync().ConfigureAwait(false);
                    await Task.Run(() => World.RunClient(worldClient, sessionKeys));
                }
            });

            while (true) {}
        }
        catch (SocketException e)
        {
            Console.WriteLine($"SocketException: {e}");
        }
        finally
        {
            auth?.Stop();
        }
    }
}