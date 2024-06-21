using WowWorldMessages.Wrath;

namespace WowWorldMessages;

public class AddonArray
{
    public List<Addon> Addons { get; set; }


    internal static async Task<AddonArray> ReadAsync(Stream stream, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("ReadAsync for AddonArray is not implemented. Open an issue on github if this is relevant for you.");
    }

    internal async Task WriteAsync(Stream stream, CancellationToken cancellationToken)
    {
        foreach (var addon in Addons)
        {
            await addon.WriteBodyAsync(stream, cancellationToken).ConfigureAwait(false);
        }
    }

    internal int Length()
    {
        return Addons.Sum(_ => 8);
    }
}