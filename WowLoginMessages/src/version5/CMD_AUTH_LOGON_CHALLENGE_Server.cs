namespace WowLoginMessages.Version5;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_CHALLENGE_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Server: Version5ServerMessage, ILoginMessage {
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
        public const int ServerPublicKeyLength = 32;
        public required byte[] ServerPublicKey { get; set; }
    }
    public class SecurityFlagType {
        public required SecurityFlag Inner;
        public SecurityFlagMatrixCard? MatrixCard;
        public SecurityFlagPin? Pin;
    }
    public class SecurityFlagMatrixCard {
        /// <summary>
        /// Number of cells to complete.
        /// </summary>
        public required byte ChallengeCount { get; set; }
        /// <summary>
        /// Number of digits to be entered for each cell.
        /// </summary>
        public required byte DigitCount { get; set; }
        /// <summary>
        /// Number of rows to display.
        /// </summary>
        public required byte Height { get; set; }
        /// <summary>
        /// Seed value used to randomize cell selection.
        /// </summary>
        public required ulong Seed { get; set; }
        /// <summary>
        /// Number of columns to display.
        /// </summary>
        public required byte Width { get; set; }
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
        _ => Version5.LoginResult.Success,
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

            await w.WriteByte((byte)loginResultSuccess.SecurityFlag.Inner, cancellationToken).ConfigureAwait(false);

            if (loginResultSuccess.SecurityFlag.Pin is {} securityFlagPin) {
                await w.WriteUInt(securityFlagPin.PinGridSeed, cancellationToken).ConfigureAwait(false);

                foreach (var v in securityFlagPin.PinSalt) {
                    await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
                }

            }

            if (loginResultSuccess.SecurityFlag.MatrixCard is {} securityFlagMatrixCard) {
                await w.WriteByte(securityFlagMatrixCard.Width, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(securityFlagMatrixCard.Height, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(securityFlagMatrixCard.DigitCount, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(securityFlagMatrixCard.ChallengeCount, cancellationToken).ConfigureAwait(false);

                await w.WriteULong(securityFlagMatrixCard.Seed, cancellationToken).ConfigureAwait(false);

            }

        }

    }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version5.LoginResult.Success) {
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

            var securityFlag = new SecurityFlagType {
                Inner = (SecurityFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false),
            };

            if (securityFlag.Inner.HasFlag(Version5.SecurityFlag.Pin)) {
                var pinGridSeed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var pinSalt = new byte[SecurityFlagPin.PinSaltLength];
                for (var i = 0; i < SecurityFlagPin.PinSaltLength; ++i) {
                    pinSalt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                }

                securityFlag.Pin = new SecurityFlagPin {
                    PinGridSeed = pinGridSeed,
                    PinSalt = pinSalt,
                };
            }

            if (securityFlag.Inner.HasFlag(Version5.SecurityFlag.MatrixCard)) {
                var width = await r.ReadByte(cancellationToken).ConfigureAwait(false);

                var height = await r.ReadByte(cancellationToken).ConfigureAwait(false);

                var digitCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

                var challengeCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

                var seed = await r.ReadULong(cancellationToken).ConfigureAwait(false);

                securityFlag.MatrixCard = new SecurityFlagMatrixCard {
                    ChallengeCount = challengeCount,
                    DigitCount = digitCount,
                    Height = height,
                    Seed = seed,
                    Width = width,
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

