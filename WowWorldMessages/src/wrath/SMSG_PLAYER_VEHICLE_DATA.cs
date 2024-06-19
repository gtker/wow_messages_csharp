using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PLAYER_VEHICLE_DATA: WrathServerMessage, IWorldMessage {
    public required ulong Target { get; set; }
    public required uint VehicleId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Target, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(VehicleId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1191, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1191, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PLAYER_VEHICLE_DATA> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var target = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var vehicleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_PLAYER_VEHICLE_DATA {
            Target = target,
            VehicleId = vehicleId,
        };
    }

    internal int Size() {
        var size = 0;

        // target: Generator.Generated.DataTypePackedGuid
        size += Target.PackedGuidLength();

        // vehicle_id: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

