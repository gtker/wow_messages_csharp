using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class WhoPlayer {
    public required string Name { get; set; }
    public required string Guild { get; set; }
    public required uint Level { get; set; }
    public required Tbc.Class ClassType { get; set; }
    public required Tbc.Race Race { get; set; }
    public required Tbc.Gender Gender { get; set; }
    public required Tbc.Area Area { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Guild, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ClassType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Race, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<WhoPlayer> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var guild = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var classType = (Tbc.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var race = (Tbc.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Tbc.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var area = (Tbc.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new WhoPlayer {
            Name = name,
            Guild = guild,
            Level = level,
            ClassType = classType,
            Race = race,
            Gender = gender,
            Area = area,
        };
    }

    internal int Size() {
        var size = 0;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // guild: Generator.Generated.DataTypeCstring
        size += Guild.Length + 1;

        // level: Generator.Generated.DataTypeLevel32
        size += 4;

        // class_type: Generator.Generated.DataTypeEnum
        size += 1;

        // race: Generator.Generated.DataTypeEnum
        size += 1;

        // gender: Generator.Generated.DataTypeEnum
        size += 1;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        return size;
    }

}

