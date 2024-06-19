using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestGiverStatusReport {
    public required ulong Npc { get; set; }
    public required Wrath.QuestGiverStatus DialogStatus { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Npc, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)DialogStatus, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<QuestGiverStatusReport> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var npc = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var dialogStatus = (Wrath.QuestGiverStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new QuestGiverStatusReport {
            Npc = npc,
            DialogStatus = dialogStatus,
        };
    }

}

