namespace WowMessages.Login.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class TelemetryKey {
    public required ushort Unknown1 { get; set; }
    public required uint Unknown2 { get; set; }
    public required List<byte> Unknown3 { get; set; }
    /// <summary>
    /// SHA1 hash of the session key, server public key, and an unknown 20 byte value.
    /// </summary>
    public required List<byte> CdKeyProof { get; set; }

    public static async Task<TelemetryKey> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown1 = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        var unknown2 = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        var unknown3 = new List<byte>();
        for (var i = 0; i < 4; ++i) {
            unknown3.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        var cdKeyProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            cdKeyProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
        }

        return new TelemetryKey {
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Unknown3 = unknown3,
            CdKeyProof = cdKeyProof,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteUShort(w, Unknown1, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, Unknown2, cancellationToken).ConfigureAwait(false);

        foreach (var v in Unknown3) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in CdKeyProof) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

    }

}

