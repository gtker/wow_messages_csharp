namespace Gtker.WowMessages.Login.Version2;

[Flags]
public enum RealmFlag : byte {
    None = 0,
    Invalid = 1,
    Offline = 2,
    SpecifyBuild = 4,
    ForceBlueRecommended = 32,
    ForceGreenRecommended = 64,
    ForceRedFull = 128,
}

