using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ACCOUNT_DATA_TIMES: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// Seconds since Unix Epoch
    /// </summary>
    public required uint UnixTime { get; set; }
    /// <summary>
    /// Both mangostwo and arcemu hardcode this to 1
    /// </summary>
    public required byte Unknown1 { get; set; }
    public required CacheMask Mask { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(UnixTime, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown1, cancellationToken).ConfigureAwait(false);

        await Mask.WriteAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 521, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 521, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ACCOUNT_DATA_TIMES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unixTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var mask = await CacheMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_ACCOUNT_DATA_TIMES {
            UnixTime = unixTime,
            Unknown1 = unknown1,
            Mask = mask,
        };
    }

    internal int Size() {
        var size = 0;

        // unix_time: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 1;

        // mask: Generator.Generated.DataTypeCacheMask
        size += Mask.Length();

        return size;
    }

}

