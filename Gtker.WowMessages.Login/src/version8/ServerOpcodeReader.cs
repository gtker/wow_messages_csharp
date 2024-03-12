namespace Gtker.WowMessages.Login.Version8;

public class ServerOpcodeReader {
    public static async Task<ILoginMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            3 => await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r),
        };
    }
}
