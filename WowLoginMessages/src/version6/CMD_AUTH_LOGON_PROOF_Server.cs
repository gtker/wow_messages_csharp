namespace WowLoginMessages.Version6;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version6ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public required uint HardwareSurveyId { get; set; }
        public required List<byte> ServerProof { get; set; }
        public required ushort Unknown { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version6.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 1, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess result) {
            foreach (var v in result.ServerProof) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteUInt(w, result.HardwareSurveyId, cancellationToken).ConfigureAwait(false);

            await WriteUtils.WriteUShort(w, result.Unknown, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        LoginResultType result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        if (result.Value is Version6.LoginResult.Success) {
            var serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            var hardwareSurveyId = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

            var unknown = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

            result = new LoginResultSuccess {
                HardwareSurveyId = hardwareSurveyId,
                ServerProof = serverProof,
                Unknown = unknown,
            };
        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
        };
    }

}

