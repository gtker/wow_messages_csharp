namespace WowLoginMessages.Version3;

[Flags]
public enum RealmFlag : byte {
    None = 0,
    Invalid = 1,
    Offline = 2,
    ForceBlueRecommended = 32,
    ForceGreenRecommended = 64,
    ForceRedFull = 128,
}

