using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class ItemStat {
    public required uint StatType { get; set; }
    public required int Value { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(StatType, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(Value, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<ItemStat> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var statType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var value = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        return new ItemStat {
            StatType = statType,
            Value = value,
        };
    }

}
