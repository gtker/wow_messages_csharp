namespace WowLoginMessages.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: Version2ClientMessage, ILoginMessage {
    public required List<byte> ClientPublicKey { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> CrcHash { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }

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

    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var clientPublicKey = new List<byte>();
        for (var i = 0; i < 32; ++i) {
            clientPublicKey.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        var crcHash = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            crcHash.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfTelemetryKeys = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var telemetryKeys = new List<TelemetryKey>();
        for (var i = 0; i < numberOfTelemetryKeys; ++i) {
            telemetryKeys.Add(await Version2.TelemetryKey.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new CMD_AUTH_LOGON_PROOF_Client {
            ClientPublicKey = clientPublicKey,
            ClientProof = clientProof,
            CrcHash = crcHash,
            TelemetryKeys = telemetryKeys,
        };
    }

}

