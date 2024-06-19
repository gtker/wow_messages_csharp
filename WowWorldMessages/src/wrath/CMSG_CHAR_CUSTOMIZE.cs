using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CHAR_CUSTOMIZE: WrathClientMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required string NewName { get; set; }
    public required Wrath.Gender Gender { get; set; }
    public required byte SkinColor { get; set; }
    public required byte HairColor { get; set; }
    public required byte HairStyle { get; set; }
    public required byte FacialHair { get; set; }
    public required byte Face { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(NewName, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SkinColor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairColor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairStyle, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(FacialHair, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Face, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1139, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 1139, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CHAR_CUSTOMIZE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var newName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var gender = (Wrath.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var skinColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairStyle = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var facialHair = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var face = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new CMSG_CHAR_CUSTOMIZE {
            Player = player,
            NewName = newName,
            Gender = gender,
            SkinColor = skinColor,
            HairColor = hairColor,
            HairStyle = hairStyle,
            FacialHair = facialHair,
            Face = face,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeGuid
        size += 8;

        // new_name: Generator.Generated.DataTypeCstring
        size += NewName.Length + 1;

        // gender: Generator.Generated.DataTypeEnum
        size += 1;

        // skin_color: Generator.Generated.DataTypeInteger
        size += 1;

        // hair_color: Generator.Generated.DataTypeInteger
        size += 1;

        // hair_style: Generator.Generated.DataTypeInteger
        size += 1;

        // facial_hair: Generator.Generated.DataTypeInteger
        size += 1;

        // face: Generator.Generated.DataTypeInteger
        size += 1;

        return size;
    }

}

