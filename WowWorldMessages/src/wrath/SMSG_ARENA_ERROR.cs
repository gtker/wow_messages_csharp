using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ARENA_ERROR: WrathServerMessage, IWorldMessage {
    public required uint Unknown { get; set; }
    public required Wrath.ArenaType ArenaType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ArenaType, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 7, 886, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 7, 886, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ARENA_ERROR> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var arenaType = (Wrath.ArenaType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_ARENA_ERROR {
            Unknown = unknown,
            ArenaType = arenaType,
        };
    }

}

