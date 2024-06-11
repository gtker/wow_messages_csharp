namespace WowWorldMessages.Vanilla;

public partial class UpdateMask
{
    private IDictionary<ushort, uint> _values = new Dictionary<ushort, uint>();

    internal static async Task<UpdateMask> ReadAsync(Stream stream, CancellationToken cancellationToken)
    {
        var amountOfBlocks = await stream.ReadByte(cancellationToken).ConfigureAwait(false);

        var blocks = new uint[amountOfBlocks];
        for (var i = 0; i < amountOfBlocks; i++)
        {
            blocks[i] = await stream.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var values = new Dictionary<ushort, uint>();
        foreach (var (index, block) in blocks.Select((v, i) => (i, v)))
        {
            for (var bit = 0; bit < 32; bit++)
            {
                if ((block & (1 << bit)) != 0)
                {
                    var value = await stream.ReadUInt(cancellationToken).ConfigureAwait(false);
                    var key = index * 32 + bit;
                    values[(ushort)key] = value;
                }
            }
        }

        return new UpdateMask
        {
            _values = values
        };
    }

    internal async Task WriteAsync(Stream stream, CancellationToken cancellationToken)
    {
        var highestKey = _values.Keys.Max();
        var amountOfBlocks = highestKey / 32;
        if (amountOfBlocks % 32 != 0)
        {
            amountOfBlocks += 1;
        }

        await stream.WriteByte((byte)amountOfBlocks, cancellationToken).ConfigureAwait(false);

        var blocks = new uint[amountOfBlocks];
        foreach (var (key, value) in _values)
        {
            var block = key / 32;
            var index = key % 32;
            blocks[block] |= (uint)(1 << index);
        }

        foreach (var block in blocks)
        {
            await stream.WriteUInt(block, cancellationToken).ConfigureAwait(false);
        }

        foreach (var (_, value) in _values)
        {
            await stream.WriteUInt(value, cancellationToken).ConfigureAwait(false);
        }
    }

    internal int Length()
    {
        var highestKey = _values.Keys.Max();
        var amountOfBlocks = highestKey / 32;
        var extra = 0;
        if (highestKey % 32 != 0)
        {
            extra = 1;
        }

        return 1 + (extra + amountOfBlocks + _values.Count) * 4;
    }
}