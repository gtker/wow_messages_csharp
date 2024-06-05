using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class NpcTextUpdate {
    public required float Probability { get; set; }
    public required List<string> Texts { get; set; }
    public required Language Language { get; set; }
    public required List<NpcTextUpdateEmote> Emotes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteFloat(Probability, cancellationToken).ConfigureAwait(false);

        foreach (var v in Texts) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)Language, cancellationToken).ConfigureAwait(false);

        foreach (var v in Emotes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<NpcTextUpdate> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var probability = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var texts = new List<string>();
        for (var i = 0; i < 2; ++i) {
            texts.Add(await r.ReadCString(cancellationToken).ConfigureAwait(false));
        }

        var language = (Language)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var emotes = new List<NpcTextUpdateEmote>();
        for (var i = 0; i < 3; ++i) {
            emotes.Add(await Vanilla.NpcTextUpdateEmote.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new NpcTextUpdate {
            Probability = probability,
            Texts = texts,
            Language = language,
            Emotes = emotes,
        };
    }

    internal int Size() {
        var size = 0;

        // probability: Generator.Generated.DataTypeFloatingPoint
        size += 4;

        // texts: Generator.Generated.DataTypeArray
        size += Texts.Sum(e => e.Length);

        // language: Generator.Generated.DataTypeEnum
        size += 4;

        // emotes: Generator.Generated.DataTypeArray
        size += Emotes.Sum(e => 8);

        return size;
    }

}

