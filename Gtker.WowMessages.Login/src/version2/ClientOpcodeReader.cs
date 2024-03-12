namespace Gtker.WowMessages.Login.Version2;

public class ClientOpcodeReader {
    public static async Task<ILoginMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            1 => await CMD_AUTH_LOGON_PROOF_Client.ReadAsync(r),
            3 => await CMD_AUTH_RECONNECT_PROOF_Client.ReadAsync(r),
            16 => await CMD_REALM_LIST_Client.ReadAsync(r),
            50 => await CMD_XFER_ACCEPT.ReadAsync(r),
            51 => await CMD_XFER_RESUME.ReadAsync(r),
            52 => await CMD_XFER_CANCEL.ReadAsync(r),
            _ => throw new NotImplementedException(),
        };
    }

    public static async Task<T> ExpectOpcode<T>(Stream r) {
        if (await ReadAsync(r) is T c) {
            return c;
        }

        throw new NotImplementedException();
    }
}
