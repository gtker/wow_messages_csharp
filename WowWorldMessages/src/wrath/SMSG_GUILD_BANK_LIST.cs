using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using GuildBankTabResultType = OneOf.OneOf<SMSG_GUILD_BANK_LIST.GuildBankTabResultPresent, GuildBankTabResult>;
using GuildBankContentResultType = OneOf.OneOf<SMSG_GUILD_BANK_LIST.GuildBankContentResultPresent, GuildBankContentResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GUILD_BANK_LIST: WrathServerMessage, IWorldMessage {
    public class GuildBankTabResultPresent {
        public required List<GuildBankTab> Tabs { get; set; }
    }
    public class GuildBankContentResultPresent {
        public required List<GuildBankSlot> SlotUpdates { get; set; }
    }
    public required ulong BankBalance { get; set; }
    public required byte TabId { get; set; }
    public required uint AmountOfAllowedItemWithdraws { get; set; }
    public required GuildBankTabResultType TabResult { get; set; }
    internal GuildBankTabResult TabResultValue => TabResult.Match(
        _ => Wrath.GuildBankTabResult.Present,
        v => v
    );
    public required GuildBankContentResultType ContentResult { get; set; }
    internal GuildBankContentResult ContentResultValue => ContentResult.Match(
        _ => Wrath.GuildBankContentResult.Present,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(BankBalance, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(TabId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfAllowedItemWithdraws, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)TabResultValue, cancellationToken).ConfigureAwait(false);

        if (TabResult.Value is SMSG_GUILD_BANK_LIST.GuildBankTabResultPresent guildBankTabResultPresent) {
            await w.WriteByte((byte)guildBankTabResultPresent.Tabs.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in guildBankTabResultPresent.Tabs) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }

        await w.WriteByte((byte)ContentResultValue, cancellationToken).ConfigureAwait(false);

        if (ContentResult.Value is SMSG_GUILD_BANK_LIST.GuildBankContentResultPresent guildBankContentResultPresent) {
            await w.WriteByte((byte)guildBankContentResultPresent.SlotUpdates.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in guildBankContentResultPresent.SlotUpdates) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1000, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1000, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GUILD_BANK_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var bankBalance = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var tabId = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var amountOfAllowedItemWithdraws = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        GuildBankTabResultType tabResult = (Wrath.GuildBankTabResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (tabResult.Value is Wrath.GuildBankTabResult.Present) {
            // ReSharper disable once UnusedVariable.Compiler
            var amountOfBankTabs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var tabs = new List<GuildBankTab>();
            for (var i = 0; i < amountOfBankTabs; ++i) {
                tabs.Add(await Wrath.GuildBankTab.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            }

            tabResult = new GuildBankTabResultPresent {
                Tabs = tabs,
            };
        }

        GuildBankContentResultType contentResult = (Wrath.GuildBankContentResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (contentResult.Value is Wrath.GuildBankContentResult.Present) {
            // ReSharper disable once UnusedVariable.Compiler
            var amountOfSlotUpdates = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var slotUpdates = new List<GuildBankSlot>();
            for (var i = 0; i < amountOfSlotUpdates; ++i) {
                slotUpdates.Add(await Wrath.GuildBankSlot.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            }

            contentResult = new GuildBankContentResultPresent {
                SlotUpdates = slotUpdates,
            };
        }

        return new SMSG_GUILD_BANK_LIST {
            BankBalance = bankBalance,
            TabId = tabId,
            AmountOfAllowedItemWithdraws = amountOfAllowedItemWithdraws,
            TabResult = tabResult,
            ContentResult = contentResult,
        };
    }

    internal int Size() {
        var size = 0;

        // bank_balance: Generator.Generated.DataTypeInteger
        size += 8;

        // tab_id: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_allowed_item_withdraws: Generator.Generated.DataTypeInteger
        size += 4;

        // tab_result: Generator.Generated.DataTypeEnum
        size += 1;

        if (TabResult.Value is SMSG_GUILD_BANK_LIST.GuildBankTabResultPresent guildBankTabResultPresent) {
            // amount_of_bank_tabs: Generator.Generated.DataTypeInteger
            size += 1;

            // tabs: Generator.Generated.DataTypeArray
            size += guildBankTabResultPresent.Tabs.Sum(e => e.Size());

        }

        // content_result: Generator.Generated.DataTypeEnum
        size += 1;

        if (ContentResult.Value is SMSG_GUILD_BANK_LIST.GuildBankContentResultPresent guildBankContentResultPresent) {
            // amount_of_slot_updates: Generator.Generated.DataTypeInteger
            size += 1;

            // slot_updates: Generator.Generated.DataTypeArray
            size += guildBankContentResultPresent.SlotUpdates.Sum(e => e.Size());

        }

        return size;
    }

}

