namespace Gtker.WowMessages.Login.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_INITIATE: ILoginMessage {
    public required string Filename { get; set; }
    public required ulong FileSize { get; set; }
    public required List<byte> FileMd5 { get; set; }

    public static async Task<CMD_XFER_INITIATE> ReadAsync(Stream r) {
        var filename = await ReadUtils.ReadString(r);

        var fileSize = await ReadUtils.ReadULong(r);

        var fileMd5 = new List<byte>();
        for (var i = 0; i < 16; ++i) {
            fileMd5.Add(await ReadUtils.ReadByte(r));
        }

        return new CMD_XFER_INITIATE {
            Filename = filename,
            FileSize = fileSize,
            FileMd5 = fileMd5,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 48);

        await WriteUtils.WriteString(w, Filename);

        await WriteUtils.WriteULong(w, FileSize);

        foreach (var v in FileMd5) {
            await WriteUtils.WriteByte(w, v);
        }

    }

}

