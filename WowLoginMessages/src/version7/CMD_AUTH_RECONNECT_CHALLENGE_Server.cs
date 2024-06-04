namespace WowLoginMessages.Version7;

using LoginResultType = OneOf.OneOf<CMD_AUTH_RECONNECT_CHALLENGE_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_CHALLENGE_Server: Version7ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public required List<byte> ChallengeData { get; set; }
        public required List<byte> ChecksumSalt { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version7.LoginResult.Success,
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

        if (result.Value is Version7.LoginResult.Success) {
            var challengeData = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                challengeData.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            }

            var checksumSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                checksumSalt.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
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

