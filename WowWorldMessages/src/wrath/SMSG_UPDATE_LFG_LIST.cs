using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using LfgListUpdateTypeType = OneOf.OneOf<SMSG_UPDATE_LFG_LIST.LfgListUpdateTypePartial, LfgListUpdateType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_UPDATE_LFG_LIST: WrathServerMessage, IWorldMessage {
    public class LfgListUpdateTypePartial {
        public required List<ulong> DeletedGuids { get; set; }
    }
    public required Wrath.LfgType LfgType { get; set; }
    public required uint DungeonId { get; set; }
    public required LfgListUpdateTypeType UpdateType { get; set; }
    internal LfgListUpdateType UpdateTypeValue => UpdateType.Match(
        _ => Wrath.LfgListUpdateType.Partial,
        v => v
    );
    /// <summary>
    /// emus set to 0.
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required List<LfgListGroup> Groups { get; set; }
    /// <summary>
    /// emus set to 0.
    /// </summary>
    public required uint Unknown2 { get; set; }
    public required List<LfgListPlayer> Players { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)LfgType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DungeonId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)UpdateTypeValue, cancellationToken).ConfigureAwait(false);

        if (UpdateType.Value is SMSG_UPDATE_LFG_LIST.LfgListUpdateTypePartial lfgListUpdateTypePartial) {
            await w.WriteUInt((uint)lfgListUpdateTypePartial.DeletedGuids.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in lfgListUpdateTypePartial.DeletedGuids) {
                await w.WriteULong(v, cancellationToken).ConfigureAwait(false);
            }

        }

        await w.WriteUInt((uint)Groups.Count, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        foreach (var v in Groups) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)Players.Count, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        foreach (var v in Players) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 864, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 864, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_UPDATE_LFG_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var lfgType = (Wrath.LfgType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeonId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        LfgListUpdateTypeType updateType = (Wrath.LfgListUpdateType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (updateType.Value is Wrath.LfgListUpdateType.Partial) {
            // ReSharper disable once UnusedVariable.Compiler
            var amountOfDeletedGuids = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var deletedGuids = new List<ulong>();
            for (var i = 0; i < amountOfDeletedGuids; ++i) {
                deletedGuids.Add(await r.ReadULong(cancellationToken).ConfigureAwait(false));
            }

            updateType = new LfgListUpdateTypePartial {
                DeletedGuids = deletedGuids,
            };
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfGroups = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var groups = new List<LfgListGroup>();
        for (var i = 0; i < amountOfGroups; ++i) {
            groups.Add(await Wrath.LfgListGroup.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPlayers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var players = new List<LfgListPlayer>();
        for (var i = 0; i < amountOfPlayers; ++i) {
            players.Add(await Wrath.LfgListPlayer.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_UPDATE_LFG_LIST {
            LfgType = lfgType,
            DungeonId = dungeonId,
            UpdateType = updateType,
            Unknown1 = unknown1,
            Groups = groups,
            Unknown2 = unknown2,
            Players = players,
        };
    }

    internal int Size() {
        var size = 0;

        // lfg_type: Generator.Generated.DataTypeEnum
        size += 4;

        // dungeon_id: Generator.Generated.DataTypeInteger
        size += 4;

        // update_type: Generator.Generated.DataTypeEnum
        size += 1;

        if (UpdateType.Value is SMSG_UPDATE_LFG_LIST.LfgListUpdateTypePartial lfgListUpdateTypePartial) {
            // amount_of_deleted_guids: Generator.Generated.DataTypeInteger
            size += 4;

            // deleted_guids: Generator.Generated.DataTypeArray
            size += lfgListUpdateTypePartial.DeletedGuids.Sum(e => 8);

        }

        // amount_of_groups: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // groups: Generator.Generated.DataTypeArray
        size += Groups.Sum(e => e.Size());

        // amount_of_players: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // players: Generator.Generated.DataTypeArray
        size += Players.Sum(e => e.Size());

        return size;
    }

}

