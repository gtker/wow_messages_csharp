using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_INSPECT_HONOR_STATS_Server: WrathServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required byte AmountOfHonor { get; set; }
    public required uint Kills { get; set; }
    public required uint HonorToday { get; set; }
    public required uint HonorYesterday { get; set; }
    public required uint LifetimeHonorableKills { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(AmountOfHonor, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Kills, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorToday, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(HonorYesterday, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LifetimeHonorableKills, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 27, 726, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 27, 726, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_INSPECT_HONOR_STATS_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var amountOfHonor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var kills = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorToday = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var honorYesterday = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var lifetimeHonorableKills = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_INSPECT_HONOR_STATS_Server {
            Guid = guid,
            AmountOfHonor = amountOfHonor,
            Kills = kills,
            HonorToday = honorToday,
            HonorYesterday = honorYesterday,
            LifetimeHonorableKills = lifetimeHonorableKills,
        };
    }

}

