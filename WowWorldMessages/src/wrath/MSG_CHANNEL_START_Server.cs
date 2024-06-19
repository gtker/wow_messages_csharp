using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_CHANNEL_START_Server: WrathServerMessage, IWorldMessage {
    public required ulong Caster { get; set; }
    public required uint Spell { get; set; }
    public required uint Duration { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Duration, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 313, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 313, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_CHANNEL_START_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_CHANNEL_START_Server {
            Caster = caster,
            Spell = spell,
            Duration = duration,
        };
    }

    internal int Size() {
        var size = 0;

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // duration: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

