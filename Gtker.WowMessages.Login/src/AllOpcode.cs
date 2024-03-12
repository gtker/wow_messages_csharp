namespace Gtker.WowMessages.Login.All;

public class ServerOpcodeReader
{
    public static async Task<ILoginMessage> ReadAsync(Stream r)
    {
        var opcode = await ReadUtils.ReadByte(r);

        return opcode switch
        {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Client.ReadAsync(r),
            1 => await CMD_AUTH_RECONNECT_CHALLENGE_Client.ReadAsync(r),
            _ => throw new NotImplementedException()
        };
    }
}