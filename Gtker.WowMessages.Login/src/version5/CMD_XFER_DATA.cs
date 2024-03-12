namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_DATA: ILoginMessage {
    public required List<byte> Data { get; set; }

    public static async Task<CMD_XFER_DATA> ReadAsync(Stream r) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r);

        var data = new List<byte>();
        for (var i = 0; i < size; ++i) {
            data.Add(await ReadUtils.ReadByte(r));
        }

        return new CMD_XFER_DATA {
            Data = data,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 49);

        await WriteUtils.WriteUShort(w, (ushort)Data.Count);

        foreach (var v in Data) {
            await WriteUtils.WriteByte(w, v);
        }

    }

}

