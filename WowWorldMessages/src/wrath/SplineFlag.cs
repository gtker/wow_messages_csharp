namespace WowWorldMessages.Wrath;

[Flags]
public enum SplineFlag : uint {
    None = 0,
    Done = 256,
    Falling = 512,
    NoSpline = 1024,
    Parabolic = 2048,
    WalkMode = 4096,
    Flying = 8192,
    OrientationFixed = 16384,
    FinalPoint = 32768,
    FinalTarget = 65536,
    FinalAngle = 131072,
    Catmullrom = 262144,
    Cyclic = 524288,
    EnterCycle = 1048576,
    Animation = 2097152,
    Frozen = 4194304,
    TransportEnter = 8388608,
    TransportExit = 16777216,
    Unknown7 = 33554432,
    Unknown8 = 67108864,
    OrientationInversed = 134217728,
    Unknown10 = 268435456,
    Unknown11 = 536870912,
    Unknown12 = 1073741824,
    Unknown13 = 2147483648,
}

