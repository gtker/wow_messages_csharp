namespace Gtker.WowMessages.Login.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server: Version2ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> ReadAsync(Stream r) {
        var result = (LoginResult)await ReadUtils.ReadByte(r);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

    public async Task WriteAsync(Stream w) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 3);

        await WriteUtils.WriteByte(w, (byte)Result);

    }

}

