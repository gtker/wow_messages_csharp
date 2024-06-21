using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_UPDATE_ACCOUNT_DATA: WrathClientMessage, IWorldMessage {
    /// <summary>
    /// You can check this against the [CacheMask] to find out if this is character-specific data or account-wide data
    /// </summary>
    public required uint DataType { get; set; }
    /// <summary>
    /// Seconds since unix epoch. The client wants this number back when it requests the ACCOUNT_DATA_TIMES
    /// </summary>
    public required uint UnixTime { get; set; }
    /// <summary>
    /// Compressed account data (macros, keybinds, etc). The server does not actually care about the uncompressed contents. It only needs to send this back to the client. The server acts as a cross-device storage
    /// </summary>
    public required List<byte> CompressedData { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DataType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(UnixTime, cancellationToken).ConfigureAwait(false);

        if (CompressedData.Count != 0) {
            var oldStream = w;
            w = new MemoryStream();
            foreach (var v in CompressedData) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }
            var uncompressedLength = w.Position;

            var compressedOutput = new MemoryStream();
            var zlib = new System.IO.Compression.ZLibStream(compressedOutput, System.IO.Compression.CompressionMode.Compress);
            zlib.Write((w as MemoryStream)!.ToArray());
            zlib.Flush();

            w = oldStream;
            await w.WriteUInt((uint)uncompressedLength, cancellationToken).ConfigureAwait(false);
            await w.WriteAsync(compressedOutput.ToArray(), cancellationToken).ConfigureAwait(false);
        }
        else {
            await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 523, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 523, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_UPDATE_ACCOUNT_DATA> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var dataType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var unixTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var decompressed = new byte[decompressedLength];
        var remaining = new byte[bodySize - __size];
        await r.ReadExactlyAsync(remaining, cancellationToken).ConfigureAwait(false);

        var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);
        zlib.ReadAtLeast(decompressed, remaining.Length);

        r = new MemoryStream(decompressed);
        var compressedData = new List<byte>();
        while (r.Position < r.Length) {
            compressedData.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            __size += 1;
        }

        return new CMSG_UPDATE_ACCOUNT_DATA {
            DataType = dataType,
            UnixTime = unixTime,
            CompressedData = compressedData,
        };
    }

    internal int Size() {
        var memory = new MemoryStream();
        Task.WaitAll(WriteBodyAsync(memory));
        return (int)memory.Position;
    }

}

