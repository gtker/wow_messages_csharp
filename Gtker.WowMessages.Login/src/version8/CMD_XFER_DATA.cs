namespace Gtker.WowMessages.Login.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_XFER_DATA: ILoginMessage {
    public required ushort Size { get; set; }
    public required List<byte> Data { get; set; }

    public static async Task<CMD_XFER_DATA> ReadAsync(Stream r) {
        var size = await ReadUtils.ReadUShort(r);

        var data = new List<byte>();
        for (var i = 0; i < size; ++i) {
            data.Add(await ReadUtils.ReadByte(r));
        }

        return new CMD_XFER_DATA {
            Size = size,
            Data = data,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 49);

        await WriteUtils.WriteUShort(w, Size);

        foreach (var v in Data) {
            await WriteUtils.WriteByte(w, v);
        }

    }

}

