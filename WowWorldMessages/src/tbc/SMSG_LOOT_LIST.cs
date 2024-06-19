using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LOOT_LIST: TbcServerMessage, IWorldMessage {
    public required ulong Creature { get; set; }
    public required ulong MasterLooter { get; set; }
    public required ulong GroupLooter { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Creature, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(MasterLooter, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(GroupLooter, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1016, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1016, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LOOT_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var creature = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var masterLooter = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var groupLooter = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        return new SMSG_LOOT_LIST {
            Creature = creature,
            MasterLooter = masterLooter,
            GroupLooter = groupLooter,
        };
    }

    internal int Size() {
        var size = 0;

        // creature: Generator.Generated.DataTypeGuid
        size += 8;

        // master_looter: Generator.Generated.DataTypePackedGuid
        size += MasterLooter.PackedGuidLength();

        // group_looter: Generator.Generated.DataTypePackedGuid
        size += GroupLooter.PackedGuidLength();

        return size;
    }

}

