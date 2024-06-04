using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ACCOUNT_DATA_TIMES: VanillaServerMessage, IWorldMessage {
    /// <summary>
    /// cmangos/vmangos/mangoszero sets to all zeros
    /// </summary>
    public required List<uint> Data { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        foreach (var v in Data) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 130, 521, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 130, 521, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ACCOUNT_DATA_TIMES> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var data = new List<uint>();
        for (var i = 0; i < 32; ++i) {
            data.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        return new SMSG_ACCOUNT_DATA_TIMES {
            Data = data,
        };
    }

}

