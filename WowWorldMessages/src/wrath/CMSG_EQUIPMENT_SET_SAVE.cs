using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_EQUIPMENT_SET_SAVE: WrathClientMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required uint Index { get; set; }
    public required string Name { get; set; }
    public required string IconName { get; set; }
    public const int EquipmentLength = 19;
    public required ulong[] Equipment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Index, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(IconName, cancellationToken).ConfigureAwait(false);

        foreach (var v in Equipment) {
            await w.WriteULong(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1213, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1213, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_EQUIPMENT_SET_SAVE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var index = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var iconName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var equipment = new ulong[EquipmentLength];
        for (var i = 0; i < EquipmentLength; ++i) {
            equipment[i] = await r.ReadULong(cancellationToken).ConfigureAwait(false);
        }

        return new CMSG_EQUIPMENT_SET_SAVE {
            Guid = guid,
            Index = index,
            Name = name,
            IconName = iconName,
            Equipment = equipment,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // index: Generator.Generated.DataTypeInteger
        size += 4;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // icon_name: Generator.Generated.DataTypeCstring
        size += IconName.Length + 1;

        // equipment: Generator.Generated.DataTypeArray
        size += Equipment.Sum(e => 8);

        return size;
    }

}

