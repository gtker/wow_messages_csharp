namespace WowLoginMessages.Version7;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Server: Version7ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_PROOF_Server {
            Result = result,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 3, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUShort(w, 0, cancellationToken).ConfigureAwait(false);

    }

}

