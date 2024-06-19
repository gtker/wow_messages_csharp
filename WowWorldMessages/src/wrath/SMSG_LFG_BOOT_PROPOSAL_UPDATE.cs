using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_BOOT_PROPOSAL_UPDATE: WrathServerMessage, IWorldMessage {
    public required bool VoteInProgress { get; set; }
    public required bool DidVote { get; set; }
    public required bool AgreedWithKick { get; set; }
    public required ulong Victim { get; set; }
    public required uint TotalVotes { get; set; }
    public required uint VotesAgree { get; set; }
    public required uint TimeLeft { get; set; }
    public required uint VotesNeeded { get; set; }
    public required string Reason { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(VoteInProgress, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(DidVote, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(AgreedWithKick, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Victim, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TotalVotes, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(VotesAgree, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeLeft, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(VotesNeeded, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Reason, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 877, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 877, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_BOOT_PROPOSAL_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var voteInProgress = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var didVote = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var agreedWithKick = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var victim = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var totalVotes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var votesAgree = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeLeft = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var votesNeeded = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var reason = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_LFG_BOOT_PROPOSAL_UPDATE {
            VoteInProgress = voteInProgress,
            DidVote = didVote,
            AgreedWithKick = agreedWithKick,
            Victim = victim,
            TotalVotes = totalVotes,
            VotesAgree = votesAgree,
            TimeLeft = timeLeft,
            VotesNeeded = votesNeeded,
            Reason = reason,
        };
    }

    internal int Size() {
        var size = 0;

        // vote_in_progress: Generator.Generated.DataTypeBool
        size += 1;

        // did_vote: Generator.Generated.DataTypeBool
        size += 1;

        // agreed_with_kick: Generator.Generated.DataTypeBool
        size += 1;

        // victim: Generator.Generated.DataTypeGuid
        size += 8;

        // total_votes: Generator.Generated.DataTypeInteger
        size += 4;

        // votes_agree: Generator.Generated.DataTypeInteger
        size += 4;

        // time_left: Generator.Generated.DataTypeSeconds
        size += 4;

        // votes_needed: Generator.Generated.DataTypeInteger
        size += 4;

        // reason: Generator.Generated.DataTypeCstring
        size += Reason.Length + 1;

        return size;
    }

}

