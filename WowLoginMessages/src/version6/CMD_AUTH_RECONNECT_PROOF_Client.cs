namespace WowLoginMessages.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Client: Version6ClientMessage, ILoginMessage {
    public const int ProofDataLength = 16;
    public required byte[] ProofData { get; set; }
    public const int ClientProofLength = 20;
    public required byte[] ClientProof { get; set; }
    public const int ClientChecksumLength = 20;
    public required byte[] ClientChecksum { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(3, cancellationToken).ConfigureAwait(false);

        foreach (var v in ProofData) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientProof) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientChecksum) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte(0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var proofData = new byte[ProofDataLength];
        for (var i = 0; i < ProofDataLength; ++i) {
            proofData[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        var clientProof = new byte[ClientProofLength];
        for (var i = 0; i < ClientProofLength; ++i) {
            clientProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        var clientChecksum = new byte[ClientChecksumLength];
        for (var i = 0; i < ClientChecksumLength; ++i) {
            clientChecksum[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        // ReSharper disable once UnusedVariable.Compiler
        var keyCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_PROOF_Client {
            ProofData = proofData,
            ClientProof = clientProof,
            ClientChecksum = clientChecksum,
        };
    }

}

