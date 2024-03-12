namespace Gtker.WowMessages.Login.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version6ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerProof { get; set; }
    public uint HardwareSurveyId { get; set; }
    public ushort Unknown { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var serverProof = default(List<byte>);
        var hardwareSurveyId = default(uint);
        var unknown = default(ushort);

        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken);

        if (result == LoginResult.Success) {
            serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            hardwareSurveyId = await ReadUtils.ReadUInt(r, cancellationToken);

            unknown = await ReadUtils.ReadUShort(r, cancellationToken);

        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
            ServerProof = serverProof,
            HardwareSurveyId = hardwareSurveyId,
            Unknown = unknown,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 1, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerProof) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            await WriteUtils.WriteUInt(w, HardwareSurveyId, cancellationToken);

            await WriteUtils.WriteUShort(w, Unknown, cancellationToken);

        }

    }

}

