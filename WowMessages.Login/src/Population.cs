// Keep manually implemented types outside of auto folders
// ReSharper disable once CheckNamespace

namespace WowMessages.Login.All;

public struct Population(float v)
{
    public float Value { get; set; } = v;

    public static Population GreenRecommended() => new(200.0f);

    public static Population RedFull() => new(400.0f);

    public static Population BlueRecommended() => new(600.0f);
}