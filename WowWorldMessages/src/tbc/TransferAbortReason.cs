namespace WowWorldMessages.Tbc;

public enum TransferAbortReason : byte {
    None = 0,
    IsFull = 1,
    NotFound = 2,
    TooManyInstances = 3,
    ZoneIsInCombat = 5,
    InsufficientExpansionLevel = 6,
    DifficultyNotAvailable = 7,
    MissingDifficulty = 8,
    ZoneInCombat = 9,
    InstanceIsFull = 10,
    NotAllowed = 11,
    HasBind = 12,
}

