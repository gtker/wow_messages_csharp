using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SendCalendarResetTime {
    public required Wrath.Map Map { get; set; }
    public required uint Period { get; set; }
    public required uint TimeOffset { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Period, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeOffset, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SendCalendarResetTime> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var period = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeOffset = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SendCalendarResetTime {
            Map = map,
            Period = period,
            TimeOffset = timeOffset,
        };
    }

}

