using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PETITION_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public required uint PetitionId { get; set; }
    public required ulong CharterOwner { get; set; }
    public required string GuildName { get; set; }
    /// <summary>
    /// cmangos/vmangos/mangoszero: Set to 0, only info is comment from vmangos
    /// </summary>
    public required string BodyText { get; set; }
    /// <summary>
    /// cmangos/vmangos/mangoszero: Set to 9, only info is comment from vmangos
    /// </summary>
    public required uint MinimumSignatures { get; set; }
    /// <summary>
    /// cmangos/vmangos/mangoszero: Set to 9, only info is comment from vmangos
    /// </summary>
    public required uint MaximumSignatures { get; set; }
    /// <summary>
    /// mangosone: bypass client - side limitation, a different value is needed here for each petition
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint Unknown2 { get; set; }
    public required uint Unknown3 { get; set; }
    public required uint Unknown4 { get; set; }
    public required uint Unknown5 { get; set; }
    public required ushort Unknown6 { get; set; }
    public required uint Unknown7 { get; set; }
    public required uint Unknown8 { get; set; }
    public required uint Unknown9 { get; set; }
    public const int Unknown10Length = 10;
    public required byte[] Unknown10 { get; set; }
    public required uint Unknown11 { get; set; }
    public required Wrath.CharterType CharterType { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(PetitionId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(CharterOwner, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(GuildName, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(BodyText, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MinimumSignatures, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaximumSignatures, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown3, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown4, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown5, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown6, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown7, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown8, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown9, cancellationToken).ConfigureAwait(false);

        foreach (var v in Unknown10) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(Unknown11, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)CharterType, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 455, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 455, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PETITION_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var petitionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var charterOwner = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var guildName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var bodyText = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var minimumSignatures = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maximumSignatures = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown4 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown5 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown6 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var unknown7 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown8 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown9 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown10 = new byte[Unknown10Length];
        for (var i = 0; i < Unknown10Length; ++i) {
            unknown10[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        }

        var unknown11 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var charterType = (Wrath.CharterType)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_PETITION_QUERY_RESPONSE {
            PetitionId = petitionId,
            CharterOwner = charterOwner,
            GuildName = guildName,
            BodyText = bodyText,
            MinimumSignatures = minimumSignatures,
            MaximumSignatures = maximumSignatures,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Unknown3 = unknown3,
            Unknown4 = unknown4,
            Unknown5 = unknown5,
            Unknown6 = unknown6,
            Unknown7 = unknown7,
            Unknown8 = unknown8,
            Unknown9 = unknown9,
            Unknown10 = unknown10,
            Unknown11 = unknown11,
            CharterType = charterType,
        };
    }

    internal int Size() {
        var size = 0;

        // petition_id: Generator.Generated.DataTypeInteger
        size += 4;

        // charter_owner: Generator.Generated.DataTypeGuid
        size += 8;

        // guild_name: Generator.Generated.DataTypeCstring
        size += GuildName.Length + 1;

        // body_text: Generator.Generated.DataTypeCstring
        size += BodyText.Length + 1;

        // minimum_signatures: Generator.Generated.DataTypeInteger
        size += 4;

        // maximum_signatures: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown3: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown4: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown5: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown6: Generator.Generated.DataTypeInteger
        size += 2;

        // unknown7: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown8: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown9: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown10: Generator.Generated.DataTypeArray
        size += Unknown10.Sum(e => 1);

        // unknown11: Generator.Generated.DataTypeInteger
        size += 4;

        // charter_type: Generator.Generated.DataTypeEnum
        size += 4;

        return size;
    }

}

