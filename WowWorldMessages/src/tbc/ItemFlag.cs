namespace WowWorldMessages.Tbc;

[Flags]
public enum ItemFlag : uint {
    NoPickup = 1,
    Conjured = 2,
    Lootable = 4,
    Deprecated = 16,
    Indestructible = 32,
    PlayerCast = 64,
    NoEquipCooldown = 128,
    IntBonusInstead = 256,
    Wrapper = 512,
    IgnoreBagSpace = 1024,
    PartyLoot = 2048,
    Charter = 8192,
    Letter = 16384,
    NoDisenchant = 32768,
    RealDuration = 65536,
    NoCreator = 131072,
    Prospectable = 262144,
    UniqueEquipped = 524288,
    IgnoreForAuras = 1048576,
    IgnoreDefaultArenaRestrictions = 2097152,
    NoDurabilityLoss = 4194304,
    SpecialUse = 8388608,
}

