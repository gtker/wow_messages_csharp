namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_DATA: Version5ServerMessage, ILoginMessage {
    public required List<byte> Data { get; set; }

    public static async Task<CMD_XFER_DATA> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r, cancellationToken);

        var data = new List<byte>();
        for (var i = 0; i < size; ++i) {
            data.Add(await ReadUtils.ReadByte(r, cancellationToken));
        }

        return new CMD_XFER_DATA {
            Data = data,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 49, cancellationToken);

        await WriteUtils.WriteUShort(w, (ushort)Data.Count, cancellationToken);

        foreach (var v in Data) {
            await WriteUtils.WriteByte(w, v, cancellationToken);
        }

    }

}

