using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_ACTIVE_VOICE_CHANNEL: WrathClientMessage, IWorldMessage {
    public required uint Unknown1 { get; set; }
    public required string Unknown2 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Unknown2, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 979, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 979, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_ACTIVE_VOICE_CHANNEL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_ACTIVE_VOICE_CHANNEL {
            Unknown1 = unknown1,
            Unknown2 = unknown2,
        };
    }

    internal int Size() {
        var size = 0;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeCstring
        size += Unknown2.Length + 1;

        return size;
    }

}

