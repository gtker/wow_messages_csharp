using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_SAVED_INSTANCE_EXTEND: WrathClientMessage, IWorldMessage {
    public required Wrath.Map Map { get; set; }
    public required Wrath.RaidDifficulty Difficulty { get; set; }
    public required bool ToggleExtend { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(ToggleExtend, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 10, 658, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 10, 658, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_SAVED_INSTANCE_EXTEND> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var difficulty = (Wrath.RaidDifficulty)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var toggleExtend = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_SAVED_INSTANCE_EXTEND {
            Map = map,
            Difficulty = difficulty,
            ToggleExtend = toggleExtend,
        };
    }

}

