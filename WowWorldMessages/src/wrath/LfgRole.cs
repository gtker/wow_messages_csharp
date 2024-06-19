using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgRole {
    public required ulong Guid { get; set; }
    public required bool Ready { get; set; }
    public required uint Roles { get; set; }
    public required byte Level { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Ready, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Roles, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgRole> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var ready = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var roles = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new LfgRole {
            Guid = guid,
            Ready = ready,
            Roles = roles,
            Level = level,
        };
    }

}

