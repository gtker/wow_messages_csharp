using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE: TbcServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public required byte Slot { get; set; }
    public required uint Spell { get; set; }
    public required uint MaxDuration { get; set; }
    public required uint RemainingDuration { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Slot, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(MaxDuration, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RemainingDuration, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 933, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 933, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var maxDuration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var remainingDuration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE {
            Unit = unit,
            Slot = slot,
            Spell = spell,
            MaxDuration = maxDuration,
            RemainingDuration = remainingDuration,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        // slot: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // max_duration: Generator.Generated.DataTypeInteger
        size += 4;

        // remaining_duration: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

