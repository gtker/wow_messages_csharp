namespace WowWorldMessages.Wrath;

public enum PetTameFailureReason : byte {
    InvalidCreature = 1,
    TooMany = 2,
    CreatureAlreadyOwned = 3,
    NotTameable = 4,
    AnotherSummonActive = 5,
    UnitsCantTame = 6,
    NoPetAvailable = 7,
    InternaLerror = 8,
    TooHighLevel = 9,
    Dead = 10,
    NotDead = 11,
    CantControlExotic = 12,
    UnknownError = 13,
}

