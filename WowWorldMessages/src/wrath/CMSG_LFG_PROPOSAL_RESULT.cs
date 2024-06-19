using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LFG_PROPOSAL_RESULT: WrathClientMessage, IWorldMessage {
    public required uint ProposalId { get; set; }
    public required bool AcceptJoin { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ProposalId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(AcceptJoin, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 9, 866, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 9, 866, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LFG_PROPOSAL_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var proposalId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var acceptJoin = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_LFG_PROPOSAL_RESULT {
            ProposalId = proposalId,
            AcceptJoin = acceptJoin,
        };
    }

}

