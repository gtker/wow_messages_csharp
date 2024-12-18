using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_GUILD_CREATE: TbcClientMessage, IWorldMessage {
    public required string GuildName { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(GuildName, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 129, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 129, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_GUILD_CREATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guildName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_GUILD_CREATE {
            GuildName = guildName,
        };
    }

    internal int Size() {
        var size = 0;

        // guild_name: Generator.Generated.DataTypeCstring
        size += GuildName.Length + 1;

        return size;
    }

}

