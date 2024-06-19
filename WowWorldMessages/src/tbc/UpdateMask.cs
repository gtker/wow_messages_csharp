namespace WowWorldMessages.Tbc;
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

    public void SetItemPropertySeed(uint value) {
        UpdateMaskUtils.AddUInt(_values, 55, value);
    }

    public void SetItemRandomPropertiesId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 56, value);
    }

    public void SetItemItemTextId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 57, value);
    }

    public void SetItemDurability(uint value) {
        UpdateMaskUtils.AddUInt(_values, 58, value);
    }

    public void SetItemMaxdurability(uint value) {
        UpdateMaskUtils.AddUInt(_values, 59, value);
    }

    public void SetContainerNumSlots(uint value) {
        UpdateMaskUtils.AddUInt(_values, 60, value);
    }

    public void SetContainerSlot1(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 62, value);
    }

    public void SetUnitCharm(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetUnitSummon(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 8, value);
    }

    public void SetUnitCharmedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 10, value);
    }

    public void SetUnitSummonedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 12, value);
    }

    public void SetUnitCreatedby(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 14, value);
    }

    public void SetUnitTarget(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 16, value);
    }

    public void SetUnitPersuaded(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 18, value);
    }

    public void SetUnitChannelObject(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 20, value);
    }

    public void SetUnitHealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 22, value);
    }

    public void SetUnitPower1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 23, value);
    }

    public void SetUnitPower2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 24, value);
    }

    public void SetUnitPower3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 25, value);
    }

    public void SetUnitPower4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 26, value);
    }

    public void SetUnitPower5(uint value) {
        UpdateMaskUtils.AddUInt(_values, 27, value);
    }

    public void SetUnitMaxhealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 28, value);
    }

    public void SetUnitMaxpower1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 29, value);
    }

    public void SetUnitMaxpower2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 30, value);
    }

    public void SetUnitMaxpower3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 31, value);
    }

    public void SetUnitMaxpower4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 32, value);
    }

    public void SetUnitMaxpower5(uint value) {
        UpdateMaskUtils.AddUInt(_values, 33, value);
    }

    public void SetUnitLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 34, value);
    }

    public void SetUnitFactiontemplate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 35, value);
    }

    public void SetUnitBytes0(Race race, Class classType, Gender gender, Power power) {
        UpdateMaskUtils.AddBytes(_values, 36, (byte)race, (byte)classType, (byte)gender, (byte)power);
    }

    public void SetUnitVirtualItemSlotDisplay(uint value) {
        UpdateMaskUtils.AddUInt(_values, 37, value);
    }

    public void SetUnitVirtualItemInfo(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 40, a, b, c, d);
    }

    public void SetUnitFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 46, value);
    }

    public void SetUnitFlags2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 47, value);
    }

    public void SetUnitAura(uint value) {
        UpdateMaskUtils.AddUInt(_values, 48, value);
    }

    public void SetUnitAuraflags(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 104, a, b, c, d);
    }

    public void SetUnitAuralevels(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 118, a, b, c, d);
    }

    public void SetUnitAuraapplications(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 132, a, b, c, d);
    }

    public void SetUnitAurastate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 146, value);
    }

    public void SetUnitBaseattacktime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 147, value);
    }

    public void SetUnitRangedattacktime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 149, value);
    }

    public void SetUnitBoundingradius(float value) {
        UpdateMaskUtils.AddFloat(_values, 150, value);
    }

    public void SetUnitCombatreach(float value) {
        UpdateMaskUtils.AddFloat(_values, 151, value);
    }

    public void SetUnitDisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 152, value);
    }

    public void SetUnitNativedisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 153, value);
    }

    public void SetUnitMountdisplayid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 154, value);
    }

    public void SetUnitMindamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 155, value);
    }

    public void SetUnitMaxdamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 156, value);
    }

    public void SetUnitMinoffhanddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 157, value);
    }

    public void SetUnitMaxoffhanddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 158, value);
    }

    public void SetUnitBytes1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 159, a, b, c, d);
    }

    public void SetUnitPetnumber(uint value) {
        UpdateMaskUtils.AddUInt(_values, 160, value);
    }

    public void SetUnitPetNameTimestamp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 161, value);
    }

    public void SetUnitPetexperience(uint value) {
        UpdateMaskUtils.AddUInt(_values, 162, value);
    }

    public void SetUnitPetnextlevelexp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 163, value);
    }

    public void SetUnitDynamicFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 164, value);
    }

    public void SetUnitChannelSpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 165, value);
    }

    public void SetUnitModCastSpeed(float value) {
        UpdateMaskUtils.AddFloat(_values, 166, value);
    }

    public void SetUnitCreatedBySpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 167, value);
    }

    public void SetUnitNpcFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 168, value);
    }

    public void SetUnitNpcEmotestate(uint value) {
        UpdateMaskUtils.AddUInt(_values, 169, value);
    }

    public void SetUnitTrainingPoints(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 170, a, b);
    }

    public void SetUnitStrength(uint value) {
        UpdateMaskUtils.AddUInt(_values, 171, value);
    }

    public void SetUnitAgility(uint value) {
        UpdateMaskUtils.AddUInt(_values, 172, value);
    }

    public void SetUnitStamina(uint value) {
        UpdateMaskUtils.AddUInt(_values, 173, value);
    }

    public void SetUnitIntellect(uint value) {
        UpdateMaskUtils.AddUInt(_values, 174, value);
    }

    public void SetUnitSpirit(uint value) {
        UpdateMaskUtils.AddUInt(_values, 175, value);
    }

    public void SetPlayerPosstat0(uint value) {
        UpdateMaskUtils.AddUInt(_values, 176, value);
    }

    public void SetUnitPosstat1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 177, value);
    }

    public void SetUnitPosstat2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 178, value);
    }

    public void SetUnitPosstat3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 179, value);
    }

    public void SetPlayerPosstat4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 180, value);
    }

    public void SetPlayerNegstat0(uint value) {
        UpdateMaskUtils.AddUInt(_values, 181, value);
    }

    public void SetUnitNegstat1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 182, value);
    }

    public void SetUnitNegstat2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 183, value);
    }

    public void SetUnitNegstat3(uint value) {
        UpdateMaskUtils.AddUInt(_values, 184, value);
    }

    public void SetPlayerNegstat4(uint value) {
        UpdateMaskUtils.AddUInt(_values, 185, value);
    }

    public void SetUnitResistances(uint value) {
        UpdateMaskUtils.AddUInt(_values, 186, value);
    }

    public void SetPlayerResistancebuffmodspositive(uint value) {
        UpdateMaskUtils.AddUInt(_values, 193, value);
    }

    public void SetPlayerResistancebuffmodsnegative(uint value) {
        UpdateMaskUtils.AddUInt(_values, 200, value);
    }

    public void SetUnitBaseMana(uint value) {
        UpdateMaskUtils.AddUInt(_values, 207, value);
    }

    public void SetUnitBaseHealth(uint value) {
        UpdateMaskUtils.AddUInt(_values, 208, value);
    }

    public void SetUnitBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 209, a, b, c, d);
    }

    public void SetUnitAttackPower(uint value) {
        UpdateMaskUtils.AddUInt(_values, 210, value);
    }

    public void SetUnitAttackPowerMods(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 211, a, b);
    }

    public void SetUnitAttackPowerMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 212, value);
    }

    public void SetUnitRangedAttackPower(uint value) {
        UpdateMaskUtils.AddUInt(_values, 213, value);
    }

    public void SetUnitRangedAttackPowerMods(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 214, a, b);
    }

    public void SetUnitRangedAttackPowerMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 215, value);
    }

    public void SetUnitMinrangeddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 216, value);
    }

    public void SetUnitMaxrangeddamage(float value) {
        UpdateMaskUtils.AddFloat(_values, 217, value);
    }

    public void SetUnitPowerCostModifier(uint value) {
        UpdateMaskUtils.AddUInt(_values, 218, value);
    }

    public void SetUnitPowerCostMultiplier(float value) {
        UpdateMaskUtils.AddFloat(_values, 225, value);
    }

    public void SetUnitMaxhealthmodifier(float value) {
        UpdateMaskUtils.AddFloat(_values, 232, value);
    }

    public void SetPlayerDuelArbiter(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 234, value);
    }

    public void SetPlayerFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 236, value);
    }

    public void SetPlayerGuildid(uint value) {
        UpdateMaskUtils.AddUInt(_values, 237, value);
    }

    public void SetPlayerGuildrank(uint value) {
        UpdateMaskUtils.AddUInt(_values, 238, value);
    }

    public void SetPlayerFieldBytes(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 239, a, b, c, d);
    }

    public void SetPlayerBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 240, a, b, c, d);
    }

    public void SetPlayerBytes3(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 241, a, b, c, d);
    }

    public void SetPlayerDuelTeam(uint value) {
        UpdateMaskUtils.AddUInt(_values, 242, value);
    }

    public void SetPlayerGuildTimestamp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 243, value);
    }

    public void SetPlayerQuestLog11(uint value) {
        UpdateMaskUtils.AddUInt(_values, 244, value);
    }

    public void SetPlayerQuestLog12(uint value) {
        UpdateMaskUtils.AddUInt(_values, 245, value);
    }

    public void SetPlayerQuestLog13(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 246, a, b, c, d);
    }

    public void SetPlayerQuestLog14(uint value) {
        UpdateMaskUtils.AddUInt(_values, 247, value);
    }

    public void SetPlayerQuestLog21(uint value) {
        UpdateMaskUtils.AddUInt(_values, 248, value);
    }

    public void SetPlayerQuestLog22(uint value) {
        UpdateMaskUtils.AddUInt(_values, 249, value);
    }

    public void SetPlayerQuestLog23(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 250, a, b, c, d);
    }

    public void SetPlayerQuestLog24(uint value) {
        UpdateMaskUtils.AddUInt(_values, 251, value);
    }

    public void SetPlayerQuestLog31(uint value) {
        UpdateMaskUtils.AddUInt(_values, 252, value);
    }

    public void SetPlayerQuestLog32(uint value) {
        UpdateMaskUtils.AddUInt(_values, 253, value);
    }

    public void SetPlayerQuestLog33(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 254, a, b, c, d);
    }

    public void SetPlayerQuestLog34(uint value) {
        UpdateMaskUtils.AddUInt(_values, 255, value);
    }

    public void SetPlayerQuestLog41(uint value) {
        UpdateMaskUtils.AddUInt(_values, 256, value);
    }

    public void SetPlayerQuestLog42(uint value) {
        UpdateMaskUtils.AddUInt(_values, 257, value);
    }

    public void SetPlayerQuestLog43(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 258, a, b, c, d);
    }

    public void SetPlayerQuestLog44(uint value) {
        UpdateMaskUtils.AddUInt(_values, 259, value);
    }

    public void SetPlayerQuestLog51(uint value) {
        UpdateMaskUtils.AddUInt(_values, 260, value);
    }

    public void SetPlayerQuestLog52(uint value) {
        UpdateMaskUtils.AddUInt(_values, 261, value);
    }

    public void SetPlayerQuestLog53(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 262, a, b, c, d);
    }

    public void SetPlayerQuestLog54(uint value) {
        UpdateMaskUtils.AddUInt(_values, 263, value);
    }

    public void SetPlayerQuestLog61(uint value) {
        UpdateMaskUtils.AddUInt(_values, 264, value);
    }

    public void SetPlayerQuestLog62(uint value) {
        UpdateMaskUtils.AddUInt(_values, 265, value);
    }

    public void SetPlayerQuestLog63(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 266, a, b, c, d);
    }

    public void SetPlayerQuestLog64(uint value) {
        UpdateMaskUtils.AddUInt(_values, 267, value);
    }

    public void SetPlayerQuestLog71(uint value) {
        UpdateMaskUtils.AddUInt(_values, 268, value);
    }

    public void SetPlayerQuestLog72(uint value) {
        UpdateMaskUtils.AddUInt(_values, 269, value);
    }

    public void SetPlayerQuestLog73(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 270, a, b, c, d);
    }

    public void SetPlayerQuestLog74(uint value) {
        UpdateMaskUtils.AddUInt(_values, 271, value);
    }

    public void SetPlayerQuestLog81(uint value) {
        UpdateMaskUtils.AddUInt(_values, 272, value);
    }

    public void SetPlayerQuestLog82(uint value) {
        UpdateMaskUtils.AddUInt(_values, 273, value);
    }

    public void SetPlayerQuestLog83(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 274, a, b, c, d);
    }

    public void SetPlayerQuestLog84(uint value) {
        UpdateMaskUtils.AddUInt(_values, 275, value);
    }

    public void SetPlayerQuestLog91(uint value) {
        UpdateMaskUtils.AddUInt(_values, 276, value);
    }

    public void SetPlayerQuestLog92(uint value) {
        UpdateMaskUtils.AddUInt(_values, 277, value);
    }

    public void SetPlayerQuestLog93(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 278, a, b, c, d);
    }

    public void SetPlayerQuestLog94(uint value) {
        UpdateMaskUtils.AddUInt(_values, 279, value);
    }

    public void SetPlayerQuestLog101(uint value) {
        UpdateMaskUtils.AddUInt(_values, 280, value);
    }

    public void SetPlayerQuestLog102(uint value) {
        UpdateMaskUtils.AddUInt(_values, 281, value);
    }

    public void SetPlayerQuestLog103(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 282, a, b, c, d);
    }

    public void SetPlayerQuestLog104(uint value) {
        UpdateMaskUtils.AddUInt(_values, 283, value);
    }

    public void SetPlayerQuestLog111(uint value) {
        UpdateMaskUtils.AddUInt(_values, 284, value);
    }

    public void SetPlayerQuestLog112(uint value) {
        UpdateMaskUtils.AddUInt(_values, 285, value);
    }

    public void SetPlayerQuestLog113(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 286, a, b, c, d);
    }

    public void SetPlayerQuestLog114(uint value) {
        UpdateMaskUtils.AddUInt(_values, 287, value);
    }

    public void SetPlayerQuestLog121(uint value) {
        UpdateMaskUtils.AddUInt(_values, 288, value);
    }

    public void SetPlayerQuestLog122(uint value) {
        UpdateMaskUtils.AddUInt(_values, 289, value);
    }

    public void SetPlayerQuestLog123(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 290, a, b, c, d);
    }

    public void SetPlayerQuestLog124(uint value) {
        UpdateMaskUtils.AddUInt(_values, 291, value);
    }

    public void SetPlayerQuestLog131(uint value) {
        UpdateMaskUtils.AddUInt(_values, 292, value);
    }

    public void SetPlayerQuestLog132(uint value) {
        UpdateMaskUtils.AddUInt(_values, 293, value);
    }

    public void SetPlayerQuestLog133(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 294, a, b, c, d);
    }

    public void SetPlayerQuestLog134(uint value) {
        UpdateMaskUtils.AddUInt(_values, 295, value);
    }

    public void SetPlayerQuestLog141(uint value) {
        UpdateMaskUtils.AddUInt(_values, 296, value);
    }

    public void SetPlayerQuestLog142(uint value) {
        UpdateMaskUtils.AddUInt(_values, 297, value);
    }

    public void SetPlayerQuestLog143(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 298, a, b, c, d);
    }

    public void SetPlayerQuestLog144(uint value) {
        UpdateMaskUtils.AddUInt(_values, 299, value);
    }

    public void SetPlayerQuestLog151(uint value) {
        UpdateMaskUtils.AddUInt(_values, 300, value);
    }

    public void SetPlayerQuestLog152(uint value) {
        UpdateMaskUtils.AddUInt(_values, 301, value);
    }

    public void SetPlayerQuestLog153(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 302, a, b, c, d);
    }

    public void SetPlayerQuestLog154(uint value) {
        UpdateMaskUtils.AddUInt(_values, 303, value);
    }

    public void SetPlayerQuestLog161(uint value) {
        UpdateMaskUtils.AddUInt(_values, 304, value);
    }

    public void SetPlayerQuestLog162(uint value) {
        UpdateMaskUtils.AddUInt(_values, 305, value);
    }

    public void SetPlayerQuestLog163(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 306, a, b, c, d);
    }

    public void SetPlayerQuestLog164(uint value) {
        UpdateMaskUtils.AddUInt(_values, 307, value);
    }

    public void SetPlayerQuestLog171(uint value) {
        UpdateMaskUtils.AddUInt(_values, 308, value);
    }

    public void SetPlayerQuestLog172(uint value) {
        UpdateMaskUtils.AddUInt(_values, 309, value);
    }

    public void SetPlayerQuestLog173(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 310, a, b, c, d);
    }

    public void SetPlayerQuestLog174(uint value) {
        UpdateMaskUtils.AddUInt(_values, 311, value);
    }

    public void SetPlayerQuestLog181(uint value) {
        UpdateMaskUtils.AddUInt(_values, 312, value);
    }

    public void SetPlayerQuestLog182(uint value) {
        UpdateMaskUtils.AddUInt(_values, 313, value);
    }

    public void SetPlayerQuestLog183(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 314, a, b, c, d);
    }

    public void SetPlayerQuestLog184(uint value) {
        UpdateMaskUtils.AddUInt(_values, 315, value);
    }

    public void SetPlayerQuestLog191(uint value) {
        UpdateMaskUtils.AddUInt(_values, 316, value);
    }

    public void SetPlayerQuestLog192(uint value) {
        UpdateMaskUtils.AddUInt(_values, 317, value);
    }

    public void SetPlayerQuestLog193(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 318, a, b, c, d);
    }

    public void SetPlayerQuestLog194(uint value) {
        UpdateMaskUtils.AddUInt(_values, 319, value);
    }

    public void SetPlayerQuestLog201(uint value) {
        UpdateMaskUtils.AddUInt(_values, 320, value);
    }

    public void SetPlayerQuestLog202(uint value) {
        UpdateMaskUtils.AddUInt(_values, 321, value);
    }

    public void SetPlayerQuestLog203(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 322, a, b, c, d);
    }

    public void SetPlayerQuestLog204(uint value) {
        UpdateMaskUtils.AddUInt(_values, 323, value);
    }

    public void SetPlayerQuestLog211(uint value) {
        UpdateMaskUtils.AddUInt(_values, 324, value);
    }

    public void SetPlayerQuestLog212(uint value) {
        UpdateMaskUtils.AddUInt(_values, 325, value);
    }

    public void SetPlayerQuestLog213(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 326, a, b, c, d);
    }

    public void SetPlayerQuestLog214(uint value) {
        UpdateMaskUtils.AddUInt(_values, 327, value);
    }

    public void SetPlayerQuestLog221(uint value) {
        UpdateMaskUtils.AddUInt(_values, 328, value);
    }

    public void SetPlayerQuestLog222(uint value) {
        UpdateMaskUtils.AddUInt(_values, 329, value);
    }

    public void SetPlayerQuestLog223(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 330, a, b, c, d);
    }

    public void SetPlayerQuestLog224(uint value) {
        UpdateMaskUtils.AddUInt(_values, 331, value);
    }

    public void SetPlayerQuestLog231(uint value) {
        UpdateMaskUtils.AddUInt(_values, 332, value);
    }

    public void SetPlayerQuestLog232(uint value) {
        UpdateMaskUtils.AddUInt(_values, 333, value);
    }

    public void SetPlayerQuestLog233(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 334, a, b, c, d);
    }

    public void SetPlayerQuestLog234(uint value) {
        UpdateMaskUtils.AddUInt(_values, 335, value);
    }

    public void SetPlayerQuestLog241(uint value) {
        UpdateMaskUtils.AddUInt(_values, 336, value);
    }

    public void SetPlayerQuestLog242(uint value) {
        UpdateMaskUtils.AddUInt(_values, 337, value);
    }

    public void SetPlayerQuestLog243(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 338, a, b, c, d);
    }

    public void SetPlayerQuestLog244(uint value) {
        UpdateMaskUtils.AddUInt(_values, 339, value);
    }

    public void SetPlayerQuestLog251(uint value) {
        UpdateMaskUtils.AddUInt(_values, 340, value);
    }

    public void SetPlayerQuestLog252(uint value) {
        UpdateMaskUtils.AddUInt(_values, 341, value);
    }

    public void SetPlayerQuestLog253(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 342, a, b, c, d);
    }

    public void SetPlayerQuestLog254(uint value) {
        UpdateMaskUtils.AddUInt(_values, 343, value);
    }

    public void SetPlayerChosenTitle(uint value) {
        UpdateMaskUtils.AddUInt(_values, 648, value);
    }

    public void SetPlayerFarsight(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 922, value);
    }

    public void SetPlayerKnownTitles(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 924, value);
    }

    public void SetPlayerXp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 926, value);
    }

    public void SetPlayerNextLevelXp(uint value) {
        UpdateMaskUtils.AddUInt(_values, 927, value);
    }

    public void SetPlayerCharacterPoints1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1312, value);
    }

    public void SetPlayerCharacterPoints2(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1313, value);
    }

    public void SetPlayerTrackCreatures(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1314, value);
    }

    public void SetPlayerTrackResources(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1315, value);
    }

    public void SetPlayerBlockPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1316, value);
    }

    public void SetPlayerDodgePercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1317, value);
    }

    public void SetPlayerParryPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1318, value);
    }

    public void SetPlayerExpertise(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1319, value);
    }

    public void SetPlayerOffhandExpertise(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1320, value);
    }

    public void SetPlayerCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1321, value);
    }

    public void SetPlayerRangedCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1322, value);
    }

    public void SetPlayerOffhandCritPercentage(float value) {
        UpdateMaskUtils.AddFloat(_values, 1323, value);
    }

    public void SetPlayerSpellCritPercentage1(float value) {
        UpdateMaskUtils.AddFloat(_values, 1324, value);
    }

    public void SetPlayerShieldBlock(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1331, value);
    }

    public void SetPlayerExploredZones1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1332, a, b, c, d);
    }

    public void SetPlayerRestStateExperience(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1460, value);
    }

    public void SetPlayerCoinage(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1461, value);
    }

    public void SetPlayerModDamageDonePos(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1462, value);
    }

    public void SetPlayerModDamageDoneNeg(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1469, value);
    }

    public void SetPlayerModDamageDonePct(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1476, value);
    }

    public void SetPlayerModHealingDonePos(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1483, value);
    }

    public void SetPlayerModTargetResistance(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1484, value);
    }

    public void SetPlayerModTargetPhysicalResistance(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1485, value);
    }

    public void SetPlayerFeatures(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1486, a, b, c, d);
    }

    public void SetPlayerAmmoId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1487, value);
    }

    public void SetPlayerSelfResSpell(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1488, value);
    }

    public void SetPlayerPvpMedals(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1489, value);
    }

    public void SetPlayerBuybackPrice1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1490, value);
    }

    public void SetPlayerBuybackTimestamp1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1502, value);
    }

    public void SetPlayerKills(ushort a, ushort b) {
        UpdateMaskUtils.AddTwoShort(_values, 1514, a, b);
    }

    public void SetPlayerTodayContribution(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1515, value);
    }

    public void SetPlayerYesterdayContribution(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1516, value);
    }

    public void SetPlayerLifetimeHonorableKills(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1517, value);
    }

    public void SetPlayerBytes2Glow(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 1518, a, b, c, d);
    }

    public void SetPlayerWatchedFactionIndex(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1519, value);
    }

    public void SetPlayerCombatRating1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1520, value);
    }

    public void SetPlayerArenaTeamInfo11(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1544, value);
    }

    public void SetPlayerHonorCurrency(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1562, value);
    }

    public void SetPlayerArenaCurrency(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1563, value);
    }

    public void SetPlayerModManaRegen(float value) {
        UpdateMaskUtils.AddFloat(_values, 1564, value);
    }

    public void SetPlayerModManaRegenInterrupt(float value) {
        UpdateMaskUtils.AddFloat(_values, 1565, value);
    }

    public void SetPlayerMaxLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1566, value);
    }

    public void SetPlayerDailyQuests1(uint value) {
        UpdateMaskUtils.AddUInt(_values, 1567, value);
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

    public void SetGameObjectRotation(float value) {
        UpdateMaskUtils.AddFloat(_values, 10, value);
    }

    public void SetGameObjectState(uint value) {
        UpdateMaskUtils.AddUInt(_values, 14, value);
    }

    public void SetGameObjectPosX(float value) {
        UpdateMaskUtils.AddFloat(_values, 15, value);
    }

    public void SetGameObjectPosY(float value) {
        UpdateMaskUtils.AddFloat(_values, 16, value);
    }

    public void SetGameObjectPosZ(float value) {
        UpdateMaskUtils.AddFloat(_values, 17, value);
    }

    public void SetGameObjectFacing(float value) {
        UpdateMaskUtils.AddFloat(_values, 18, value);
    }

    public void SetGameObjectDynFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 19, value);
    }

    public void SetGameObjectFaction(uint value) {
        UpdateMaskUtils.AddUInt(_values, 20, value);
    }

    public void SetGameObjectTypeId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 21, value);
    }

    public void SetGameObjectLevel(uint value) {
        UpdateMaskUtils.AddUInt(_values, 22, value);
    }

    public void SetGameObjectArtkit(uint value) {
        UpdateMaskUtils.AddUInt(_values, 23, value);
    }

    public void SetGameObjectAnimprogress(uint value) {
        UpdateMaskUtils.AddUInt(_values, 24, value);
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

    public void SetDynamicObjectPosX(float value) {
        UpdateMaskUtils.AddFloat(_values, 11, value);
    }

    public void SetDynamicObjectPosY(float value) {
        UpdateMaskUtils.AddFloat(_values, 12, value);
    }

    public void SetDynamicObjectPosZ(float value) {
        UpdateMaskUtils.AddFloat(_values, 13, value);
    }

    public void SetDynamicObjectFacing(float value) {
        UpdateMaskUtils.AddFloat(_values, 14, value);
    }

    public void SetDynamicObjectCasttime(uint value) {
        UpdateMaskUtils.AddUInt(_values, 15, value);
    }

    public void SetCorpseOwner(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 6, value);
    }

    public void SetCorpseParty(ulong value) {
        UpdateMaskUtils.AddGuid(_values, 8, value);
    }

    public void SetCorpseFacing(float value) {
        UpdateMaskUtils.AddFloat(_values, 10, value);
    }

    public void SetCorpsePosX(float value) {
        UpdateMaskUtils.AddFloat(_values, 11, value);
    }

    public void SetCorpsePosY(float value) {
        UpdateMaskUtils.AddFloat(_values, 12, value);
    }

    public void SetCorpsePosZ(float value) {
        UpdateMaskUtils.AddFloat(_values, 13, value);
    }

    public void SetCorpseDisplayId(uint value) {
        UpdateMaskUtils.AddUInt(_values, 14, value);
    }

    public void SetCorpseItem(uint value) {
        UpdateMaskUtils.AddUInt(_values, 15, value);
    }

    public void SetCorpseBytes1(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 34, a, b, c, d);
    }

    public void SetCorpseBytes2(byte a, byte b, byte c, byte d) {
        UpdateMaskUtils.AddBytes(_values, 35, a, b, c, d);
    }

    public void SetCorpseGuild(uint value) {
        UpdateMaskUtils.AddUInt(_values, 36, value);
    }

    public void SetCorpseFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 37, value);
    }

    public void SetCorpseDynamicFlags(uint value) {
        UpdateMaskUtils.AddUInt(_values, 38, value);
    }

}
