using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_ROLE_CHOSEN: WrathServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required bool Ready { get; set; }
    public required uint Roles { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Ready, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Roles, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 15, 699, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 15, 699, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_ROLE_CHOSEN> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var ready = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var roles = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_LFG_ROLE_CHOSEN {
            Guid = guid,
            Ready = ready,
            Roles = roles,
        };
    }

}

