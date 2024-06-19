using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_QUEST_POI_QUERY: WrathClientMessage, IWorldMessage {
    public required List<uint> PointsOfInterests { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)PointsOfInterests.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in PointsOfInterests) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 483, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 483, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_QUEST_POI_QUERY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPois = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var pointsOfInterests = new List<uint>();
        for (var i = 0; i < amountOfPois; ++i) {
            pointsOfInterests.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        return new CMSG_QUEST_POI_QUERY {
            PointsOfInterests = pointsOfInterests,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_pois: Generator.Generated.DataTypeInteger
        size += 4;

        // points_of_interests: Generator.Generated.DataTypeArray
        size += PointsOfInterests.Sum(e => 4);

        return size;
    }

}

