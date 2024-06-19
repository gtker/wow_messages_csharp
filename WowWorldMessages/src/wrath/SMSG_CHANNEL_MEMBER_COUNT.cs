using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CHANNEL_MEMBER_COUNT: WrathServerMessage, IWorldMessage {
    public required string Channel { get; set; }
    public required byte Flags { get; set; }
    public required uint AmountOfMembers { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Channel, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfMembers, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 981, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 981, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CHANNEL_MEMBER_COUNT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var channel = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var amountOfMembers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CHANNEL_MEMBER_COUNT {
            Channel = channel,
            Flags = flags,
            AmountOfMembers = amountOfMembers,
        };
    }

    internal int Size() {
        var size = 0;

        // channel: Generator.Generated.DataTypeCstring
        size += Channel.Length + 1;

        // flags: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_members: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

