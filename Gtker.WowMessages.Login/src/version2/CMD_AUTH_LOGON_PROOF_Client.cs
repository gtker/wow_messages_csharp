namespace Gtker.WowMessages.Login.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Client: ILoginMessage {
    public required List<byte> ClientPublicKey { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> CrcHash { get; set; }
    public required byte NumberOfTelemetryKeys { get; set; }
    public required List<TelemetryKey> TelemetryKeys { get; set; }

    public static async Task<CMD_AUTH_LOGON_PROOF_Client> ReadAsync(Stream r) {
        var clientPublicKey = new List<byte>();
        for (var i = 0; i < 32; ++i) {
            clientPublicKey.Add(await ReadUtils.ReadByte(r));
        }

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await ReadUtils.ReadByte(r));
        }

        var crcHash = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            crcHash.Add(await ReadUtils.ReadByte(r));
        }

        var numberOfTelemetryKeys = await ReadUtils.ReadByte(r);

        var telemetryKeys = new List<TelemetryKey>();
        for (var i = 0; i < numberOfTelemetryKeys; ++i) {
            telemetryKeys.Add(await TelemetryKey.ReadAsync(r));
        }

        return new CMD_AUTH_LOGON_PROOF_Client {
            ClientPublicKey = clientPublicKey,
            ClientProof = clientProof,
            CrcHash = crcHash,
            NumberOfTelemetryKeys = numberOfTelemetryKeys,
            TelemetryKeys = telemetryKeys,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 1);

        foreach (var v in ClientPublicKey) {
            await WriteUtils.WriteByte(w, v);
        }

        foreach (var v in ClientProof) {
            await WriteUtils.WriteByte(w, v);
        }

        foreach (var v in CrcHash) {
            await WriteUtils.WriteByte(w, v);
        }

        await WriteUtils.WriteByte(w, NumberOfTelemetryKeys);

        foreach (var v in TelemetryKeys) {
            await v.WriteAsync(w);
        }

    }

}

