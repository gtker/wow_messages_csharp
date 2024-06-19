using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AuraUpdate {
    public class AuraFlagType {
        public required AuraFlag Inner;
        public AuraFlagDuration? Duration;
        public AuraFlagNotCaster? NotCaster;
    }
    public class AuraFlagDuration {
        public required uint Duration { get; set; }
        public required uint TimeLeft { get; set; }
    }
    public class AuraFlagNotCaster {
        public required ulong Caster { get; set; }
    }
    public required byte VisualSlot { get; set; }
    public required uint Spell { get; set; }
    public required AuraFlagType Flags { get; set; }
    public required byte Level { get; set; }
    public required byte AuraStackCount { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(VisualSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Flags.Inner, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Level, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(AuraStackCount, cancellationToken).ConfigureAwait(false);

        if (Flags.NotCaster is {} auraFlagNotCaster) {
            await w.WritePackedGuid(auraFlagNotCaster.Caster, cancellationToken).ConfigureAwait(false);

        }

        if (Flags.Duration is {} auraFlagDuration) {
            await w.WriteUInt(auraFlagDuration.Duration, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(auraFlagDuration.TimeLeft, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<AuraUpdate> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var visualSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var flags = new AuraFlagType {
            Inner = (AuraFlag)await r.ReadByte(cancellationToken).ConfigureAwait(false),
        };

        var level = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var auraStackCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (flags.Inner.HasFlag(Wrath.AuraFlag.NotCaster)) {
            var caster = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            flags.NotCaster = new AuraFlagNotCaster {
                Caster = caster,
            };
        }

        if (flags.Inner.HasFlag(Wrath.AuraFlag.Duration)) {
            var duration = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var timeLeft = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            flags.Duration = new AuraFlagDuration {
                Duration = duration,
                TimeLeft = timeLeft,
            };
        }

        return new AuraUpdate {
            VisualSlot = visualSlot,
            Spell = spell,
            Flags = flags,
            Level = level,
            AuraStackCount = auraStackCount,
        };
    }

    internal int Size() {
        var size = 0;

        // visual_slot: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // flags: Generator.Generated.DataTypeFlag
        size += 1;

        // level: Generator.Generated.DataTypeLevel
        size += 1;

        // aura_stack_count: Generator.Generated.DataTypeInteger
        size += 1;

        if (Flags.NotCaster is {} auraFlagNotCaster) {
            // caster: Generator.Generated.DataTypePackedGuid
            size += auraFlagNotCaster.Caster.PackedGuidLength();

        }

        if (Flags.Duration is {} auraFlagDuration) {
            // duration: Generator.Generated.DataTypeInteger
            size += 4;

            // time_left: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

