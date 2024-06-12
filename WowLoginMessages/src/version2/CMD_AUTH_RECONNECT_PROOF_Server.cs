namespace WowLoginMessages.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server: Version2ServerMessage, ILoginMessage {
    public required Version2.LoginResult Result { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(3, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Result, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var result = (Version2.LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

}

