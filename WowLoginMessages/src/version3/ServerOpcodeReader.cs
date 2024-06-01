namespace WowLoginMessages.Version3;

public abstract class Version3ServerMessage {}

public static class ServerOpcodeReader {
    public static async Task<Version3ServerMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var opcode = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Server.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            1 => await CMD_AUTH_LOGON_PROOF_Server.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            16 => await CMD_REALM_LIST_Server.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            48 => await CMD_XFER_INITIATE.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            49 => await CMD_XFER_DATA.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: Version3ServerMessage {
        if (await ReadAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
