namespace WowLoginMessages.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_INITIATE: Version2ServerMessage, ILoginMessage {
    public required string Filename { get; set; }
    public required ulong FileSize { get; set; }
    public required List<byte> FileMd5 { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(48, cancellationToken).ConfigureAwait(false);

        await w.WriteString(Filename, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(FileSize, cancellationToken).ConfigureAwait(false);

        foreach (var v in FileMd5) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<CMD_XFER_INITIATE> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var filename = await r.ReadString(cancellationToken).ConfigureAwait(false);

        var fileSize = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var fileMd5 = new List<byte>();
        for (var i = 0; i < 16; ++i) {
            fileMd5.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        return new CMD_XFER_INITIATE {
            Filename = filename,
            FileSize = fileSize,
            FileMd5 = fileMd5,
        };
    }

}

