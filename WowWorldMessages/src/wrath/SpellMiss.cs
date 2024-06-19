using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using SpellMissInfoType = OneOf.OneOf<SpellMiss.SpellMissInfoReflect, SpellMissInfo>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SpellMiss {
    public class SpellMissInfoReflect {
        public required byte ReflectResult { get; set; }
    }
    public required ulong Target { get; set; }
    public required SpellMissInfoType MissInfo { get; set; }
    internal SpellMissInfo MissInfoValue => MissInfo.Match(
        _ => Wrath.SpellMissInfo.Reflect,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Target, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)MissInfoValue, cancellationToken).ConfigureAwait(false);

        if (MissInfo.Value is SpellMiss.SpellMissInfoReflect spellMissInfoReflect) {
            await w.WriteByte(spellMissInfoReflect.ReflectResult, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<SpellMiss> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var target = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        SpellMissInfoType missInfo = (Wrath.SpellMissInfo)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (missInfo.Value is Wrath.SpellMissInfo.Reflect) {
            var reflectResult = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            missInfo = new SpellMissInfoReflect {
                ReflectResult = reflectResult,
            };
        }

        return new SpellMiss {
            Target = target,
            MissInfo = missInfo,
        };
    }

    internal int Size() {
        var size = 0;

        // target: Generator.Generated.DataTypeGuid
        size += 8;

        // miss_info: Generator.Generated.DataTypeEnum
        size += 1;

        if (MissInfo.Value is SpellMiss.SpellMissInfoReflect spellMissInfoReflect) {
            // reflect_result: Generator.Generated.DataTypeInteger
            size += 1;

        }

        return size;
    }

}

