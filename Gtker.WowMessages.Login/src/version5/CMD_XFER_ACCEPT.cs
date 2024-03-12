// This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
// Empty reads will have an unnecessary async keyword
#pragma warning disable 1998
namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_ACCEPT: ILoginMessage {

    public static async Task<CMD_XFER_ACCEPT> ReadAsync(Stream r) {
        return new CMD_XFER_ACCEPT {
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 50);

    }

}

