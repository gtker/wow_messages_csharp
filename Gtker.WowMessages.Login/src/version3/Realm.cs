using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.Login.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Realm {
    public required RealmType RealmType { get; set; }
    public required RealmFlag Flag { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required Population Population { get; set; }
    public required byte NumberOfCharactersOnRealm { get; set; }
    public required RealmCategory Category { get; set; }
    public required byte RealmId { get; set; }

    public static async Task<Realm> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var realmType = (RealmType)await ReadUtils.ReadUInt(r, cancellationToken);

        var flag = (RealmFlag)await ReadUtils.ReadByte(r, cancellationToken);

        var name = await ReadUtils.ReadCString(r, cancellationToken);

        var address = await ReadUtils.ReadCString(r, cancellationToken);

        var population = await ReadUtils.ReadPopulation(r, cancellationToken);

        var numberOfCharactersOnRealm = await ReadUtils.ReadByte(r, cancellationToken);

        var category = (RealmCategory)await ReadUtils.ReadByte(r, cancellationToken);

        var realmId = await ReadUtils.ReadByte(r, cancellationToken);

        return new Realm {
            RealmType = realmType,
            Flag = flag,
            Name = name,
            Address = address,
            Population = population,
            NumberOfCharactersOnRealm = numberOfCharactersOnRealm,
            Category = category,
            RealmId = realmId,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteUInt(w, (uint)RealmType, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Flag, cancellationToken);

        await WriteUtils.WriteCString(w, Name, cancellationToken);

        await WriteUtils.WriteCString(w, Address, cancellationToken);

        await WriteUtils.WritePopulation(w, Population, cancellationToken);

        await WriteUtils.WriteByte(w, NumberOfCharactersOnRealm, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Category, cancellationToken);

        await WriteUtils.WriteByte(w, RealmId, cancellationToken);

    }

    public int Size() {
        var size = 0;

        // realm_type: Gtker.WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

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

        return size;
    }

}

