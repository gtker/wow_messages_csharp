using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using BankSwapSourceType = OneOf.OneOf<CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceBank, CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceInventory, BankSwapSource>;
using BankSwapStoreModeType = OneOf.OneOf<CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeAutomatic, CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeManual, BankSwapStoreMode>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_BANK_SWAP_ITEMS: TbcClientMessage, IWorldMessage {
    public class BankSwapSourceBank {
        public required byte Amount { get; set; }
        public required byte BankDestinationSlot { get; set; }
        public required byte BankDestinationTab { get; set; }
        public required byte BankSourceSlot { get; set; }
        public required byte BankSourceTab { get; set; }
        public required uint Item1 { get; set; }
        public required uint Unknown1 { get; set; }
        public required byte Unknown2 { get; set; }
    }
    public class BankSwapSourceInventory {
        public required byte BankSlot { get; set; }
        public required byte BankTab { get; set; }
        public required uint Item2 { get; set; }
        public required BankSwapStoreModeType Mode { get; set; }
        internal BankSwapStoreMode ModeValue => Mode.Match(
            _ => Tbc.BankSwapStoreMode.Automatic,
            _ => Tbc.BankSwapStoreMode.Manual,
            v => v
        );
    }
    public class BankSwapStoreModeAutomatic {
        public required uint AutoCount { get; set; }
        public required byte Unknown3 { get; set; }
        public required byte Unknown4 { get; set; }
    }
    public class BankSwapStoreModeManual {
        public required bool BankToCharacterTransfer { get; set; }
        public required byte PlayerBag { get; set; }
        public required byte PlayerBagSlot { get; set; }
        public required byte SplitAmount { get; set; }
    }
    public required ulong Bank { get; set; }
    public required BankSwapSourceType Source { get; set; }
    internal BankSwapSource SourceValue => Source.Match(
        _ => Tbc.BankSwapSource.Bank,
        _ => Tbc.BankSwapSource.Inventory,
        v => v
    );
    /// <summary>
    /// cmangos-tbc/mangosone has extra
    /// </summary>
    public required List<byte> Unknown5 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Bank, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)SourceValue, cancellationToken).ConfigureAwait(false);

        if (Source.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceBank bankSwapSourceBank) {
            await w.WriteByte(bankSwapSourceBank.BankDestinationTab, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceBank.BankDestinationSlot, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(bankSwapSourceBank.Unknown1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceBank.BankSourceTab, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceBank.BankSourceSlot, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(bankSwapSourceBank.Item1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceBank.Unknown2, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceBank.Amount, cancellationToken).ConfigureAwait(false);

        }
        else if (Source.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceInventory bankSwapSourceInventory) {
            await w.WriteByte(bankSwapSourceInventory.BankTab, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(bankSwapSourceInventory.BankSlot, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(bankSwapSourceInventory.Item2, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)bankSwapSourceInventory.ModeValue, cancellationToken).ConfigureAwait(false);

            if (bankSwapSourceInventory.Mode.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeAutomatic bankSwapStoreModeAutomatic) {
                await w.WriteUInt(bankSwapStoreModeAutomatic.AutoCount, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(bankSwapStoreModeAutomatic.Unknown3, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(bankSwapStoreModeAutomatic.Unknown4, cancellationToken).ConfigureAwait(false);

            }
            else if (bankSwapSourceInventory.Mode.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeManual bankSwapStoreModeManual) {
                await w.WriteByte(bankSwapStoreModeManual.PlayerBag, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(bankSwapStoreModeManual.PlayerBagSlot, cancellationToken).ConfigureAwait(false);

                await w.WriteBool8(bankSwapStoreModeManual.BankToCharacterTransfer, cancellationToken).ConfigureAwait(false);

                await w.WriteByte(bankSwapStoreModeManual.SplitAmount, cancellationToken).ConfigureAwait(false);

            }


        }


        foreach (var v in Unknown5) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1000, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1000, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_BANK_SWAP_ITEMS> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var bank = await r.ReadULong(cancellationToken).ConfigureAwait(false);
        size += 8;

        BankSwapSourceType source = (Tbc.BankSwapSource)await r.ReadByte(cancellationToken).ConfigureAwait(false);
        size += 1;

        if (source.Value is Tbc.BankSwapSource.Bank) {
            var bankDestinationTab = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var bankDestinationSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            var bankSourceTab = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var bankSourceSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var item1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            var unknown2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var amount = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            source = new BankSwapSourceBank {
                Amount = amount,
                BankDestinationSlot = bankDestinationSlot,
                BankDestinationTab = bankDestinationTab,
                BankSourceSlot = bankSourceSlot,
                BankSourceTab = bankSourceTab,
                Item1 = item1,
                Unknown1 = unknown1,
                Unknown2 = unknown2,
            };
        }
        else if (source.Value is Tbc.BankSwapSource.Inventory) {
            var bankTab = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var bankSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var item2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            BankSwapStoreModeType mode = (Tbc.BankSwapStoreMode)await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            if (mode.Value is Tbc.BankSwapStoreMode.Automatic) {
                var autoCount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
                size += 4;

                var unknown3 = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                size += 1;

                var unknown4 = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                size += 1;

                mode = new BankSwapStoreModeAutomatic {
                    AutoCount = autoCount,
                    Unknown3 = unknown3,
                    Unknown4 = unknown4,
                };
            }
            else if (mode.Value is Tbc.BankSwapStoreMode.Manual) {
                var playerBag = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                size += 1;

                var playerBagSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                size += 1;

                var bankToCharacterTransfer = await r.ReadBool8(cancellationToken).ConfigureAwait(false);
                size += 1;

                var splitAmount = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                size += 1;

                mode = new BankSwapStoreModeManual {
                    BankToCharacterTransfer = bankToCharacterTransfer,
                    PlayerBag = playerBag,
                    PlayerBagSlot = playerBagSlot,
                    SplitAmount = splitAmount,
                };
            }


            source = new BankSwapSourceInventory {
                BankSlot = bankSlot,
                BankTab = bankTab,
                Item2 = item2,
                Mode = mode,
            };
        }


        var unknown5 = new List<byte>();
        while (size <= bodySize) {
            unknown5.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            size += 1;
        }

        return new CMSG_GUILD_BANK_SWAP_ITEMS {
            Bank = bank,
            Source = source,
            Unknown5 = unknown5,
        };
    }

    internal int Size() {
        var size = 0;

        // bank: Generator.Generated.DataTypeGuid
        size += 8;

        // source: Generator.Generated.DataTypeEnum
        size += 1;

        if (Source.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceBank bankSwapSourceBank) {
            // bank_destination_tab: Generator.Generated.DataTypeInteger
            size += 1;

            // bank_destination_slot: Generator.Generated.DataTypeInteger
            size += 1;

            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

            // bank_source_tab: Generator.Generated.DataTypeInteger
            size += 1;

            // bank_source_slot: Generator.Generated.DataTypeInteger
            size += 1;

            // item1: Generator.Generated.DataTypeItem
            size += 4;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 1;

            // amount: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Source.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapSourceInventory bankSwapSourceInventory) {
            // bank_tab: Generator.Generated.DataTypeInteger
            size += 1;

            // bank_slot: Generator.Generated.DataTypeInteger
            size += 1;

            // item2: Generator.Generated.DataTypeItem
            size += 4;

            // mode: Generator.Generated.DataTypeEnum
            size += 1;

            if (bankSwapSourceInventory.Mode.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeAutomatic bankSwapStoreModeAutomatic) {
                // auto_count: Generator.Generated.DataTypeInteger
                size += 4;

                // unknown3: Generator.Generated.DataTypeInteger
                size += 1;

                // unknown4: Generator.Generated.DataTypeInteger
                size += 1;

            }
            else if (bankSwapSourceInventory.Mode.Value is CMSG_GUILD_BANK_SWAP_ITEMS.BankSwapStoreModeManual bankSwapStoreModeManual) {
                // player_bag: Generator.Generated.DataTypeInteger
                size += 1;

                // player_bag_slot: Generator.Generated.DataTypeInteger
                size += 1;

                // bank_to_character_transfer: Generator.Generated.DataTypeBool
                size += 1;

                // split_amount: Generator.Generated.DataTypeInteger
                size += 1;

            }


        }


        // unknown5: Generator.Generated.DataTypeArray
        size += Unknown5.Sum(e => 1);

        return size;
    }

}

