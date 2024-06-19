namespace WowWorldMessages.Wrath;

[Flags]
public enum VictimState : byte {
    Intact = 0,
    Hit = 1,
    Dodge = 2,
    Parry = 3,
    Interrupt = 4,
    Blocks = 5,
    Evades = 6,
    IsImmune = 7,
    Deflects = 8,
}

