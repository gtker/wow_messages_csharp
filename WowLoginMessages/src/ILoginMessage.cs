namespace WowLoginMessages;

public interface ILoginMessage
{
    public Task WriteAsync(Stream w, CancellationToken cancellationToken = default);

    public static Task<ILoginMessage> ReadAsync(Stream r, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}