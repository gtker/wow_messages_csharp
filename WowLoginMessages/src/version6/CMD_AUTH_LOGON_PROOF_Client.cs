namespace WowLoginMessages.Version6;


[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: Version6ClientMessage, ILoginMessage {
    public class SecurityFlagType {
        public required SecurityFlag Inner;
        public SecurityFlagMatrixCard? MatrixCard;
        public SecurityFlagPin? Pin;
    }
    public class SecurityFlagMatrixCard {
        /// <summary>
        /// Client proof of matrix input.
        /// Implementation details at `https://gist.github.com/barncastle/979c12a9c5e64d810a28ad1728e7e0f9`.
        /// </summary>
        public required List<byte> MatrixCardProof { get; set; }
    }
    public class SecurityFlagPin {
        public required List<byte> PinHash { get; set; }
        public required List<byte> PinSalt { get; set; }
    }
    public required List<byte> ClientPublicKey { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> CrcHash { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }
    public required SecurityFlagType SecurityFlag { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 1, cancellationToken).ConfigureAwait(false);

        foreach (var v in ClientPublicKey) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientProof) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in CrcHash) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        await WriteUtils.WriteByte(w, (byte)TelemetryKeys.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in TelemetryKeys) {
            await v.WriteAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await WriteUtils.WriteByte(w, (byte)SecurityFlag.Inner, cancellationToken).ConfigureAwait(false);

        if (SecurityFlag.Pin is {} pin) {
            foreach (var v in pin.PinSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in pin.PinHash) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

        }

        if (SecurityFlag.MatrixCard is {} matrixCard) {
            foreach (var v in matrixCard.MatrixCardProof) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var clientPublicKey = new List<byte>();
        for (var i = 0; i < 32; ++i) {
            clientPublicKey.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        var crcHash = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            crcHash.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfTelemetryKeys = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var telemetryKeys = new List<TelemetryKey>();
        for (var i = 0; i < numberOfTelemetryKeys; ++i) {
            telemetryKeys.Add(await Version6.TelemetryKey.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var securityFlag = new SecurityFlagType {
            Inner = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false),
        };

        if (securityFlag.Inner.HasFlag(Version6.SecurityFlag.Pin)) {
            var pinSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            var pinHash = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                pinHash.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            securityFlag.Pin = new SecurityFlagPin {
                PinHash = pinHash,
                PinSalt = pinSalt,
            };
        }

        if (securityFlag.Inner.HasFlag(Version6.SecurityFlag.MatrixCard)) {
            var matrixCardProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                matrixCardProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            securityFlag.MatrixCard = new SecurityFlagMatrixCard {
                MatrixCardProof = matrixCardProof,
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

