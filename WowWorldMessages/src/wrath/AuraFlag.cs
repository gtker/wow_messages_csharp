namespace WowWorldMessages.Wrath;

[Flags]
public enum AuraFlag : byte {
    Empty = 0,
    Effect1 = 1,
    Effect2 = 2,
    Effect3 = 4,
    NotCaster = 8,
    Set = 9,
    Cancellable = 16,
    Duration = 32,
    Hide = 64,
    Negative = 128,
}

