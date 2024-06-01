namespace WowLoginMessages.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Version {
    public required byte Major { get; set; }
    public required byte Minor { get; set; }
    public required byte Patch { get; set; }
    public required ushort Build { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Major, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Minor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Patch, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Build, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<Version> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var major = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var minor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var patch = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var build = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        return new Version {
            Major = major,
            Minor = minor,
            Patch = patch,
            Build = build,
        };
    }

}

