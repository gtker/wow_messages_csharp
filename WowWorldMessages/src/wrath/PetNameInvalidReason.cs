namespace WowWorldMessages.Wrath;

public enum PetNameInvalidReason : byte {
    Invalid = 1,
    NoName = 2,
    TooShort = 3,
    TooLong = 4,
    MixedLanguages = 6,
    Profane = 7,
    Reserved = 8,
    ThreeConsecutive = 11,
    InvalidSpace = 12,
    ConsecutiveSpaces = 13,
    RussianConsecutiveSilentCharacters = 14,
    RussianSilentCharacterAtBeginningOrEnd = 15,
    DeclensionDoesntMatchBaseName = 16,
}

