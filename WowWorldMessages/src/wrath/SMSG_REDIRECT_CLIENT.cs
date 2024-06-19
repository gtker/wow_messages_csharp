using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_REDIRECT_CLIENT: WrathServerMessage, IWorldMessage {
    public required uint IpAddress { get; set; }
    public required ushort Port { get; set; }
    public required uint Unknown { get; set; }
    /// <summary>
    /// azerothcore: ip + port, seed = sessionkey
    /// </summary>
    public const int HashLength = 20;
    public required byte[] Hash { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(IpAddress, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Port, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

        foreach (var v in Hash) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 32, 1293, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 32, 1293, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_REDIRECT_CLIENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var ipAddress = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var port = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var hash = new byte[HashLength];
        for (var i = 0; i < HashLength; ++i) {
            hash[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_REDIRECT_CLIENT {
            IpAddress = ipAddress,
            Port = port,
            Unknown = unknown,
            Hash = hash,
        };
    }

}

