using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CHANGE_SEATS_ON_CONTROLLED_VEHICLE: WrathClientMessage, IWorldMessage {
    public required ulong Vehicle { get; set; }
    public required MovementInfo Info { get; set; }
    public required ulong Accessory { get; set; }
    public required byte Seat { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Vehicle, cancellationToken).ConfigureAwait(false);

        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Accessory, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Seat, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1179, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1179, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CHANGE_SEATS_ON_CONTROLLED_VEHICLE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var vehicle = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var accessory = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var seat = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_CHANGE_SEATS_ON_CONTROLLED_VEHICLE {
            Vehicle = vehicle,
            Info = info,
            Accessory = accessory,
            Seat = seat,
        };
    }

    internal int Size() {
        var size = 0;

        // vehicle: Generator.Generated.DataTypePackedGuid
        size += Vehicle.PackedGuidLength();

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        // accessory: Generator.Generated.DataTypePackedGuid
        size += Accessory.PackedGuidLength();

        // seat: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

