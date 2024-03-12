namespace Gtker.WowMessages.Login.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: Version8ClientMessage, ILoginMessage {
    public required List<byte> ClientPublicKey { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> CrcHash { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }
    public required SecurityFlag SecurityFlag { get; set; }
    public List<byte> PinSalt { get; set; }
    public List<byte> PinHash { get; set; }
    /// <summary>
    /// Client proof of matrix input.
    /// Implementation details at `https://gist.github.com/barncastle/979c12a9c5e64d810a28ad1728e7e0f9`.
    /// </summary>
    public List<byte> MatrixCardProof { get; set; }
    /// <summary>
    /// String entered by the user in the "Authenticator" popup.
    /// Can be empty and up to 16 characters.
    /// Is not used by the client in any way but just sent directly, so this could in theory be used for anything.
    /// </summary>
    public string Authenticator { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var pinSalt = default(List<byte>);
        var pinHash = default(List<byte>);
        var matrixCardProof = default(List<byte>);
        var authenticator = default(string);

        var clientPublicKey = new List<byte>();
        for (var i = 0; i < 32; ++i) {
            clientPublicKey.Add(await ReadUtils.ReadByte(r, cancellationToken));
        }

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await ReadUtils.ReadByte(r, cancellationToken));
        }

        var crcHash = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            crcHash.Add(await ReadUtils.ReadByte(r, cancellationToken));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfTelemetryKeys = await ReadUtils.ReadByte(r, cancellationToken);

        var telemetryKeys = new List<TelemetryKey>();
        for (var i = 0; i < numberOfTelemetryKeys; ++i) {
            telemetryKeys.Add(await TelemetryKey.ReadAsync(r, cancellationToken));
        }

        var securityFlag = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken);

        if (securityFlag.HasFlag(SecurityFlag.Pin)) {
            pinSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            pinHash = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                pinHash.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

        }

        if (securityFlag.HasFlag(SecurityFlag.MatrixCard)) {
            matrixCardProof = new List<byte>();
            for (var i = 0; i < 20; ++i) {
                matrixCardProof.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

        }

        if (securityFlag.HasFlag(SecurityFlag.Authenticator)) {
            authenticator = await ReadUtils.ReadString(r, cancellationToken);

        }

        return new CMD_AUTH_LOGON_PROOF_Client {
            ClientPublicKey = clientPublicKey,
            ClientProof = clientProof,
            CrcHash = crcHash,
            TelemetryKeys = telemetryKeys,
            SecurityFlag = securityFlag,
            PinSalt = pinSalt,
            PinHash = pinHash,
            MatrixCardProof = matrixCardProof,
            Authenticator = authenticator,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 1, cancellationToken);

        foreach (var v in ClientPublicKey) {
            await WriteUtils.WriteByte(w, v, cancellationToken);
        }

        foreach (var v in ClientProof) {
            await WriteUtils.WriteByte(w, v, cancellationToken);
        }

        foreach (var v in CrcHash) {
            await WriteUtils.WriteByte(w, v, cancellationToken);
        }

        await WriteUtils.WriteByte(w, (byte)TelemetryKeys.Count, cancellationToken);

        foreach (var v in TelemetryKeys) {
            await v.WriteAsync(w, cancellationToken);
        }

        await WriteUtils.WriteByte(w, (byte)SecurityFlag, cancellationToken);

        if (SecurityFlag.HasFlag(SecurityFlag.Pin)) {
            foreach (var v in PinSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            foreach (var v in PinHash) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

        }

        if (SecurityFlag.HasFlag(SecurityFlag.MatrixCard)) {
            foreach (var v in MatrixCardProof) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

        }

        if (SecurityFlag.HasFlag(SecurityFlag.Authenticator)) {
            await WriteUtils.WriteString(w, Authenticator, cancellationToken);

        }

    }

}

