namespace WowWorldMessages.Wrath;

[Flags]
public enum LfgUpdateFlag : uint {
    None = 0,
    CharacterInfo = 1,
    Comment = 2,
    GroupLeader = 4,
    GroupGuid = 8,
    Roles = 16,
    Area = 32,
    Status = 64,
    Bound = 128,
}

