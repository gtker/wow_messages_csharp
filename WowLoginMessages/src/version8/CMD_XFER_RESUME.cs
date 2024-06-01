namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_RESUME: Version8ClientMessage, ILoginMessage {
    public required ulong Offset { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(51, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Offset, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_XFER_RESUME> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var offset = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new CMD_XFER_RESUME {
            Offset = offset,
        };
    }

}

