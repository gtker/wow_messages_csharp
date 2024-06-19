using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_ROSTER: WrathServerMessage, IWorldMessage {
    public required uint ArenaTeam { get; set; }
    /// <summary>
    /// arcemu: new 3.0.8.
    /// arcemu sets to 0.
    /// </summary>
    public required byte Unknown { get; set; }
    public required Wrath.ArenaType ArenaType { get; set; }
    public required List<ArenaTeamMember> Members { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Members.Count, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ArenaType, cancellationToken).ConfigureAwait(false);

        foreach (var v in Members) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 846, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 846, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_ROSTER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMembers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaType = (Wrath.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var members = new List<ArenaTeamMember>();
        for (var i = 0; i < amountOfMembers; ++i) {
            members.Add(await Wrath.ArenaTeamMember.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_ARENA_TEAM_ROSTER {
            ArenaTeam = arenaTeam,
            Unknown = unknown,
            ArenaType = arenaType,
            Members = members,
        };
    }

    internal int Size() {
        var size = 0;

        // arena_team: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_members: Generator.Generated.DataTypeInteger
        size += 4;

        // arena_type: Generator.Generated.DataTypeEnum
        size += 1;

        // members: Generator.Generated.DataTypeArray
        size += Members.Sum(e => e.Size());

        return size;
    }

}

