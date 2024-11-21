using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

using UpdateFlagLivingMulti = OneOf.OneOf<MovementBlock.UpdateFlagHasPosition, MovementBlock.UpdateFlagLiving, MovementBlock.UpdateFlagPosition, UpdateFlag>;
using MovementFlagsOnTransportAndInterpolatedMovementMulti = OneOf.OneOf<MovementBlock.MovementFlagsOnTransport, MovementBlock.MovementFlagsOnTransportAndInterpolatedMovement, MovementFlags>;
using SplineFlagFinalAngleMulti = OneOf.OneOf<MovementBlock.SplineFlagFinalAngle, MovementBlock.SplineFlagFinalPoint, MovementBlock.SplineFlagFinalTarget, SplineFlag>;
using MovementFlagsSwimmingMulti = OneOf.OneOf<MovementBlock.MovementFlagsAlwaysAllowPitching, MovementBlock.MovementFlagsFlying, MovementBlock.MovementFlagsSwimming, MovementFlags>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MovementBlock {
    public class UpdateFlagHasPosition {
        public required float Orientation2 { get; set; }
        public required Vector3d Position2 { get; set; }
    }
    public class UpdateFlagLiving {
        public required float BackwardsFlightSpeed { get; set; }
        public required float BackwardsRunningSpeed { get; set; }
        public required float BackwardsSwimmingSpeed { get; set; }
        public required float FallTime { get; set; }
        public required MovementFlagsType Flags { get; set; }
        public required float FlightSpeed { get; set; }
        public required float Orientation { get; set; }
        public required float PitchRate { get; set; }
        public required Vector3d Position { get; set; }
        public required float RunningSpeed { get; set; }
        public required float SwimmingSpeed { get; set; }
        public required uint Timestamp { get; set; }
        public required float TurnRate { get; set; }
        public required float WalkingSpeed { get; set; }
    }
    public class UpdateFlagPosition {
        public required float CorpseOrientation { get; set; }
        public required float Orientation1 { get; set; }
        public required Vector3d Position1 { get; set; }
        public required ulong TransportGuid { get; set; }
        public required Vector3d TransportOffset { get; set; }
    }
    public class MovementFlagsOnTransport {
        public required TransportInfo Transport { get; set; }
    }
    public class MovementFlagsOnTransportAndInterpolatedMovement {
        public required TransportInfo TransportInfo { get; set; }
        public required uint TransportTime { get; set; }
    }
    public class SplineFlagFinalAngle {
        public required float Angle { get; set; }
    }
    public class SplineFlagFinalPoint {
        public required Vector3d SplineFinalPoint { get; set; }
    }
    public class SplineFlagFinalTarget {
        public required ulong Target { get; set; }
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
    public class UpdateFlagType {
        public required UpdateFlag Inner;
        public UpdateFlagHasAttackingTarget? HasAttackingTarget;
        public UpdateFlagHighGuid? HighGuid;
        public UpdateFlagLivingMulti Living;
        public UpdateFlagLowGuid? LowGuid;
        public UpdateFlagRotation? Rotation;
        public UpdateFlagTransport? Transport;
        public UpdateFlagVehicle? Vehicle;
    }
    public class UpdateFlagHasAttackingTarget {
        public required ulong Guid { get; set; }
    }
    public class UpdateFlagHighGuid {
        /// <summary>
        /// vmangos statically sets to 0
        /// </summary>
        public required uint Unknown0 { get; set; }
    }
    public class UpdateFlagLowGuid {
        public required uint Unknown1 { get; set; }
    }
    public class UpdateFlagRotation {
        /// <summary>
        /// AzerothCore deliberately casts to i64
        /// </summary>
        public required ulong PackedLocalRotation { get; set; }
    }
    public class UpdateFlagTransport {
        public required uint TransportProgressInMs { get; set; }
    }
    public class UpdateFlagVehicle {
        public required uint VehicleId { get; set; }
        public required float VehicleOrientation { get; set; }
    }
    public class MovementFlagsType {
        public required MovementFlags Inner;
        public MovementFlagsFalling? Falling;
        public MovementFlagsOnTransportAndInterpolatedMovementMulti OnTransportAndInterpolatedMovement;
        public MovementFlagsSplineElevation? SplineElevation;
        public MovementFlagsSplineEnabled? SplineEnabled;
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
    public class MovementFlagsSplineEnabled {
        public required uint Duration { get; set; }
        public required float DurationMod { get; set; }
        public required float DurationModNext { get; set; }
        public required float EffectStartTime { get; set; }
        public required Vector3d FinalNode { get; set; }
        public required uint Id { get; set; }
        public required byte Mode { get; set; }
        public required List<Vector3d> Nodes { get; set; }
        public required SplineFlagFinalAngleMulti SplineFlags { get; set; }
        internal SplineFlag SplineFlagsValue => SplineFlags.Match(
            _ => Wrath.SplineFlag.FinalAngle,
            _ => Wrath.SplineFlag.FinalPoint,
            _ => Wrath.SplineFlag.FinalTarget,
            v => v
        );
        public required uint TimePassed { get; set; }
        public required float VerticalAcceleration { get; set; }
    }
    public required UpdateFlagType UpdateFlag { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort((ushort)UpdateFlag.Inner, cancellationToken).ConfigureAwait(false);

        if (UpdateFlag.Living.Value is UpdateFlagLiving updateFlagLiving) {
            await w.WriteU48((ulong)updateFlagLiving.Flags.Inner, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(updateFlagLiving.Timestamp, cancellationToken).ConfigureAwait(false);

            await updateFlagLiving.Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.Orientation, cancellationToken).ConfigureAwait(false);

            if (updateFlagLiving.Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransportAndInterpolatedMovement movementFlagsOnTransportAndInterpolatedMovement) {
                await movementFlagsOnTransportAndInterpolatedMovement.TransportInfo.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(movementFlagsOnTransportAndInterpolatedMovement.TransportTime, cancellationToken).ConfigureAwait(false);

            }
            else if (updateFlagLiving.Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransport movementFlagsOnTransport) {
                await movementFlagsOnTransport.Transport.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            }

            if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
                await w.WriteFloat(movementFlagsSwimming.Pitch1, cancellationToken).ConfigureAwait(false);

            }
            else if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsFlying movementFlagsFlying) {
                await w.WriteFloat(movementFlagsFlying.Pitch2, cancellationToken).ConfigureAwait(false);

            }
            else if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsAlwaysAllowPitching movementFlagsAlwaysAllowPitching) {
                await w.WriteFloat(movementFlagsAlwaysAllowPitching.Pitch3, cancellationToken).ConfigureAwait(false);

            }

            await w.WriteFloat(updateFlagLiving.FallTime, cancellationToken).ConfigureAwait(false);

            if (updateFlagLiving.Flags.Falling is MovementFlagsFalling movementFlagsFalling) {
                await w.WriteFloat(movementFlagsFalling.ZSpeed, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsFalling.CosAngle, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsFalling.SinAngle, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsFalling.XySpeed, cancellationToken).ConfigureAwait(false);

            }

            if (updateFlagLiving.Flags.SplineElevation is MovementFlagsSplineElevation movementFlagsSplineElevation) {
                await w.WriteFloat(movementFlagsSplineElevation.SplineElevation, cancellationToken).ConfigureAwait(false);

            }

            await w.WriteFloat(updateFlagLiving.WalkingSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.RunningSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.BackwardsRunningSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.SwimmingSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.BackwardsSwimmingSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.FlightSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.BackwardsFlightSpeed, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.TurnRate, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagLiving.PitchRate, cancellationToken).ConfigureAwait(false);

            if (updateFlagLiving.Flags.SplineEnabled is MovementFlagsSplineEnabled movementFlagsSplineEnabled) {
                await w.WriteUInt((uint)movementFlagsSplineEnabled.SplineFlagsValue, cancellationToken).ConfigureAwait(false);

                if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalAngle splineFlagFinalAngle) {
                    await w.WriteFloat(splineFlagFinalAngle.Angle, cancellationToken).ConfigureAwait(false);

                }
                else if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalTarget splineFlagFinalTarget) {
                    await w.WriteULong(splineFlagFinalTarget.Target, cancellationToken).ConfigureAwait(false);

                }
                else if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalPoint splineFlagFinalPoint) {
                    await splineFlagFinalPoint.SplineFinalPoint.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

                }

                await w.WriteUInt(movementFlagsSplineEnabled.TimePassed, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(movementFlagsSplineEnabled.Duration, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(movementFlagsSplineEnabled.Id, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsSplineEnabled.DurationMod, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsSplineEnabled.DurationModNext, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsSplineEnabled.VerticalAcceleration, cancellationToken).ConfigureAwait(false);

                await w.WriteFloat(movementFlagsSplineEnabled.EffectStartTime, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt((uint)movementFlagsSplineEnabled.Nodes.Count, cancellationToken).ConfigureAwait(false);

                foreach (var v in movementFlagsSplineEnabled.Nodes) {
                    await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
                }

                await w.WriteByte(movementFlagsSplineEnabled.Mode, cancellationToken).ConfigureAwait(false);

                await movementFlagsSplineEnabled.FinalNode.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            }

        }
        else if (UpdateFlag.Living.Value is UpdateFlagPosition updateFlagPosition) {
            await w.WritePackedGuid(updateFlagPosition.TransportGuid, cancellationToken).ConfigureAwait(false);

            await updateFlagPosition.Position1.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await updateFlagPosition.TransportOffset.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagPosition.Orientation1, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagPosition.CorpseOrientation, cancellationToken).ConfigureAwait(false);

        }
        else if (UpdateFlag.Living.Value is UpdateFlagHasPosition updateFlagHasPosition) {
            await updateFlagHasPosition.Position2.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagHasPosition.Orientation2, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.HighGuid is UpdateFlagHighGuid updateFlagHighGuid) {
            await w.WriteUInt(updateFlagHighGuid.Unknown0, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.LowGuid is UpdateFlagLowGuid updateFlagLowGuid) {
            await w.WriteUInt(updateFlagLowGuid.Unknown1, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.HasAttackingTarget is UpdateFlagHasAttackingTarget updateFlagHasAttackingTarget) {
            await w.WritePackedGuid(updateFlagHasAttackingTarget.Guid, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.Transport is UpdateFlagTransport updateFlagTransport) {
            await w.WriteUInt(updateFlagTransport.TransportProgressInMs, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.Vehicle is UpdateFlagVehicle updateFlagVehicle) {
            await w.WriteUInt(updateFlagVehicle.VehicleId, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(updateFlagVehicle.VehicleOrientation, cancellationToken).ConfigureAwait(false);

        }

        if (UpdateFlag.Rotation is UpdateFlagRotation updateFlagRotation) {
            await w.WriteULong(updateFlagRotation.PackedLocalRotation, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<MovementBlock> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var updateFlag = new UpdateFlagType {
            Inner = (UpdateFlag)await r.ReadUShort(cancellationToken).ConfigureAwait(false),
        };

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.Living)) {
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

            var walkingSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var runningSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var backwardsRunningSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var swimmingSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var backwardsSwimmingSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var flightSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var backwardsFlightSpeed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var turnRate = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var pitchRate = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            if (flags.Inner.HasFlag(Wrath.MovementFlags.SplineEnabled)) {
                SplineFlagFinalAngleMulti splineFlags = (Wrath.SplineFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                if (((Wrath.SplineFlag)splineFlags.Value & Wrath.SplineFlag.FinalAngle) != 0) {
                    var angle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

                    splineFlags = new SplineFlagFinalAngle {
                        Angle = angle,
                    };
                }
                else if (((Wrath.SplineFlag)splineFlags.Value & Wrath.SplineFlag.FinalTarget) != 0) {
                    var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

                    splineFlags = new SplineFlagFinalTarget {
                        Target = target,
                    };
                }
                else if (((Wrath.SplineFlag)splineFlags.Value & Wrath.SplineFlag.FinalPoint) != 0) {
                    var splineFinalPoint = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

                    splineFlags = new SplineFlagFinalPoint {
                        SplineFinalPoint = splineFinalPoint,
                    };
                }

                var timePassed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var durationMod = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

                var durationModNext = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

                var verticalAcceleration = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

                var effectStartTime = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

                // ReSharper disable once UnusedVariable.Compiler
                var amountOfNodes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var nodes = new List<Vector3d>();
                for (var i = 0; i < amountOfNodes; ++i) {
                    nodes.Add(await All.Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
                }

                var mode = await r.ReadByte(cancellationToken).ConfigureAwait(false);

                var finalNode = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

                flags.SplineEnabled = new MovementFlagsSplineEnabled {
                    Duration = duration,
                    DurationMod = durationMod,
                    DurationModNext = durationModNext,
                    EffectStartTime = effectStartTime,
                    FinalNode = finalNode,
                    Id = id,
                    Mode = mode,
                    Nodes = nodes,
                    SplineFlags = splineFlags,
                    TimePassed = timePassed,
                    VerticalAcceleration = verticalAcceleration,
                };
            }

            updateFlag.Living = new UpdateFlagLiving {
                BackwardsFlightSpeed = backwardsFlightSpeed,
                BackwardsRunningSpeed = backwardsRunningSpeed,
                BackwardsSwimmingSpeed = backwardsSwimmingSpeed,
                FallTime = fallTime,
                Flags = flags,
                FlightSpeed = flightSpeed,
                Orientation = orientation,
                PitchRate = pitchRate,
                Position = position,
                RunningSpeed = runningSpeed,
                SwimmingSpeed = swimmingSpeed,
                Timestamp = timestamp,
                TurnRate = turnRate,
                WalkingSpeed = walkingSpeed,
            };
        }
        else if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.Position)) {
            var transportGuid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var position1 = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var transportOffset = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var orientation1 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var corpseOrientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            updateFlag.Living = new UpdateFlagPosition {
                CorpseOrientation = corpseOrientation,
                Orientation1 = orientation1,
                Position1 = position1,
                TransportGuid = transportGuid,
                TransportOffset = transportOffset,
            };
        }
        else if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.HasPosition)) {
            var position2 = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var orientation2 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            updateFlag.Living = new UpdateFlagHasPosition {
                Orientation2 = orientation2,
                Position2 = position2,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.HighGuid)) {
            var unknown0 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            updateFlag.HighGuid = new UpdateFlagHighGuid {
                Unknown0 = unknown0,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.LowGuid)) {
            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            updateFlag.LowGuid = new UpdateFlagLowGuid {
                Unknown1 = unknown1,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.HasAttackingTarget)) {
            var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            updateFlag.HasAttackingTarget = new UpdateFlagHasAttackingTarget {
                Guid = guid,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.Transport)) {
            var transportProgressInMs = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            updateFlag.Transport = new UpdateFlagTransport {
                TransportProgressInMs = transportProgressInMs,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.Vehicle)) {
            var vehicleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var vehicleOrientation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            updateFlag.Vehicle = new UpdateFlagVehicle {
                VehicleId = vehicleId,
                VehicleOrientation = vehicleOrientation,
            };
        }

        if (updateFlag.Inner.HasFlag(Wrath.UpdateFlag.Rotation)) {
            var packedLocalRotation = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            updateFlag.Rotation = new UpdateFlagRotation {
                PackedLocalRotation = packedLocalRotation,
            };
        }

        return new MovementBlock {
            UpdateFlag = updateFlag,
        };
    }

    internal int Size() {
        var size = 0;

        // update_flag: Generator.Generated.DataTypeFlag
        size += 2;

        if (UpdateFlag.Living.Value is UpdateFlagLiving updateFlagLiving) {
            // flags: Generator.Generated.DataTypeFlag
            size += 6;

            // timestamp: Generator.Generated.DataTypeInteger
            size += 4;

            // position: Generator.Generated.DataTypeStruct
            size += 12;

            // orientation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            if (updateFlagLiving.Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransportAndInterpolatedMovement movementFlagsOnTransportAndInterpolatedMovement) {
                // transport_info: Generator.Generated.DataTypeStruct
                size += movementFlagsOnTransportAndInterpolatedMovement.TransportInfo.Size();

                // transport_time: Generator.Generated.DataTypeInteger
                size += 4;

            }
            else if (updateFlagLiving.Flags.OnTransportAndInterpolatedMovement.Value is MovementFlagsOnTransport movementFlagsOnTransport) {
                // transport: Generator.Generated.DataTypeStruct
                size += movementFlagsOnTransport.Transport.Size();

            }

            if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsSwimming movementFlagsSwimming) {
                // pitch1: Generator.Generated.DataTypeFloatingPoint
                size += 4;

            }
            else if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsFlying movementFlagsFlying) {
                // pitch2: Generator.Generated.DataTypeFloatingPoint
                size += 4;

            }
            else if (updateFlagLiving.Flags.Swimming.Value is MovementFlagsAlwaysAllowPitching movementFlagsAlwaysAllowPitching) {
                // pitch3: Generator.Generated.DataTypeFloatingPoint
                size += 4;

            }

            // fall_time: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            if (updateFlagLiving.Flags.Falling is MovementFlagsFalling movementFlagsFalling) {
                // z_speed: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // cos_angle: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // sin_angle: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // xy_speed: Generator.Generated.DataTypeFloatingPoint
                size += 4;

            }

            if (updateFlagLiving.Flags.SplineElevation is MovementFlagsSplineElevation movementFlagsSplineElevation) {
                // spline_elevation: Generator.Generated.DataTypeFloatingPoint
                size += 4;

            }

            // walking_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // running_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // backwards_running_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // swimming_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // backwards_swimming_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // flight_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // backwards_flight_speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // turn_rate: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // pitch_rate: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            if (updateFlagLiving.Flags.SplineEnabled is MovementFlagsSplineEnabled movementFlagsSplineEnabled) {
                // spline_flags: Generator.Generated.DataTypeFlag
                size += 4;

                if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalAngle splineFlagFinalAngle) {
                    // angle: Generator.Generated.DataTypeFloatingPoint
                    size += 4;

                }
                else if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalTarget splineFlagFinalTarget) {
                    // target: Generator.Generated.DataTypeInteger
                    size += 8;

                }
                else if (movementFlagsSplineEnabled.SplineFlags.Value is SplineFlagFinalPoint splineFlagFinalPoint) {
                    // spline_final_point: Generator.Generated.DataTypeStruct
                    size += 12;

                }

                // time_passed: Generator.Generated.DataTypeInteger
                size += 4;

                // duration: Generator.Generated.DataTypeInteger
                size += 4;

                // id: Generator.Generated.DataTypeInteger
                size += 4;

                // duration_mod: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // duration_mod_next: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // vertical_acceleration: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // effect_start_time: Generator.Generated.DataTypeFloatingPoint
                size += 4;

                // amount_of_nodes: Generator.Generated.DataTypeInteger
                size += 4;

                // nodes: Generator.Generated.DataTypeArray
                size += movementFlagsSplineEnabled.Nodes.Sum(e => 12);

                // mode: Generator.Generated.DataTypeInteger
                size += 1;

                // final_node: Generator.Generated.DataTypeStruct
                size += 12;

            }

        }
        else if (UpdateFlag.Living.Value is UpdateFlagPosition updateFlagPosition) {
            // transport_guid: Generator.Generated.DataTypePackedGuid
            size += updateFlagPosition.TransportGuid.PackedGuidLength();

            // position1: Generator.Generated.DataTypeStruct
            size += 12;

            // transport_offset: Generator.Generated.DataTypeStruct
            size += 12;

            // orientation1: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // corpse_orientation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (UpdateFlag.Living.Value is UpdateFlagHasPosition updateFlagHasPosition) {
            // position2: Generator.Generated.DataTypeStruct
            size += 12;

            // orientation2: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        if (UpdateFlag.HighGuid is UpdateFlagHighGuid updateFlagHighGuid) {
            // unknown0: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (UpdateFlag.LowGuid is UpdateFlagLowGuid updateFlagLowGuid) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (UpdateFlag.HasAttackingTarget is UpdateFlagHasAttackingTarget updateFlagHasAttackingTarget) {
            // guid: Generator.Generated.DataTypePackedGuid
            size += updateFlagHasAttackingTarget.Guid.PackedGuidLength();

        }

        if (UpdateFlag.Transport is UpdateFlagTransport updateFlagTransport) {
            // transport_progress_in_ms: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (UpdateFlag.Vehicle is UpdateFlagVehicle updateFlagVehicle) {
            // vehicle_id: Generator.Generated.DataTypeInteger
            size += 4;

            // vehicle_orientation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        if (UpdateFlag.Rotation is UpdateFlagRotation updateFlagRotation) {
            // packed_local_rotation: Generator.Generated.DataTypeInteger
            size += 8;

        }

        return size;
    }

}

