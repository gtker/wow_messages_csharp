using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgPlayer {
    public required ulong Guid { get; set; }
    public required uint Level { get; set; }
    public required Tbc.Area Area { get; set; }
    public required Tbc.LfgMode LfgMode { get; set; }
    public const int LfgSlotsLength = 3;
    public required uint[] LfgSlots { get; set; }
    public required string Comment { get; set; }
    public required List<LfgPlayerMember> Members { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)LfgMode, cancellationToken).ConfigureAwait(false);

        foreach (var v in LfgSlots) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteCString(Comment, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Members.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Members) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<LfgPlayer> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var area = (Tbc.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var lfgMode = (Tbc.LfgMode)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var lfgSlots = new uint[LfgSlotsLength];
        for (var i = 0; i < LfgSlotsLength; ++i) {
            lfgSlots[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMembers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var members = new List<LfgPlayerMember>();
        for (var i = 0; i < amountOfMembers; ++i) {
            members.Add(await Tbc.LfgPlayerMember.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new LfgPlayer {
            Guid = guid,
            Level = level,
            Area = area,
            LfgMode = lfgMode,
            LfgSlots = lfgSlots,
            Comment = comment,
            Members = members,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // level: Generator.Generated.DataTypeLevel32
        size += 4;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        // lfg_mode: Generator.Generated.DataTypeEnum
        size += 1;

        // lfg_slots: Generator.Generated.DataTypeArray
        size += LfgSlots.Sum(e => 4);

        // comment: Generator.Generated.DataTypeCstring
        size += Comment.Length + 1;

        // amount_of_members: Generator.Generated.DataTypeInteger
        size += 4;

        // members: Generator.Generated.DataTypeArray
        size += Members.Sum(e => e.Size());

        return size;
    }

}

