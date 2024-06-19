namespace WowWorldMessages.Tbc;

public enum QuestFailedReason : uint {
    DontHaveReq = 0,
    QuestFailedLowLevel = 1,
    QuestFailedWrongRace = 6,
    QuestAlreadyDone = 7,
    QuestOnlyOneTimed = 12,
    QuestAlreadyOn = 13,
    QuestFailedExpansion = 16,
    QuestAlreadyOn2 = 18,
    QuestFailedMissingItems = 21,
    QuestFailedNotEnoughMoney = 23,
    DailyQuestsRemaining = 26,
    QuestFailedCais = 27,
}

