namespace WowLoginMessages.All;

public abstract class AllClientMessage {}

public static class ClientOpcodeReader {
    public static async Task<AllClientMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var opcode = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        return opcode switch {
            0 => await CMD_AUTH_LOGON_CHALLENGE_Client.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            2 => await CMD_AUTH_RECONNECT_CHALLENGE_Client.ReadAsync(r, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: AllClientMessage {
        if (await ReadAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
