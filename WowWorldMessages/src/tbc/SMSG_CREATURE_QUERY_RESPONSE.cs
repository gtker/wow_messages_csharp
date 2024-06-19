using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CREATURE_QUERY_RESPONSE: TbcServerMessage, IWorldMessage {
    /// <summary>
    /// When the `found` optional is not present all emulators bitwise OR the entry with `0x80000000`.``
    /// </summary>
    public required uint CreatureEntry { get; set; }
    public struct OptionalFound {
        public required string Name1 { get; set; }
        public required string Name2 { get; set; }
        public required string Name3 { get; set; }
        public required string Name4 { get; set; }
        public required string SubName { get; set; }
        /// <summary>
        /// mangosone: 'Directions' for guard, string for Icons 2.3.0
        /// </summary>
        public required string Description { get; set; }
        public required uint TypeFlags { get; set; }
        /// <summary>
        /// mangosone: CreatureType.dbc   wdbFeild8
        /// </summary>
        public required uint CreatureType { get; set; }
        public required Tbc.CreatureFamily CreatureFamily { get; set; }
        /// <summary>
        /// mangosone: Creature Rank (elite, boss, etc)
        /// </summary>
        public required uint CreatureRank { get; set; }
        /// <summary>
        /// mangosone: wdbFeild11
        /// </summary>
        public required uint Unknown0 { get; set; }
        /// <summary>
        /// mangosone: Id from CreatureSpellData.dbc wdbField12
        /// </summary>
        public required uint SpellDataId { get; set; }
        public const int DisplayIdsLength = 4;
        public required uint[] DisplayIds { get; set; }
        public required float HealthMultiplier { get; set; }
        public required float ManaMultiplier { get; set; }
        public required byte RacialLeader { get; set; }
    }
    public required OptionalFound? Found { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(CreatureEntry, cancellationToken).ConfigureAwait(false);

        if (Found is { } found) {
            await w.WriteCString(found.Name1, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(found.Name2, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(found.Name3, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(found.Name4, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(found.SubName, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(found.Description, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(found.TypeFlags, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(found.CreatureType, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)found.CreatureFamily, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(found.CreatureRank, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(found.Unknown0, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(found.SpellDataId, cancellationToken).ConfigureAwait(false);

            foreach (var v in found.DisplayIds) {
                await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteFloat(found.HealthMultiplier, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(found.ManaMultiplier, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(found.RacialLeader, cancellationToken).ConfigureAwait(false);

        }
    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 97, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 97, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CREATURE_QUERY_RESPONSE> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var creatureEntry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        OptionalFound? optionalFound = null;
        if (__size < bodySize) {
            var name1 = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += name1.Length + 1;

            var name2 = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += name2.Length + 1;

            var name3 = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += name3.Length + 1;

            var name4 = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += name4.Length + 1;

            var subName = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += subName.Length + 1;

            var description = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            __size += description.Length + 1;

            var typeFlags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var creatureType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var creatureFamily = (Tbc.CreatureFamily)await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var creatureRank = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var unknown0 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var spellDataId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var displayIds = new uint[OptionalFound.DisplayIdsLength];
            for (var i = 0; i < OptionalFound.DisplayIdsLength; ++i) {
                displayIds[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
                __size += 4;
            }

            var healthMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var manaMultiplier = await r.ReadFloat(cancellationToken).ConfigureAwait(false);
            __size += 4;

            var racialLeader = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            __size += 1;

            optionalFound = new OptionalFound {
                Name1 = name1,
                Name2 = name2,
                Name3 = name3,
                Name4 = name4,
                SubName = subName,
                Description = description,
                TypeFlags = typeFlags,
                CreatureType = creatureType,
                CreatureFamily = creatureFamily,
                CreatureRank = creatureRank,
                Unknown0 = unknown0,
                SpellDataId = spellDataId,
                DisplayIds = displayIds,
                HealthMultiplier = healthMultiplier,
                ManaMultiplier = manaMultiplier,
                RacialLeader = racialLeader,
            };
        }

        return new SMSG_CREATURE_QUERY_RESPONSE {
            CreatureEntry = creatureEntry,
            Found = optionalFound,
        };
    }

    internal int Size() {
        var size = 0;

        // creature_entry: Generator.Generated.DataTypeInteger
        size += 4;

        if (Found is { } found) {
            // name1: Generator.Generated.DataTypeCstring
            size += found.Name1.Length + 1;

            // name2: Generator.Generated.DataTypeCstring
            size += found.Name2.Length + 1;

            // name3: Generator.Generated.DataTypeCstring
            size += found.Name3.Length + 1;

            // name4: Generator.Generated.DataTypeCstring
            size += found.Name4.Length + 1;

            // sub_name: Generator.Generated.DataTypeCstring
            size += found.SubName.Length + 1;

            // description: Generator.Generated.DataTypeCstring
            size += found.Description.Length + 1;

            // type_flags: Generator.Generated.DataTypeInteger
            size += 4;

            // creature_type: Generator.Generated.DataTypeInteger
            size += 4;

            // creature_family: Generator.Generated.DataTypeEnum
            size += 4;

            // creature_rank: Generator.Generated.DataTypeInteger
            size += 4;

            // unknown0: Generator.Generated.DataTypeInteger
            size += 4;

            // spell_data_id: Generator.Generated.DataTypeInteger
            size += 4;

            // display_ids: Generator.Generated.DataTypeArray
            size += found.DisplayIds.Sum(e => 4);

            // health_multiplier: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // mana_multiplier: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // racial_leader: Generator.Generated.DataTypeInteger
            size += 1;

        }
        return size;
    }

}

