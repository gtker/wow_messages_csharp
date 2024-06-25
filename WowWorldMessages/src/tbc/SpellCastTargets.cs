using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Tbc;

using SpellCastTargetFlagsCorpseAllyMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsCorpseAlly, SpellCastTargets.SpellCastTargetFlagsCorpseEnemy, SpellCastTargetFlags>;
using SpellCastTargetFlagsGameobjectMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsGameobject, SpellCastTargets.SpellCastTargetFlagsLocked, SpellCastTargetFlags>;
using SpellCastTargetFlagsItemMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsItem, SpellCastTargets.SpellCastTargetFlagsTradeItem, SpellCastTargetFlags>;
using SpellCastTargetFlagsUnitMulti = OneOf.OneOf<SpellCastTargets.SpellCastTargetFlagsUnit, SpellCastTargets.SpellCastTargetFlagsUnitEnemy, SpellCastTargets.SpellCastTargetFlagsUnitMinipet, SpellCastTargetFlags>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SpellCastTargets {
    public class SpellCastTargetFlagsCorpseAlly {
        public required ulong CorpseAlly { get; set; }
    }
    public class SpellCastTargetFlagsCorpseEnemy {
        public required ulong CorpseEnemy { get; set; }
    }
    public class SpellCastTargetFlagsGameobject {
        public required ulong Gameobject { get; set; }
    }
    public class SpellCastTargetFlagsLocked {
        public required ulong Locked { get; set; }
    }
    public class SpellCastTargetFlagsItem {
        public required ulong Item { get; set; }
    }
    public class SpellCastTargetFlagsTradeItem {
        public required ulong TradeItem { get; set; }
    }
    public class SpellCastTargetFlagsUnit {
        public required ulong UnitTarget { get; set; }
    }
    public class SpellCastTargetFlagsUnitEnemy {
        public required ulong UnitEnemy { get; set; }
    }
    public class SpellCastTargetFlagsUnitMinipet {
        public required ulong UnitMinipet { get; set; }
    }
    public class SpellCastTargetFlagsType {
        public required SpellCastTargetFlags Inner;
        public SpellCastTargetFlagsCorpseAllyMulti CorpseAlly;
        public SpellCastTargetFlagsDestLocation? DestLocation;
        public SpellCastTargetFlagsGameobjectMulti Gameobject;
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
            await w.WritePackedGuid(spellCastTargetFlagsUnitMinipet.UnitMinipet, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnitEnemy spellCastTargetFlagsUnitEnemy) {
            await w.WritePackedGuid(spellCastTargetFlagsUnitEnemy.UnitEnemy, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.Gameobject.Value is SpellCastTargetFlagsGameobject spellCastTargetFlagsGameobject) {
            await w.WritePackedGuid(spellCastTargetFlagsGameobject.Gameobject, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Gameobject.Value is SpellCastTargetFlagsLocked spellCastTargetFlagsLocked) {
            await w.WritePackedGuid(spellCastTargetFlagsLocked.Locked, cancellationToken).ConfigureAwait(false);

        }

        if (TargetFlags.Item.Value is SpellCastTargetFlagsItem spellCastTargetFlagsItem) {
            await w.WritePackedGuid(spellCastTargetFlagsItem.Item, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.Item.Value is SpellCastTargetFlagsTradeItem spellCastTargetFlagsTradeItem) {
            await w.WritePackedGuid(spellCastTargetFlagsTradeItem.TradeItem, cancellationToken).ConfigureAwait(false);

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

        if (TargetFlags.CorpseAlly.Value is SpellCastTargetFlagsCorpseAlly spellCastTargetFlagsCorpseAlly) {
            await w.WritePackedGuid(spellCastTargetFlagsCorpseAlly.CorpseAlly, cancellationToken).ConfigureAwait(false);

        }
        else if (TargetFlags.CorpseAlly.Value is SpellCastTargetFlagsCorpseEnemy spellCastTargetFlagsCorpseEnemy) {
            await w.WritePackedGuid(spellCastTargetFlagsCorpseEnemy.CorpseEnemy, cancellationToken).ConfigureAwait(false);

        }

    }

    public static async Task<SpellCastTargets> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var targetFlags = new SpellCastTargetFlagsType {
            Inner = (SpellCastTargetFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.Unit)) {
            var unitTarget = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsUnit {
                UnitTarget = unitTarget,
            };
        }
        else if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.UnitMinipet)) {
            var unitMinipet = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsUnitMinipet {
                UnitMinipet = unitMinipet,
            };
        }
        else if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.UnitEnemy)) {
            var unitEnemy = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Unit = new SpellCastTargetFlagsUnitEnemy {
                UnitEnemy = unitEnemy,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.Gameobject)) {
            var gameobject = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Gameobject = new SpellCastTargetFlagsGameobject {
                Gameobject = gameobject,
            };
        }
        else if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.Locked)) {
            var locked = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Gameobject = new SpellCastTargetFlagsLocked {
                Locked = locked,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.Item)) {
            var item = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Item = new SpellCastTargetFlagsItem {
                Item = item,
            };
        }
        else if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.TradeItem)) {
            var tradeItem = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.Item = new SpellCastTargetFlagsTradeItem {
                TradeItem = tradeItem,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.SourceLocation)) {
            var source = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            targetFlags.SourceLocation = new SpellCastTargetFlagsSourceLocation {
                Source = source,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.DestLocation)) {
            var destination = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            targetFlags.DestLocation = new SpellCastTargetFlagsDestLocation {
                Destination = destination,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.String)) {
            var targetString = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            targetFlags.String = new SpellCastTargetFlagsString {
                TargetString = targetString,
            };
        }

        if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.CorpseAlly)) {
            var corpseAlly = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.CorpseAlly = new SpellCastTargetFlagsCorpseAlly {
                CorpseAlly = corpseAlly,
            };
        }
        else if (targetFlags.Inner.HasFlag(Tbc.SpellCastTargetFlags.CorpseEnemy)) {
            var corpseEnemy = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            targetFlags.CorpseAlly = new SpellCastTargetFlagsCorpseEnemy {
                CorpseEnemy = corpseEnemy,
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
            // unit_minipet: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsUnitMinipet.UnitMinipet.PackedGuidLength();

        }
        else if (TargetFlags.Unit.Value is SpellCastTargetFlagsUnitEnemy spellCastTargetFlagsUnitEnemy) {
            // unit_enemy: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsUnitEnemy.UnitEnemy.PackedGuidLength();

        }

        if (TargetFlags.Gameobject.Value is SpellCastTargetFlagsGameobject spellCastTargetFlagsGameobject) {
            // gameobject: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsGameobject.Gameobject.PackedGuidLength();

        }
        else if (TargetFlags.Gameobject.Value is SpellCastTargetFlagsLocked spellCastTargetFlagsLocked) {
            // locked: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsLocked.Locked.PackedGuidLength();

        }

        if (TargetFlags.Item.Value is SpellCastTargetFlagsItem spellCastTargetFlagsItem) {
            // item: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsItem.Item.PackedGuidLength();

        }
        else if (TargetFlags.Item.Value is SpellCastTargetFlagsTradeItem spellCastTargetFlagsTradeItem) {
            // trade_item: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsTradeItem.TradeItem.PackedGuidLength();

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

        if (TargetFlags.CorpseAlly.Value is SpellCastTargetFlagsCorpseAlly spellCastTargetFlagsCorpseAlly) {
            // corpse_ally: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsCorpseAlly.CorpseAlly.PackedGuidLength();

        }
        else if (TargetFlags.CorpseAlly.Value is SpellCastTargetFlagsCorpseEnemy spellCastTargetFlagsCorpseEnemy) {
            // corpse_enemy: Generator.Generated.DataTypePackedGuid
            size += spellCastTargetFlagsCorpseEnemy.CorpseEnemy.PackedGuidLength();

        }

        return size;
    }

}

