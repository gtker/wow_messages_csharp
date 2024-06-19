namespace WowWorldMessages.Wrath;

public enum PartyResult : byte {
    Success = 0,
    BadPlayerName = 1,
    TargetNotInGroup = 2,
    TargetNotInInstance = 3,
    GroupFull = 4,
    AlreadyInGroup = 5,
    NotInGroup = 6,
    NotLeader = 7,
    PlayerWrongFaction = 8,
    IgnoringYou = 9,
    LfgPending = 12,
    InviteRestricted = 13,
}

