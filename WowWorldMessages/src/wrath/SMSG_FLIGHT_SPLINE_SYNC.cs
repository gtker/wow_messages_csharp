using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_FLIGHT_SPLINE_SYNC: WrathServerMessage, IWorldMessage {
    public required float ElapsedValue { get; set; }
    public required ulong Guid { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteFloat(ElapsedValue, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 904, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 904, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_FLIGHT_SPLINE_SYNC> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var elapsedValue = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SMSG_FLIGHT_SPLINE_SYNC {
            ElapsedValue = elapsedValue,
            Guid = guid,
        };
    }

    internal int Size() {
        var size = 0;

        // elapsed_value: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        return size;
    }

}

