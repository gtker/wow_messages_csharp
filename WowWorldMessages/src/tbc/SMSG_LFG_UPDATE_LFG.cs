using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_UPDATE_LFG: TbcServerMessage, IWorldMessage {
    public const int DataLength = 3;
    public required LfgData[] Data { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        foreach (var v in Data) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 878, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 14, 878, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_UPDATE_LFG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var data = new LfgData[DataLength];
        for (var i = 0; i < DataLength; ++i) {
            data[i] = await Tbc.LfgData.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_LFG_UPDATE_LFG {
            Data = data,
        };
    }

}

