using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestPoi {
    public required uint Id { get; set; }
    public required uint ObjectiveId { get; set; }
    public required Wrath.Map Map { get; set; }
    public required Wrath.Area Area { get; set; }
    public required uint FloorId { get; set; }
    public required uint Unknown1 { get; set; }
    public required uint Unknown2 { get; set; }
    public required List<Vector2dUnsigned> Points { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Id, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ObjectiveId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(FloorId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Points.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Points) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<QuestPoi> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var id = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var objectiveId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var floorId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPoints = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var points = new List<Vector2dUnsigned>();
        for (var i = 0; i < amountOfPoints; ++i) {
            points.Add(await Wrath.Vector2dUnsigned.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new QuestPoi {
            Id = id,
            ObjectiveId = objectiveId,
            Map = map,
            Area = area,
            FloorId = floorId,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Points = points,
        };
    }

    internal int Size() {
        var size = 0;

        // id: Generator.Generated.DataTypeInteger
        size += 4;

        // objective_id: Generator.Generated.DataTypeInteger
        size += 4;

        // map: Generator.Generated.DataTypeEnum
        size += 4;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        // floor_id: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_points: Generator.Generated.DataTypeInteger
        size += 4;

        // points: Generator.Generated.DataTypeArray
        size += Points.Sum(e => 8);

        return size;
    }

}

