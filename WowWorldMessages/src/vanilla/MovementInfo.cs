using WowSrp.Header;

namespace WowWorldMessages.Vanilla;


[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MovementInfo {
    public class MovementFlagsType {
        public required MovementFlags Inner;
        public MovementFlagsJumping? Jumping;
        public MovementFlagsOnTransport? OnTransport;
        public MovementFlagsSplineElevation? SplineElevation;
        public MovementFlagsSwimming? Swimming;
    }
    public class MovementFlagsJumping {
        public required float CosAngle { get; set; }
        public required float SinAngle { get; set; }
        public required float XySpeed { get; set; }
        public required float ZSpeed { get; set; }
    }
    public class MovementFlagsOnTransport {
        public required TransportInfo Transport { get; set; }
    }
    public class MovementFlagsSplineElevation {
        public required float SplineElevation { get; set; }
    }
    public class MovementFlagsSwimming {
        public required float Pitch { get; set; }
    }
    public required MovementFlagsType Flags { get; set; }
    public required uint Timestamp { get; set; }
    public required Vector3d Position { get; set; }
    public required float Orientation { get; set; }
    public required float FallTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timestamp, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Orientation, cancellationToken).ConfigureAwait(false);

        if (Flags.OnTransport is {} onTransport) {
            await onTransport.Transport.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Swimming is {} swimming) {
            await w.WriteFloat(swimming.Pitch, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteFloat(FallTime, cancellationToken).ConfigureAwait(false);

        if (Flags.Jumping is {} jumping) {
            await w.WriteFloat(jumping.ZSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(jumping.CosAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(jumping.SinAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(jumping.XySpeed, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.SplineElevation is {} splineElevation) {
            await w.WriteFloat(splineElevation.SplineElevation, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<MovementInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var flags = new MovementFlagsType {
            Inner = (MovementFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var timestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var orientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Vanilla.MovementFlags.OnTransport)) {
            var transport = await TransportInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            flags.OnTransport = new MovementFlagsOnTransport {
                Transport = transport,
            };
        }

        if (flags.Inner.HasFlag(Vanilla.MovementFlags.Swimming)) {
            var pitch = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsSwimming {
                Pitch = pitch,
            };
        }

        var fallTime = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Vanilla.MovementFlags.Jumping)) {
            var zSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var cosAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var sinAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var xySpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Jumping = new MovementFlagsJumping {
                CosAngle = cosAngle,
                SinAngle = sinAngle,
                XySpeed = xySpeed,
                ZSpeed = zSpeed,
            };
        }

        if (flags.Inner.HasFlag(Vanilla.MovementFlags.SplineElevation)) {
            var splineElevation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.SplineElevation = new MovementFlagsSplineElevation {
                SplineElevation = splineElevation,
            };
        }

        return new MovementInfo {
            Flags = flags,
            Timestamp = timestamp,
            Position = position,
            Orientation = orientation,
            FallTime = fallTime,
        };
    }

    internal int Size() {
        var size = 0;

        // flags: WowMessages.Generator.Generated.DataTypeFlag
        size += 4;

        // timestamp: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // position: WowMessages.Generator.Generated.DataTypeStruct
        size += 12;

        // orientation: WowMessages.Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.OnTransport is {} onTransport) {
            // transport: WowMessages.Generator.Generated.DataTypeStruct
            size += onTransport.Transport.Size();

        }

        if (Flags.Swimming is {} swimming) {
            // pitch: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        // fall_time: WowMessages.Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.Jumping is {} jumping) {
            // z_speed: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // cos_angle: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // sin_angle: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // xy_speed: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        if (Flags.SplineElevation is {} splineElevation) {
            // spline_elevation: WowMessages.Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        return size;
    }

}

