using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LOOT_METHOD: TbcClientMessage, IWorldMessage {
    public required Tbc.GroupLootSetting LootSetting { get; set; }
    public required ulong LootMaster { get; set; }
    public required Tbc.ItemQuality LootThreshold { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)LootSetting, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(LootMaster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)LootThreshold, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 20, 122, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 20, 122, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LOOT_METHOD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var lootSetting = (Tbc.GroupLootSetting)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var lootMaster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var lootThreshold = (Tbc.ItemQuality)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_LOOT_METHOD {
            LootSetting = lootSetting,
            LootMaster = lootMaster,
            LootThreshold = lootThreshold,
        };
    }

}

