using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_AUTH_SESSION: VanillaClientMessage, IWorldMessage {
    public required uint Build { get; set; }
    /// <summary>
    /// This is sent to the client in [CMD_REALM_LIST_Server].
    /// </summary>
    public required uint ServerId { get; set; }
    public required string Username { get; set; }
    public required uint ClientSeed { get; set; }
    public required List<byte> ClientProof { get; set; }
    public required List<AddonInfo> AddonInfo { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await WriteUtils.WriteUInt(w, Build, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, ServerId, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteCString(w, Username, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, ClientSeed, cancellationToken).ConfigureAwait(false);

        foreach (var v in ClientProof) {
            await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
        }

        var oldStream = w;
        w = new MemoryStream();
        foreach (var v in AddonInfo) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }
        var uncompressedLength = w.Position;

        var compressedOutput = new MemoryStream();
        var zlib = new System.IO.Compression.ZLibStream(compressedOutput, System.IO.Compression.CompressionMode.Compress);
        zlib.Write((w as MemoryStream)!.ToArray());
        zlib.Flush();

        w = oldStream;
        await WriteUtils.WriteUInt(w, (uint)uncompressedLength, cancellationToken).ConfigureAwait(false);
        await w.WriteAsync(compressedOutput.ToArray(), cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 493, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 493, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_AUTH_SESSION> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var build = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);
        size += 4;

        var serverId = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);
        size += 4;

        var username = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);
        size += username.Length + 1;

        var clientSeed = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);
        size += 4;

        var clientProof = new List<byte>();
        for (var i = 0; i < 20; ++i) {
            clientProof.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            size += 1;
        }

        var decompressedLength = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);
        size += 4;

        var decompressed = new byte[decompressedLength];
        var remaining = new byte[bodySize - size];
        r.ReadExactly(remaining);

        var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);
        zlib.ReadAtLeast(decompressed, remaining.Length);

        r = new MemoryStream(decompressed);
        var addonInfo = new List<AddonInfo>();
        while (r.Position < r.Length) {
            addonInfo.Add(await Vanilla.AddonInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            size += addonInfo[^1].Size();
        }

        return new CMSG_AUTH_SESSION {
            Build = build,
            ServerId = serverId,
            Username = username,
            ClientSeed = clientSeed,
            ClientProof = clientProof,
            AddonInfo = addonInfo,
        };
    }

    internal int Size() {
        var memory = new MemoryStream();
        Task.WaitAll(WriteBodyAsync(memory));
        return (int)memory.Position;
    }

}

