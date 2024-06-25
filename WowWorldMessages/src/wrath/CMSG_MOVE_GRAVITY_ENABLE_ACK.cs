using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MOVE_GRAVITY_ENABLE_ACK: WrathClientMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required uint Unknown { get; set; }
    public required MovementInfo Info { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1233, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1233, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MOVE_GRAVITY_ENABLE_ACK> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_MOVE_GRAVITY_ENABLE_ACK {
            Guid = guid,
            Unknown = unknown,
            Info = info,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        return size;
    }

}

