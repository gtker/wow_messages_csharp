namespace WowWorldMessages.Vanilla;

public enum ActivateTaxiReply : uint {
    Ok = 0,
    UnspecifiedServerError = 1,
    NoSuchPath = 2,
    NotEnoughMoney = 3,
    TooFarAway = 4,
    NoVendorNearby = 5,
    NotVisited = 6,
    PlayerBusy = 7,
    PlayerAlreadyMounted = 8,
    PlayerShapeShifted = 9,
    PlayerMoving = 10,
    SameNode = 11,
    NotStanding = 12,
}

