using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LOOT_ROLL: TbcServerMessage, IWorldMessage {
    public required ulong Creature { get; set; }
    public required uint LootSlot { get; set; }
    public required ulong Player { get; set; }
    public required uint Item { get; set; }
    /// <summary>
    /// vmangos/mangoszero: not used ?
    /// </summary>
    public required uint ItemRandomSuffix { get; set; }
    public required uint ItemRandomPropertyId { get; set; }
    /// <summary>
    /// vmangos/cmangos/mangoszero: 0: Need for: `item_name` > 127: you passed on: `item_name`      Roll number
    /// </summary>
    public required byte RollNumber { get; set; }
    public required Tbc.RollVote Vote { get; set; }
    /// <summary>
    /// mangosone/arcemu sets to 0.
    /// mangosone: auto pass on loot
    /// arcemu: possibly related to disenchanting of loot
    /// azerothcore: 1: 'You automatically passed on: %s because you cannot loot that item.' - Possibly used in need before greed
    /// </summary>
    public required byte AutoPass { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Creature, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LootSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemRandomSuffix, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemRandomPropertyId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(RollNumber, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Vote, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(AutoPass, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 37, 674, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 37, 674, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LOOT_ROLL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var creature = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var lootSlot = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRandomSuffix = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemRandomPropertyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var rollNumber = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var vote = (Tbc.RollVote)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var autoPass = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_LOOT_ROLL {
            Creature = creature,
            LootSlot = lootSlot,
            Player = player,
            Item = item,
            ItemRandomSuffix = itemRandomSuffix,
            ItemRandomPropertyId = itemRandomPropertyId,
            RollNumber = rollNumber,
            Vote = vote,
            AutoPass = autoPass,
        };
    }

}

