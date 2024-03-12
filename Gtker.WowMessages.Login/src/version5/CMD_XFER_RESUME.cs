namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_RESUME: Version5ClientMessage, ILoginMessage {
    public required ulong Offset { get; set; }

    public static async Task<CMD_XFER_RESUME> ReadAsync(Stream r) {
        var offset = await ReadUtils.ReadULong(r);

        return new CMD_XFER_RESUME {
            Offset = offset,
        };
    }

    public async Task WriteAsync(Stream w) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 51);

        await WriteUtils.WriteULong(w, Offset);

    }

}

