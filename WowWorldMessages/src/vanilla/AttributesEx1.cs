namespace WowWorldMessages.Vanilla;

[Flags]
public enum AttributesEx1 : uint {
    None = 0,
    DismissPetFirst = 1,
    UseAllMana = 2,
    IsChanneled = 4,
    NoRedirection = 8,
    NoSkillIncrease = 16,
    AllowWhileStealthed = 32,
    IsSelfChanneled = 64,
    NoReflection = 128,
    OnlyPeacefulTargets = 256,
    InitiatesCombatEnablesAutoAttack = 512,
    NoThreat = 1024,
    AuraUnique = 2048,
    FailureBreaksStealth = 4096,
    ToggleFarsight = 8192,
    TrackTargetInChannel = 16384,
    ImmunityPurgesEffect = 32768,
    ImmunityToHostileAndFriendlyEffects = 65536,
    NoAutocastAi = 131072,
    PreventsAnim = 262144,
    ExcludeCaster = 524288,
    FinishingMoveDamage = 1048576,
    ThreatOnlyOnMiss = 2097152,
    FinishingMoveDuration = 4194304,
    Unk23 = 8388608,
    SpecialSkillup = 16777216,
    AuraStaysAfterCombat = 33554432,
    RequireAllTargets = 67108864,
    DiscountPowerOnMiss = 134217728,
    NoAuraIcon = 268435456,
    NameInChannelBar = 536870912,
    ComboOnBlock = 1073741824,
    CastWhenLearned = 2147483648,
}

