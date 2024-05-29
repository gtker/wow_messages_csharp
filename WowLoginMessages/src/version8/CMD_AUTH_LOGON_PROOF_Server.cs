namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version8ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerProof { get; set; }
    public AccountFlag AccountFlag { get; set; }
    public uint HardwareSurveyId { get; set; }
    public ushort Unknown { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 1, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken).ConfigureAwait(false);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerProof) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteUInt(w, (uint)AccountFlag, cancellationToken).ConfigureAwait(false);

            await WriteUtils.WriteUInt(w, HardwareSurveyId, cancellationToken).ConfigureAwait(false);

            await WriteUtils.WriteUShort(w, Unknown, cancellationToken).ConfigureAwait(false);

        }
        else {
            await WriteUtils.WriteUShort(w, 0, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var serverProof = default(List<byte>);
        var accountFlag = default(AccountFlag);
        var hardwareSurveyId = default(uint);
        var unknown = default(ushort);
        var padding = default(ushort);

        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        if (result == LoginResult.Success) {
            serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            accountFlag = (AccountFlag)await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

            hardwareSurveyId = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

            unknown = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        }
        else {
            // ReSharper disable once UnusedVariable.Compiler
            padding = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
            ServerProof = serverProof,
            AccountFlag = accountFlag,
            HardwareSurveyId = hardwareSurveyId,
            Unknown = unknown,
        };
    }

}

