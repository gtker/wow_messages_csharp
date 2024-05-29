namespace WowLoginMessages.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Client: Version3ClientMessage, ILoginMessage {

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 16, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, 0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_REALM_LIST_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        return new CMD_REALM_LIST_Client {
        };
    }

}

