namespace Gtker.WowMessages.Login;

public interface ILoginMessage
{
    public Task WriteAsync(Stream w);

    public static Task<ILoginMessage> ReadAsync(Stream r) => throw new NotImplementedException();
}