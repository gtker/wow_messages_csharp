using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_REQUEST_VEHICLE_SWITCH_SEAT: WrathClientMessage, IWorldMessage {
    public required ulong Vehicle { get; set; }
    public required byte Seat { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Vehicle, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Seat, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 13, 1145, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 13, 1145, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_REQUEST_VEHICLE_SWITCH_SEAT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var vehicle = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var seat = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_REQUEST_VEHICLE_SWITCH_SEAT {
            Vehicle = vehicle,
            Seat = seat,
        };
    }

}

