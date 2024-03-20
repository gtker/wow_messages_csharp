using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.Login.Version5;

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

    public static async Task<Realm> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var realmType = (RealmType)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var locked = await ReadUtils.ReadBool8(r, cancellationToken).ConfigureAwait(false);

        var flag = (RealmFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var name = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);

        var address = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);

        var population = await ReadUtils.ReadPopulation(r, cancellationToken).ConfigureAwait(false);

        var numberOfCharactersOnRealm = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var category = (RealmCategory)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var realmId = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

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
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteByte(w, (byte)RealmType, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteBool8(w, Locked, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Flag, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteCString(w, Name, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteCString(w, Address, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WritePopulation(w, Population, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, NumberOfCharactersOnRealm, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Category, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, RealmId, cancellationToken).ConfigureAwait(false);

    }

    internal int Size() {
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

        return size;
    }

}

