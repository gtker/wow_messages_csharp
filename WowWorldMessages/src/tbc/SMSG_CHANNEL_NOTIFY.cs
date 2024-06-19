using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CHANNEL_NOTIFY: TbcServerMessage, IWorldMessage {
    public required Tbc.ChatNotify NotifyType { get; set; }
    public required string ChannelName { get; set; }
    public struct OptionalUnknown1 {
        public required uint Unknown2 { get; set; }
        public required uint Unkwown3 { get; set; }
    }
    public required OptionalUnknown1? Unknown1 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)NotifyType, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(ChannelName, cancellationToken).ConfigureAwait(false);

        if (Unknown1 is { } unknown1) {
            await w.WriteUInt(unknown1.Unknown2, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(unknown1.Unkwown3, cancellationToken).ConfigureAwait(false);

        }
    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 153, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 153, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CHANNEL_NOTIFY> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var notifyType = (Tbc.ChatNotify)await r.ReadByte(cancellationToken).ConfigureAwait(false);
        size += 1;

        var channelName = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        size += channelName.Length + 1;

        OptionalUnknown1? optionalUnknown1 = null;
        if (size < bodySize) {
            var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            var unkwown3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            optionalUnknown1 = new OptionalUnknown1 {
                Unknown2 = unknown2,
                Unkwown3 = unkwown3,
            };
        }

        return new SMSG_CHANNEL_NOTIFY {
            NotifyType = notifyType,
            ChannelName = channelName,
            Unknown1 = optionalUnknown1,
        };
    }

    internal int Size() {
        var size = 0;

        // notify_type: Generator.Generated.DataTypeEnum
        size += 1;

        // channel_name: Generator.Generated.DataTypeCstring
        size += ChannelName.Length + 1;

        if (Unknown1 is { } unknown1) {
            // unknown2: Generator.Generated.DataTypeInteger
            size += 4;

            // unkwown3: Generator.Generated.DataTypeInteger
            size += 4;

        }
        return size;
    }

}

