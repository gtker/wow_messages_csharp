using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_MIRRORIMAGE_DATA: TbcServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required uint DisplayId { get; set; }
    public required Tbc.Race Race { get; set; }
    public required Tbc.Gender Gender { get; set; }
    public required byte SkinColor { get; set; }
    public required byte Face { get; set; }
    public required byte HairStyle { get; set; }
    public required byte HairColor { get; set; }
    public required byte FacialHair { get; set; }
    public required uint GuildId { get; set; }
    /// <summary>
    /// This array contains the: HEAD, SHOULDERS, BODY, CHEST, WAIST, LEGS, FEET, WRISTS, HANDS, BACK, and TABARD.
    /// </summary>
    public const int DisplayIdsLength = 11;
    public required uint[] DisplayIds { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DisplayId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Race, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SkinColor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Face, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairStyle, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HairColor, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(FacialHair, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GuildId, cancellationToken).ConfigureAwait(false);

        foreach (var v in DisplayIds) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 69, 1025, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, 69, 1025, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_MIRRORIMAGE_DATA> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var displayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var race = (Tbc.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Tbc.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var skinColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var face = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairStyle = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var hairColor = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var facialHair = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var guildId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var displayIds = new uint[DisplayIdsLength];
        for (var i = 0; i < DisplayIdsLength; ++i) {
            displayIds[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_MIRRORIMAGE_DATA {
            Guid = guid,
            DisplayId = displayId,
            Race = race,
            Gender = gender,
            SkinColor = skinColor,
            Face = face,
            HairStyle = hairStyle,
            HairColor = hairColor,
            FacialHair = facialHair,
            GuildId = guildId,
            DisplayIds = displayIds,
        };
    }

}

