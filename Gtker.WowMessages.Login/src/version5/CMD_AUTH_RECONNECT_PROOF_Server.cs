namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server {
    public required LoginResult Result { get; set; }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> Read(Stream r) {
        var result = (LoginResult)await ReadUtils.ReadByte(r);

        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUShort(r);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

}

