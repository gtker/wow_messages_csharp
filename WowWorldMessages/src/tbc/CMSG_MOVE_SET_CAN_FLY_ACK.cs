using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_MOVE_SET_CAN_FLY_ACK: TbcClientMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required uint Counter { get; set; }
    public required MovementInfo Info { get; set; }
    public required bool Applied { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Counter, cancellationToken).ConfigureAwait(false);

        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(Applied, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 837, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 837, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_MOVE_SET_CAN_FLY_ACK> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var counter = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var applied = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new CMSG_MOVE_SET_CAN_FLY_ACK {
            Player = player,
            Counter = counter,
            Info = info,
            Applied = applied,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // counter: Generator.Generated.DataTypeInteger
        size += 4;

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        // applied: Generator.Generated.DataTypeBool
        size += 4;

        return size;
    }

}

