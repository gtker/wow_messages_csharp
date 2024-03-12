using Gtker.WowMessages.Login.All;
using Version = Gtker.WowMessages.Login.All.Version;

namespace Gtker.WowMessages.Login.Version8;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Realm {
    public required RealmType RealmType { get; set; }
    public required bool Locked { get; set; }
    public required RealmFlag Flag { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required Population Population { get; set; }
    public required byte NumberOfCharactersOnRealm { get; set; }
    public required RealmCategory Category { get; set; }
    public required byte RealmId { get; set; }
    public Version Version { get; set; }

    public static async Task<Realm> ReadAsync(Stream r) {
        var version = default(Version);

        var realmType = (RealmType)await ReadUtils.ReadByte(r);

        var locked = await ReadUtils.ReadBool8(r);

        var flag = (RealmFlag)await ReadUtils.ReadByte(r);

        var name = await ReadUtils.ReadCString(r);

        var address = await ReadUtils.ReadCString(r);

        var population = await ReadUtils.ReadPopulation(r);

        var numberOfCharactersOnRealm = await ReadUtils.ReadByte(r);

        var category = (RealmCategory)await ReadUtils.ReadByte(r);

        var realmId = await ReadUtils.ReadByte(r);

        if (flag.HasFlag(RealmFlag.SpecifyBuild)) {
            version = await Version.ReadAsync(r);

        }
        return new Realm {
            RealmType = realmType,
            Locked = locked,
            Flag = flag,
            Name = name,
            Address = address,
            Population = population,
            NumberOfCharactersOnRealm = numberOfCharactersOnRealm,
            Category = category,
            RealmId = realmId,
            Version = version,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, (byte)RealmType);

        await WriteUtils.WriteBool8(w, Locked);

        await WriteUtils.WriteByte(w, (byte)Flag);

        await WriteUtils.WriteCString(w, Name);

        await WriteUtils.WriteCString(w, Address);

        await WriteUtils.WritePopulation(w, Population);

        await WriteUtils.WriteByte(w, NumberOfCharactersOnRealm);

        await WriteUtils.WriteByte(w, (byte)Category);

        await WriteUtils.WriteByte(w, RealmId);

        if (Flag.HasFlag(RealmFlag.SpecifyBuild)) {
            await Version.WriteAsync(w);

        }
    }

    public int Size() {
        var size = 0;

        // realm_type: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // locked: Gtker.WowMessages.Generator.Generated.DataTypeBool
        size += 1;

        // flag: Gtker.WowMessages.Generator.Generated.DataTypeFlag
        size += 1;

        // name: Gtker.WowMessages.Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // address: Gtker.WowMessages.Generator.Generated.DataTypeCstring
        size += Address.Length + 1;

        // population: Gtker.WowMessages.Generator.Generated.DataTypePopulation
        size += 4;

        // number_of_characters_on_realm: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // category: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // realm_id: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        if (Flag.HasFlag(RealmFlag.SpecifyBuild)) {
            // version: Gtker.WowMessages.Generator.Generated.DataTypeStruct
            size += 5;

        }
        return size;
    }

}

