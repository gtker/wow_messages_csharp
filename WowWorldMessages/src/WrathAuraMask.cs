namespace WowWorldMessages.Wrath;

public class AuraMask(Aura?[] auras)
{
    public const int AuraArraySize = 64;

    public Aura? Aura(int index) => auras[index];

    public void SetAura(int index, Aura value) => auras[index] = value;

    internal static async Task<AuraMask> ReadAsync(Stream stream, CancellationToken cancellationToken)
    {
        var mask = await stream.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auras = new Aura?[AuraArraySize];

        for (var i = 0; i < AuraArraySize; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                auras[i] = await Wrath.Aura.ReadBodyAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }

        return new AuraMask(auras);
    }

    internal async Task WriteAsync(Stream stream, CancellationToken cancellationToken)
    {
        ulong mask = 0;
        for (var i = 0; i < AuraArraySize; i++)
        {
            if (auras[i] != null)
            {
                mask |= (uint)(1 << i);
            }
        }

        await stream.WriteULong(mask, cancellationToken).ConfigureAwait(false);

        foreach (var aura in auras)
        {
            if (aura != null)
            {
                await aura.WriteBodyAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    internal int Length()
    {
        var size = 8;

        for (var i = 0; i < AuraArraySize; i++)
        {
            if (auras[i] != null)
            {
                size += 5;
            }
        }

        return size;
    }
}