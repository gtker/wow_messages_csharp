using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_GUILD_BANK_TEXT: WrathClientMessage, IWorldMessage {
    public required byte Tab { get; set; }
    public required string Text { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Tab, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Text, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1035, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1035, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_GUILD_BANK_TEXT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var tab = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_GUILD_BANK_TEXT {
            Tab = tab,
            Text = text,
        };
    }

    internal int Size() {
        var size = 0;

        // tab: Generator.Generated.DataTypeInteger
        size += 1;

        // text: Generator.Generated.DataTypeCstring
        size += Text.Length + 1;

        return size;
    }

}

