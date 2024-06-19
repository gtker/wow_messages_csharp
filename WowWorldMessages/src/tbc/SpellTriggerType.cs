namespace WowWorldMessages.Tbc;

public enum SpellTriggerType : byte {
    OnUse = 0,
    OnEquip = 1,
    ChanceOnHit = 2,
    ServerSideScript = 3,
    Soulstone = 4,
    NoEquipCooldown = 5,
    LearnSpellId = 6,
}

