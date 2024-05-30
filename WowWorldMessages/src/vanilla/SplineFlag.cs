namespace WowWorldMessages.Vanilla;

[Flags]
public enum SplineFlag : uint {
    None = 0,
    Done = 1,
    Falling = 2,
    Unknown3 = 4,
    Unknown4 = 8,
    Unknown5 = 16,
    Unknown6 = 32,
    Unknown7 = 64,
    Unknown8 = 128,
    RunMode = 256,
    Flying = 512,
    NoSpline = 1024,
    Unknown12 = 2048,
    Unknown13 = 4096,
    Unknown14 = 8192,
    Unknown15 = 16384,
    Unknown16 = 32768,
    FinalPoint = 65536,
    FinalTarget = 131072,
    FinalAngle = 262144,
    Unknown19 = 524288,
    Cyclic = 1048576,
    EnterCycle = 2097152,
    Frozen = 4194304,
    Unknown23 = 8388608,
    Unknown24 = 16777216,
    Unknown25 = 33554432,
    Unknown26 = 67108864,
    Unknown27 = 134217728,
    Unknown28 = 268435456,
    Unknown29 = 536870912,
    Unknown30 = 1073741824,
    Unknown31 = 2147483648,
}

