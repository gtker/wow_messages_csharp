namespace WowLoginMessages.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server: Version6ServerMessage, ILoginMessage {
    public required Version6.LoginResult Result { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(3, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Result, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var result = (Version6.LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

}

