using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class InspectTalentSpec {
    public required List<InspectTalent> Talents { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Talents.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Talents) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<InspectTalentSpec> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfTalents = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var talents = new List<InspectTalent>();
        for (var i = 0; i < amountOfTalents; ++i) {
            talents.Add(await Wrath.InspectTalent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new InspectTalentSpec {
            Talents = talents,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_talents: Generator.Generated.DataTypeInteger
        size += 1;

        // talents: Generator.Generated.DataTypeArray
        size += Talents.Sum(e => 5);

        return size;
    }

}

