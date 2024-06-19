using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MiniMoveMessage {
    public required Wrath.MiniMoveOpcode Opcode { get; set; }
    public required ulong Guid { get; set; }
    public required uint MovementCounter { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Size(), cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Opcode, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MovementCounter, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<MiniMoveMessage> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var opcode = (Wrath.MiniMoveOpcode)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var movementCounter = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MiniMoveMessage {
            Opcode = opcode,
            Guid = guid,
            MovementCounter = movementCounter,
        };
    }

    internal int Size() {
        var size = 0;

        // size: Generator.Generated.DataTypeInteger
        size += 1;

        // opcode: Generator.Generated.DataTypeEnum
        size += 2;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // movement_counter: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

