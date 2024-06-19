namespace WowWorldMessages.Wrath;

public enum TransferAbortReason : byte {
    None = 0,
    Error = 1,
    MaxPlayers = 2,
    NotFound = 3,
    TooManyInstances = 4,
    ZoneInCombat = 6,
    InsufficientExpansionLevel = 7,
    DifficultyNotAvailable = 8,
    UniqueMessage = 9,
    TooManyRealmInstances = 10,
    NeedGroup = 11,
    NotFound1 = 12,
    NotFound2 = 13,
    NotFound3 = 14,
    RealmOnly = 15,
    MapNotAllowed = 16,
}

