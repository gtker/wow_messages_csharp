using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_EQUIPMENT_SET_LIST: WrathServerMessage, IWorldMessage {
    public required List<EquipmentSetListItem> EquipmentSets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)EquipmentSets.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in EquipmentSets) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1212, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1212, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_EQUIPMENT_SET_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEquipmentSets = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var equipmentSets = new List<EquipmentSetListItem>();
        for (var i = 0; i < amountOfEquipmentSets; ++i) {
            equipmentSets.Add(await Wrath.EquipmentSetListItem.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_EQUIPMENT_SET_LIST {
            EquipmentSets = equipmentSets,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_equipment_sets: Generator.Generated.DataTypeInteger
        size += 4;

        // equipment_sets: Generator.Generated.DataTypeArray
        size += EquipmentSets.Sum(e => e.Size());

        return size;
    }

}

