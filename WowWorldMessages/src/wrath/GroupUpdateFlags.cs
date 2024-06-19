namespace WowWorldMessages.Wrath;

[Flags]
public enum GroupUpdateFlags : uint {
    None = 0,
    Status = 1,
    CurHp = 2,
    MaxHp = 4,
    PowerType = 8,
    CurPower = 16,
    MaxPower = 32,
    Level = 64,
    Zone = 128,
    Position = 256,
    Auras = 512,
    PetGuid = 1024,
    PetName = 2048,
    PetModelId = 4096,
    PetCurHp = 8192,
    PetMaxHp = 16384,
    PetPowerType = 32768,
    PetCurPower = 65536,
    PetMaxPower = 131072,
    PetAuras = 262144,
    VehicleSeat = 524288,
}

