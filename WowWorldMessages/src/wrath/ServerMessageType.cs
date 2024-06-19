namespace WowWorldMessages.Wrath;

public enum ServerMessageType : uint {
    ShutdownTime = 1,
    RestartTime = 2,
    Custom = 3,
    ShutdownCancelled = 4,
    RestartCancelled = 5,
    BattlegroundShutdown = 6,
    BattlegroundRestart = 7,
    InstanceShutdown = 8,
    InstanceRestart = 9,
}

