namespace Gtker.WowMessages.Login.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_SURVEY_RESULT: Version3ClientMessage, ILoginMessage {
    public required uint SurveyId { get; set; }
    public required byte Error { get; set; }
    public required List<byte> Data { get; set; }

    public static async Task<CMD_SURVEY_RESULT> ReadAsync(Stream r) {
        var surveyId = await ReadUtils.ReadUInt(r);

        var error = await ReadUtils.ReadByte(r);

        // ReSharper disable once UnusedVariable.Compiler
        var compressedDataLength = await ReadUtils.ReadUShort(r);

        var data = new List<byte>();
        for (var i = 0; i < compressedDataLength; ++i) {
            data.Add(await ReadUtils.ReadByte(r));
        }

        return new CMD_SURVEY_RESULT {
            SurveyId = surveyId,
            Error = error,
            Data = data,
        };
    }

    public async Task WriteAsync(Stream w) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 4);

        await WriteUtils.WriteUInt(w, SurveyId);

        await WriteUtils.WriteByte(w, Error);

        await WriteUtils.WriteUShort(w, (ushort)Data.Count);

        foreach (var v in Data) {
            await WriteUtils.WriteByte(w, v);
        }

    }

}

