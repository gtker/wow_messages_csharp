namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_DATA: Version8ServerMessage, ILoginMessage {
    public required List<byte> Data { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(49, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Data.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Data) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<CMD_XFER_DATA> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var data = new List<byte>();
        for (var i = 0; i < size; ++i) {
            data.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        return new CMD_XFER_DATA {
            Data = data,
        };
    }

}

