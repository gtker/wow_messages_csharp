using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_POWER_UPDATE: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required Wrath.Power Power { get; set; }
    public required uint Amount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Power, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Amount, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1152, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1152, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_POWER_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var power = (Wrath.Power)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var amount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_POWER_UPDATE {
            Unit = unit,
            Power = power,
            Amount = amount,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // power: Generator.Generated.DataTypeEnum
        size += 1;

        // amount: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

