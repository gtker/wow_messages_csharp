using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using MonsterMoveTypeType = OneOf.OneOf<SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle, SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot, SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget, MonsterMoveType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MONSTER_MOVE_TRANSPORT: VanillaServerMessage, IWorldMessage {
    public class MonsterMoveTypeFacingAngle {
        public required float Angle { get; set; }
    }
    public class MonsterMoveTypeFacingSpot {
        public required Vector3d Position { get; set; }
    }
    public class MonsterMoveTypeFacingTarget {
        public required ulong Target { get; set; }
    }
    public required ulong Guid { get; set; }
    public required ulong Transport { get; set; }
    public required Vector3d SplinePoint { get; set; }
    public required uint SplineId { get; set; }
    public required MonsterMoveTypeType MoveType { get; set; }
    internal MonsterMoveType MoveTypeValue => MoveType.Match(
        _ => Vanilla.MonsterMoveType.FacingAngle,
        _ => Vanilla.MonsterMoveType.FacingSpot,
        _ => Vanilla.MonsterMoveType.FacingTarget,
        v => v
    );
    public required SplineFlag SplineFlags { get; set; }
    public required uint Duration { get; set; }
    public required List<Vector3d> Splines { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Transport, cancellationToken).ConfigureAwait(false);

        await SplinePoint.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(SplineId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)MoveTypeValue, cancellationToken).ConfigureAwait(false);

        if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget facingTarget) {
            await w.WriteULong(facingTarget.Target, cancellationToken).ConfigureAwait(false);

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle facingAngle) {
            await w.WriteFloat(facingAngle.Angle, cancellationToken).ConfigureAwait(false);

        }

        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot facingSpot) {
            await facingSpot.Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }


        await w.WriteUInt((uint)SplineFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Duration, cancellationToken).ConfigureAwait(false);

        await ReadUtils.WriteMonsterMoveSpline(w, Splines, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 686, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 686, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MONSTER_MOVE_TRANSPORT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var transport = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var splinePoint = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        var splineId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        MonsterMoveTypeType moveType = (MonsterMoveType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (moveType.Value is Vanilla.MonsterMoveType.FacingTarget) {
            var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingTarget {
                Target = target,
            };
        }
        else if (moveType.Value is Vanilla.MonsterMoveType.FacingAngle) {
            var angle = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingAngle {
                Angle = angle,
            };
        }

        else if (moveType.Value is Vanilla.MonsterMoveType.FacingSpot) {
            var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            moveType = new MonsterMoveTypeFacingSpot {
                Position = position,
            };
        }


        var splineFlags = (SplineFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var splines = await ReadUtils.ReadMonsterMoveSpline(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_MONSTER_MOVE_TRANSPORT {
            Guid = guid,
            Transport = transport,
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

        // spline_point: Generator.Generated.DataTypeStruct
        size += 12;

        // spline_id: Generator.Generated.DataTypeInteger
        size += 4;

        // move_type: Generator.Generated.DataTypeEnum
        size += 1;

        if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingTarget facingTarget) {
            // target: Generator.Generated.DataTypeGuid
            size += 8;

        }
        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingAngle facingAngle) {
            // angle: Generator.Generated.DataTypeFloatingPoint
            size += 4;

        }

        else if (MoveType.Value is SMSG_MONSTER_MOVE_TRANSPORT.MonsterMoveTypeFacingSpot facingSpot) {
            // position: Generator.Generated.DataTypeStruct
            size += 12;

        }


        // spline_flags: Generator.Generated.DataTypeFlag
        size += 4;

        // duration: Generator.Generated.DataTypeInteger
        size += 4;

        // splines: Generator.Generated.DataTypeMonsterMoveSpline
        size += ReadUtils.MonsterMoveSplineLength(Splines);

        return size;
    }

}

