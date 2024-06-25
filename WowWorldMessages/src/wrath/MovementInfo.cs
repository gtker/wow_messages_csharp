using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

using MovementFlagsOnTransportAndInterpolatedMovementMulti = OneOf.OneOf<MovementInfo.MovementFlagsOnTransport, MovementInfo.MovementFlagsOnTransportAndInterpolatedMovement, MovementFlags>;
using MovementFlagsSwimmingMulti = OneOf.OneOf<MovementInfo.MovementFlagsAlwaysAllowPitching, MovementInfo.MovementFlagsFlying, MovementInfo.MovementFlagsSwimming, MovementFlags>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MovementInfo {
    public class MovementFlagsOnTransport {
        public required TransportInfo Transport { get; set; }
    }
    public class MovementFlagsOnTransportAndInterpolatedMovement {
        public required TransportInfo TransportInfo { get; set; }
        public required uint TransportTime { get; set; }
    }
    public class MovementFlagsAlwaysAllowPitching {
        public required float Pitch3 { get; set; }
    }
    public class MovementFlagsFlying {
        public required float Pitch2 { get; set; }
    }
    public class MovementFlagsSwimming {
        public required float Pitch1 { get; set; }
    }
    public class MovementFlagsType {
        public required MovementFlags Inner;
        public MovementFlagsFalling? Falling;
        public MovementFlagsOnTransportAndInterpolatedMovementMulti OnTransportAndInterpolatedMovement;
        public MovementFlagsSplineElevation? SplineElevation;
        public MovementFlagsSwimmingMulti Swimming;
    }
    public class MovementFlagsFalling {
        public required float CosAngle { get; set; }
        public required float SinAngle { get; set; }
        public required float XySpeed { get; set; }
        public required float ZSpeed { get; set; }
    }
    public class MovementFlagsSplineElevation {
        public required float SplineElevation { get; set; }
    }
    public required MovementFlagsType Flags { get; set; }
    public required uint Timestamp { get; set; }
    public required Vector3d Position { get; set; }
    public required float Orientation { get; set; }
    public required float FallTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteU48((ulong)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timestamp, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Orientation, cancellationToken).ConfigureAwait(false);

        if (Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransportAndInterpolatedMovement movementFlagsOnTransportAndInterpolatedMovement) {
            await movementFlagsOnTransportAndInterpolatedMovement.TransportInfo.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(movementFlagsOnTransportAndInterpolatedMovement.TransportTime, cancellationToken).ConfigureAwait(false);

        }
        else if (Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransport movementFlagsOnTransport) {
            await movementFlagsOnTransport.Transport.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
            await w.WriteFloat(movementFlagsSwimming.Pitch1, cancellationToken).ConfigureAwait(false);

        }
        else if (Flags.Swimming.Value is MovementFlagsFlying movementFlagsFlying) {
            await w.WriteFloat(movementFlagsFlying.Pitch2, cancellationToken).ConfigureAwait(false);

        }
        else if (Flags.Swimming.Value is MovementFlagsAlwaysAllowPitching movementFlagsAlwaysAllowPitching) {
            await w.WriteFloat(movementFlagsAlwaysAllowPitching.Pitch3, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteFloat(FallTime, cancellationToken).ConfigureAwait(false);

        if (Flags.Falling is MovementFlagsFalling movementFlagsFalling) {
            await w.WriteFloat(movementFlagsFalling.ZSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsFalling.CosAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsFalling.SinAngle, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(movementFlagsFalling.XySpeed, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.SplineElevation is MovementFlagsSplineElevation movementFlagsSplineElevation) {
            await w.WriteFloat(movementFlagsSplineElevation.SplineElevation, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<MovementInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var flags = new MovementFlagsType {
            Inner = (MovementFlags)await r.ReadU48(cancellationToken).ConfigureAwait(false),
        };

        var timestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var orientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Wrath.MovementFlags.OnTransportAndInterpolatedMovement)) {
            var transportInfo = await TransportInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var transportTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.OnTransportAndInterpolatedMovement = new MovementFlagsOnTransportAndInterpolatedMovement {
                TransportInfo = transportInfo,
                TransportTime = transportTime,
            };
        }
        else if (flags.Inner.HasFlag(Wrath.MovementFlags.OnTransport)) {
            var transport = await TransportInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            flags.OnTransportAndInterpolatedMovement = new MovementFlagsOnTransport {
                Transport = transport,
            };
        }

        if (flags.Inner.HasFlag(Wrath.MovementFlags.Swimming)) {
            var pitch1 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsSwimming {
                Pitch1 = pitch1,
            };
        }
        else if (flags.Inner.HasFlag(Wrath.MovementFlags.Flying)) {
            var pitch2 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsFlying {
                Pitch2 = pitch2,
            };
        }
        else if (flags.Inner.HasFlag(Wrath.MovementFlags.AlwaysAllowPitching)) {
            var pitch3 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Swimming = new MovementFlagsAlwaysAllowPitching {
                Pitch3 = pitch3,
            };
        }

        var fallTime = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Wrath.MovementFlags.Falling)) {
            var zSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var cosAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var sinAngle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var xySpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            flags.Falling = new MovementFlagsFalling {
                CosAngle = cosAngle,
                SinAngle = sinAngle,
                XySpeed = xySpeed,
                ZSpeed = zSpeed,
            };
        }

        if (flags.Inner.HasFlag(Wrath.MovementFlags.SplineElevation)) {
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

        // flags: Generator.Generated.DataTypeFlag
        size += 6;

        // timestamp: Generator.Generated.DataTypeInteger
        size += 4;

        // position: Generator.Generated.DataTypeStruct
        size += 12;

        // orientation: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransportAndInterpolatedMovement movementFlagsOnTransportAndInterpolatedMovement) {
            // transport_info: Generator.Generated.DataTypeStruct
            size += movementFlagsOnTransportAndInterpolatedMovement.TransportInfo.Size();

            // transport_time: Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransport movementFlagsOnTransport) {
            // transport: Generator.Generated.DataTypeStruct
            size += movementFlagsOnTransport.Transport.Size();

        }

        if (Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
            // pitch1: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (Flags.Swimming.Value is MovementFlagsFlying movementFlagsFlying) {
            // pitch2: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (Flags.Swimming.Value is MovementFlagsAlwaysAllowPitching movementFlagsAlwaysAllowPitching) {
            // pitch3: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        // fall_time: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        if (Flags.Falling is MovementFlagsFalling movementFlagsFalling) {
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

