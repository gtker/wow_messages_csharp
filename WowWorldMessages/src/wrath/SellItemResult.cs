namespace WowWorldMessages.Wrath;

public enum SellItemResult : byte {
    ErrCantFindItem = 1,
    ErrCantSellItem = 2,
    ErrCantFindVendor = 3,
    ErrYouDontOwnThatItem = 4,
    ErrUnk = 5,
    ErrOnlyEmptyBag = 6,
    ErrCantSellToThisMerchant = 7,
    ErrMustRepairItemDurabilityToUse = 8,
    InternalBagError = 9,
}

