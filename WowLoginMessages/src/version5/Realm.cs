using WowLoginMessages.All;

namespace WowLoginMessages.Version5;

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

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)RealmType, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Locked, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Flag, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Address, cancellationToken).ConfigureAwait(false);

        await w.WritePopulation(Population, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(NumberOfCharactersOnRealm, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Category, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(RealmId, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Realm> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var realmType = (RealmType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var locked = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var flag = (RealmFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var address = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var population = await r.ReadPopulation(cancellationToken).ConfigureAwait(false);

        var numberOfCharactersOnRealm = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var category = (RealmCategory)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var realmId = await r.ReadByte(cancellationToken).ConfigureAwait(false);

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

    internal int Size() {
        var size = 0;

        // realm_type: Generator.Generated.DataTypeEnum
        size += 1;

        // locked: Generator.Generated.DataTypeBool
        size += 1;

        // flag: Generator.Generated.DataTypeFlag
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // address: Generator.Generated.DataTypeCstring
        size += Address.Length + 1;

        // population: Generator.Generated.DataTypePopulation
        size += 4;

        // number_of_characters_on_realm: Generator.Generated.DataTypeInteger
        size += 1;

        // category: Generator.Generated.DataTypeEnum
        size += 1;

        // realm_id: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

