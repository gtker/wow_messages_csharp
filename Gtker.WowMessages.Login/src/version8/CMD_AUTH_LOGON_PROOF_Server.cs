namespace Gtker.WowMessages.Login.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerProof { get; set; }
    public AccountFlag AccountFlag { get; set; }
    public uint HardwareSurveyId { get; set; }
    public ushort Unknown { get; set; }
    public ushort Padding { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r) {
        var serverProof = default(List<byte>);
        var accountFlag = default(AccountFlag);
        var hardwareSurveyId = default(uint);
        var unknown = default(ushort);
        var padding = default(ushort);

        var result = (LoginResult)await ReadUtils.ReadByte(r);

        if (result == LoginResult.Success) {
            serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r));
            }

            accountFlag = (AccountFlag)await ReadUtils.ReadUInt(r);

            hardwareSurveyId = await ReadUtils.ReadUInt(r);

            unknown = await ReadUtils.ReadUShort(r);

        }
        else {
            // ReSharper disable once UnusedVariable.Compiler
            padding = await ReadUtils.ReadUShort(r);

        }
        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
            ServerProof = serverProof,
            AccountFlag = accountFlag,
            HardwareSurveyId = hardwareSurveyId,
            Unknown = unknown,
            Padding = padding,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 1);

        await WriteUtils.WriteByte(w, (byte)Result);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerProof) {
                await WriteUtils.WriteByte(w, v);
            }

            await WriteUtils.WriteUInt(w, (uint)AccountFlag);

            await WriteUtils.WriteUInt(w, HardwareSurveyId);

            await WriteUtils.WriteUShort(w, Unknown);

        }
        else {
            await WriteUtils.WriteUShort(w, 0);

        }
    }

}

