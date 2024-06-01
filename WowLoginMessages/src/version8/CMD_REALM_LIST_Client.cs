namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Client: Version8ClientMessage, ILoginMessage {

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(16, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_REALM_LIST_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var padding = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMD_REALM_LIST_Client {
        };
    }

}

