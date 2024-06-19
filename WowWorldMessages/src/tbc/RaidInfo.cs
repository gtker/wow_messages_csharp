using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class RaidInfo {
    public required Tbc.Map Map { get; set; }
    public required uint ResetTime { get; set; }
    public required uint InstanceId { get; set; }
    /// <summary>
    /// Neither 1.12 nor 3.3.5 have an index field so this might not be accurate.
    /// </summary>
    public required uint Index { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ResetTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(InstanceId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Index, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<RaidInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Tbc.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var resetTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var instanceId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var index = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new RaidInfo {
            Map = map,
            ResetTime = resetTime,
            InstanceId = instanceId,
            Index = index,
        };
    }

}

