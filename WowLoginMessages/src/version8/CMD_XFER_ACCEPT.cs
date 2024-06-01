// This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
// Empty reads will have an unnecessary async keyword
#pragma warning disable 1998
namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_ACCEPT: Version8ClientMessage, ILoginMessage {

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(50, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_XFER_ACCEPT> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        return new CMD_XFER_ACCEPT {
        };
    }

}

