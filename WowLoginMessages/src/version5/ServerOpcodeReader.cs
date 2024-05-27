namespace WowLoginMessages.Version5;

public abstract class Version5ServerMessage {}

public static class ServerOpcodeReader {
    public static async Task<Version5ServerMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var opcode = await ReadUtils.ReadByte(r, cancellationToken);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Server.ReadAsync(r, cancellationToken),
            1 => await CMD_AUTH_LOGON_PROOF_Server.ReadAsync(r, cancellationToken),
            2 => await CMD_AUTH_RECONNECT_CHALLENGE_Server.ReadAsync(r, cancellationToken),
            3 => await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r, cancellationToken),
            16 => await CMD_REALM_LIST_Server.ReadAsync(r, cancellationToken),
            48 => await CMD_XFER_INITIATE.ReadAsync(r, cancellationToken),
            49 => await CMD_XFER_DATA.ReadAsync(r, cancellationToken),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: Version5ServerMessage {
        if (await ReadAsync(r, cancellationToken) is T c) {
            return c;
        }

        return null;
    }
}
