namespace WowWorldMessages.Wrath;

public enum FriendResult : byte {
    DbError = 0,
    ListFull = 1,
    Online = 2,
    Offline = 3,
    NotFound = 4,
    Removed = 5,
    AddedOnline = 6,
    AddedOffline = 7,
    Already = 8,
    Self = 9,
    Enemy = 10,
    IgnoreFull = 11,
    IgnoreSelf = 12,
    IgnoreNotFound = 13,
    IgnoreAlready = 14,
    IgnoreAdded = 15,
    IgnoreRemoved = 16,
}

