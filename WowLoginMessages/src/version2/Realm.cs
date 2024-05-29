using WowLoginMessages.All;

namespace WowLoginMessages.Version2;

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

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteUInt(w, (uint)RealmType, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Flag, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteCString(w, Name, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteCString(w, Address, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WritePopulation(w, Population, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, NumberOfCharactersOnRealm, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Category, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, RealmId, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Realm> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var realmType = (RealmType)await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var flag = (RealmFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var name = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);

        var address = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);

        var population = await ReadUtils.ReadPopulation(r, cancellationToken).ConfigureAwait(false);

        var numberOfCharactersOnRealm = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var category = (RealmCategory)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var realmId = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

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

    internal int Size() {
        var size = 0;

        // realm_type: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // flag: WowMessages.Generator.Generated.DataTypeFlag
        size += 1;

        // name: WowMessages.Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // address: WowMessages.Generator.Generated.DataTypeCstring
        size += Address.Length + 1;

        // population: WowMessages.Generator.Generated.DataTypePopulation
        size += 4;

        // number_of_characters_on_realm: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // category: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        // realm_id: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}
