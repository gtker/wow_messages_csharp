namespace WowLoginMessages.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_SURVEY_RESULT: Version3ClientMessage, ILoginMessage {
    public required uint SurveyId { get; set; }
    public required byte Error { get; set; }
    public required List<byte> Data { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(4, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SurveyId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Error, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Data.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Data) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<CMD_SURVEY_RESULT> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var surveyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var error = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var compressedDataLength = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var data = new List<byte>();
        for (var i = 0; i < compressedDataLength; ++i) {
            data.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        return new CMD_SURVEY_RESULT {
            SurveyId = surveyId,
            Error = error,
            Data = data,
        };
    }

}

