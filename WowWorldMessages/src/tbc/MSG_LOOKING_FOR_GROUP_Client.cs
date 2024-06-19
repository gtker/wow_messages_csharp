using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_LOOKING_FOR_GROUP_Client: TbcClientMessage, IWorldMessage {
    public required Tbc.LfgType LfgType { get; set; }
    /// <summary>
    /// entry from LfgDunggeons.dbc
    /// </summary>
    public required uint Entry { get; set; }
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)LfgType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Entry, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 16, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 16, 511, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_LOOKING_FOR_GROUP_Client> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var lfgType = (Tbc.LfgType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var entry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_LOOKING_FOR_GROUP_Client {
            LfgType = lfgType,
            Entry = entry,
            Unknown = unknown,
        };
    }

}

