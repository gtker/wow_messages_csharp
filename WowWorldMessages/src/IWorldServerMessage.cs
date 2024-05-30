using WowSrp.Header;

namespace WowWorldMessages;

public interface IWorldServerMessage : IWorldMessage
{
    public Task WriteEncryptedServerAsync(Stream w, IServerEncrypter enc,
        CancellationToken cancellationToken = default);
}