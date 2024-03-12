namespace Gtker.WowMessages.Login.All;

public abstract class AllClientMessage {}

public static class ClientOpcodeReader {
    public static async Task<AllClientMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Client.ReadAsync(r),
            2 => await CMD_AUTH_RECONNECT_CHALLENGE_Client.ReadAsync(r),
            _ => throw new NotImplementedException(),
        };
    }

    public static async Task<T> ExpectOpcode<T>(Stream r) where T: AllClientMessage {
        if (await ReadAsync(r) is T c) {
            return c;
        }

        throw new NotImplementedException();
    }
}
