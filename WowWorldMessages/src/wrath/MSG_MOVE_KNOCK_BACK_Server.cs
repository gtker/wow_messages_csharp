using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_MOVE_KNOCK_BACK_Server: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required MovementInfo Info { get; set; }
    public required float SinAngle { get; set; }
    public required float CosAngle { get; set; }
    public required float XYSpeed { get; set; }
    public required float Velocity { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(SinAngle, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(CosAngle, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(XYSpeed, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Velocity, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 241, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 241, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_MOVE_KNOCK_BACK_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var sinAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var cosAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var xYSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var velocity = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new MSG_MOVE_KNOCK_BACK_Server {
            Player = player,
            Info = info,
            SinAngle = sinAngle,
            CosAngle = cosAngle,
            XYSpeed = xYSpeed,
            Velocity = velocity,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // info: Generator.Generated.DataTypeStruct
        size += Info.Size();

        // sin_angle: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // cos_angle: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // x_y_speed: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // velocity: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        return size;
    }

}

