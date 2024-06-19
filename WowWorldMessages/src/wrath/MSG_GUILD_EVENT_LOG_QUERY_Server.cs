using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_GUILD_EVENT_LOG_QUERY_Server: WrathServerMessage, IWorldMessage {
    public required List<GuildLogEvent> Events { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)Events.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Events) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1023, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1023, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_GUILD_EVENT_LOG_QUERY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEvents = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var events = new List<GuildLogEvent>();
        for (var i = 0; i < amountOfEvents; ++i) {
            events.Add(await Wrath.GuildLogEvent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new MSG_GUILD_EVENT_LOG_QUERY_Server {
            Events = events,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_events: Generator.Generated.DataTypeInteger
        size += 1;

        // events: Generator.Generated.DataTypeArray
        size += Events.Sum(e => e.Size());

        return size;
    }

}

