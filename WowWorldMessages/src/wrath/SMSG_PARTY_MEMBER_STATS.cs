using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PARTY_MEMBER_STATS: WrathServerMessage, IWorldMessage {
    public class GroupUpdateFlagsType {
        public required GroupUpdateFlags Inner;
        public GroupUpdateFlagsAuras? Auras;
        public GroupUpdateFlagsCurHp? CurHp;
        public GroupUpdateFlagsCurPower? CurPower;
        public GroupUpdateFlagsLevel? Level;
        public GroupUpdateFlagsMaxHp? MaxHp;
        public GroupUpdateFlagsMaxPower? MaxPower;
        public GroupUpdateFlagsPetAuras? PetAuras;
        public GroupUpdateFlagsPetCurHp? PetCurHp;
        public GroupUpdateFlagsPetCurPower? PetCurPower;
        public GroupUpdateFlagsPetGuid? PetGuid;
        public GroupUpdateFlagsPetMaxHp? PetMaxHp;
        public GroupUpdateFlagsPetMaxPower? PetMaxPower;
        public GroupUpdateFlagsPetModelId? PetModelId;
        public GroupUpdateFlagsPetName? PetName;
        public GroupUpdateFlagsPetPowerType? PetPowerType;
        public GroupUpdateFlagsPosition? Position;
        public GroupUpdateFlagsPowerType? PowerType;
        public GroupUpdateFlagsStatus? Status;
        public GroupUpdateFlagsVehicleSeat? VehicleSeat;
        public GroupUpdateFlagsZone? Zone;
    }
    public class GroupUpdateFlagsAuras {
        /// <summary>
        /// cmangos: In all checked pre-2.x data of packets included only positive auras
        /// </summary>
        public required AuraMask Auras { get; set; }
    }
    public class GroupUpdateFlagsCurHp {
        public required uint CurrentHealth { get; set; }
    }
    public class GroupUpdateFlagsCurPower {
        public required ushort CurrentPower { get; set; }
    }
    public class GroupUpdateFlagsLevel {
        public required ushort Level { get; set; }
    }
    public class GroupUpdateFlagsMaxHp {
        public required uint MaxHealth { get; set; }
    }
    public class GroupUpdateFlagsMaxPower {
        public required ushort MaxPower { get; set; }
    }
    public class GroupUpdateFlagsPetAuras {
        public required AuraMask PetAuras { get; set; }
    }
    public class GroupUpdateFlagsPetCurHp {
        public required uint PetCurrentHealth { get; set; }
    }
    public class GroupUpdateFlagsPetCurPower {
        public required ushort PetCurrentPower { get; set; }
    }
    public class GroupUpdateFlagsPetGuid {
        public required ulong Pet { get; set; }
    }
    public class GroupUpdateFlagsPetMaxHp {
        public required uint PetMaxHealth { get; set; }
    }
    public class GroupUpdateFlagsPetMaxPower {
        public required ushort PetMaxPower { get; set; }
    }
    public class GroupUpdateFlagsPetModelId {
        public required ushort PetDisplayId { get; set; }
    }
    public class GroupUpdateFlagsPetName {
        public required string PetName { get; set; }
    }
    public class GroupUpdateFlagsPetPowerType {
        public required Wrath.Power PetPowerType { get; set; }
    }
    public class GroupUpdateFlagsPosition {
        /// <summary>
        /// cmangos: float cast to u16
        /// </summary>
        public required ushort PositionX { get; set; }
        /// <summary>
        /// cmangos: float cast to u16
        /// </summary>
        public required ushort PositionY { get; set; }
    }
    public class GroupUpdateFlagsPowerType {
        public required Wrath.Power Power { get; set; }
    }
    public class GroupUpdateFlagsStatus {
        public required Wrath.GroupMemberOnlineStatus Status { get; set; }
    }
    public class GroupUpdateFlagsVehicleSeat {
        public required uint Transport { get; set; }
    }
    public class GroupUpdateFlagsZone {
        public required Wrath.Area Area { get; set; }
    }
    public required ulong Guid { get; set; }
    public required GroupUpdateFlagsType Mask { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Mask.Inner, cancellationToken).ConfigureAwait(false);

        if (Mask.Status is {} groupUpdateFlagsStatus) {
            await w.WriteByte((byte)groupUpdateFlagsStatus.Status, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.CurHp is {} groupUpdateFlagsCurHp) {
            await w.WriteUInt(groupUpdateFlagsCurHp.CurrentHealth, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.MaxHp is {} groupUpdateFlagsMaxHp) {
            await w.WriteUInt(groupUpdateFlagsMaxHp.MaxHealth, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PowerType is {} groupUpdateFlagsPowerType) {
            await w.WriteByte((byte)groupUpdateFlagsPowerType.Power, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.CurPower is {} groupUpdateFlagsCurPower) {
            await w.WriteUShort(groupUpdateFlagsCurPower.CurrentPower, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.MaxPower is {} groupUpdateFlagsMaxPower) {
            await w.WriteUShort(groupUpdateFlagsMaxPower.MaxPower, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.Level is {} groupUpdateFlagsLevel) {
            await w.WriteUShort(groupUpdateFlagsLevel.Level, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.Zone is {} groupUpdateFlagsZone) {
            await w.WriteUInt((uint)groupUpdateFlagsZone.Area, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.Position is {} groupUpdateFlagsPosition) {
            await w.WriteUShort(groupUpdateFlagsPosition.PositionX, cancellationToken).ConfigureAwait(false);

            await w.WriteUShort(groupUpdateFlagsPosition.PositionY, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.Auras is {} groupUpdateFlagsAuras) {
            await groupUpdateFlagsAuras.Auras.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetGuid is {} groupUpdateFlagsPetGuid) {
            await w.WriteULong(groupUpdateFlagsPetGuid.Pet, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetName is {} groupUpdateFlagsPetName) {
            await w.WriteCString(groupUpdateFlagsPetName.PetName, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetModelId is {} groupUpdateFlagsPetModelId) {
            await w.WriteUShort(groupUpdateFlagsPetModelId.PetDisplayId, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetCurHp is {} groupUpdateFlagsPetCurHp) {
            await w.WriteUInt(groupUpdateFlagsPetCurHp.PetCurrentHealth, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetMaxHp is {} groupUpdateFlagsPetMaxHp) {
            await w.WriteUInt(groupUpdateFlagsPetMaxHp.PetMaxHealth, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetPowerType is {} groupUpdateFlagsPetPowerType) {
            await w.WriteByte((byte)groupUpdateFlagsPetPowerType.PetPowerType, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetCurPower is {} groupUpdateFlagsPetCurPower) {
            await w.WriteUShort(groupUpdateFlagsPetCurPower.PetCurrentPower, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetMaxPower is {} groupUpdateFlagsPetMaxPower) {
            await w.WriteUShort(groupUpdateFlagsPetMaxPower.PetMaxPower, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.PetAuras is {} groupUpdateFlagsPetAuras) {
            await groupUpdateFlagsPetAuras.PetAuras.WriteAsync(w, cancellationToken).ConfigureAwait(false);

        }

        if (Mask.VehicleSeat is {} groupUpdateFlagsVehicleSeat) {
            await w.WriteUInt(groupUpdateFlagsVehicleSeat.Transport, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 126, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 126, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PARTY_MEMBER_STATS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var mask = new GroupUpdateFlagsType {
            Inner = (GroupUpdateFlags)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.Status)) {
            var status = (GroupMemberOnlineStatus)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            mask.Status = new GroupUpdateFlagsStatus {
                Status = status,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.CurHp)) {
            var currentHealth = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.CurHp = new GroupUpdateFlagsCurHp {
                CurrentHealth = currentHealth,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.MaxHp)) {
            var maxHealth = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.MaxHp = new GroupUpdateFlagsMaxHp {
                MaxHealth = maxHealth,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PowerType)) {
            var power = (Wrath.Power)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            mask.PowerType = new GroupUpdateFlagsPowerType {
                Power = power,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.CurPower)) {
            var currentPower = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.CurPower = new GroupUpdateFlagsCurPower {
                CurrentPower = currentPower,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.MaxPower)) {
            var maxPower = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.MaxPower = new GroupUpdateFlagsMaxPower {
                MaxPower = maxPower,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.Level)) {
            var level = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.Level = new GroupUpdateFlagsLevel {
                Level = level,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.Zone)) {
            var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.Zone = new GroupUpdateFlagsZone {
                Area = area,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.Position)) {
            var positionX = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            var positionY = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.Position = new GroupUpdateFlagsPosition {
                PositionX = positionX,
                PositionY = positionY,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.Auras)) {
            var auras = await AuraMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);

            mask.Auras = new GroupUpdateFlagsAuras {
                Auras = auras,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetGuid)) {
            var pet = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            mask.PetGuid = new GroupUpdateFlagsPetGuid {
                Pet = pet,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetName)) {
            var petName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            mask.PetName = new GroupUpdateFlagsPetName {
                PetName = petName,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetModelId)) {
            var petDisplayId = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.PetModelId = new GroupUpdateFlagsPetModelId {
                PetDisplayId = petDisplayId,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetCurHp)) {
            var petCurrentHealth = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.PetCurHp = new GroupUpdateFlagsPetCurHp {
                PetCurrentHealth = petCurrentHealth,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetMaxHp)) {
            var petMaxHealth = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.PetMaxHp = new GroupUpdateFlagsPetMaxHp {
                PetMaxHealth = petMaxHealth,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetPowerType)) {
            var petPowerType = (Wrath.Power)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            mask.PetPowerType = new GroupUpdateFlagsPetPowerType {
                PetPowerType = petPowerType,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetCurPower)) {
            var petCurrentPower = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.PetCurPower = new GroupUpdateFlagsPetCurPower {
                PetCurrentPower = petCurrentPower,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetMaxPower)) {
            var petMaxPower = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            mask.PetMaxPower = new GroupUpdateFlagsPetMaxPower {
                PetMaxPower = petMaxPower,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.PetAuras)) {
            var petAuras = await AuraMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);

            mask.PetAuras = new GroupUpdateFlagsPetAuras {
                PetAuras = petAuras,
            };
        }

        if (mask.Inner.HasFlag(Wrath.GroupUpdateFlags.VehicleSeat)) {
            var transport = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            mask.VehicleSeat = new GroupUpdateFlagsVehicleSeat {
                Transport = transport,
            };
        }

        return new SMSG_PARTY_MEMBER_STATS {
            Guid = guid,
            Mask = mask,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // mask: Generator.Generated.DataTypeFlag
        size += 4;

        if (Mask.Status is {} groupUpdateFlagsStatus) {
            // status: Generator.Generated.DataTypeFlag
            size += 1;

        }

        if (Mask.CurHp is {} groupUpdateFlagsCurHp) {
            // current_health: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Mask.MaxHp is {} groupUpdateFlagsMaxHp) {
            // max_health: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Mask.PowerType is {} groupUpdateFlagsPowerType) {
            // power: Generator.Generated.DataTypeEnum
            size += 1;

        }

        if (Mask.CurPower is {} groupUpdateFlagsCurPower) {
            // current_power: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.MaxPower is {} groupUpdateFlagsMaxPower) {
            // max_power: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.Level is {} groupUpdateFlagsLevel) {
            // level: Generator.Generated.DataTypeLevel16
            size += 2;

        }

        if (Mask.Zone is {} groupUpdateFlagsZone) {
            // area: Generator.Generated.DataTypeEnum
            size += 4;

        }

        if (Mask.Position is {} groupUpdateFlagsPosition) {
            // position_x: Generator.Generated.DataTypeInteger
            size += 2;

            // position_y: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.Auras is {} groupUpdateFlagsAuras) {
            // auras: Generator.Generated.DataTypeAuraMask
            size += groupUpdateFlagsAuras.Auras.Length();;

        }

        if (Mask.PetGuid is {} groupUpdateFlagsPetGuid) {
            // pet: Generator.Generated.DataTypeGuid
            size += 8;

        }

        if (Mask.PetName is {} groupUpdateFlagsPetName) {
            // pet_name: Generator.Generated.DataTypeCstring
            size += groupUpdateFlagsPetName.PetName.Length + 1;

        }

        if (Mask.PetModelId is {} groupUpdateFlagsPetModelId) {
            // pet_display_id: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.PetCurHp is {} groupUpdateFlagsPetCurHp) {
            // pet_current_health: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Mask.PetMaxHp is {} groupUpdateFlagsPetMaxHp) {
            // pet_max_health: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (Mask.PetPowerType is {} groupUpdateFlagsPetPowerType) {
            // pet_power_type: Generator.Generated.DataTypeEnum
            size += 1;

        }

        if (Mask.PetCurPower is {} groupUpdateFlagsPetCurPower) {
            // pet_current_power: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.PetMaxPower is {} groupUpdateFlagsPetMaxPower) {
            // pet_max_power: Generator.Generated.DataTypeInteger
            size += 2;

        }

        if (Mask.PetAuras is {} groupUpdateFlagsPetAuras) {
            // pet_auras: Generator.Generated.DataTypeAuraMask
            size += groupUpdateFlagsPetAuras.PetAuras.Length();;

        }

        if (Mask.VehicleSeat is {} groupUpdateFlagsVehicleSeat) {
            // transport: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

