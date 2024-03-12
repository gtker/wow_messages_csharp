namespace Gtker.WowMessages.Login.Version3;

public abstract class Version3ServerMessage {}

public static class ServerOpcodeReader {
    public static async Task<Version3ServerMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Server.ReadAsync(r),
            1 => await CMD_AUTH_LOGON_PROOF_Server.ReadAsync(r),
            16 => await CMD_REALM_LIST_Server.ReadAsync(r),
            48 => await CMD_XFER_INITIATE.ReadAsync(r),
            49 => await CMD_XFER_DATA.ReadAsync(r),
            _ => throw new NotImplementedException(),
        };
    }

    public static async Task<T> ExpectOpcode<T>(Stream r) where T: Version3ServerMessage {
        if (await ReadAsync(r) is T c) {
            return c;
        }

        throw new NotImplementedException();
    }
}
