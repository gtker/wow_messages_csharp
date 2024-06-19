using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_USERLIST_UPDATE: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required byte PlayerFlags { get; set; }
    public required byte Flags { get; set; }
    public required uint AmountOfPlayers { get; set; }
    public required string Name { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(PlayerFlags, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfPlayers, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1010, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1010, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_USERLIST_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var playerFlags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var flags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var amountOfPlayers = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_USERLIST_UPDATE {
            Player = player,
            PlayerFlags = playerFlags,
            Flags = flags,
            AmountOfPlayers = amountOfPlayers,
            Name = name,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // player_flags: Generator.Generated.DataTypeInteger
        size += 1;

        // flags: Generator.Generated.DataTypeInteger
        size += 1;

        // amount_of_players: Generator.Generated.DataTypeInteger
        size += 4;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        return size;
    }

}

