namespace WowLoginMessages.Version8;

public abstract class Version8ClientMessage {}

public static class ClientOpcodeReader {
    public static async Task<Version8ClientMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var opcode = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        return opcode switch {
            1 => await CMD_AUTH_LOGON_PROOF_Client.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            3 => await CMD_AUTH_RECONNECT_PROOF_Client.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            16 => await CMD_REALM_LIST_Client.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            50 => await CMD_XFER_ACCEPT.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            51 => await CMD_XFER_RESUME.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            52 => await CMD_XFER_CANCEL.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: Version8ClientMessage {
        if (await ReadAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
