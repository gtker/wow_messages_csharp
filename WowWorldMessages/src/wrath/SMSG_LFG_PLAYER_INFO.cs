using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_PLAYER_INFO: WrathServerMessage, IWorldMessage {
    public required List<LfgAvailableDungeon> AvailableDungeons { get; set; }
    public required List<LfgJoinLockedDungeon> LockedDungeons { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)AvailableDungeons.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in AvailableDungeons) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)LockedDungeons.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in LockedDungeons) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 879, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 879, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_PLAYER_INFO> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfAvailableDungeons = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var availableDungeons = new List<LfgAvailableDungeon>();
        for (var i = 0; i < amountOfAvailableDungeons; ++i) {
            availableDungeons.Add(await Wrath.LfgAvailableDungeon.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfLockedDungeons = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var lockedDungeons = new List<LfgJoinLockedDungeon>();
        for (var i = 0; i < amountOfLockedDungeons; ++i) {
            lockedDungeons.Add(await Wrath.LfgJoinLockedDungeon.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_LFG_PLAYER_INFO {
            AvailableDungeons = availableDungeons,
            LockedDungeons = lockedDungeons,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_available_dungeons: Generator.Generated.DataTypeInteger
        size += 1;

        // available_dungeons: Generator.Generated.DataTypeArray
        size += AvailableDungeons.Sum(e => e.Size());

        // amount_of_locked_dungeons: Generator.Generated.DataTypeInteger
        size += 1;

        // locked_dungeons: Generator.Generated.DataTypeArray
        size += LockedDungeons.Sum(e => 8);

        return size;
    }

}

