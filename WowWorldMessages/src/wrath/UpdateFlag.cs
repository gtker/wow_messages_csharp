namespace WowWorldMessages.Wrath;

[Flags]
public enum UpdateFlag : ushort {
    None = 0,
    Self = 1,
    Transport = 2,
    HasAttackingTarget = 4,
    LowGuid = 8,
    HighGuid = 16,
    Living = 32,
    HasPosition = 64,
    Vehicle = 128,
    Position = 256,
    Rotation = 512,
}

