using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public required float Unknown1 { get; set; }
    public required float Unknown2 { get; set; }
    public required float Unknown3 { get; set; }
    public required float Unknown4 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteFloat(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Unknown3, cancellationToken).ConfigureAwait(false);

        await w.WriteFloat(Unknown4, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 18, 1207, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 18, 1207, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown1 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var unknown3 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var unknown4 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        return new SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE {
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Unknown3 = unknown3,
            Unknown4 = unknown4,
        };
    }

}

