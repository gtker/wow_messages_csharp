namespace WowWorldMessages.Wrath;

public enum LfgUpdateType : byte {
    Default = 0,
    LeaderLeave = 1,
    RolecheckAborted = 4,
    Join = 5,
    RolecheckFailed = 6,
    Leave = 7,
    ProposalFailed = 8,
    ProposalDeclined = 9,
    GroupFound = 10,
    AddedToQueue = 12,
    ProposalBegin = 13,
    Status = 14,
    GroupMemberOffline = 15,
    GroupDisband = 16,
}

