namespace WowWorldMessages.Wrath;

public class AuraMask
{
    private const int AuraArraySize = 64;
    private readonly Aura?[] _auras;

    public AuraMask(Aura?[] auras)
    {
        _auras = auras;
    }

    public Aura? Aura(int index) => _auras[index];

    public void SetAura(int index, Aura value) => _auras[index] = value;

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
        uint mask = 0;
        for (var i = 0; i < AuraArraySize; i++)
        {
            if (_auras[i] != null)
            {
                mask |= (uint)(1 << i);
            }
        }

        await stream.WriteUInt(mask, cancellationToken).ConfigureAwait(false);

        foreach (var aura in _auras)
        {
            if (aura != null)
            {
                await aura.WriteBodyAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    internal int Length()
    {
        var size = 4;

        for (var i = 0; i < AuraArraySize; i++)
        {
            if (_auras[i] != null)
            {
                size += 2;
            }
        }

        return size;
    }
}