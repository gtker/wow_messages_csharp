namespace Gtker.WowMessages.Login.All;

[Flags]
public enum SecurityFlag : byte {
    None = 0,
    Pin = 1,
    MatrixCard = 2,
    Authenticator = 4,
}

