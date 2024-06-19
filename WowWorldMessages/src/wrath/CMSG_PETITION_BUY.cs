using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_PETITION_BUY: WrathClientMessage, IWorldMessage {
    public required ulong Npc { get; set; }
    public required uint Unknown1 { get; set; }
    public required ulong Unknown2 { get; set; }
    public required string Name { get; set; }
    public required string Unknown3 { get; set; }
    public required uint Unknown4 { get; set; }
    public required uint Unknown5 { get; set; }
    public required uint Unknown6 { get; set; }
    public required uint Unknown7 { get; set; }
    public required uint Unknown8 { get; set; }
    public required uint Unknown9 { get; set; }
    public required uint Unknown10 { get; set; }
    public required ushort Unknown11 { get; set; }
    public required uint Unknown12 { get; set; }
    public required uint Unknown13 { get; set; }
    public required uint Unknown14 { get; set; }
    public const int Unknown15Length = 10;
    public required string[] Unknown15 { get; set; }
    public required uint Index { get; set; }
    public required uint Unknown16 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Npc, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Unknown3, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown4, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown5, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown6, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown7, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown8, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown9, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown10, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort(Unknown11, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown12, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown13, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown14, cancellationToken).ConfigureAwait(false);

        foreach (var v in Unknown15) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(Index, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown16, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 445, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 445, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_PETITION_BUY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var npc = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var unknown3 = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var unknown4 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown5 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown6 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown7 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown8 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown9 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown10 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown11 = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var unknown12 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown13 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown14 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown15 = new string[Unknown15Length];
        for (var i = 0; i < Unknown15Length; ++i) {
            unknown15[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        }

        var index = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown16 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_PETITION_BUY {
            Npc = npc,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Name = name,
            Unknown3 = unknown3,
            Unknown4 = unknown4,
            Unknown5 = unknown5,
            Unknown6 = unknown6,
            Unknown7 = unknown7,
            Unknown8 = unknown8,
            Unknown9 = unknown9,
            Unknown10 = unknown10,
            Unknown11 = unknown11,
            Unknown12 = unknown12,
            Unknown13 = unknown13,
            Unknown14 = unknown14,
            Unknown15 = unknown15,
            Index = index,
            Unknown16 = unknown16,
        };
    }

    internal int Size() {
        var size = 0;

        // npc: Generator.Generated.DataTypeGuid
        size += 8;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeGuid
        size += 8;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // unknown3: Generator.Generated.DataTypeCstring
        size += Unknown3.Length + 1;

        // unknown4: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown5: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown6: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown7: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown8: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown9: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown10: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown11: Generator.Generated.DataTypeInteger
        size += 2;

        // unknown12: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown13: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown14: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown15: Generator.Generated.DataTypeArray
        size += Unknown15.Sum(e => e.Length + 1);

        // index: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown16: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

