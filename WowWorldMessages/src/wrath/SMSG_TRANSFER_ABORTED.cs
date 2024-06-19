using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using TransferAbortReasonType = OneOf.OneOf<SMSG_TRANSFER_ABORTED.TransferAbortReasonDifficultyNotAvailable, SMSG_TRANSFER_ABORTED.TransferAbortReasonInsufficientExpansionLevel, SMSG_TRANSFER_ABORTED.TransferAbortReasonUniqueMessage, TransferAbortReason>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_TRANSFER_ABORTED: WrathServerMessage, IWorldMessage {
    public class TransferAbortReasonDifficultyNotAvailable {
        public required Wrath.DungeonDifficulty Difficulty { get; set; }
    }
    public class TransferAbortReasonInsufficientExpansionLevel {
        public required Wrath.DungeonDifficulty Difficulty { get; set; }
    }
    public class TransferAbortReasonUniqueMessage {
        public required Wrath.DungeonDifficulty Difficulty { get; set; }
    }
    public required Wrath.Map Map { get; set; }
    public required TransferAbortReasonType Reason { get; set; }
    internal TransferAbortReason ReasonValue => Reason.Match(
        _ => Wrath.TransferAbortReason.DifficultyNotAvailable,
        _ => Wrath.TransferAbortReason.InsufficientExpansionLevel,
        _ => Wrath.TransferAbortReason.UniqueMessage,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ReasonValue, cancellationToken).ConfigureAwait(false);

        if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonInsufficientExpansionLevel transferAbortReasonInsufficientExpansionLevel) {
            await w.WriteByte((byte)transferAbortReasonInsufficientExpansionLevel.Difficulty, cancellationToken).ConfigureAwait(false);

        }
        else if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonDifficultyNotAvailable transferAbortReasonDifficultyNotAvailable) {
            await w.WriteByte((byte)transferAbortReasonDifficultyNotAvailable.Difficulty, cancellationToken).ConfigureAwait(false);

        }
        else if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonUniqueMessage transferAbortReasonUniqueMessage) {
            await w.WriteByte((byte)transferAbortReasonUniqueMessage.Difficulty, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 64, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 64, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_TRANSFER_ABORTED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        TransferAbortReasonType reason = (Wrath.TransferAbortReason)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (reason.Value is Wrath.TransferAbortReason.InsufficientExpansionLevel) {
            var difficulty = (Wrath.DungeonDifficulty)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            reason = new TransferAbortReasonInsufficientExpansionLevel {
                Difficulty = difficulty,
            };
        }
        else if (reason.Value is Wrath.TransferAbortReason.DifficultyNotAvailable) {
            var difficulty = (Wrath.DungeonDifficulty)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            reason = new TransferAbortReasonDifficultyNotAvailable {
                Difficulty = difficulty,
            };
        }
        else if (reason.Value is Wrath.TransferAbortReason.UniqueMessage) {
            var difficulty = (Wrath.DungeonDifficulty)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            reason = new TransferAbortReasonUniqueMessage {
                Difficulty = difficulty,
            };
        }

        return new SMSG_TRANSFER_ABORTED {
            Map = map,
            Reason = reason,
        };
    }

    internal int Size() {
        var size = 0;

        // map: Generator.Generated.DataTypeEnum
        size += 4;

        // reason: Generator.Generated.DataTypeEnum
        size += 1;

        if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonInsufficientExpansionLevel transferAbortReasonInsufficientExpansionLevel) {
            // difficulty: Generator.Generated.DataTypeEnum
            size += 1;

        }
        else if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonDifficultyNotAvailable transferAbortReasonDifficultyNotAvailable) {
            // difficulty: Generator.Generated.DataTypeEnum
            size += 1;

        }
        else if (Reason.Value is SMSG_TRANSFER_ABORTED.TransferAbortReasonUniqueMessage transferAbortReasonUniqueMessage) {
            // difficulty: Generator.Generated.DataTypeEnum
            size += 1;

        }

        return size;
    }

}

