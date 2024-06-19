using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_FACTION_ATWAR: WrathClientMessage, IWorldMessage {
    public required Wrath.Faction Faction { get; set; }
    public required Wrath.FactionFlag Flags { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUShort((ushort)Faction, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Flags, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 7, 293, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 7, 293, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_FACTION_ATWAR> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var faction = (Wrath.Faction)await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var flags = (FactionFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_FACTION_ATWAR {
            Faction = faction,
            Flags = flags,
        };
    }

}
