using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SERVER_FIRST_ACHIEVEMENT: WrathServerMessage, IWorldMessage {
    public required string Name { get; set; }
    public required ulong Player { get; set; }
    public required uint Achievement { get; set; }
    public required Wrath.AchievementNameLinkType LinkType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Achievement, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)LinkType, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1176, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1176, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SERVER_FIRST_ACHIEVEMENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var achievement = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var linkType = (Wrath.AchievementNameLinkType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_SERVER_FIRST_ACHIEVEMENT {
            Name = name,
            Player = player,
            Achievement = achievement,
            LinkType = linkType,
        };
    }

    internal int Size() {
        var size = 0;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // achievement: Generator.Generated.DataTypeInteger
        size += 4;

        // link_type: Generator.Generated.DataTypeEnum
        size += 1;

        return size;
    }

}

