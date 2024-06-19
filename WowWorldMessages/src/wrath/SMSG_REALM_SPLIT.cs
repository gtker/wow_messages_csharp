using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_REALM_SPLIT: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// ArcEmu/TrinityCore/mangosthree send realm_id from [CMSG_REALM_SPLIT] back.
    /// </summary>
    public required uint RealmId { get; set; }
    public required Wrath.RealmSplitState State { get; set; }
    /// <summary>
    /// Seems to be slash separated string, like '01/01/01'.
    /// </summary>
    public required string SplitDate { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(RealmId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)State, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(SplitDate, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 907, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 907, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_REALM_SPLIT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var realmId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var state = (Wrath.RealmSplitState)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var splitDate = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_REALM_SPLIT {
            RealmId = realmId,
            State = state,
            SplitDate = splitDate,
        };
    }

    internal int Size() {
        var size = 0;

        // realm_id: Generator.Generated.DataTypeInteger
        size += 4;

        // state: Generator.Generated.DataTypeEnum
        size += 4;

        // split_date: Generator.Generated.DataTypeCstring
        size += SplitDate.Length + 1;

        return size;
    }

}

