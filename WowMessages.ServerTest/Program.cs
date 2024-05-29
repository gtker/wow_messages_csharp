using System.Net;
using System.Net.Sockets;
using WowLoginMessages.All;
using WowLoginMessages.Version3;
using WowSrp;
using WowSrp.Server;
using ClientOpcodeReader = WowLoginMessages.All.ClientOpcodeReader;

namespace WowMessages.ServerTest;

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
        try
        {
            using (client)
            {
                var c = await ClientOpcodeReader.ReadAsync(client.GetStream());
                Console.WriteLine("Received");
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
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static async Task Login(TcpClient client, CMD_AUTH_LOGON_CHALLENGE_Client l)
    {
        if (l.ProtocolVersion != ProtocolVersion.Three)
        {
            return;
        }

        Console.WriteLine("Received");

        var cts = new CancellationTokenSource();
        cts.CancelAfter(3500);

        var proof = new SrpVerifier(l.AccountName, l.AccountName).IntoProof();

        await new CMD_AUTH_LOGON_CHALLENGE_Server
        {
            Result = LoginResult.Success,
            ServerPublicKey = proof.ServerPublicKey.ToList(),
            Generator = [Constants.Generator],
            LargeSafePrime = Constants.LargeSafePrimeLittleEndian.ToList(),
            Salt = proof.Salt.ToList(),
            CrcSalt = Pin.RandomPinSalt().ToList(),
            SecurityFlag = SecurityFlag.None
        }.WriteAsync(client.GetStream(), cts.Token);
        Console.WriteLine("Sent");

        var c =
            await WowLoginMessages.Version3.ClientOpcodeReader.ExpectOpcode<CMD_AUTH_LOGON_PROOF_Client>(
                client.GetStream(), cts.Token);

        if (c is null)
        {
            await new CMD_AUTH_LOGON_PROOF_Server
            {
                Result = LoginResult.FailBanned
            }.WriteAsync(client.GetStream(), cts.Token);

            return;
        }

        Console.WriteLine("Received");
        var success = proof.IntoServer(c.ClientPublicKey.ToArray(), c.ClientProof.ToArray());

        if (success is null)
        {
            await new CMD_AUTH_LOGON_PROOF_Server
            {
                Result = LoginResult.FailBanned
            }.WriteAsync(client.GetStream(), cts.Token);

            return;
        }

        var (server, serverProof) = success.Value;

        await new CMD_AUTH_LOGON_PROOF_Server
        {
            Result = LoginResult.Success,
            ServerProof = serverProof.ToList(),
            HardwareSurveyId = 0
        }.WriteAsync(client.GetStream(), cts.Token);

        while (await WowLoginMessages.Version3.ClientOpcodeReader.ExpectOpcode<CMD_REALM_LIST_Client>(
                   client.GetStream(),
                   cts.Token) is not null)
        {
            await new CMD_REALM_LIST_Server
            {
                Realms =
                [
                    new Realm
                    {
                        RealmType = RealmType.PlayerVsEnvironment,
                        Flag = RealmFlag.None,
                        Name = "Realm Name",
                        Address = "localhost:8085",
                        Population = Population.RedFull(),
                        NumberOfCharactersOnRealm = 6,
                        Category = RealmCategory.Default,
                        RealmId = 0
                    }
                ]
            }.WriteAsync(client.GetStream(), cts.Token);
            Console.WriteLine("Sent realm");
        }
    }
}