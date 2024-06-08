namespace WowLoginMessages.Version8;

using LoginResultType = OneOf.OneOf<CMD_AUTH_RECONNECT_CHALLENGE_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_CHALLENGE_Server: Version8ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public const int ChallengeDataLength = 16;
        public required byte[] ChallengeData { get; set; }
        public const int ChecksumSaltLength = 16;
        public required byte[] ChecksumSalt { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version8.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_RECONNECT_CHALLENGE_Server.LoginResultSuccess success) {
            foreach (var v in success.ChallengeData) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in success.ChecksumSalt) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public static async Task<CMD_AUTH_RECONNECT_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version8.LoginResult.Success) {
            var challengeData = new byte[LoginResultSuccess.ChallengeDataLength];
            for (var i = 0; i < LoginResultSuccess.ChallengeDataLength; ++i) {
                challengeData[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            var checksumSalt = new byte[LoginResultSuccess.ChecksumSaltLength];
            for (var i = 0; i < LoginResultSuccess.ChecksumSaltLength; ++i) {
                checksumSalt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            result = new LoginResultSuccess {
                ChallengeData = challengeData,
                ChecksumSalt = checksumSalt,
            };
        }

        return new CMD_AUTH_RECONNECT_CHALLENGE_Server {
            Result = result,
        };
    }

}

