namespace WowLoginMessages.Version7;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version7ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public required uint HardwareSurveyId { get; set; }
        public const int ServerProofLength = 20;
        public required byte[] ServerProof { get; set; }
        public required ushort Unknown { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version7.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess success) {
            foreach (var v in success.ServerProof) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteUInt(success.HardwareSurveyId, cancellationToken).ConfigureAwait(false);

            await w.WriteUShort(success.Unknown, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version7.LoginResult.Success) {
            var serverProof = new byte[LoginResultSuccess.ServerProofLength];
            for (var i = 0; i < LoginResultSuccess.ServerProofLength; ++i) {
                serverProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            var hardwareSurveyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

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

