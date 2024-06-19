using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_PLAYER_DECLINED_NAMES: TbcClientMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required string Name { get; set; }
    public const int DeclinedNamesLength = 5;
    public required string[] DeclinedNames { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        foreach (var v in DeclinedNames) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1048, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1048, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_PLAYER_DECLINED_NAMES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var declinedNames = new string[DeclinedNamesLength];
        for (var i = 0; i < DeclinedNamesLength; ++i) {
            declinedNames[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        }

        return new CMSG_SET_PLAYER_DECLINED_NAMES {
            Player = player,
            Name = name,
            DeclinedNames = declinedNames,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // declined_names: Generator.Generated.DataTypeArray
        size += DeclinedNames.Sum(e => e.Length + 1);

        return size;
    }

}

