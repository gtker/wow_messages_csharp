namespace WowWorldMessages;

public interface IWorldMessage
{
    public Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default);

    public static Task<IWorldMessage> ReadBodyAsync(Stream w, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}