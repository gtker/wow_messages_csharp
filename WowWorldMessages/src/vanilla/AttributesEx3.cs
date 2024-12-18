namespace WowWorldMessages.Vanilla;

[Flags]
public enum AttributesEx3 : uint {
    None = 0,
    PvpEnabling = 1,
    NoProcEquipRequirement = 2,
    NoCastingBarText = 4,
    CompletelyBlocked = 8,
    NoResTimer = 16,
    NoDurabilityLoss = 32,
    NoAvoidance = 64,
    DotStackingRule = 128,
    OnlyOnPlayer = 256,
    NotAProc = 512,
    RequiresMainHandWeapon = 1024,
    OnlyBattlegrounds = 2048,
    OnlyOnGhosts = 4096,
    HideChannelBar = 8192,
    HideInRaidFilter = 16384,
    NormalRangedAttack = 32768,
    SuppressCasterProcs = 65536,
    SuppressTargetProcs = 131072,
    AlwaysHit = 262144,
    InstantTargetProcs = 524288,
    AllowAuraWhileDead = 1048576,
    OnlyProcOutdoors = 2097152,
    CastingCancelsAutorepeat = 4194304,
    NoDamageHistory = 8388608,
    RequiresOffhandWeapon = 16777216,
    TreatAsPeriodic = 33554432,
    CanProcFromProcs = 67108864,
    OnlyProcOnCaster = 134217728,
    IgnoreCasterAndTargetRestrictions = 268435456,
    IgnoreCasterModifiers = 536870912,
    DoNotDisplayRange = 1073741824,
    NotOnAoeImmune = 2147483648,
}

