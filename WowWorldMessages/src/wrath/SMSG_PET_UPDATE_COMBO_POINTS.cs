using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_UPDATE_COMBO_POINTS: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required ulong Target { get; set; }
    public required byte ComboPoints { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Target, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ComboPoints, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1170, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1170, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_UPDATE_COMBO_POINTS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var target = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var comboPoints = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_PET_UPDATE_COMBO_POINTS {
            Unit = unit,
            Target = target,
            ComboPoints = comboPoints,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // target: Generator.Generated.DataTypePackedGuid
        size += Target.PackedGuidLength();

        // combo_points: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

