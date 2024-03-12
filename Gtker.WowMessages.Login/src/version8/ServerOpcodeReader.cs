namespace Gtker.WowMessages.Login.Version8;

public class ServerOpcodeReader {
    public static async Task<ILoginMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Server.ReadAsync(r),
            1 => await CMD_AUTH_LOGON_PROOF_Server.ReadAsync(r),
            2 => await CMD_AUTH_RECONNECT_CHALLENGE_Server.ReadAsync(r),
            3 => await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r),
            16 => await CMD_REALM_LIST_Server.ReadAsync(r),
            48 => await CMD_XFER_INITIATE.ReadAsync(r),
            49 => await CMD_XFER_DATA.ReadAsync(r),
            _ => throw new NotImplementedException(),
        };
    }
}
