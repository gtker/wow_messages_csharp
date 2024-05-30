namespace WowLoginMessages.Version3;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_CHALLENGE_Server.LoginResultSuccess, LoginResult>;
using SecurityFlagType = OneOf.OneOf<CMD_AUTH_LOGON_CHALLENGE_Server.SecurityFlagPin, SecurityFlag>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Server: Version3ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        /// <summary>
        /// Used for the `crc_hash` in [CMD_AUTH_LOGON_PROOF_Client].
        /// </summary>
        public required List<byte> CrcSalt { get; set; }
        public required List<byte> Generator { get; set; }
        public required List<byte> LargeSafePrime { get; set; }
        public required List<byte> Salt { get; set; }
        public required SecurityFlagType SecurityFlag { get; set; }
        internal SecurityFlag SecurityFlagValue => SecurityFlag.Match(
            _ => Version3.SecurityFlag.Pin,
            v => v
        );
        public required List<byte> ServerPublicKey { get; set; }
    }
    public class SecurityFlagPin {
        /// <summary>
        /// Used to randomize the layout of the PIN keypad.
        /// </summary>
        public required uint PinGridSeed { get; set; }
        public required List<byte> PinSalt { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version3.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_CHALLENGE_Server.LoginResultSuccess result) {
            foreach (var v in result.ServerPublicKey) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)result.Generator.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in result.Generator) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)result.LargeSafePrime.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in result.LargeSafePrime) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in result.Salt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in result.CrcSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)result.SecurityFlagValue, cancellationToken).ConfigureAwait(false);

            if (result.SecurityFlag.Value is CMD_AUTH_LOGON_CHALLENGE_Server.SecurityFlagPin securityFlag) {
                await WriteUtils.WriteUInt(w, securityFlag.PinGridSeed, cancellationToken).ConfigureAwait(false);

                foreach (var v in securityFlag.PinSalt) {
                    await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
                }

            }

        }

    }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        LoginResultType result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        if (result.Value is Version3.LoginResult.Success) {
            var serverPublicKey = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                serverPublicKey.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            // ReSharper disable once UnusedVariable.Compiler
            var generatorLength = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            var generator = new List<byte>();
            for (var i = 0; i < generatorLength; ++i) {
                generator.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            // ReSharper disable once UnusedVariable.Compiler
            var largeSafePrimeLength = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            var largeSafePrime = new List<byte>();
            for (var i = 0; i < largeSafePrimeLength; ++i) {
                largeSafePrime.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            var salt = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                salt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            var crcSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                crcSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            SecurityFlagType securityFlag = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            if (securityFlag.Value is Version3.SecurityFlag.Pin) {
                var pinGridSeed = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

                var pinSalt = new List<byte>();
                for (var i = 0; i < 16; ++i) {
                    pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
                }

                securityFlag = new SecurityFlagPin {
                    PinGridSeed = pinGridSeed,
                    PinSalt = pinSalt,
                };
            }

            result = new LoginResultSuccess {
                CrcSalt = crcSalt,
                Generator = generator,
                LargeSafePrime = largeSafePrime,
                Salt = salt,
                SecurityFlag = securityFlag,
                ServerPublicKey = serverPublicKey,
            };
        }

        return new CMD_AUTH_LOGON_CHALLENGE_Server {
            Result = result,
        };
    }

}

