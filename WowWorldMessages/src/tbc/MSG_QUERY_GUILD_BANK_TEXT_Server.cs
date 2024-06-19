using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_QUERY_GUILD_BANK_TEXT_Server: TbcServerMessage, IWorldMessage {
    public required byte Tab { get; set; }
    public required string Text { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(Tab, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Text, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1033, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1033, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_QUERY_GUILD_BANK_TEXT_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var tab = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new MSG_QUERY_GUILD_BANK_TEXT_Server {
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

