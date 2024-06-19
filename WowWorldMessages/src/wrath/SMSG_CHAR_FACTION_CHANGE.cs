using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using WorldResultType = OneOf.OneOf<SMSG_CHAR_FACTION_CHANGE.WorldResultResponseSuccess, WorldResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CHAR_FACTION_CHANGE: WrathServerMessage, IWorldMessage {
    public class WorldResultResponseSuccess {
        public required byte Face { get; set; }
        public required byte FacialHair { get; set; }
        public required Wrath.Gender Gender { get; set; }
        public required ulong Guid { get; set; }
        public required byte HairColor { get; set; }
        public required byte HairStyle { get; set; }
        public required string Name { get; set; }
        public required Wrath.Race Race { get; set; }
        public required byte SkinColor { get; set; }
    }
    public required WorldResultType Result { get; set; }
    internal WorldResult ResultValue => Result.Match(
        _ => Wrath.WorldResult.ResponseSuccess,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_CHAR_FACTION_CHANGE.WorldResultResponseSuccess worldResultResponseSuccess) {
            await w.WriteULong(worldResultResponseSuccess.Guid, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(worldResultResponseSuccess.Name, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)worldResultResponseSuccess.Gender, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(worldResultResponseSuccess.SkinColor, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(worldResultResponseSuccess.Face, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(worldResultResponseSuccess.HairStyle, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(worldResultResponseSuccess.HairColor, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(worldResultResponseSuccess.FacialHair, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)worldResultResponseSuccess.Race, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1242, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1242, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CHAR_FACTION_CHANGE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        WorldResultType result = (Wrath.WorldResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.WorldResult.ResponseSuccess) {
            var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            var gender = (Wrath.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var skinColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var face = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var hairStyle = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var hairColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var facialHair = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var race = (Wrath.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            result = new WorldResultResponseSuccess {
                Face = face,
                FacialHair = facialHair,
                Gender = gender,
                Guid = guid,
                HairColor = hairColor,
                HairStyle = hairStyle,
                Name = name,
                Race = race,
                SkinColor = skinColor,
            };
        }

        return new SMSG_CHAR_FACTION_CHANGE {
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is SMSG_CHAR_FACTION_CHANGE.WorldResultResponseSuccess worldResultResponseSuccess) {
            // guid: Generator.Generated.DataTypeGuid
            size += 8;

            // name: Generator.Generated.DataTypeCstring
            size += worldResultResponseSuccess.Name.Length + 1;

            // gender: Generator.Generated.DataTypeEnum
            size += 1;

            // skin_color: Generator.Generated.DataTypeInteger
            size += 1;

            // face: Generator.Generated.DataTypeInteger
            size += 1;

            // hair_style: Generator.Generated.DataTypeInteger
            size += 1;

            // hair_color: Generator.Generated.DataTypeInteger
            size += 1;

            // facial_hair: Generator.Generated.DataTypeInteger
            size += 1;

            // race: Generator.Generated.DataTypeEnum
            size += 1;

        }

        return size;
    }

}

