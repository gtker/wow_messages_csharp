namespace WowWorldMessages.Wrath;

[Flags]
public enum AllowedRace : uint {
    All = 0,
    Human = 1,
    Orc = 2,
    Dwarf = 4,
    NightElf = 8,
    Undead = 16,
    Tauren = 32,
    Gnome = 64,
    Troll = 128,
    Goblin = 256,
    Bloodelf = 512,
    Draenei = 1024,
    FelOrc = 2048,
    Naga = 4096,
    Broken = 8192,
    Skeleton = 16384,
    Vrykul = 32768,
    Tuskarr = 65536,
    ForestTroll = 131072,
    Taunka = 262144,
    NorthrendSkeleton = 524288,
    IceTroll = 1048576,
}

