using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class MoneyLogItem {
    public required byte Action { get; set; }
    public required ulong Player { get; set; }
    public required uint Entry { get; set; }
    public required uint Timestamp { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Action, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Entry, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Timestamp, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<MoneyLogItem> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var action = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var entry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MoneyLogItem {
            Action = action,
            Player = player,
            Entry = entry,
            Timestamp = timestamp,
        };
    }

}

