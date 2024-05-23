namespace WowMessages.Login.Version3;

public abstract class Version3ClientMessage {}

public static class ClientOpcodeReader {
    public static async Task<Version3ClientMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var opcode = await ReadUtils.ReadByte(r, cancellationToken);
        return opcode switch {
            1 => await CMD_AUTH_LOGON_PROOF_Client.ReadAsync(r, cancellationToken),
            4 => await CMD_SURVEY_RESULT.ReadAsync(r, cancellationToken),
            16 => await CMD_REALM_LIST_Client.ReadAsync(r, cancellationToken),
            50 => await CMD_XFER_ACCEPT.ReadAsync(r, cancellationToken),
            51 => await CMD_XFER_RESUME.ReadAsync(r, cancellationToken),
            52 => await CMD_XFER_CANCEL.ReadAsync(r, cancellationToken),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: Version3ClientMessage {
        if (await ReadAsync(r, cancellationToken) is T c) {
            return c;
        }

        return null;
    }
}
