namespace WowWorldMessages.Tbc;

[Flags]
public enum RelationType : uint {
    None = 0,
    Friend = 1,
    Ignored = 2,
    Muted = 4,
    Recruitafriend = 8,
}

