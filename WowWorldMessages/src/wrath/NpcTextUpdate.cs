using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class NpcTextUpdate {
    public required float Probability { get; set; }
    public const int TextsLength = 2;
    public required string[] Texts { get; set; }
    public required Wrath.Language Language { get; set; }
    public const int EmotesLength = 3;
    public required NpcTextUpdateEmote[] Emotes { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteFloat(Probability, cancellationToken).ConfigureAwait(false);

        foreach (var v in Texts) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Language, cancellationToken).ConfigureAwait(false);

        foreach (var v in Emotes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<NpcTextUpdate> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var probability = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

        var texts = new string[TextsLength];
        for (var i = 0; i < TextsLength; ++i) {
            texts[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        }

        var language = (Wrath.Language)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var emotes = new NpcTextUpdateEmote[EmotesLength];
        for (var i = 0; i < EmotesLength; ++i) {
            emotes[i] = await Wrath.NpcTextUpdateEmote.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
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
        size += Texts.Sum(e => e.Length + 1);

        // language: Generator.Generated.DataTypeEnum
        size += 1;

        // emotes: Generator.Generated.DataTypeArray
        size += Emotes.Sum(e => 8);

        return size;
    }

}

