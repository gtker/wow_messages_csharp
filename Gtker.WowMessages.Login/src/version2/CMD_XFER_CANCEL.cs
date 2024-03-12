namespace Gtker.WowMessages.Login.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_CANCEL: ILoginMessage {

    public static async Task<CMD_XFER_CANCEL> ReadAsync(Stream r) {
        return new CMD_XFER_CANCEL {
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 52);

    }

}

