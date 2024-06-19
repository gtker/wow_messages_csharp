using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ENCHANTMENTLOG: WrathServerMessage, IWorldMessage {
    public required ulong Target { get; set; }
    /// <summary>
    /// vmangos: message says enchant has faded if empty
    /// </summary>
    public required ulong Caster { get; set; }
    public required uint Item { get; set; }
    public required uint Spell { get; set; }
    /// <summary>
    /// vmangos: Only used if `caster` is not 0.
    /// </summary>
    public required bool ShowAffiliation { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Target, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Caster, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(ShowAffiliation, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 471, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 471, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ENCHANTMENTLOG> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var target = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var showAffiliation = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_ENCHANTMENTLOG {
            Target = target,
            Caster = caster,
            Item = item,
            Spell = spell,
            ShowAffiliation = showAffiliation,
        };
    }

    internal int Size() {
        var size = 0;

        // target: Generator.Generated.DataTypePackedGuid
        size += Target.PackedGuidLength();

        // caster: Generator.Generated.DataTypePackedGuid
        size += Caster.PackedGuidLength();

        // item: Generator.Generated.DataTypeItem
        size += 4;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // show_affiliation: Generator.Generated.DataTypeBool
        size += 1;

        return size;
    }

}

