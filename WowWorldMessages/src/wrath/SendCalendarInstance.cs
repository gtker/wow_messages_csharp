using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SendCalendarInstance {
    public required Wrath.Map Map { get; set; }
    public required uint Difficulty { get; set; }
    public required uint ResetTime { get; set; }
    public required ulong InstanceId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ResetTime, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InstanceId, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SendCalendarInstance> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var difficulty = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var resetTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var instanceId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new SendCalendarInstance {
            Map = map,
            Difficulty = difficulty,
            ResetTime = resetTime,
            InstanceId = instanceId,
        };
    }

}

