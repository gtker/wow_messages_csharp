using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Tbc;

using MovementFlagsSwimmingMulti = OneOf.OneOf<MovementInfo.MovementFlagsOntransport, MovementInfo.MovementFlagsSwimming, MovementFlags>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MovementInfo {
    public class MovementFlagsOntransport {
        public required float Pitch2 { get; set; }
    }
    public class MovementFlagsSwimming {
        public required float Pitch1 { get; set; }
    }
    public class MovementFlagsType {
        public required MovementFlags Inner;
        public MovementFlagsJumping? Jumping;
        public MovementFlagsOnTransport? OnTransport;
        public MovementFlagsSplineElevation? SplineElevation;
        public MovementFlagsSwimmingMulti Swimming;
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
    public required MovementFlagsType Flags { get; set; }
    public required byte ExtraFlags { get; set; }
    public required uint Timestamp { get; set; }
    public required Vector3d Position { get; set; }
    public required float Orientation { get; set; }
    public required float FallTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ExtraFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timestamp, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Orientation, cancellationToken).ConfigureAwait(false);

        if (Flags.OnTransport is MovementFlagsOnTransport movementFlagsOnTransport) {
            await movementFlagsOnTransport.Transport.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
            await w.WriteFloat(movementFlagsSwimming.Pitch1, cancellationToken).ConfigureAwait(false);

        }
        else if (Flags.Swimming.Value is MovementFlagsOntransport movementFlagsOntransport) {
            await w.WriteFloat(movementFlagsOntransport.Pitch2, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteFloat(FallTime, cancellationToken).ConfigureAwait(false);

        if (Flags.Jumping is MovementFlagsJumping movementFlagsJumping) {
            await w.WriteFloat(movementFlagsJumping.ZSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsJumping.CosAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsJumping.SinAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsJumping.XySpeed, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.SplineElevation is MovementFlagsSplineElevation movementFlagsSplineElevation) {
            await w.WriteFloat(movementFlagsSplineElevation.SplineElevation, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<MovementInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var flags = new MovementFlagsType {
            Inner = (MovementFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var extraFlags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var timestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var orientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Tbc.MovementFlags.OnTransport)) {
            var transport = await TransportInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            flags.OnTransport = new MovementFlagsOnTransport {
                Transport = transport,
            };
        }

        if (flags.Inner.HasFlag(Tbc.MovementFlags.Swimming)) {
            var pitch1 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsSwimming {
                Pitch1 = pitch1,
            };
        }
        else if (flags.Inner.HasFlag(Tbc.MovementFlags.Ontransport)) {
            var pitch2 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsOntransport {
                Pitch2 = pitch2,
            };
        }

        var fallTime = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Tbc.MovementFlags.Jumping)) {
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

        if (flags.Inner.HasFlag(Tbc.MovementFlags.SplineElevation)) {
            var splineElevation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.SplineElevation = new MovementFlagsSplineElevation {
                SplineElevation = splineElevation,
            };
        }

        return new MovementInfo {
            Flags = flags,
            ExtraFlags = extraFlags,
            Timestamp = timestamp,
            Position = position,
            Orientation = orientation,
            FallTime = fallTime,
        };
    }

    internal int Size() {
        var size = 0;

        // flags: Generator.Generated.DataTypeFlag
        size += 4;

        // extra_flags: Generator.Generated.DataTypeInteger
        size += 1;

        // timestamp: Generator.Generated.DataTypeInteger
        size += 4;

        // position: Generator.Generated.DataTypeStruct
        size += 12;

        // orientation: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.OnTransport is MovementFlagsOnTransport movementFlagsOnTransport) {
            // transport: Generator.Generated.DataTypeStruct
            size += movementFlagsOnTransport.Transport.Size();

        }

        if (Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
            // pitch1: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (Flags.Swimming.Value is MovementFlagsOntransport movementFlagsOntransport) {
            // pitch2: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        // fall_time: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.Jumping is MovementFlagsJumping movementFlagsJumping) {
            // z_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // cos_angle: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // sin_angle: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // xy_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        if (Flags.SplineElevation is MovementFlagsSplineElevation movementFlagsSplineElevation) {
            // spline_elevation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        return size;
    }

}

