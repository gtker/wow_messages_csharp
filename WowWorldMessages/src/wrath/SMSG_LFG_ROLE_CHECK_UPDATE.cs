using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_ROLE_CHECK_UPDATE: WrathServerMessage, IWorldMessage {
    public required uint RolecheckState { get; set; }
    public required byte RolecheckInitializing { get; set; }
    public required List<uint> DungeonEntries { get; set; }
    /// <summary>
    /// azerothcore: Leader info MUST be sent first.
    /// </summary>
    public required List<LfgRole> Roles { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RolecheckState, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(RolecheckInitializing, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)DungeonEntries.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in DungeonEntries) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Roles.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Roles) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 867, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 867, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_ROLE_CHECK_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var rolecheckState = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rolecheckInitializing = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfDungeonEntries = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var dungeonEntries = new List<uint>();
        for (var i = 0; i < amountOfDungeonEntries; ++i) {
            dungeonEntries.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfRoles = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var roles = new List<LfgRole>();
        for (var i = 0; i < amountOfRoles; ++i) {
            roles.Add(await Wrath.LfgRole.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_LFG_ROLE_CHECK_UPDATE {
            RolecheckState = rolecheckState,
            RolecheckInitializing = rolecheckInitializing,
            DungeonEntries = dungeonEntries,
            Roles = roles,
        };
    }

    internal int Size() {
        var size = 0;

        // rolecheck_state: Generator.Generated.DataTypeInteger
        size += 4;

        // rolecheck_initializing: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_dungeon_entries: Generator.Generated.DataTypeInteger
        size += 1;

        // dungeon_entries: Generator.Generated.DataTypeArray
        size += DungeonEntries.Sum(e => 4);

        // amount_of_roles: Generator.Generated.DataTypeInteger
        size += 1;

        // roles: Generator.Generated.DataTypeArray
        size += Roles.Sum(e => 14);

        return size;
    }

}

