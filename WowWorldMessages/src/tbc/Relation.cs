using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using FriendStatusType = OneOf.OneOf<Relation.FriendStatusOnline, FriendStatus>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Relation {
    public class FriendStatusOnline {
        public required Tbc.Area Area { get; set; }
        public required Tbc.Class ClassType { get; set; }
        public required uint Level { get; set; }
    }
    public class RelationTypeType {
        public required RelationType Inner;
        public RelationTypeFriend? Friend;
    }
    public class RelationTypeFriend {
        public required FriendStatusType Status { get; set; }
        internal FriendStatus StatusValue => Status.Match(
            _ => Tbc.FriendStatus.Online,
            v => v
        );
    }
    public required ulong Guid { get; set; }
    public required RelationTypeType RelationMask { get; set; }
    public required string Note { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)RelationMask.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Note, cancellationToken).ConfigureAwait(false);

        if (RelationMask.Friend is {} relationTypeFriend) {
            await w.WriteByte((byte)relationTypeFriend.StatusValue, cancellationToken).ConfigureAwait(false);

            if (relationTypeFriend.Status.Value is Relation.FriendStatusOnline friendStatusOnline) {
                await w.WriteUInt((uint)friendStatusOnline.Area, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt(friendStatusOnline.Level, cancellationToken).ConfigureAwait(false);

                await w.WriteUInt((uint)friendStatusOnline.ClassType, cancellationToken).ConfigureAwait(false);

            }

        }

    }

    public static async Task<Relation> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var relationMask = new RelationTypeType {
            Inner = (RelationType)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var note = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        if (relationMask.Inner.HasFlag(Tbc.RelationType.Friend)) {
            FriendStatusType status = (Tbc.FriendStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            if (status.Value is Tbc.FriendStatus.Online) {
                var area = (Tbc.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var classType = (Tbc.Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                status = new FriendStatusOnline {
                    Area = area,
                    ClassType = classType,
                    Level = level,
                };
            }

            relationMask.Friend = new RelationTypeFriend {
                Status = status,
            };
        }

        return new Relation {
            Guid = guid,
            RelationMask = relationMask,
            Note = note,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // relation_mask: Generator.Generated.DataTypeFlag
        size += 4;

        // note: Generator.Generated.DataTypeCstring
        size += Note.Length + 1;

        if (RelationMask.Friend is {} relationTypeFriend) {
            // status: Generator.Generated.DataTypeEnum
            size += 1;

            if (relationTypeFriend.Status.Value is Relation.FriendStatusOnline friendStatusOnline) {
                // area: Generator.Generated.DataTypeEnum
                size += 4;

                // level: Generator.Generated.DataTypeLevel32
                size += 4;

                // class_type: Generator.Generated.DataTypeEnum
                size += 4;

            }

        }

        return size;
    }

}

