namespace Gtker.WowMessages.Login.All;

public class Version
{
    public byte Major { get; set; }
    public byte Minor { get; set; }
    public byte Patch { get; set; }
    public ushort Build { get; set; }

    public static async Task<Version> Read(Stream r)
    {
        var major = await Utils.ReadByte(r);

        var minor = await Utils.ReadByte(r);

        var patch = await Utils.ReadByte(r);

        var build = await Utils.ReadUShort(r);

        return new Version
        {
            Major = major,
            Minor = minor,
            Patch = patch,
            Build = build
        };
    }
}