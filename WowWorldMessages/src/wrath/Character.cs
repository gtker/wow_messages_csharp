using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Character {
    public required ulong Guid { get; set; }
    public required string Name { get; set; }
    public required Wrath.Race Race { get; set; }
    public required Wrath.Class ClassType { get; set; }
    public required Wrath.Gender Gender { get; set; }
    public required byte Skin { get; set; }
    public required byte Face { get; set; }
    public required byte HairStyle { get; set; }
    public required byte HairColor { get; set; }
    public required byte FacialHair { get; set; }
    public required byte Level { get; set; }
    public required Wrath.Area Area { get; set; }
    public required Wrath.Map Map { get; set; }
    public required Vector3d Position { get; set; }
    public required uint GuildId { get; set; }
    public required uint Flags { get; set; }
    public required uint RecustomizationFlags { get; set; }
    public required bool FirstLogin { get; set; }
    public required uint PetDisplayId { get; set; }
    public required uint PetLevel { get; set; }
    public required Wrath.CreatureFamily PetFamily { get; set; }
    public const int EquipmentLength = 23;
    public required CharacterGear[] Equipment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Race, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ClassType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Skin, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Face, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairStyle, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairColor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(FacialHair, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GuildId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RecustomizationFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(FirstLogin, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetDisplayId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)PetFamily, cancellationToken).ConfigureAwait(false);

        foreach (var v in Equipment) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<Character> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var race = (Wrath.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var classType = (Wrath.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Wrath.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var skin = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var face = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairStyle = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var facialHair = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var guildId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var recustomizationFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var firstLogin = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var petDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var petLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var petFamily = (Wrath.CreatureFamily)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var equipment = new CharacterGear[EquipmentLength];
        for (var i = 0; i < EquipmentLength; ++i) {
            equipment[i] = await Wrath.CharacterGear.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new Character {
            Guid = guid,
            Name = name,
            Race = race,
            ClassType = classType,
            Gender = gender,
            Skin = skin,
            Face = face,
            HairStyle = hairStyle,
            HairColor = hairColor,
            FacialHair = facialHair,
            Level = level,
            Area = area,
            Map = map,
            Position = position,
            GuildId = guildId,
            Flags = flags,
            RecustomizationFlags = recustomizationFlags,
            FirstLogin = firstLogin,
            PetDisplayId = petDisplayId,
            PetLevel = petLevel,
            PetFamily = petFamily,
            Equipment = equipment,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // race: Generator.Generated.DataTypeEnum
        size += 1;

        // class_type: Generator.Generated.DataTypeEnum
        size += 1;

        // gender: Generator.Generated.DataTypeEnum
        size += 1;

        // skin: Generator.Generated.DataTypeInteger
        size += 1;

        // face: Generator.Generated.DataTypeInteger
        size += 1;

        // hair_style: Generator.Generated.DataTypeInteger
        size += 1;

        // hair_color: Generator.Generated.DataTypeInteger
        size += 1;

        // facial_hair: Generator.Generated.DataTypeInteger
        size += 1;

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        // map: Generator.Generated.DataTypeEnum
        size += 4;

        // position: Generator.Generated.DataTypeStruct
        size += 12;

        // guild_id: Generator.Generated.DataTypeInteger
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // recustomization_flags: Generator.Generated.DataTypeInteger
        size += 4;

        // first_login: Generator.Generated.DataTypeBool
        size += 1;

        // pet_display_id: Generator.Generated.DataTypeInteger
        size += 4;

        // pet_level: Generator.Generated.DataTypeLevel32
        size += 4;

        // pet_family: Generator.Generated.DataTypeEnum
        size += 4;

        // equipment: Generator.Generated.DataTypeArray
        size += Equipment.Sum(e => 9);

        return size;
    }

}
