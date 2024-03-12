namespace Gtker.WowMessages.Login.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerProof { get; set; }
    public uint HardwareSurveyId { get; set; }
    public ushort Unknown { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r) {
        var serverProof = default(List<byte>);
        var hardwareSurveyId = default(uint);
        var unknown = default(ushort);

        var result = (LoginResult)await ReadUtils.ReadByte(r);

        if (result == LoginResult.Success) {
            serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r));
            }

            hardwareSurveyId = await ReadUtils.ReadUInt(r);

            unknown = await ReadUtils.ReadUShort(r);

        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
            ServerProof = serverProof,
            HardwareSurveyId = hardwareSurveyId,
            Unknown = unknown,
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

            await WriteUtils.WriteUShort(w, Unknown);

        }

    }

}
