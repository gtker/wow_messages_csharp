using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_ARENA_TEAM: WrathServerMessage, IWorldMessage {
    public required List<CalendarMember> Members { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Members.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Members) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1081, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1081, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_ARENA_TEAM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMembers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var members = new List<CalendarMember>();
        for (var i = 0; i < amountOfMembers; ++i) {
            members.Add(await Wrath.CalendarMember.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_CALENDAR_ARENA_TEAM {
            Members = members,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_members: Generator.Generated.DataTypeInteger
        size += 4;

        // members: Generator.Generated.DataTypeArray
        size += Members.Sum(e => e.Size());

        return size;
    }

}

