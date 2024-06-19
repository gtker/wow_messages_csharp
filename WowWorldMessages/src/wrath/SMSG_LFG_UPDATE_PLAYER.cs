using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using LfgJoinStatusType = OneOf.OneOf<SMSG_LFG_UPDATE_PLAYER.LfgJoinStatusJoined, LfgJoinStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_UPDATE_PLAYER: WrathServerMessage, IWorldMessage {
    public class LfgJoinStatusJoined {
        public required byte Achievements { get; set; }
        public required string Comment { get; set; }
        public required List<uint> Dungeons { get; set; }
        public required byte NoPartialClear { get; set; }
        public required byte Queued { get; set; }
    }
    public required Wrath.LfgUpdateType UpdateType { get; set; }
    public required LfgJoinStatusType JoinStatus { get; set; }
    internal LfgJoinStatus JoinStatusValue => JoinStatus.Match(
        _ => Wrath.LfgJoinStatus.Joined,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)UpdateType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)JoinStatusValue, cancellationToken).ConfigureAwait(false);

        if (JoinStatus.Value is SMSG_LFG_UPDATE_PLAYER.LfgJoinStatusJoined lfgJoinStatusJoined) {
            await w.WriteByte(lfgJoinStatusJoined.Queued, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(lfgJoinStatusJoined.NoPartialClear, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(lfgJoinStatusJoined.Achievements, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)lfgJoinStatusJoined.Dungeons.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in lfgJoinStatusJoined.Dungeons) {
                await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteCString(lfgJoinStatusJoined.Comment, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 871, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 871, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_UPDATE_PLAYER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var updateType = (Wrath.LfgUpdateType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        LfgJoinStatusType joinStatus = (Wrath.LfgJoinStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (joinStatus.Value is Wrath.LfgJoinStatus.Joined) {
            var queued = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var noPartialClear = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var achievements = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            // ReSharper disable once UnusedVariable.Compiler
            var amountOfDungeons = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var dungeons = new List<uint>();
            for (var i = 0; i < amountOfDungeons; ++i) {
                dungeons.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
            }

            var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            joinStatus = new LfgJoinStatusJoined {
                Achievements = achievements,
                Comment = comment,
                Dungeons = dungeons,
                NoPartialClear = noPartialClear,
                Queued = queued,
            };
        }

        return new SMSG_LFG_UPDATE_PLAYER {
            UpdateType = updateType,
            JoinStatus = joinStatus,
        };
    }

    internal int Size() {
        var size = 0;

        // update_type: Generator.Generated.DataTypeEnum
        size += 1;

        // join_status: Generator.Generated.DataTypeEnum
        size += 1;

        if (JoinStatus.Value is SMSG_LFG_UPDATE_PLAYER.LfgJoinStatusJoined lfgJoinStatusJoined) {
            // queued: Generator.Generated.DataTypeInteger
            size += 1;

            // no_partial_clear: Generator.Generated.DataTypeInteger
            size += 1;

            // achievements: Generator.Generated.DataTypeInteger
            size += 1;

            // amount_of_dungeons: Generator.Generated.DataTypeInteger
            size += 1;

            // dungeons: Generator.Generated.DataTypeArray
            size += lfgJoinStatusJoined.Dungeons.Sum(e => 4);

            // comment: Generator.Generated.DataTypeCstring
            size += lfgJoinStatusJoined.Comment.Length + 1;

        }

        return size;
    }

}

