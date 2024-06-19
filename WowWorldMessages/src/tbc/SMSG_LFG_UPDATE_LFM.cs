using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using LfgUpdateLookingForMoreType = OneOf.OneOf<SMSG_LFG_UPDATE_LFM.LfgUpdateLookingForMoreLookingForMore, LfgUpdateLookingForMore>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_UPDATE_LFM: TbcServerMessage, IWorldMessage {
    public class LfgUpdateLookingForMoreLookingForMore {
        public required LfgData Data { get; set; }
    }
    public required LfgUpdateLookingForMoreType LookingForMore { get; set; }
    internal LfgUpdateLookingForMore LookingForMoreValue => LookingForMore.Match(
        _ => Tbc.LfgUpdateLookingForMore.LookingForMore,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)LookingForMoreValue, cancellationToken).ConfigureAwait(false);

        if (LookingForMore.Value is SMSG_LFG_UPDATE_LFM.LfgUpdateLookingForMoreLookingForMore lfgUpdateLookingForMoreLookingForMore) {
            await lfgUpdateLookingForMoreLookingForMore.Data.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 877, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 877, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_UPDATE_LFM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        LfgUpdateLookingForMoreType lookingForMore = (Tbc.LfgUpdateLookingForMore)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (lookingForMore.Value is Tbc.LfgUpdateLookingForMore.LookingForMore) {
            var data = await LfgData.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            lookingForMore = new LfgUpdateLookingForMoreLookingForMore {
                Data = data,
            };
        }

        return new SMSG_LFG_UPDATE_LFM {
            LookingForMore = lookingForMore,
        };
    }

    internal int Size() {
        var size = 0;

        // looking_for_more: Generator.Generated.DataTypeEnum
        size += 1;

        if (LookingForMore.Value is SMSG_LFG_UPDATE_LFM.LfgUpdateLookingForMoreLookingForMore lfgUpdateLookingForMoreLookingForMore) {
            // data: Generator.Generated.DataTypeStruct
            size += 4;

        }

        return size;
    }

}

