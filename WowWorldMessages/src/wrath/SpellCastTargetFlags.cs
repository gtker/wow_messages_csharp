namespace WowWorldMessages.Wrath;

[Flags]
public enum SpellCastTargetFlags : uint {
    Self = 0,
    Unused1 = 1,
    Unit = 2,
    UnitRaid = 4,
    UnitParty = 8,
    Item = 16,
    SourceLocation = 32,
    DestLocation = 64,
    UnitEnemy = 128,
    UnitAlly = 256,
    CorpseEnemy = 512,
    UnitDead = 1024,
    Gameobject = 2048,
    TradeItem = 4096,
    String = 8192,
    Locked = 16384,
    CorpseAlly = 32768,
    UnitMinipet = 65536,
    GlyphSlot = 131072,
    DestTarget = 262144,
    Unused20 = 524288,
    UnitPassenger = 1048576,
}

