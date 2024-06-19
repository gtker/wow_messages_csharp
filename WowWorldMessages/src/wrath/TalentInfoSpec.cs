using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class TalentInfoSpec {
    public required List<InspectTalent> Talents { get; set; }
    public required List<ushort> Glyphs { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Talents.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Talents) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Glyphs.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Glyphs) {
            await w.WriteUShort(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<TalentInfoSpec> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfTalents = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var talents = new List<InspectTalent>();
        for (var i = 0; i < amountOfTalents; ++i) {
            talents.Add(await Wrath.InspectTalent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfGlyphs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var glyphs = new List<ushort>();
        for (var i = 0; i < amountOfGlyphs; ++i) {
            glyphs.Add(await r.ReadUShort(cancellationToken).ConfigureAwait(false));
        }

        return new TalentInfoSpec {
            Talents = talents,
            Glyphs = glyphs,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_talents: Generator.Generated.DataTypeInteger
        size += 1;

        // talents: Generator.Generated.DataTypeArray
        size += Talents.Sum(e => 5);

        // amount_of_glyphs: Generator.Generated.DataTypeInteger
        size += 1;

        // glyphs: Generator.Generated.DataTypeArray
        size += Glyphs.Sum(e => 2);

        return size;
    }

}

