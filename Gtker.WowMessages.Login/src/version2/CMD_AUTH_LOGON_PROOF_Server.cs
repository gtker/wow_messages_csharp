namespace Gtker.WowMessages.Login.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerProof { get; set; }
    public uint HardwareSurveyId { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r) {
        var serverProof = default(List<byte>);
        var hardwareSurveyId = default(uint);

        var result = (LoginResult)await ReadUtils.ReadByte(r);

        if (result == LoginResult.Success) {
            serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r));
            }

            hardwareSurveyId = await ReadUtils.ReadUInt(r);

        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
            ServerProof = serverProof,
            HardwareSurveyId = hardwareSurveyId,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 1);

        await WriteUtils.WriteByte(w, (byte)Result);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerProof) {
                await WriteUtils.WriteByte(w, v);
            }

            await WriteUtils.WriteUInt(w, HardwareSurveyId);

        }

    }

}

