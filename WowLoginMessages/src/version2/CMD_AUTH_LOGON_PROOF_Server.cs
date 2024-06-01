namespace WowLoginMessages.Version2;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version2ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public required uint HardwareSurveyId { get; set; }
        public required List<byte> ServerProof { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version2.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess result) {
            foreach (var v in result.ServerProof) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteUInt(result.HardwareSurveyId, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version2.LoginResult.Success) {
            var serverProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                serverProof.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            }

            var hardwareSurveyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new LoginResultSuccess {
                HardwareSurveyId = hardwareSurveyId,
                ServerProof = serverProof,
            };
        }

        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
        };
    }

}

