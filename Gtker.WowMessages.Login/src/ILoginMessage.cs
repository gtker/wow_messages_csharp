namespace Gtker.WowMessages.Login;

public interface ILoginMessage
{
    public Task Write(Stream w);
}