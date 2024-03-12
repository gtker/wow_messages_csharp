namespace Gtker.WowMessages.Login.Version6;

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

