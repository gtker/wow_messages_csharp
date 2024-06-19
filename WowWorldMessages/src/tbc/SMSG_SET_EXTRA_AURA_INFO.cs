using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SET_EXTRA_AURA_INFO: TbcServerMessage, IWorldMessage {
    public required ulong Unit { get; set; }
    public struct OptionalAura {
        public required byte Slot { get; set; }
        public required uint Spell { get; set; }
        public required uint MaxDuration { get; set; }
        public required uint RemainingDuration { get; set; }
    }
    public required OptionalAura? Aura { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Unit, cancellationToken).ConfigureAwait(false);

        if (Aura is { } aura) {
            await w.WriteByte(aura.Slot, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(aura.Spell, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(aura.MaxDuration, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(aura.RemainingDuration, cancellationToken).ConfigureAwait(false);

        }
    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 932, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 932, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SET_EXTRA_AURA_INFO> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var unit = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);
        size += unit.PackedGuidLength();

        OptionalAura? optionalAura = null;
        if (size < bodySize) {
            var slot = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            size += 1;

            var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            var maxDuration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            var remainingDuration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            size += 4;

            optionalAura = new OptionalAura {
                Slot = slot,
                Spell = spell,
                MaxDuration = maxDuration,
                RemainingDuration = remainingDuration,
            };
        }

        return new SMSG_SET_EXTRA_AURA_INFO {
            Unit = unit,
            Aura = optionalAura,
        };
    }

    internal int Size() {
        var size = 0;

        // unit: Generator.Generated.DataTypePackedGuid
        size += Unit.PackedGuidLength();

        if (Aura is { } aura) {
            // slot: Generator.Generated.DataTypeInteger
            size += 1;

            // spell: Generator.Generated.DataTypeSpell
            size += 4;

            // max_duration: Generator.Generated.DataTypeInteger
            size += 4;

            // remaining_duration: Generator.Generated.DataTypeInteger
            size += 4;

        }
        return size;
    }

}

