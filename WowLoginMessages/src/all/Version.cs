namespace WowLoginMessages.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Version {
    public required byte Major { get; set; }
    public required byte Minor { get; set; }
    public required byte Patch { get; set; }
    public required ushort Build { get; set; }

    public static async Task<Version> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var major = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var minor = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var patch = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var build = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        return new Version {
            Major = major,
            Minor = minor,
            Patch = patch,
            Build = build,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteByte(w, Major, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, Minor, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, Patch, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUShort(w, Build, cancellationToken).ConfigureAwait(false);

    }

}

