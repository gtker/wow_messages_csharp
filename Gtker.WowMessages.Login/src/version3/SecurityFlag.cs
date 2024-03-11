namespace Gtker.WowMessages.Login.Version3;

[Flags]
public enum SecurityFlag : byte {
    None = 0,
    Pin = 1,
    MatrixCard = 2,
    Authenticator = 4,
}

