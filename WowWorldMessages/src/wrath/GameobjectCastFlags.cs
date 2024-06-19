namespace WowWorldMessages.Wrath;

[Flags]
public enum GameobjectCastFlags : uint {
    LockPlayerCastAnim = 1,
    Unknown2 = 2,
    Unknown4 = 4,
    Unknown8 = 8,
    Unknown16 = 16,
    Ammo = 32,
    DestLocation = 64,
    ItemCaster = 256,
    Unk200 = 512,
    ExtraMessage = 1024,
    PowerUpdate = 2048,
    Unk2000 = 8192,
    Unk1000 = 4096,
    Unk8000 = 32768,
    AdjustMissile = 131072,
    Unk40000 = 262144,
    VisualChain = 524288,
    RuneUpdate = 2097152,
    Unk400000 = 4194304,
}

