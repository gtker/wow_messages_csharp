namespace WowWorldMessages.Wrath;

public enum PetitionResult : uint {
    Ok = 0,
    AlreadySigned = 1,
    AlreadyInGuild = 2,
    CantSignOwn = 3,
    NotServer = 4,
}

