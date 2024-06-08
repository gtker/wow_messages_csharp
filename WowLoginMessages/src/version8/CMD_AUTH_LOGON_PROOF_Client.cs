namespace WowLoginMessages.Version8;


[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: Version8ClientMessage, ILoginMessage {
    public class SecurityFlagType {
        public required SecurityFlag Inner;
        public SecurityFlagAuthenticator? Authenticator;
        public SecurityFlagMatrixCard? MatrixCard;
        public SecurityFlagPin? Pin;
    }
    public class SecurityFlagAuthenticator {
        /// <summary>
        /// String entered by the user in the "Authenticator" popup.
        /// Can be empty and up to 16 characters.
        /// Is not used by the client in any way but just sent directly, so this could in theory be used for anything.
        /// </summary>
        public required string Authenticator { get; set; }
    }
    public class SecurityFlagMatrixCard {
        /// <summary>
        /// Client proof of matrix input.
        /// Implementation details at `https://gist.github.com/barncastle/979c12a9c5e64d810a28ad1728e7e0f9`.
        /// </summary>
        public const int MatrixCardProofLength = 20;
        public required byte[] MatrixCardProof { get; set; }
    }
    public class SecurityFlagPin {
        public const int PinHashLength = 20;
        public required byte[] PinHash { get; set; }
        public const int PinSaltLength = 16;
        public required byte[] PinSalt { get; set; }
    }
    public const int ClientPublicKeyLength = 32;
    public required byte[] ClientPublicKey { get; set; }
    public const int ClientProofLength = 20;
    public required byte[] ClientProof { get; set; }
    public const int CrcHashLength = 20;
    public required byte[] CrcHash { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }
    public required SecurityFlagType SecurityFlag { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(1, cancellationToken).ConfigureAwait(false);

        foreach (var v in ClientPublicKey) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientProof) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in CrcHash) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)TelemetryKeys.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in TelemetryKeys) {
            await v.WriteAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)SecurityFlag.Inner, cancellationToken).ConfigureAwait(false);

        if (SecurityFlag.Pin is {} pin) {
            foreach (var v in pin.PinSalt) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in pin.PinHash) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

        }

        if (SecurityFlag.MatrixCard is {} matrixCard) {
            foreach (var v in matrixCard.MatrixCardProof) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

        }

        if (SecurityFlag.Authenticator is {} authenticator) {
            await w.WriteString(authenticator.Authenticator, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var clientPublicKey = new byte[ClientPublicKeyLength];
        for (var i = 0; i < ClientPublicKeyLength; ++i) {
            clientPublicKey[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        var clientProof = new byte[ClientProofLength];
        for (var i = 0; i < ClientProofLength; ++i) {
            clientProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        var crcHash = new byte[CrcHashLength];
        for (var i = 0; i < CrcHashLength; ++i) {
            crcHash[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfTelemetryKeys = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var telemetryKeys = new List<TelemetryKey>();
        for (var i = 0; i < numberOfTelemetryKeys; ++i) {
            telemetryKeys.Add(await Version8.TelemetryKey.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var securityFlag = new SecurityFlagType {
            Inner = (SecurityFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false),
        };

        if (securityFlag.Inner.HasFlag(Version8.SecurityFlag.Pin)) {
            var pinSalt = new byte[SecurityFlagPin.PinSaltLength];
            for (var i = 0; i < SecurityFlagPin.PinSaltLength; ++i) {
                pinSalt[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            var pinHash = new byte[SecurityFlagPin.PinHashLength];
            for (var i = 0; i < SecurityFlagPin.PinHashLength; ++i) {
                pinHash[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            securityFlag.Pin = new SecurityFlagPin {
                PinHash = pinHash,
                PinSalt = pinSalt,
            };
        }

        if (securityFlag.Inner.HasFlag(Version8.SecurityFlag.MatrixCard)) {
            var matrixCardProof = new byte[SecurityFlagMatrixCard.MatrixCardProofLength];
            for (var i = 0; i < SecurityFlagMatrixCard.MatrixCardProofLength; ++i) {
                matrixCardProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            securityFlag.MatrixCard = new SecurityFlagMatrixCard {
                MatrixCardProof = matrixCardProof,
            };
        }

        if (securityFlag.Inner.HasFlag(Version8.SecurityFlag.Authenticator)) {
            var authenticator = await r.ReadString(cancellationToken).ConfigureAwait(false);

            securityFlag.Authenticator = new SecurityFlagAuthenticator {
                Authenticator = authenticator,
            };
        }

        return new CMD_AUTH_LOGON_PROOF_Client {
            ClientPublicKey = clientPublicKey,
            ClientProof = clientProof,
            CrcHash = crcHash,
            TelemetryKeys = telemetryKeys,
            SecurityFlag = securityFlag,
        };
    }

}

