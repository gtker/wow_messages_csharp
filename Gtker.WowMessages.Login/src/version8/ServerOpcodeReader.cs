namespace Gtker.WowMessages.Login.Version8;

public class ServerOpcodeReader {
    public static async Task<ILoginMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            3 => await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r),
            48 => await CMD_XFER_INITIATE.ReadAsync(r),
            49 => await CMD_XFER_DATA.ReadAsync(r),
        };
    }
}
