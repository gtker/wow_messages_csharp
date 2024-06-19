using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_PARTY_ASSIGNMENT_Client: TbcClientMessage, IWorldMessage {
    public required Tbc.PartyRole Role { get; set; }
    public required bool Apply { get; set; }
    public required ulong Player { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Role, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Apply, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 14, 910, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 14, 910, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_PARTY_ASSIGNMENT_Client> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var role = (Tbc.PartyRole)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var apply = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new MSG_PARTY_ASSIGNMENT_Client {
            Role = role,
            Apply = apply,
            Player = player,
        };
    }

}

