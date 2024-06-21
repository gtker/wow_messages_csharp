namespace WowWorldMessages.Wrath;

public class InspectTalentGearMask(InspectTalentGear?[] auras)
{
    public const int InnerArraySize = 32;

    public InspectTalentGear? InspectTalentGear(int index) => auras[index];

    public void SetInspectTalentGear(int index, InspectTalentGear value) => auras[index] = value;

    internal static async Task<InspectTalentGearMask> ReadAsync(Stream stream, CancellationToken cancellationToken)
    {
        var mask = await stream.ReadUInt(cancellationToken).ConfigureAwait(false);

        var auras = new InspectTalentGear?[InnerArraySize];

        for (var i = 0; i < InnerArraySize; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                auras[i] = await Wrath.InspectTalentGear.ReadBodyAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }

        return new InspectTalentGearMask(auras);
    }

    internal async Task WriteAsync(Stream stream, CancellationToken cancellationToken)
    {
        ulong mask = 0;
        for (var i = 0; i < InnerArraySize; i++)
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
        var size = 4;

        for (var i = 0; i < InnerArraySize; i++)
        {
            if (auras[i] is { } aura)
            {
                size += aura.Size();
            }
        }

        return size;
    }
}