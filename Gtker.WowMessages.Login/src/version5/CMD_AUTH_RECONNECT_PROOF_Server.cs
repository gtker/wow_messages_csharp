namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server: Version5ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken);

        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUShort(r, cancellationToken);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 3, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken);

        await WriteUtils.WriteUShort(w, 0, cancellationToken);

    }

}

