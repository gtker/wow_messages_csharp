using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgPartyInfo {
    public required ulong Player { get; set; }
    public required List<LfgJoinLockedDungeon> Dungeons { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Dungeons.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Dungeons) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<LfgPartyInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfDungeons = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var dungeons = new List<LfgJoinLockedDungeon>();
        for (var i = 0; i < amountOfDungeons; ++i) {
            dungeons.Add(await Wrath.LfgJoinLockedDungeon.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new LfgPartyInfo {
            Player = player,
            Dungeons = dungeons,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // amount_of_dungeons: Generator.Generated.DataTypeInteger
        size += 4;

        // dungeons: Generator.Generated.DataTypeArray
        size += Dungeons.Sum(e => 8);

        return size;
    }

}

