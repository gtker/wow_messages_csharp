using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

using MonsterMoveTypeType = OneOf.OneOf<SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle, SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot, SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget, MonsterMoveType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MONSTER_MOVE_TRANSPORT: WrathServerMessage, IWorldMessage {
    public class MonsterMoveTypeFacingAngle {
        public required float Angle { get; set; }
    }
    public class MonsterMoveTypeFacingSpot {
        public required Vector3d Position { get; set; }
    }
    public class MonsterMoveTypeFacingTarget {
        public required ulong Target { get; set; }
    }
    public class SplineFlagType {
        public required SplineFlag Inner;
        public SplineFlagEnterCycle? EnterCycle;
        public SplineFlagParabolic? Parabolic;
    }
    public class SplineFlagEnterCycle {
        public required uint AnimationId { get; set; }
        public required uint AnimationStartTime { get; set; }
    }
    public class SplineFlagParabolic {
        public required uint EffectStartTime { get; set; }
        public required float VerticalAcceleration { get; set; }
    }
    public required ulong Guid { get; set; }
    public required ulong Transport { get; set; }
    /// <summary>
    /// cmangos-wotlk sets to 0
    /// </summary>
    public required byte Unknown { get; set; }
    public required Vector3d SplinePoint { get; set; }
    public required uint SplineId { get; set; }
    public required MonsterMoveTypeType MoveType { get; set; }
    internal MonsterMoveType MoveTypeValue => MoveType.Match(
        _ => Wrath.MonsterMoveType.FacingAngle,
        _ => Wrath.MonsterMoveType.FacingSpot,
        _ => Wrath.MonsterMoveType.FacingTarget,
        v => v
    );
    public required SplineFlagType SplineFlags { get; set; }
    public required uint Duration { get; set; }
    public required List<Vector3d> Splines { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Transport, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

        await SplinePoint.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SplineId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)MoveTypeValue, cancellationToken).ConfigureAwait(false);

        if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget monsterMoveTypeFacingTarget) {
            await w.WriteULong(monsterMoveTypeFacingTarget.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle monsterMoveTypeFacingAngle) {
            await w.WriteFloat(monsterMoveTypeFacingAngle.Angle, cancellationToken).ConfigureAwait(false);

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot monsterMoveTypeFacingSpot) {
            await monsterMoveTypeFacingSpot.Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteUInt((uint)SplineFlags.Inner, cancellationToken).ConfigureAwait(false);

        if (SplineFlags.EnterCycle is {} splineFlagEnterCycle) {
            await w.WriteUInt(splineFlagEnterCycle.AnimationId, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(splineFlagEnterCycle.AnimationStartTime, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteUInt(Duration, cancellationToken).ConfigureAwait(false);

        if (SplineFlags.Parabolic is {} splineFlagParabolic) {
            await w.WriteFloat(splineFlagParabolic.VerticalAcceleration, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(splineFlagParabolic.EffectStartTime, cancellationToken).ConfigureAwait(false);

        }

        await ReadUtils.WriteMonsterMoveSpline(w, Splines, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 686, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 686, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MONSTER_MOVE_TRANSPORT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var transport = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var splinePoint = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var splineId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        MonsterMoveTypeType moveType = (Wrath.MonsterMoveType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (moveType.Value is Wrath.MonsterMoveType.FacingTarget) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingTarget {
                Target = target,
            };
        }
        else if (moveType.Value is Wrath.MonsterMoveType.FacingAngle) {
            var angle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingAngle {
                Angle = angle,
            };
        }
        else if (moveType.Value is Wrath.MonsterMoveType.FacingSpot) {
            var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingSpot {
                Position = position,
            };
        }

        var splineFlags = new SplineFlagType {
            Inner = (SplineFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (splineFlags.Inner.HasFlag(Wrath.SplineFlag.EnterCycle)) {
            var animationId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var animationStartTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            splineFlags.EnterCycle = new SplineFlagEnterCycle {
                AnimationId = animationId,
                AnimationStartTime = animationStartTime,
            };
        }

        var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (splineFlags.Inner.HasFlag(Wrath.SplineFlag.Parabolic)) {
            var verticalAcceleration = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var effectStartTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            splineFlags.Parabolic = new SplineFlagParabolic {
                EffectStartTime = effectStartTime,
                VerticalAcceleration = verticalAcceleration,
            };
        }

        var splines = await ReadUtils.ReadMonsterMoveSpline(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_MONSTER_MOVE_TRANSPORT {
            Guid = guid,
            Transport = transport,
            Unknown = unknown,
            SplinePoint = splinePoint,
            SplineId = splineId,
            MoveType = moveType,
            SplineFlags = splineFlags,
            Duration = duration,
            Splines = splines,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // transport: Generator.Generated.DataTypePackedGuid
        size += Transport.PackedGuidLength();

        // unknown: Generator.Generated.DataTypeInteger
        size += 1;

        // spline_point: Generator.Generated.DataTypeStruct
        size += 12;

        // spline_id: Generator.Generated.DataTypeInteger
        size += 4;

        // move_type: Generator.Generated.DataTypeEnum
        size += 1;

        if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget monsterMoveTypeFacingTarget) {
            // target: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle monsterMoveTypeFacingAngle) {
            // angle: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot monsterMoveTypeFacingSpot) {
            // position: Generator.Generated.DataTypeStruct
            size += 12;

        }

        // spline_flags: Generator.Generated.DataTypeFlag
        size += 4;

        if (SplineFlags.EnterCycle is {} splineFlagEnterCycle) {
            // animation_id: Generator.Generated.DataTypeInteger
            size += 4;

            // animation_start_time: Generator.Generated.DataTypeInteger
            size += 4;

        }

        // duration: Generator.Generated.DataTypeInteger
        size += 4;

        if (SplineFlags.Parabolic is {} splineFlagParabolic) {
            // vertical_acceleration: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // effect_start_time: Generator.Generated.DataTypeInteger
            size += 4;

        }

        // splines: Generator.Generated.DataTypeMonsterMoveSpline
        size += ReadUtils.MonsterMoveSplineLength(Splines);

        return size;
    }

}

