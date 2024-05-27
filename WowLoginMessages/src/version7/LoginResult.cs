namespace WowLoginMessages.Version7;

public enum LoginResult : byte {
    Success = 0,
    FailUnknown0 = 1,
    FailUnknown1 = 2,
    FailBanned = 3,
    FailUnknownAccount = 4,
    FailIncorrectPassword = 5,
    FailAlreadyOnline = 6,
    FailNoTime = 7,
    FailDbBusy = 8,
    FailVersionInvalid = 9,
    LoginDownloadFile = 10,
    FailInvalidServer = 11,
    FailSuspended = 12,
    FailNoAccess = 13,
    SuccessSurvey = 14,
    FailParentalcontrol = 15,
}

