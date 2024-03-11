namespace Gtker.WowMessages.Login.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class Version {
    public required byte Major { get; set; }
    public required byte Minor { get; set; }
    public required byte Patch { get; set; }
    public required ushort Build { get; set; }

    public static async Task<Version> Read(Stream r) {
        var major = await ReadUtils.ReadByte(r);

        var minor = await ReadUtils.ReadByte(r);

        var patch = await ReadUtils.ReadByte(r);

        var build = await ReadUtils.ReadUShort(r);

        return new Version {
            Major = major,
            Minor = minor,
            Patch = patch,
            Build = build,
        };
    }

}

