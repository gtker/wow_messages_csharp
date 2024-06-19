using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgJoinPlayer {
    public required ulong Player { get; set; }
    public required List<LfgJoinLockedDungeon> LockedDungeons { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)LockedDungeons.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in LockedDungeons) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<LfgJoinPlayer> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfLockedDungeons = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var lockedDungeons = new List<LfgJoinLockedDungeon>();
        for (var i = 0; i < amountOfLockedDungeons; ++i) {
            lockedDungeons.Add(await Wrath.LfgJoinLockedDungeon.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new LfgJoinPlayer {
            Player = player,
            LockedDungeons = lockedDungeons,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // amount_of_locked_dungeons: Generator.Generated.DataTypeInteger
        size += 4;

        // locked_dungeons: Generator.Generated.DataTypeArray
        size += LockedDungeons.Sum(e => 8);

        return size;
    }

}

