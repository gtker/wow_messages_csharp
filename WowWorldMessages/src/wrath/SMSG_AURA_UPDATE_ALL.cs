using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AURA_UPDATE_ALL: WrathServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required List<AuraUpdate> AuraUpdates { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        foreach (var v in AuraUpdates) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1173, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1173, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AURA_UPDATE_ALL> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);
        __size += unit.PackedGuidLength();

        var auraUpdates = new List<AuraUpdate>();
        while (__size < bodySize) {
            auraUpdates.Add(await Wrath.AuraUpdate.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            __size += auraUpdates[^1].Size();
        }

        return new SMSG_AURA_UPDATE_ALL {
            Unit = unit,
            AuraUpdates = auraUpdates,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // aura_updates: Generator.Generated.DataTypeArray
        size += AuraUpdates.Sum(e => e.Size());

        return size;
    }

}

