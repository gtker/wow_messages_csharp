namespace WowWorldMessages.Vanilla;

public enum ReferAFriendError : byte {
    None = 0,
    NotReferredBy = 1,
    TargetTooHigh = 2,
    InsufficientGrantableLevels = 3,
    TooFar = 4,
    DifferentFaction = 5,
    NotNow = 6,
    GrantLevelMax = 7,
    NoTarget = 8,
    NotInGroup = 9,
    SummonLevelMax = 10,
    SummonCooldown = 11,
    InsufficientExpansionLevel = 12,
    SummonOffline = 13,
}

