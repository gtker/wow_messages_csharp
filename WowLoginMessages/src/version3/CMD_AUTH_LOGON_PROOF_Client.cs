namespace WowLoginMessages.Version3;

using SecurityFlagType = OneOf.OneOf<CMD_AUTH_LOGON_PROOF_Client.SecurityFlagPin, SecurityFlag>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: Version3ClientMessage, ILoginMessage {
    public class SecurityFlagPin {
        public required List<byte> PinHash { get; set; }
        public required List<byte> PinSalt { get; set; }
    }
    public required List<byte> ClientPublicKey { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> CrcHash { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }
    public required SecurityFlagType SecurityFlag { get; set; }
    internal SecurityFlag SecurityFlagValue => SecurityFlag.Match(
        _ => Version3.SecurityFlag.Pin,
        v => v
    );

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

        await WriteUtils.WriteByte(w, (byte)SecurityFlagValue, cancellationToken).ConfigureAwait(false);

        if (SecurityFlag.Value is CMD_AUTH_LOGON_PROOF_Client.SecurityFlagPin securityFlag) {
            foreach (var v in securityFlag.PinSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in securityFlag.PinHash) {
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
            telemetryKeys.Add(await TelemetryKey.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        SecurityFlagType securityFlag = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        if (securityFlag.Value is Version3.SecurityFlag.Pin) {
            var pinSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            var pinHash = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                pinHash.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            securityFlag = new SecurityFlagPin {
                PinHash = pinHash,
                PinSalt = pinSalt,
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

