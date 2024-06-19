using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_PROPOSAL_UPDATE: WrathServerMessage, IWorldMessage {
    public required uint DungeonId { get; set; }
    public required byte ProposalState { get; set; }
    public required uint ProposalId { get; set; }
    public required uint EncountersFinishedMask { get; set; }
    public required byte Silent { get; set; }
    public required List<LfgProposal> Proposals { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ProposalState, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ProposalId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EncountersFinishedMask, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Silent, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Proposals.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Proposals) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 865, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 865, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_PROPOSAL_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var proposalState = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var proposalId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var encountersFinishedMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var silent = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfProposals = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var proposals = new List<LfgProposal>();
        for (var i = 0; i < amountOfProposals; ++i) {
            proposals.Add(await Wrath.LfgProposal.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_LFG_PROPOSAL_UPDATE {
            DungeonId = dungeonId,
            ProposalState = proposalState,
            ProposalId = proposalId,
            EncountersFinishedMask = encountersFinishedMask,
            Silent = silent,
            Proposals = proposals,
        };
    }

    internal int Size() {
        var size = 0;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // proposal_state: Generator.Generated.DataTypeInteger
        size += 1;

        // proposal_id: Generator.Generated.DataTypeInteger
        size += 4;

        // encounters_finished_mask: Generator.Generated.DataTypeInteger
        size += 4;

        // silent: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_proposals: Generator.Generated.DataTypeInteger
        size += 1;

        // proposals: Generator.Generated.DataTypeArray
        size += Proposals.Sum(e => 9);

        return size;
    }

}

