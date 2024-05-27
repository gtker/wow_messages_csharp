namespace WowLoginMessages.Version5;

[Flags]
public enum SecurityFlag : byte {
    None = 0,
    Pin = 1,
    MatrixCard = 2,
}

