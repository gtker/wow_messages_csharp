using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSPECT_TALENT: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required uint UnspentTalentPoints { get; set; }
    public required byte ActiveSpec { get; set; }
    public required List<InspectTalentSpec> Specs { get; set; }
    public required List<ushort> Glyphs { get; set; }
    public required InspectTalentGearMask TalentGearMask { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(UnspentTalentPoints, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Specs.Count, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(ActiveSpec, cancellationToken).ConfigureAwait(false);

        foreach (var v in Specs) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Glyphs.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Glyphs) {
            await w.WriteUShort(v, cancellationToken).ConfigureAwait(false);
        }

        await TalentGearMask.WriteAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1012, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1012, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSPECT_TALENT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var unspentTalentPoints = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSpecs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var activeSpec = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var specs = new List<InspectTalentSpec>();
        for (var i = 0; i < amountOfSpecs; ++i) {
            specs.Add(await Wrath.InspectTalentSpec.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfGlyphs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var glyphs = new List<ushort>();
        for (var i = 0; i < amountOfGlyphs; ++i) {
            glyphs.Add(await r.ReadUShort(cancellationToken).ConfigureAwait(false));
        }

        var talentGearMask = await InspectTalentGearMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);

        return new SMSG_INSPECT_TALENT {
            Player = player,
            UnspentTalentPoints = unspentTalentPoints,
            ActiveSpec = activeSpec,
            Specs = specs,
            Glyphs = glyphs,
            TalentGearMask = talentGearMask,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // unspent_talent_points: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_specs: Generator.Generated.DataTypeInteger
        size += 1;

        // active_spec: Generator.Generated.DataTypeInteger
        size += 1;

        // specs: Generator.Generated.DataTypeArray
        size += Specs.Sum(e => e.Size());

        // amount_of_glyphs: Generator.Generated.DataTypeInteger
        size += 1;

        // glyphs: Generator.Generated.DataTypeArray
        size += Glyphs.Sum(e => 2);

        // talent_gear_mask: Generator.Generated.DataTypeInspectTalentGearMask
        size += TalentGearMask.Length();

        return size;
    }

}

