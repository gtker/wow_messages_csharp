using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GROUP_INVITE: WrathServerMessage, IWorldMessage {
    public required Wrath.PlayerInviteStatus Status { get; set; }
    public required string Name { get; set; }
    public struct OptionalUnknown {
        /// <summary>
        /// All emulators set entire optional to 0.
        /// </summary>
        public required uint Unknown1 { get; set; }
        /// <summary>
        /// All emulators set entire optional to 0.
        /// </summary>
        public required byte Count { get; set; }
        /// <summary>
        /// All emulators set entire optional to 0.
        /// </summary>
        public required uint Unknown2 { get; set; }
    }
    public required OptionalUnknown? Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Status, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        if (Unknown is { } unknown) {
            await w.WriteUInt(unknown.Unknown1, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(unknown.Count, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(unknown.Unknown2, cancellationToken).ConfigureAwait(false);

        }
    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 111, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 111, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GROUP_INVITE> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var status = (Wrath.PlayerInviteStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);
        __size += 1;

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        __size += name.Length + 1;

        OptionalUnknown? optionalUnknown = null;
        if (__size < bodySize) {
            var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var count = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            __size += 1;

            var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            optionalUnknown = new OptionalUnknown {
                Unknown1 = unknown1,
                Count = count,
                Unknown2 = unknown2,
            };
        }

        return new SMSG_GROUP_INVITE {
            Status = status,
            Name = name,
            Unknown = optionalUnknown,
        };
    }

    internal int Size() {
        var size = 0;

        // status: Generator.Generated.DataTypeEnum
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        if (Unknown is { } unknown) {
            // unknown1: Generator.Generated.DataTypeInteger
            size += 4;

            // count: Generator.Generated.DataTypeInteger
            size += 1;

            // unknown2: Generator.Generated.DataTypeInteger
            size += 4;

        }
        return size;
    }

}

