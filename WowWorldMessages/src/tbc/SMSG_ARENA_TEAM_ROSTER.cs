using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_TEAM_ROSTER: TbcServerMessage, IWorldMessage {
    public required uint ArenaTeam { get; set; }
    public required Tbc.ArenaType ArenaType { get; set; }
    public required List<ArenaTeamMember> Members { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ArenaTeam, cancellationToken).ConfigureAwait(false);

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
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 846, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_TEAM_ROSTER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaTeam = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMembers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaType = (Tbc.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var members = new List<ArenaTeamMember>();
        for (var i = 0; i < amountOfMembers; ++i) {
            members.Add(await Tbc.ArenaTeamMember.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_ARENA_TEAM_ROSTER {
            ArenaTeam = arenaTeam,
            ArenaType = arenaType,
            Members = members,
        };
    }

    internal int Size() {
        var size = 0;

        // arena_team: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_members: Generator.Generated.DataTypeInteger
        size += 4;

        // arena_type: Generator.Generated.DataTypeEnum
        size += 1;

        // members: Generator.Generated.DataTypeArray
        size += Members.Sum(e => e.Size());

        return size;
    }

}

