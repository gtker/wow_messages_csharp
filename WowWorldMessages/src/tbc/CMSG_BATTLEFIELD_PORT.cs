using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BATTLEFIELD_PORT: TbcClientMessage, IWorldMessage {
    /// <summary>
    /// mangosone/mangos-tbc/azerothcore: arenatype if arena
    /// </summary>
    public required byte ArenaType { get; set; }
    /// <summary>
    /// mangosone/mangos-tbc/azerothcore: unk, can be 0x0 (may be if was invited?) and 0x1
    /// </summary>
    public required byte Unknown1 { get; set; }
    /// <summary>
    /// mangosone/mangos-tbc/azerothcore: type id from dbc
    /// </summary>
    public required uint BgTypeId { get; set; }
    /// <summary>
    /// mangosone/mangos-tbc/azerothcore: 0x1F90 constant?
    /// </summary>
    public required ushort Unknown2 { get; set; }
    public required Tbc.BattlefieldPortAction Action { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(ArenaType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BgTypeId, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Action, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 13, 725, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 13, 725, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BATTLEFIELD_PORT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var arenaType = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var bgTypeId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var action = (Tbc.BattlefieldPortAction)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_BATTLEFIELD_PORT {
            ArenaType = arenaType,
            Unknown1 = unknown1,
            BgTypeId = bgTypeId,
            Unknown2 = unknown2,
            Action = action,
        };
    }

}

