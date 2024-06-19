using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BATTLEFIELD_LIST: WrathClientMessage, IWorldMessage {
    public required Wrath.BattlegroundType BattlegroundType { get; set; }
    public required Wrath.BattlefieldListLocation Location { get; set; }
    /// <summary>
    /// azerothcore: players with locked xp have their own bg queue on retail
    /// </summary>
    public required bool CanGainExp { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)BattlegroundType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Location, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(CanGainExp, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 10, 572, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 10, 572, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BATTLEFIELD_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battlegroundType = (Wrath.BattlegroundType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var location = (Wrath.BattlefieldListLocation)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var canGainExp = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_BATTLEFIELD_LIST {
            BattlegroundType = battlegroundType,
            Location = location,
            CanGainExp = canGainExp,
        };
    }

}

