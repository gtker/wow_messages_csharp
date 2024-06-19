using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BATTLEMASTER_JOIN_ARENA: WrathClientMessage, IWorldMessage {
    public required ulong Battlemaster { get; set; }
    public required Wrath.JoinArenaType ArenaType { get; set; }
    public required bool AsGroup { get; set; }
    public required bool Rated { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Battlemaster, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ArenaType, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(AsGroup, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Rated, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 15, 856, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 15, 856, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BATTLEMASTER_JOIN_ARENA> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battlemaster = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var arenaType = (Wrath.JoinArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var asGroup = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var rated = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_BATTLEMASTER_JOIN_ARENA {
            Battlemaster = battlemaster,
            ArenaType = arenaType,
            AsGroup = asGroup,
            Rated = rated,
        };
    }

}

