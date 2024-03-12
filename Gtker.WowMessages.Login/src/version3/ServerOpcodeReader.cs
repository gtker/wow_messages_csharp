namespace Gtker.WowMessages.Login.Version3;

public class ServerOpcodeReader {
    public static async Task<ILoginMessage> ReadAsync(Stream r) {
        var opcode = await ReadUtils.ReadByte(r);
        return opcode switch {
            16 => await CMD_REALM_LIST_Server.ReadAsync(r),
            48 => await CMD_XFER_INITIATE.ReadAsync(r),
            49 => await CMD_XFER_DATA.ReadAsync(r),
        };
    }
}
