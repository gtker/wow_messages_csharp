using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSPECT_TALENT: TbcServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required List<byte> TalentData { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        foreach (var v in TalentData) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1011, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1011, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSPECT_TALENT> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);
        size += player.PackedGuidLength();

        var talentData = new List<byte>();
        while (size <= bodySize) {
            talentData.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            size += 1;
        }

        return new SMSG_INSPECT_TALENT {
            Player = player,
            TalentData = talentData,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // talent_data: Generator.Generated.DataTypeArray
        size += TalentData.Sum(e => 1);

        return size;
    }

}

