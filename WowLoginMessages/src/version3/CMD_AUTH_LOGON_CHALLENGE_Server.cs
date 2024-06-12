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
        public const int CrcSaltLength = 16;
        public required byte[] CrcSalt { get; set; }
        public required List<byte> Generator { get; set; }
        public required List<byte> LargeSafePrime { get; set; }
        public const int SaltLength = 32;
        public required byte[] Salt { get; set; }
        public required SecurityFlagType SecurityFlag { get; set; }
        internal SecurityFlag SecurityFlagValue => SecurityFlag.Match(
            _ => Version3.SecurityFlag.Pin,
            v => v
        );
        public const int ServerPublicKeyLength = 32;
        public required byte[] ServerPublicKey { get; set; }
    }
    public class SecurityFlagPin {
        /// <summary>
        /// Used to randomize the layout of the PIN keypad.
        /// </summary>
        public required uint PinGridSeed { get; set; }
        public const int PinSaltLength = 16;
        public required byte[] PinSalt { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version3.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(0, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(0, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_CHALLENGE_Server.LoginResultSuccess loginResultSuccess) {
            foreach (var v in loginResultSuccess.ServerPublicKey) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteByte((byte)loginResultSuccess.Generator.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in loginResultSuccess.Generator) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteByte((byte)loginResultSuccess.LargeSafePrime.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in loginResultSuccess.LargeSafePrime) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in loginResultSuccess.Salt) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in loginResultSuccess.CrcSalt) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteByte((byte)loginResultSuccess.SecurityFlagValue, cancellationToken).ConfigureAwait(false);

            if (loginResultSuccess.SecurityFlag.Value is CMD_AUTH_LOGON_CHALLENGE_Server.SecurityFlagPin securityFlagPin) {
                await w.WriteUInt(securityFlagPin.PinGridSeed, cancellationToken).ConfigureAwait(false);

                foreach (var v in securityFlagPin.PinSalt) {
                    await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
                }

            }

        }

    }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version3.LoginResult.Success) {
            var serverPublicKey = new byte[LoginResultSuccess.ServerPublicKeyLength];
            for (var i = 0; i < LoginResultSuccess.ServerPublicKeyLength; ++i) {
                serverPublicKey[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            // ReSharper disable once UnusedVariable.Compiler
            var generatorLength = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var generator = new List<byte>();
            for (var i = 0; i < generatorLength; ++i) {
                generator.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            }

            // ReSharper disable once UnusedVariable.Compiler
            var largeSafePrimeLength = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var largeSafePrime = new List<byte>();
            for (var i = 0; i < largeSafePrimeLength; ++i) {
                largeSafePrime.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            }

            var salt = new byte[LoginResultSuccess.SaltLength];
            for (var i = 0; i < LoginResultSuccess.SaltLength; ++i) {
                salt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            var crcSalt = new byte[LoginResultSuccess.CrcSaltLength];
            for (var i = 0; i < LoginResultSuccess.CrcSaltLength; ++i) {
                crcSalt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            SecurityFlagType securityFlag = (SecurityFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            if (securityFlag.Value is Version3.SecurityFlag.Pin) {
                var pinGridSeed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var pinSalt = new byte[SecurityFlagPin.PinSaltLength];
                for (var i = 0; i < SecurityFlagPin.PinSaltLength; ++i) {
                    pinSalt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
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

