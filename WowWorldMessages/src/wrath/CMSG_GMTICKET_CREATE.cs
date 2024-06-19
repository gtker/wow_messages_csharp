using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GMTICKET_CREATE: WrathClientMessage, IWorldMessage {
    public required Wrath.Map Map { get; set; }
    public required Vector3d Position { get; set; }
    public required string Message { get; set; }
    public required bool NeedsResponse { get; set; }
    public required bool NeedsMoreHelp { get; set; }
    public required List<uint> Times { get; set; }
    public required List<byte> CompressedData { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Message, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(NeedsResponse, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(NeedsMoreHelp, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Times.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Times) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

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
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 517, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 517, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GMTICKET_CREATE> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        __size += 12;

        var message = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        __size += message.Length + 1;

        var needsResponse = await r.ReadBool8(cancellationToken).ConfigureAwait(false);
        __size += 1;

        var needsMoreHelp = await r.ReadBool8(cancellationToken).ConfigureAwait(false);
        __size += 1;

        // ReSharper disable once UnusedVariable.Compiler
        var numOfTimes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var times = new List<uint>();
        for (var i = 0; i < numOfTimes; ++i) {
            times.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
            __size += 4;
        }

        var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var decompressed = new byte[decompressedLength];
        var remaining = new byte[bodySize - __size];
        r.ReadExactly(remaining);

        var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);
        zlib.ReadAtLeast(decompressed, remaining.Length);

        r = new MemoryStream(decompressed);
        var compressedData = new List<byte>();
        while (r.Position < r.Length) {
            compressedData.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            __size += 1;
        }

        return new CMSG_GMTICKET_CREATE {
            Map = map,
            Position = position,
            Message = message,
            NeedsResponse = needsResponse,
            NeedsMoreHelp = needsMoreHelp,
            Times = times,
            CompressedData = compressedData,
        };
    }

    internal int Size() {
        var memory = new MemoryStream();
        Task.WaitAll(WriteBodyAsync(memory));
        return (int)memory.Position;
    }

}

