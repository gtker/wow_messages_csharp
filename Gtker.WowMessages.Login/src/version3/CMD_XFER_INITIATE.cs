namespace Gtker.WowMessages.Login.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_INITIATE: Version3ServerMessage, ILoginMessage {
    public required string Filename { get; set; }
    public required ulong FileSize { get; set; }
    public required List<byte> FileMd5 { get; set; }

    public static async Task<CMD_XFER_INITIATE> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var filename = await ReadUtils.ReadString(r, cancellationToken);

        var fileSize = await ReadUtils.ReadULong(r, cancellationToken);

        var fileMd5 = new List<byte>();
        for (var i = 0; i < 16; ++i) {
            fileMd5.Add(await ReadUtils.ReadByte(r, cancellationToken));
        }

        return new CMD_XFER_INITIATE {
            Filename = filename,
            FileSize = fileSize,
            FileMd5 = fileMd5,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 48, cancellationToken);

        await WriteUtils.WriteString(w, Filename, cancellationToken);

        await WriteUtils.WriteULong(w, FileSize, cancellationToken);

        foreach (var v in FileMd5) {
            await WriteUtils.WriteByte(w, v, cancellationToken);
        }

    }

}

