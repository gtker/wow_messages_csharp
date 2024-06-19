using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestItem {
    public required uint QuestId { get; set; }
    public required uint QuestIcon { get; set; }
    public required uint Level { get; set; }
    public required uint Flags { get; set; }
    public required bool Repeatable { get; set; }
    /// <summary>
    /// vmangos/cmangos/mangoszero: max 0x200
    /// </summary>
    public required string Title { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QuestIcon, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Repeatable, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Title, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<QuestItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var questIcon = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var repeatable = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var title = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new QuestItem {
            QuestId = questId,
            QuestIcon = questIcon,
            Level = level,
            Flags = flags,
            Repeatable = repeatable,
            Title = title,
        };
    }

    internal int Size() {
        var size = 0;

        // quest_id: Generator.Generated.DataTypeInteger
        size += 4;

        // quest_icon: Generator.Generated.DataTypeInteger
        size += 4;

        // level: Generator.Generated.DataTypeLevel32
        size += 4;

        // flags: Generator.Generated.DataTypeInteger
        size += 4;

        // repeatable: Generator.Generated.DataTypeBool
        size += 1;

        // title: Generator.Generated.DataTypeCstring
        size += Title.Length + 1;

        return size;
    }

}

