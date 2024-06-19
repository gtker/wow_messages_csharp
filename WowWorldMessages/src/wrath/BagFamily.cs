namespace WowWorldMessages.Wrath;

[Flags]
public enum BagFamily : uint {
    None = 0,
    Arrows = 1,
    Bullets = 2,
    SoulShards = 4,
    LeatherworkingSupplies = 8,
    InscriptionSupplies = 16,
    Herbs = 32,
    EnchantingSupplies = 64,
    EngineeringSupplies = 128,
    Keys = 256,
    Gems = 512,
    MiningSupplies = 1024,
    SoulboundEquipment = 2048,
    VanityPets = 4096,
    CurrencyTokens = 8192,
    QuestItems = 16384,
}

