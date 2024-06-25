using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

using SpellCastTargetFlagsItemMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsItem, SpellCastTargets.SpellCastTargetFlagsTradeItem, SpellCastTargetFlags>;
using SpellCastTargetFlagsUnitMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsCorpseAlly, SpellCastTargets.SpellCastTargetFlagsCorpseEnemy, SpellCastTargets.SpellCastTargetFlagsGameobject, SpellCastTargets.SpellCastTargetFlagsUnit, SpellCastTargets.SpellCastTargetFlagsUnitMinipet, SpellCastTargetFlags>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SpellCastTargets {
    public class SpellCastTargetFlagsItem {
        public required ulong ItemTarget { get; set; }
    }
    public class SpellCastTargetFlagsTradeItem {
        public required ulong TradeItemTarget { get; set; }
    }
    public class SpellCastTargetFlagsCorpseAlly {
        public required ulong AllyCorpseTarget { get; set; }
    }
    public class SpellCastTargetFlagsCorpseEnemy {
        public required ulong EnemyCorpseTarget { get; set; }
    }
    public class SpellCastTargetFlagsGameobject {
        public required ulong GameobjectTarget { get; set; }
    }
    public class SpellCastTargetFlagsUnit {
        public required ulong UnitTarget { get; set; }
    }
    public class SpellCastTargetFlagsUnitMinipet {
        public required ulong MinipetTarget { get; set; }
    }
    public class SpellCastTargetFlagsType {
        public required SpellCastTargetFlags Inner;
        public SpellCastTargetFlagsDestLocation? DestLocation;
        public SpellCastTargetFlagsItemMulti Item;
        public SpellCastTargetFlagsSourceLocation? SourceLocation;
        public SpellCastTargetFlagsString? String;
        public SpellCastTargetFlagsUnitMulti Unit;
    }
    public class SpellCastTargetFlagsDestLocation {
        public required Vector3d Destination { get; set; }
    }
    public class SpellCastTargetFlagsSourceLocation {
        public required Vector3d Source { get; set; }
    }
    public class SpellCastTargetFlagsString {
        public required string TargetString { get; set; }
    }
    public required SpellCastTargetFlagsType TargetFlags { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)TargetFlags.Inner, cancellationToken).ConfigureAwait(false);

        if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnit spellCastTargetFlagsUnit) {
            await w.WritePackedGuid(spellCastTargetFlagsUnit.UnitTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnitMinipet spellCastTargetFlagsUnitMinipet) {
            await w.WritePackedGuid(spellCastTargetFlagsUnitMinipet.MinipetTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsGameobject spellCastTargetFlagsGameobject) {
            await w.WritePackedGuid(spellCastTargetFlagsGameobject.GameobjectTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsCorpseEnemy spellCastTargetFlagsCorpseEnemy) {
            await w.WritePackedGuid(spellCastTargetFlagsCorpseEnemy.EnemyCorpseTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsCorpseAlly spellCastTargetFlagsCorpseAlly) {
            await w.WritePackedGuid(spellCastTargetFlagsCorpseAlly.AllyCorpseTarget, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.Item.Value is SpellCastTargetFlagsItem spellCastTargetFlagsItem) {
            await w.WritePackedGuid(spellCastTargetFlagsItem.ItemTarget, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Item.Value is SpellCastTargetFlagsTradeItem spellCastTargetFlagsTradeItem) {
            await w.WritePackedGuid(spellCastTargetFlagsTradeItem.TradeItemTarget, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.SourceLocation is SpellCastTargetFlagsSourceLocation spellCastTargetFlagsSourceLocation) {
            await spellCastTargetFlagsSourceLocation.Source.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.DestLocation is SpellCastTargetFlagsDestLocation spellCastTargetFlagsDestLocation) {
            await spellCastTargetFlagsDestLocation.Destination.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.String is SpellCastTargetFlagsString spellCastTargetFlagsString) {
            await w.WriteCString(spellCastTargetFlagsString.TargetString, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<SpellCastTargets> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var targetFlags = new SpellCastTargetFlagsType {
            Inner = (SpellCastTargetFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.Unit)) {
            var unitTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsUnit {
                UnitTarget = unitTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.UnitMinipet)) {
            var minipetTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsUnitMinipet {
                MinipetTarget = minipetTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.Gameobject)) {
            var gameobjectTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsGameobject {
                GameobjectTarget = gameobjectTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.CorpseEnemy)) {
            var enemyCorpseTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsCorpseEnemy {
                EnemyCorpseTarget = enemyCorpseTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.CorpseAlly)) {
            var allyCorpseTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsCorpseAlly {
                AllyCorpseTarget = allyCorpseTarget,
            };
        }

        if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.Item)) {
            var itemTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Item = new SpellCastTargetFlagsItem {
                ItemTarget = itemTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.TradeItem)) {
            var tradeItemTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Item = new SpellCastTargetFlagsTradeItem {
                TradeItemTarget = tradeItemTarget,
            };
        }

        if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.SourceLocation)) {
            var source = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            targetFlags.SourceLocation = new SpellCastTargetFlagsSourceLocation {
                Source = source,
            };
        }

        if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.DestLocation)) {
            var destination = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            targetFlags.DestLocation = new SpellCastTargetFlagsDestLocation {
                Destination = destination,
            };
        }

        if (targetFlags.Inner.HasFlag(Wrath.SpellCastTargetFlags.String)) {
            var targetString = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            targetFlags.String = new SpellCastTargetFlagsString {
                TargetString = targetString,
            };
        }

        return new SpellCastTargets {
            TargetFlags = targetFlags,
        };
    }

    internal int Size() {
        var size = 0;

        // target_flags: Generator.Generated.DataTypeFlag
        size += 4;

        if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnit spellCastTargetFlagsUnit) {
            // unit_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsUnit.UnitTarget.PackedGuidLength();

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnitMinipet spellCastTargetFlagsUnitMinipet) {
            // minipet_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsUnitMinipet.MinipetTarget.PackedGuidLength();

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsGameobject spellCastTargetFlagsGameobject) {
            // gameobject_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsGameobject.GameobjectTarget.PackedGuidLength();

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsCorpseEnemy spellCastTargetFlagsCorpseEnemy) {
            // enemy_corpse_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsCorpseEnemy.EnemyCorpseTarget.PackedGuidLength();

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsCorpseAlly spellCastTargetFlagsCorpseAlly) {
            // ally_corpse_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsCorpseAlly.AllyCorpseTarget.PackedGuidLength();

        }

        if (TargetFlags.Item.Value is SpellCastTargetFlagsItem spellCastTargetFlagsItem) {
            // item_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsItem.ItemTarget.PackedGuidLength();

        }
        else if (TargetFlags.Item.Value is SpellCastTargetFlagsTradeItem spellCastTargetFlagsTradeItem) {
            // trade_item_target: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsTradeItem.TradeItemTarget.PackedGuidLength();

        }

        if (TargetFlags.SourceLocation is SpellCastTargetFlagsSourceLocation spellCastTargetFlagsSourceLocation) {
            // source: Generator.Generated.DataTypeStruct
            size += 12;

        }

        if (TargetFlags.DestLocation is SpellCastTargetFlagsDestLocation spellCastTargetFlagsDestLocation) {
            // destination: Generator.Generated.DataTypeStruct
            size += 12;

        }

        if (TargetFlags.String is SpellCastTargetFlagsString spellCastTargetFlagsString) {
            // target_string: Generator.Generated.DataTypeCstring
            size += spellCastTargetFlagsString.TargetString.Length + 1;

        }

        return size;
    }

}

