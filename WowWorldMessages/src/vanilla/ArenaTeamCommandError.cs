namespace WowWorldMessages.Vanilla;

public enum ArenaTeamCommandError : uint {
    ArenaTeamInternal = 1,
    AlreadyInArenaTeam = 2,
    AlreadyInArenaTeamS = 3,
    InvitedToArenaTeam = 4,
    AlreadyInvitedToArenaTeamS = 5,
    ArenaTeamNameInvalid = 6,
    ArenaTeamNameExistsS = 7,
    ArenaTeamLeaderLeaveS = 8,
    ArenaTeamPlayerNotInTeam = 9,
    ArenaTeamPlayerNotInTeamSs = 10,
    ArenaTeamPlayerNotFoundS = 11,
    ArenaTeamNotAllied = 12,
    ArenaTeamIgnoringYouS = 19,
    ArenaTeamTargetTooLowS = 21,
    ArenaTeamTooManyMembersS = 22,
}

