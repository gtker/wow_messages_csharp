namespace WowLoginMessages.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_SURVEY_RESULT: Version3ClientMessage, ILoginMessage {
    public required uint SurveyId { get; set; }
    public required byte Error { get; set; }
    public required List<byte> Data { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 4, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, SurveyId, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, Error, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUShort(w, (ushort)Data.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Data) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<CMD_SURVEY_RESULT> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var surveyId = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var error = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var compressedDataLength = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        var data = new List<byte>();
        for (var i = 0; i < compressedDataLength; ++i) {
            data.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        return new CMD_SURVEY_RESULT {
            SurveyId = surveyId,
            Error = error,
            Data = data,
        };
    }

}

