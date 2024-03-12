namespace Gtker.WowMessages.Login.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_CHALLENGE_Server: Version6ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ChallengeData { get; set; }
    public List<byte> ChecksumSalt { get; set; }

    public static async Task<CMD_AUTH_RECONNECT_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var challengeData = default(List<byte>);
        var checksumSalt = default(List<byte>);

        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken);

        if (result == LoginResult.Success) {
            challengeData = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                challengeData.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            checksumSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                checksumSalt.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

        }

        return new CMD_AUTH_RECONNECT_CHALLENGE_Server {
            Result = result,
            ChallengeData = challengeData,
            ChecksumSalt = checksumSalt,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 2, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken);

        if (Result == LoginResult.Success) {
            foreach (var v in ChallengeData) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            foreach (var v in ChecksumSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

        }

    }

}

