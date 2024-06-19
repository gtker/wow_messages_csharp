namespace WowWorldMessages.Wrath;
public partial class UpdateMask {
    public void SetObjectGuid(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 0, value);
    }

    public void SetObjectType(uint value) {
        UpdateMaskUtils.AddUInt(_values, 2, value);
    }

    public void SetObjectEntry(uint value) {
        UpdateMaskUtils.AddUInt(_values, 3, value);
    }

    public void SetObjectScaleX(float value) {
        UpdateMaskUtils.AddFloat(_values, 4, value);
    }

    public void SetItemOwner(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetItemContained(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 8, value);
    }

    public void SetItemCreator(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 10, value);
    }

    public void SetItemGiftcreator(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 12, value);
    }

    public void SetItemStackCount(uint value) {
        UpdateMaskUtils.AddUInt(_values, 14, value);
    }

    public void SetItemDuration(uint value) {
        UpdateMaskUtils.AddUInt(_values, 15, value);
    }

    public void SetItemSpellCharges(uint value) {
        UpdateMaskUtils.AddUInt(_values, 16, value);
    }

    public void SetItemFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 21, value);
    }

    public void SetItemEnchantment11(uint value) {
        UpdateMaskUtils.AddUInt(_values, 22, value);
    }

    public void SetItemEnchantment13(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 24, a, b);
    }

    public void SetItemEnchantment21(uint value) {
        UpdateMaskUtils.AddUInt(_values, 25, value);
    }

    public void SetItemEnchantment23(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 27, a, b);
    }

    public void SetItemEnchantment31(uint value) {
        UpdateMaskUtils.AddUInt(_values, 28, value);
    }

    public void SetItemEnchantment33(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 30, a, b);
    }

    public void SetItemEnchantment41(uint value) {
        UpdateMaskUtils.AddUInt(_values, 31, value);
    }

    public void SetItemEnchantment43(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 33, a, b);
    }

    public void SetItemEnchantment51(uint value) {
        UpdateMaskUtils.AddUInt(_values, 34, value);
    }

    public void SetItemEnchantment53(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 36, a, b);
    }

    public void SetItemEnchantment61(uint value) {
        UpdateMaskUtils.AddUInt(_values, 37, value);
    }

    public void SetItemEnchantment63(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 39, a, b);
    }

    public void SetItemEnchantment71(uint value) {
        UpdateMaskUtils.AddUInt(_values, 40, value);
    }

    public void SetItemEnchantment73(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 42, a, b);
    }

    public void SetItemEnchantment81(uint value) {
        UpdateMaskUtils.AddUInt(_values, 43, value);
    }

    public void SetItemEnchantment83(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 45, a, b);
    }

    public void SetItemEnchantment91(uint value) {
        UpdateMaskUtils.AddUInt(_values, 46, value);
    }

    public void SetItemEnchantment93(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 48, a, b);
    }

    public void SetItemEnchantment101(uint value) {
        UpdateMaskUtils.AddUInt(_values, 49, value);
    }

    public void SetItemEnchantment103(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 51, a, b);
    }

    public void SetItemEnchantment111(uint value) {
        UpdateMaskUtils.AddUInt(_values, 52, value);
    }

    public void SetItemEnchantment113(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 54, a, b);
    }

    public void SetItemEnchantment121(uint value) {
        UpdateMaskUtils.AddUInt(_values, 55, value);
    }

    public void SetItemEnchantment123(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 57, a, b);
    }

    public void SetItemPropertySeed(uint value) {
        UpdateMaskUtils.AddUInt(_values, 58, value);
    }

    public void SetItemRandomPropertiesId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 59, value);
    }

    public void SetItemDurability(uint value) {
        UpdateMaskUtils.AddUInt(_values, 60, value);
    }

    public void SetItemMaxdurability(uint value) {
        UpdateMaskUtils.AddUInt(_values, 61, value);
    }

    public void SetItemCreatePlayedTime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 62, value);
    }

    public void SetContainerNumSlots(uint value) {
        UpdateMaskUtils.AddUInt(_values, 64, value);
    }

    public void SetContainerSlot1(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 66, value);
    }

    public void SetUnitCharm(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetUnitSummon(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 8, value);
    }

    public void SetUnitCritter(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 10, value);
    }

    public void SetUnitCharmedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 12, value);
    }

    public void SetUnitSummonedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 14, value);
    }

    public void SetUnitCreatedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 16, value);
    }

    public void SetUnitTarget(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 18, value);
    }

    public void SetUnitChannelObject(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 20, value);
    }

    public void SetUnitChannelSpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 22, value);
    }

    public void SetUnitBytes0(Race race, Class classType, Gender gender, Power power) {
        UpdateMaskUtils.AddBytes(_values, 23, (byte)race, (byte)classType, (byte)gender, (byte)power);
    }

    public void SetUnitHealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 24, value);
    }

    public void SetUnitPower1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 25, value);
    }

    public void SetUnitPower2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 26, value);
    }

    public void SetUnitPower3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 27, value);
    }

    public void SetUnitPower4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 28, value);
    }

    public void SetUnitPower5(uint value) {
        UpdateMaskUtils.AddUInt(_values, 29, value);
    }

    public void SetUnitPower6(uint value) {
        UpdateMaskUtils.AddUInt(_values, 30, value);
    }

    public void SetUnitPower7(uint value) {
        UpdateMaskUtils.AddUInt(_values, 31, value);
    }

    public void SetUnitMaxhealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 32, value);
    }

    public void SetUnitMaxpower1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 33, value);
    }

    public void SetUnitMaxpower2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 34, value);
    }

    public void SetUnitMaxpower3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 35, value);
    }

    public void SetUnitMaxpower4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 36, value);
    }

    public void SetUnitMaxpower5(uint value) {
        UpdateMaskUtils.AddUInt(_values, 37, value);
    }

    public void SetUnitMaxpower6(uint value) {
        UpdateMaskUtils.AddUInt(_values, 38, value);
    }

    public void SetUnitMaxpower7(uint value) {
        UpdateMaskUtils.AddUInt(_values, 39, value);
    }

    public void SetUnitPowerRegenFlatModifier(float value) {
        UpdateMaskUtils.AddFloat(_values, 40, value);
    }

    public void SetUnitPowerRegenInterruptedFlatModifier(float value) {
        UpdateMaskUtils.AddFloat(_values, 47, value);
    }

    public void SetUnitLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 54, value);
    }

    public void SetUnitFactiontemplate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 55, value);
    }

    public void SetUnitVirtualItemSlotId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 56, value);
    }

    public void SetUnitFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 59, value);
    }

    public void SetUnitFlags2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 60, value);
    }

    public void SetUnitAurastate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 61, value);
    }

    public void SetUnitBaseattacktime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 62, value);
    }

    public void SetUnitRangedattacktime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 64, value);
    }

    public void SetUnitBoundingradius(float value) {
        UpdateMaskUtils.AddFloat(_values, 65, value);
    }

    public void SetUnitCombatreach(float value) {
        UpdateMaskUtils.AddFloat(_values, 66, value);
    }

    public void SetUnitDisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 67, value);
    }

    public void SetUnitNativedisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 68, value);
    }

    public void SetUnitMountdisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 69, value);
    }

    public void SetUnitMindamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 70, value);
    }

    public void SetUnitMaxdamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 71, value);
    }

    public void SetUnitMinoffhanddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 72, value);
    }

    public void SetUnitMaxoffhanddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 73, value);
    }

    public void SetUnitBytes1(UnitStandState standState, byte unknown1, byte unknown2, byte unknown3) {
        UpdateMaskUtils.AddBytes(_values, 74, (byte)standState, unknown1, unknown2, unknown3);
    }

    public void SetUnitPetnumber(uint value) {
        UpdateMaskUtils.AddUInt(_values, 75, value);
    }

    public void SetUnitPetNameTimestamp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 76, value);
    }

    public void SetUnitPetexperience(uint value) {
        UpdateMaskUtils.AddUInt(_values, 77, value);
    }

    public void SetUnitPetnextlevelexp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 78, value);
    }

    public void SetUnitDynamicFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 79, value);
    }

    public void SetUnitModCastSpeed(float value) {
        UpdateMaskUtils.AddFloat(_values, 80, value);
    }

    public void SetUnitCreatedBySpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 81, value);
    }

    public void SetUnitNpcFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 82, value);
    }

    public void SetUnitNpcEmotestate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 83, value);
    }

    public void SetUnitStrength(uint value) {
        UpdateMaskUtils.AddUInt(_values, 84, value);
    }

    public void SetUnitAgility(uint value) {
        UpdateMaskUtils.AddUInt(_values, 85, value);
    }

    public void SetUnitStamina(uint value) {
        UpdateMaskUtils.AddUInt(_values, 86, value);
    }

    public void SetUnitIntellect(uint value) {
        UpdateMaskUtils.AddUInt(_values, 87, value);
    }

    public void SetUnitSpirit(uint value) {
        UpdateMaskUtils.AddUInt(_values, 88, value);
    }

    public void SetUnitPosstat0(uint value) {
        UpdateMaskUtils.AddUInt(_values, 89, value);
    }

    public void SetUnitPosstat1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 90, value);
    }

    public void SetUnitPosstat2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 91, value);
    }

    public void SetUnitPosstat3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 92, value);
    }

    public void SetUnitPosstat4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 93, value);
    }

    public void SetUnitNegstat0(uint value) {
        UpdateMaskUtils.AddUInt(_values, 94, value);
    }

    public void SetUnitNegstat1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 95, value);
    }

    public void SetUnitNegstat2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 96, value);
    }

    public void SetUnitNegstat3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 97, value);
    }

    public void SetUnitNegstat4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 98, value);
    }

    public void SetUnitResistances(uint value) {
        UpdateMaskUtils.AddUInt(_values, 99, value);
    }

    public void SetUnitResistancebuffmodspositive(uint value) {
        UpdateMaskUtils.AddUInt(_values, 106, value);
    }

    public void SetUnitResistancebuffmodsnegative(uint value) {
        UpdateMaskUtils.AddUInt(_values, 113, value);
    }

    public void SetUnitBaseMana(uint value) {
        UpdateMaskUtils.AddUInt(_values, 120, value);
    }

    public void SetUnitBaseHealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 121, value);
    }

    public void SetUnitBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 122, a, b, c, d);
    }

    public void SetUnitAttackPower(uint value) {
        UpdateMaskUtils.AddUInt(_values, 123, value);
    }

    public void SetUnitAttackPowerMods(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 124, a, b);
    }

    public void SetUnitAttackPowerMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 125, value);
    }

    public void SetUnitRangedAttackPower(uint value) {
        UpdateMaskUtils.AddUInt(_values, 126, value);
    }

    public void SetUnitRangedAttackPowerMods(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 127, a, b);
    }

    public void SetUnitRangedAttackPowerMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 128, value);
    }

    public void SetUnitMinrangeddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 129, value);
    }

    public void SetUnitMaxrangeddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 130, value);
    }

    public void SetUnitPowerCostModifier(uint value) {
        UpdateMaskUtils.AddUInt(_values, 131, value);
    }

    public void SetUnitPowerCostMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 138, value);
    }

    public void SetUnitMaxhealthmodifier(float value) {
        UpdateMaskUtils.AddFloat(_values, 145, value);
    }

    public void SetUnitHoverheight(float value) {
        UpdateMaskUtils.AddFloat(_values, 146, value);
    }

    public void SetPlayerDuelArbiter(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 148, value);
    }

    public void SetPlayerFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 150, value);
    }

    public void SetPlayerGuildid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 151, value);
    }

    public void SetPlayerGuildrank(uint value) {
        UpdateMaskUtils.AddUInt(_values, 152, value);
    }

    public void SetPlayerFieldBytes(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 153, a, b, c, d);
    }

    public void SetPlayerBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 154, a, b, c, d);
    }

    public void SetPlayerBytes3(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 155, a, b, c, d);
    }

    public void SetPlayerDuelTeam(uint value) {
        UpdateMaskUtils.AddUInt(_values, 156, value);
    }

    public void SetPlayerGuildTimestamp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 157, value);
    }

    public void SetPlayerQuestLog11(uint value) {
        UpdateMaskUtils.AddUInt(_values, 158, value);
    }

    public void SetPlayerQuestLog12(uint value) {
        UpdateMaskUtils.AddUInt(_values, 159, value);
    }

    public void SetPlayerQuestLog13(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 160, a, b);
    }

    public void SetPlayerQuestLog14(uint value) {
        UpdateMaskUtils.AddUInt(_values, 162, value);
    }

    public void SetPlayerQuestLog21(uint value) {
        UpdateMaskUtils.AddUInt(_values, 163, value);
    }

    public void SetPlayerQuestLog22(uint value) {
        UpdateMaskUtils.AddUInt(_values, 164, value);
    }

    public void SetPlayerQuestLog23(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 165, a, b);
    }

    public void SetPlayerQuestLog25(uint value) {
        UpdateMaskUtils.AddUInt(_values, 167, value);
    }

    public void SetPlayerQuestLog31(uint value) {
        UpdateMaskUtils.AddUInt(_values, 168, value);
    }

    public void SetPlayerQuestLog32(uint value) {
        UpdateMaskUtils.AddUInt(_values, 169, value);
    }

    public void SetPlayerQuestLog33(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 170, a, b);
    }

    public void SetPlayerQuestLog35(uint value) {
        UpdateMaskUtils.AddUInt(_values, 172, value);
    }

    public void SetPlayerQuestLog41(uint value) {
        UpdateMaskUtils.AddUInt(_values, 173, value);
    }

    public void SetPlayerQuestLog42(uint value) {
        UpdateMaskUtils.AddUInt(_values, 174, value);
    }

    public void SetPlayerQuestLog43(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 175, a, b);
    }

    public void SetPlayerQuestLog45(uint value) {
        UpdateMaskUtils.AddUInt(_values, 177, value);
    }

    public void SetPlayerQuestLog51(uint value) {
        UpdateMaskUtils.AddUInt(_values, 178, value);
    }

    public void SetPlayerQuestLog52(uint value) {
        UpdateMaskUtils.AddUInt(_values, 179, value);
    }

    public void SetPlayerQuestLog53(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 180, a, b);
    }

    public void SetPlayerQuestLog55(uint value) {
        UpdateMaskUtils.AddUInt(_values, 182, value);
    }

    public void SetPlayerQuestLog61(uint value) {
        UpdateMaskUtils.AddUInt(_values, 183, value);
    }

    public void SetPlayerQuestLog62(uint value) {
        UpdateMaskUtils.AddUInt(_values, 184, value);
    }

    public void SetPlayerQuestLog63(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 185, a, b);
    }

    public void SetPlayerQuestLog65(uint value) {
        UpdateMaskUtils.AddUInt(_values, 187, value);
    }

    public void SetPlayerQuestLog71(uint value) {
        UpdateMaskUtils.AddUInt(_values, 188, value);
    }

    public void SetPlayerQuestLog72(uint value) {
        UpdateMaskUtils.AddUInt(_values, 189, value);
    }

    public void SetPlayerQuestLog73(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 190, a, b);
    }

    public void SetPlayerQuestLog75(uint value) {
        UpdateMaskUtils.AddUInt(_values, 192, value);
    }

    public void SetPlayerQuestLog81(uint value) {
        UpdateMaskUtils.AddUInt(_values, 193, value);
    }

    public void SetPlayerQuestLog82(uint value) {
        UpdateMaskUtils.AddUInt(_values, 194, value);
    }

    public void SetPlayerQuestLog83(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 195, a, b);
    }

    public void SetPlayerQuestLog85(uint value) {
        UpdateMaskUtils.AddUInt(_values, 197, value);
    }

    public void SetPlayerQuestLog91(uint value) {
        UpdateMaskUtils.AddUInt(_values, 198, value);
    }

    public void SetPlayerQuestLog92(uint value) {
        UpdateMaskUtils.AddUInt(_values, 199, value);
    }

    public void SetPlayerQuestLog93(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 200, a, b);
    }

    public void SetPlayerQuestLog95(uint value) {
        UpdateMaskUtils.AddUInt(_values, 202, value);
    }

    public void SetPlayerQuestLog101(uint value) {
        UpdateMaskUtils.AddUInt(_values, 203, value);
    }

    public void SetPlayerQuestLog102(uint value) {
        UpdateMaskUtils.AddUInt(_values, 204, value);
    }

    public void SetPlayerQuestLog103(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 205, a, b);
    }

    public void SetPlayerQuestLog105(uint value) {
        UpdateMaskUtils.AddUInt(_values, 207, value);
    }

    public void SetPlayerQuestLog111(uint value) {
        UpdateMaskUtils.AddUInt(_values, 208, value);
    }

    public void SetPlayerQuestLog112(uint value) {
        UpdateMaskUtils.AddUInt(_values, 209, value);
    }

    public void SetPlayerQuestLog113(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 210, a, b);
    }

    public void SetPlayerQuestLog115(uint value) {
        UpdateMaskUtils.AddUInt(_values, 212, value);
    }

    public void SetPlayerQuestLog121(uint value) {
        UpdateMaskUtils.AddUInt(_values, 213, value);
    }

    public void SetPlayerQuestLog122(uint value) {
        UpdateMaskUtils.AddUInt(_values, 214, value);
    }

    public void SetPlayerQuestLog123(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 215, a, b);
    }

    public void SetPlayerQuestLog125(uint value) {
        UpdateMaskUtils.AddUInt(_values, 217, value);
    }

    public void SetPlayerQuestLog131(uint value) {
        UpdateMaskUtils.AddUInt(_values, 218, value);
    }

    public void SetPlayerQuestLog132(uint value) {
        UpdateMaskUtils.AddUInt(_values, 219, value);
    }

    public void SetPlayerQuestLog133(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 220, a, b);
    }

    public void SetPlayerQuestLog135(uint value) {
        UpdateMaskUtils.AddUInt(_values, 222, value);
    }

    public void SetPlayerQuestLog141(uint value) {
        UpdateMaskUtils.AddUInt(_values, 223, value);
    }

    public void SetPlayerQuestLog142(uint value) {
        UpdateMaskUtils.AddUInt(_values, 224, value);
    }

    public void SetPlayerQuestLog143(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 225, a, b);
    }

    public void SetPlayerQuestLog145(uint value) {
        UpdateMaskUtils.AddUInt(_values, 227, value);
    }

    public void SetPlayerQuestLog151(uint value) {
        UpdateMaskUtils.AddUInt(_values, 228, value);
    }

    public void SetPlayerQuestLog152(uint value) {
        UpdateMaskUtils.AddUInt(_values, 229, value);
    }

    public void SetPlayerQuestLog153(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 230, a, b);
    }

    public void SetPlayerQuestLog155(uint value) {
        UpdateMaskUtils.AddUInt(_values, 232, value);
    }

    public void SetPlayerQuestLog161(uint value) {
        UpdateMaskUtils.AddUInt(_values, 233, value);
    }

    public void SetPlayerQuestLog162(uint value) {
        UpdateMaskUtils.AddUInt(_values, 234, value);
    }

    public void SetPlayerQuestLog163(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 235, a, b);
    }

    public void SetPlayerQuestLog165(uint value) {
        UpdateMaskUtils.AddUInt(_values, 237, value);
    }

    public void SetPlayerQuestLog171(uint value) {
        UpdateMaskUtils.AddUInt(_values, 238, value);
    }

    public void SetPlayerQuestLog172(uint value) {
        UpdateMaskUtils.AddUInt(_values, 239, value);
    }

    public void SetPlayerQuestLog173(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 240, a, b);
    }

    public void SetPlayerQuestLog175(uint value) {
        UpdateMaskUtils.AddUInt(_values, 242, value);
    }

    public void SetPlayerQuestLog181(uint value) {
        UpdateMaskUtils.AddUInt(_values, 243, value);
    }

    public void SetPlayerQuestLog182(uint value) {
        UpdateMaskUtils.AddUInt(_values, 244, value);
    }

    public void SetPlayerQuestLog183(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 245, a, b);
    }

    public void SetPlayerQuestLog185(uint value) {
        UpdateMaskUtils.AddUInt(_values, 247, value);
    }

    public void SetPlayerQuestLog191(uint value) {
        UpdateMaskUtils.AddUInt(_values, 248, value);
    }

    public void SetPlayerQuestLog192(uint value) {
        UpdateMaskUtils.AddUInt(_values, 249, value);
    }

    public void SetPlayerQuestLog193(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 250, a, b);
    }

    public void SetPlayerQuestLog195(uint value) {
        UpdateMaskUtils.AddUInt(_values, 252, value);
    }

    public void SetPlayerQuestLog201(uint value) {
        UpdateMaskUtils.AddUInt(_values, 253, value);
    }

    public void SetPlayerQuestLog202(uint value) {
        UpdateMaskUtils.AddUInt(_values, 254, value);
    }

    public void SetPlayerQuestLog203(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 255, a, b);
    }

    public void SetPlayerQuestLog205(uint value) {
        UpdateMaskUtils.AddUInt(_values, 257, value);
    }

    public void SetPlayerQuestLog211(uint value) {
        UpdateMaskUtils.AddUInt(_values, 258, value);
    }

    public void SetPlayerQuestLog212(uint value) {
        UpdateMaskUtils.AddUInt(_values, 259, value);
    }

    public void SetPlayerQuestLog213(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 260, a, b);
    }

    public void SetPlayerQuestLog215(uint value) {
        UpdateMaskUtils.AddUInt(_values, 262, value);
    }

    public void SetPlayerQuestLog221(uint value) {
        UpdateMaskUtils.AddUInt(_values, 263, value);
    }

    public void SetPlayerQuestLog222(uint value) {
        UpdateMaskUtils.AddUInt(_values, 264, value);
    }

    public void SetPlayerQuestLog223(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 265, a, b);
    }

    public void SetPlayerQuestLog225(uint value) {
        UpdateMaskUtils.AddUInt(_values, 267, value);
    }

    public void SetPlayerQuestLog231(uint value) {
        UpdateMaskUtils.AddUInt(_values, 268, value);
    }

    public void SetPlayerQuestLog232(uint value) {
        UpdateMaskUtils.AddUInt(_values, 269, value);
    }

    public void SetPlayerQuestLog233(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 270, a, b);
    }

    public void SetPlayerQuestLog235(uint value) {
        UpdateMaskUtils.AddUInt(_values, 272, value);
    }

    public void SetPlayerQuestLog241(uint value) {
        UpdateMaskUtils.AddUInt(_values, 273, value);
    }

    public void SetPlayerQuestLog242(uint value) {
        UpdateMaskUtils.AddUInt(_values, 274, value);
    }

    public void SetPlayerQuestLog243(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 275, a, b);
    }

    public void SetPlayerQuestLog245(uint value) {
        UpdateMaskUtils.AddUInt(_values, 277, value);
    }

    public void SetPlayerQuestLog251(uint value) {
        UpdateMaskUtils.AddUInt(_values, 278, value);
    }

    public void SetPlayerQuestLog252(uint value) {
        UpdateMaskUtils.AddUInt(_values, 279, value);
    }

    public void SetPlayerQuestLog253(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 280, a, b);
    }

    public void SetPlayerQuestLog255(uint value) {
        UpdateMaskUtils.AddUInt(_values, 282, value);
    }

    public void SetPlayerChosenTitle(uint value) {
        UpdateMaskUtils.AddUInt(_values, 321, value);
    }

    public void SetPlayerFakeInebriation(uint value) {
        UpdateMaskUtils.AddUInt(_values, 322, value);
    }

    public void SetPlayerFarsight(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 624, value);
    }

    public void SetPlayerKnownTitles(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 626, value);
    }

    public void SetPlayerKnownTitles1(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 628, value);
    }

    public void SetPlayerKnownTitles2(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 630, value);
    }

    public void SetPlayerKnownCurrencies(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 632, value);
    }

    public void SetPlayerXp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 634, value);
    }

    public void SetPlayerNextLevelXp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 635, value);
    }

    public void SetPlayerCharacterPoints1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1020, value);
    }

    public void SetPlayerCharacterPoints2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1021, value);
    }

    public void SetPlayerTrackCreatures(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1022, value);
    }

    public void SetPlayerTrackResources(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1023, value);
    }

    public void SetPlayerBlockPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1024, value);
    }

    public void SetPlayerDodgePercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1025, value);
    }

    public void SetPlayerParryPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1026, value);
    }

    public void SetPlayerExpertise(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1027, value);
    }

    public void SetPlayerOffhandExpertise(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1028, value);
    }

    public void SetPlayerCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1029, value);
    }

    public void SetPlayerRangedCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1030, value);
    }

    public void SetPlayerOffhandCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1031, value);
    }

    public void SetPlayerSpellCritPercentage1(float value) {
        UpdateMaskUtils.AddFloat(_values, 1032, value);
    }

    public void SetPlayerShieldBlock(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1039, value);
    }

    public void SetPlayerShieldBlockCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1040, value);
    }

    public void SetPlayerExploredZones1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1041, a, b, c, d);
    }

    public void SetPlayerRestStateExperience(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1169, value);
    }

    public void SetPlayerCoinage(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1170, value);
    }

    public void SetPlayerModDamageDonePos(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1171, value);
    }

    public void SetPlayerModDamageDoneNeg(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1178, value);
    }

    public void SetPlayerModDamageDonePct(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1185, value);
    }

    public void SetPlayerModHealingDonePos(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1192, value);
    }

    public void SetPlayerModHealingPct(float value) {
        UpdateMaskUtils.AddFloat(_values, 1193, value);
    }

    public void SetPlayerModHealingDonePct(float value) {
        UpdateMaskUtils.AddFloat(_values, 1194, value);
    }

    public void SetPlayerModTargetResistance(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1195, value);
    }

    public void SetPlayerModTargetPhysicalResistance(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1196, value);
    }

    public void SetPlayerFeatures(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1197, a, b, c, d);
    }

    public void SetPlayerAmmoId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1198, value);
    }

    public void SetPlayerSelfResSpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1199, value);
    }

    public void SetPlayerPvpMedals(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1200, value);
    }

    public void SetPlayerBuybackPrice1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1201, value);
    }

    public void SetPlayerBuybackTimestamp1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1213, value);
    }

    public void SetPlayerKills(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 1225, a, b);
    }

    public void SetPlayerTodayContribution(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1226, value);
    }

    public void SetPlayerYesterdayContribution(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1227, value);
    }

    public void SetPlayerLifetimeHonorbaleKills(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1228, value);
    }

    public void SetPlayerBytes2Glow(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1229, a, b, c, d);
    }

    public void SetPlayerWatchedFactionIndex(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1230, value);
    }

    public void SetPlayerCombatRating1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1231, value);
    }

    public void SetPlayerArenaTeamInfo11(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1256, value);
    }

    public void SetPlayerHonorCurrency(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1277, value);
    }

    public void SetPlayerArenaCurrency(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1278, value);
    }

    public void SetPlayerMaxLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1279, value);
    }

    public void SetPlayerDailyQuests1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1280, value);
    }

    public void SetPlayerRuneRegen1(float value) {
        UpdateMaskUtils.AddFloat(_values, 1305, value);
    }

    public void SetPlayerNoReagentCost1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1309, value);
    }

    public void SetPlayerGlyphSlots1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1312, value);
    }

    public void SetPlayerGlyphs1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1318, value);
    }

    public void SetPlayerGlyphsEnabled(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1324, value);
    }

    public void SetPlayerPetSpellPower(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1325, value);
    }

    public void SetObjectCreatedBy(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetGameObjectDisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 8, value);
    }

    public void SetGameObjectFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 9, value);
    }

    public void SetGameObjectParentrotation(float value) {
        UpdateMaskUtils.AddFloat(_values, 10, value);
    }

    public void SetGameObjectDynamic(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 14, a, b);
    }

    public void SetGameObjectFaction(uint value) {
        UpdateMaskUtils.AddUInt(_values, 15, value);
    }

    public void SetGameObjectLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 16, value);
    }

    public void SetGameObjectBytes1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 17, a, b, c, d);
    }

    public void SetDynamicObjectCaster(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetDynamicObjectBytes(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 8, a, b, c, d);
    }

    public void SetDynamicObjectSpellid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 9, value);
    }

    public void SetDynamicObjectRadius(float value) {
        UpdateMaskUtils.AddFloat(_values, 10, value);
    }

    public void SetDynamicObjectCasttime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 11, value);
    }

    public void SetCorpseOwner(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetCorpseParty(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 8, value);
    }

    public void SetCorpseDisplayId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 10, value);
    }

    public void SetCorpseItem(uint value) {
        UpdateMaskUtils.AddUInt(_values, 11, value);
    }

    public void SetCorpseBytes1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 30, a, b, c, d);
    }

    public void SetCorpseBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 31, a, b, c, d);
    }

    public void SetCorpseGuild(uint value) {
        UpdateMaskUtils.AddUInt(_values, 32, value);
    }

    public void SetCorpseFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 33, value);
    }

    public void SetCorpseDynamicFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 34, value);
    }

}
