using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.Login.Version6;

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

    public static async Task<Realm> Read(Stream r) {
        var realmType = (RealmType)await ReadUtils.ReadByte(r);

        var locked = await ReadUtils.ReadBool8(r);

        var flag = (RealmFlag)await ReadUtils.ReadByte(r);

        var name = await ReadUtils.ReadCString(r);

        var address = await ReadUtils.ReadCString(r);

        var population = await ReadUtils.ReadPopulation(r);

        var numberOfCharactersOnRealm = await ReadUtils.ReadByte(r);

        var category = (RealmCategory)await ReadUtils.ReadByte(r);

        var realmId = await ReadUtils.ReadByte(r);

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

    public async Task Write(Stream w) {
        await WriteUtils.WriteByte(w, (byte)RealmType);

        await WriteUtils.WriteBool8(w, Locked);

        await WriteUtils.WriteByte(w, (byte)Flag);

        await WriteUtils.WriteCString(w, Name);

        await WriteUtils.WriteCString(w, Address);

        await WriteUtils.WritePopulation(w, Population);

        await WriteUtils.WriteByte(w, NumberOfCharactersOnRealm);

        await WriteUtils.WriteByte(w, (byte)Category);

        await WriteUtils.WriteByte(w, RealmId);

    }

}

