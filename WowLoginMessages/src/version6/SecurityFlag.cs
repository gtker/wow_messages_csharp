namespace WowLoginMessages.Version6;

[Flags]
public enum SecurityFlag : byte {
    None = 0,
    Pin = 1,
    MatrixCard = 2,
}

