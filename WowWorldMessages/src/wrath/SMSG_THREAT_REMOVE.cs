using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_THREAT_REMOVE: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required ulong Victim { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Victim, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1156, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1156, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_THREAT_REMOVE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var victim = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SMSG_THREAT_REMOVE {
            Unit = unit,
            Victim = victim,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // victim: Generator.Generated.DataTypePackedGuid
        size += Victim.PackedGuidLength();

        return size;
    }

}

