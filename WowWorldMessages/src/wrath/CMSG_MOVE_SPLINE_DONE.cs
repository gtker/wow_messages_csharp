using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MOVE_SPLINE_DONE: WrathClientMessage, IWorldMessage {
    public required MovementInfo Info { get; set; }
    public required uint MovementCounter { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MovementCounter, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 713, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 713, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MOVE_SPLINE_DONE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var movementCounter = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_MOVE_SPLINE_DONE {
            Info = info,
            MovementCounter = movementCounter,
        };
    }

    internal int Size() {
        var size = 0;

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        // movement_counter: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

