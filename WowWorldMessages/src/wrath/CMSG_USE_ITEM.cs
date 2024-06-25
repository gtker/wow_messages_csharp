using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ClientCastFlagsType = OneOf.OneOf<CMSG_USE_ITEM.ClientCastFlagsExtra, ClientCastFlags>;
using ClientMovementDataType = OneOf.OneOf<CMSG_USE_ITEM.ClientMovementDataPresent, ClientMovementData>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_USE_ITEM: WrathClientMessage, IWorldMessage {
    public class ClientCastFlagsExtra {
        public required float Elevation { get; set; }
        public required ClientMovementDataType MovementData { get; set; }
        internal ClientMovementData MovementDataValue => MovementData.Match(
            _ => Wrath.ClientMovementData.Present,
            v => v
        );
        public required float Speed { get; set; }
    }
    public class ClientMovementDataPresent {
        public required ulong Guid { get; set; }
        public required MovementInfo Info { get; set; }
        public required uint Opcode { get; set; }
    }
    public required byte BagIndex { get; set; }
    public required byte BagSlot { get; set; }
    public required byte SpellIndex { get; set; }
    /// <summary>
    /// mangosone: next cast if exists (single or not)
    /// </summary>
    public required byte CastCount { get; set; }
    public required uint Spell { get; set; }
    public required ulong Item { get; set; }
    public required uint GlyphIndex { get; set; }
    public required ClientCastFlagsType CastFlags { get; set; }
    internal ClientCastFlags CastFlagsValue => CastFlags.Match(
        _ => Wrath.ClientCastFlags.Extra,
        v => v
    );
    public required SpellCastTargets Targets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(BagIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(BagSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SpellIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(CastCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(GlyphIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)CastFlagsValue, cancellationToken).ConfigureAwait(false);

        if (CastFlags.Value is CMSG_USE_ITEM.ClientCastFlagsExtra clientCastFlagsExtra) {
            await w.WriteFloat(clientCastFlagsExtra.Elevation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(clientCastFlagsExtra.Speed, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)clientCastFlagsExtra.MovementDataValue, cancellationToken).ConfigureAwait(false);

            if (clientCastFlagsExtra.MovementData.Value is CMSG_USE_ITEM.ClientMovementDataPresent clientMovementDataPresent) {
                await w.WriteUInt(clientMovementDataPresent.Opcode, cancellationToken).ConfigureAwait(false);

                await w.WritePackedGuid(clientMovementDataPresent.Guid, cancellationToken).ConfigureAwait(false);

                await clientMovementDataPresent.Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            }

        }

        await Targets.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 171, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 171, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_USE_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var bagIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var bagSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spellIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var castCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var glyphIndex = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        ClientCastFlagsType castFlags = (Wrath.ClientCastFlags)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (castFlags.Value is Wrath.ClientCastFlags.Extra) {
            var elevation = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var speed = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            ClientMovementDataType movementData = (Wrath.ClientMovementData)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            if (movementData.Value is Wrath.ClientMovementData.Present) {
                var opcode = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

                var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

                var info = await MovementInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

                movementData = new ClientMovementDataPresent {
                    Guid = guid,
                    Info = info,
                    Opcode = opcode,
                };
            }

            castFlags = new ClientCastFlagsExtra {
                Elevation = elevation,
                MovementData = movementData,
                Speed = speed,
            };
        }

        var targets = await SpellCastTargets.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_USE_ITEM {
            BagIndex = bagIndex,
            BagSlot = bagSlot,
            SpellIndex = spellIndex,
            CastCount = castCount,
            Spell = spell,
            Item = item,
            GlyphIndex = glyphIndex,
            CastFlags = castFlags,
            Targets = targets,
        };
    }

    internal int Size() {
        var size = 0;

        // bag_index: Generator.Generated.DataTypeInteger
        size += 1;

        // bag_slot: Generator.Generated.DataTypeInteger
        size += 1;

        // spell_index: Generator.Generated.DataTypeInteger
        size += 1;

        // cast_count: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // item: Generator.Generated.DataTypeGuid
        size += 8;

        // glyph_index: Generator.Generated.DataTypeInteger
        size += 4;

        // cast_flags: Generator.Generated.DataTypeEnum
        size += 1;

        if (CastFlags.Value is CMSG_USE_ITEM.ClientCastFlagsExtra clientCastFlagsExtra) {
            // elevation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // movement_data: Generator.Generated.DataTypeEnum
            size += 1;

            if (clientCastFlagsExtra.MovementData.Value is CMSG_USE_ITEM.ClientMovementDataPresent clientMovementDataPresent) {
                // opcode: Generator.Generated.DataTypeInteger
                size += 4;

                // guid: Generator.Generated.DataTypePackedGuid
                size += clientMovementDataPresent.Guid.PackedGuidLength();

                // info: Generator.Generated.DataTypeStruct
                size += clientMovementDataPresent.Info.Size();

            }

        }

        // targets: Generator.Generated.DataTypeStruct
        size += Targets.Size();

        return size;
    }

}

