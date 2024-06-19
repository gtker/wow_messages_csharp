using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_UPDATE_ACCOUNT_DATA: WrathServerMessage, IWorldMessage {
    public required uint DataType { get; set; }
    public required uint DecompressedSize { get; set; }
    public required List<byte> CompressedData { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DataType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DecompressedSize, cancellationToken).ConfigureAwait(false);

        foreach (var v in CompressedData) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 524, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 524, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_UPDATE_ACCOUNT_DATA> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var dataType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var decompressedSize = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var compressedData = new List<byte>();
        while (__size <= bodySize) {
            compressedData.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            __size += 1;
        }

        return new SMSG_UPDATE_ACCOUNT_DATA {
            DataType = dataType,
            DecompressedSize = decompressedSize,
            CompressedData = compressedData,
        };
    }

    internal int Size() {
        var size = 0;

        // data_type: Generator.Generated.DataTypeInteger
        size += 4;

        // decompressed_size: Generator.Generated.DataTypeInteger
        size += 4;

        // compressed_data: Generator.Generated.DataTypeArray
        size += CompressedData.Sum(e => 1);

        return size;
    }

}

