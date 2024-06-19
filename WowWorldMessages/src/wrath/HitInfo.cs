namespace WowWorldMessages.Wrath;

[Flags]
public enum HitInfo : uint {
    Normalswing = 0,
    Unk1 = 1,
    AffectsVictim = 2,
    Offhand = 4,
    Unk2 = 8,
    Miss = 16,
    FullAbsorb = 32,
    PartialAbsorb = 64,
    AllAbsorb = 96,
    FullResist = 128,
    PartialResist = 256,
    AllResist = 384,
    Criticalhit = 512,
    Unk10 = 1024,
    Unk11 = 2048,
    Unk12 = 4096,
    Block = 8192,
    Unk14 = 16384,
    Unk15 = 32768,
    Glancing = 65536,
    Crushing = 131072,
    NoAnimation = 262144,
    Unk19 = 524288,
    Unk20 = 1048576,
    Swingnohitsound = 2097152,
    Unk22 = 4194304,
    RageGain = 8388608,
    FakeDamage = 16777216,
}

