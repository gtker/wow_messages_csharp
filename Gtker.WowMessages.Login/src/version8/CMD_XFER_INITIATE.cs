namespace Gtker.WowMessages.Login.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_INITIATE: Version8ServerMessage, ILoginMessage {
    public required string Filename { get; set; }
    public required ulong FileSize { get; set; }
    public required List<byte> FileMd5 { get; set; }

    public static async Task<CMD_XFER_INITIATE> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var filename = await ReadUtils.ReadString(r, cancellationToken).ConfigureAwait(false);

        var fileSize = await ReadUtils.ReadULong(r, cancellationToken).ConfigureAwait(false);

        var fileMd5 = new List<byte>();
        for (var i = 0; i < 16; ++i) {
            fileMd5.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
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

        await WriteUtils.WriteString(w, Filename, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteULong(w, FileSize, cancellationToken).ConfigureAwait(false);

        foreach (var v in FileMd5) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

    }

}

