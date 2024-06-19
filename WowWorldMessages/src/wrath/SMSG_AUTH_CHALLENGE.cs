using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUTH_CHALLENGE: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// TrinityCore/ArcEmu/mangostwo always set to 1.
    /// TrinityCore/mangostwo: 1...31
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint ServerSeed { get; set; }
    /// <summary>
    /// Randomized values. Is not used at all by TrinityCore/mangostwo/ArcEmu.
    /// </summary>
    public const int SeedLength = 32;
    public required byte[] Seed { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ServerSeed, cancellationToken).ConfigureAwait(false);

        foreach (var v in Seed) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 42, 492, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 42, 492, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUTH_CHALLENGE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var serverSeed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var seed = new byte[SeedLength];
        for (var i = 0; i < SeedLength; ++i) {
            seed[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_AUTH_CHALLENGE {
            Unknown1 = unknown1,
            ServerSeed = serverSeed,
            Seed = seed,
        };
    }

}

