using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Character {
    public required ulong Guid { get; set; }
    public required string Name { get; set; }
    public required Race Race { get; set; }
    public required Class ClassType { get; set; }
    public required Gender Gender { get; set; }
    public required byte Skin { get; set; }
    public required byte Face { get; set; }
    public required byte HairStyle { get; set; }
    public required byte HairColor { get; set; }
    public required byte FacialHair { get; set; }
    public required byte Level { get; set; }
    public required Area Area { get; set; }
    public required Map Map { get; set; }
    public required Vector3d Position { get; set; }
    public required uint GuildId { get; set; }
    public required CharacterFlags Flags { get; set; }
    public required bool FirstLogin { get; set; }
    public required uint PetDisplayId { get; set; }
    public required uint PetLevel { get; set; }
    public required CreatureFamily PetFamily { get; set; }
    public required List<CharacterGear> Equipment { get; set; }

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

        await w.WriteUInt((uint)Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(FirstLogin, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetDisplayId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetLevel, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)PetFamily, cancellationToken).ConfigureAwait(false);

        foreach (var v in Equipment) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Character> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var race = (Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var classType = (Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var skin = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var face = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairStyle = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var facialHair = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var area = (Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var guildId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = (CharacterFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var firstLogin = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var petDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var petLevel = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var petFamily = (CreatureFamily)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var equipment = new List<CharacterGear>();
        for (var i = 0; i < 19; ++i) {
            equipment.Add(await Vanilla.CharacterGear.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var firstBagDisplayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var firstBagInventoryId = await r.ReadByte(cancellationToken).ConfigureAwait(false);

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
            FirstLogin = firstLogin,
            PetDisplayId = petDisplayId,
            PetLevel = petLevel,
            PetFamily = petFamily,
            Equipment = equipment,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: WowMessages.Generator.Generated.DataTypeGuid
        size += 8;

        // name: WowMessages.Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // race: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // class_type: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // gender: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // skin: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // face: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // hair_style: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // hair_color: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // facial_hair: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // level: WowMessages.Generator.Generated.DataTypeLevel
        size += 1;

        // area: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // map: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // position: WowMessages.Generator.Generated.DataTypeStruct
        size += 12;

        // guild_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // flags: WowMessages.Generator.Generated.DataTypeFlag
        size += 4;

        // first_login: WowMessages.Generator.Generated.DataTypeBool
        size += 1;

        // pet_display_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // pet_level: WowMessages.Generator.Generated.DataTypeLevel32
        size += 4;

        // pet_family: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // equipment: WowMessages.Generator.Generated.DataTypeArray
        size += Equipment.Sum(e => 5);

        // first_bag_display_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // first_bag_inventory_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

