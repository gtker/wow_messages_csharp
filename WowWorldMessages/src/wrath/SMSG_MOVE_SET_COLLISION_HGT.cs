using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MOVE_SET_COLLISION_HGT: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required uint PacketCounter { get; set; }
    public required float CollisionHeight { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PacketCounter, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(CollisionHeight, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1302, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1302, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MOVE_SET_COLLISION_HGT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var packetCounter = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var collisionHeight = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new SMSG_MOVE_SET_COLLISION_HGT {
            Unit = unit,
            PacketCounter = packetCounter,
            CollisionHeight = collisionHeight,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // packet_counter: Generator.Generated.DataTypeInteger
        size += 4;

        // collision_height: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        return size;
    }

}

