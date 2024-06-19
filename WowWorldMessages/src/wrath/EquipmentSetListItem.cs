using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class EquipmentSetListItem {
    public required ulong Guid { get; set; }
    public required string Name { get; set; }
    public required string IconName { get; set; }
    public const int EquipmentLength = 19;
    public required ulong[] Equipment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(IconName, cancellationToken).ConfigureAwait(false);

        foreach (var v in Equipment) {
            await w.WriteULong(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<EquipmentSetListItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var iconName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var equipment = new ulong[EquipmentLength];
        for (var i = 0; i < EquipmentLength; ++i) {
            equipment[i] = await r.ReadULong(cancellationToken).ConfigureAwait(false);
        }

        return new EquipmentSetListItem {
            Guid = guid,
            Name = name,
            IconName = iconName,
            Equipment = equipment,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // icon_name: Generator.Generated.DataTypeCstring
        size += IconName.Length + 1;

        // equipment: Generator.Generated.DataTypeArray
        size += Equipment.Sum(e => 8);

        return size;
    }

}

