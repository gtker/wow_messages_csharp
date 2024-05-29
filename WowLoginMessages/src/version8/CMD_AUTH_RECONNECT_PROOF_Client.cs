namespace WowLoginMessages.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_RECONNECT_PROOF_Client: Version8ClientMessage, ILoginMessage {
    public required List<byte> ProofData { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<byte> ClientChecksum { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 3, cancellationToken).ConfigureAwait(false);

        foreach (var v in ProofData) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientProof) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in ClientChecksum) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_AUTH_RECONNECT_PROOF_Client> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var proofData = new List<byte>();
        for (var i = 0; i < 16; ++i) {
            proofData.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        var clientChecksum = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientChecksum.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var keyCount = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        return new CMD_AUTH_RECONNECT_PROOF_Client {
            ProofData = proofData,
            ClientProof = clientProof,
            ClientChecksum = clientChecksum,
        };
    }

}

