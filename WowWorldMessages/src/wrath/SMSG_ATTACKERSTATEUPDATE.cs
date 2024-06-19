using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ATTACKERSTATEUPDATE: WrathServerMessage, IWorldMessage {
    public class HitInfoType {
        public required HitInfo Inner;
        public HitInfoAllAbsorb? AllAbsorb;
        public HitInfoAllResist? AllResist;
        public HitInfoBlock? Block;
        public HitInfoUnk1? Unk1;
        public HitInfoUnk19? Unk19;
    }
    public class HitInfoAllAbsorb {
        public required uint Absorb { get; set; }
    }
    public class HitInfoAllResist {
        public required uint Resist { get; set; }
    }
    public class HitInfoBlock {
        public required uint BlockedAmount { get; set; }
    }
    public class HitInfoUnk1 {
        public required float Unknown10 { get; set; }
        public required float Unknown11 { get; set; }
        public required float Unknown12 { get; set; }
        public required float Unknown13 { get; set; }
        public required float Unknown14 { get; set; }
        public required uint Unknown15 { get; set; }
        public required uint Unknown4 { get; set; }
        public required float Unknown5 { get; set; }
        public required float Unknown6 { get; set; }
        public required float Unknown7 { get; set; }
        public required float Unknown8 { get; set; }
        public required float Unknown9 { get; set; }
    }
    public class HitInfoUnk19 {
        public required uint Unknown3 { get; set; }
    }
    public required HitInfoType HitInfo { get; set; }
    public required ulong Attacker { get; set; }
    public required ulong Target { get; set; }
    public required uint TotalDamage { get; set; }
    public required uint Overkill { get; set; }
    public required List<DamageInfo> DamageInfos { get; set; }
    public required Wrath.VictimState VictimState { get; set; }
    /// <summary>
    /// arcemu: can be 0,1000 or -1
    /// </summary>
    public required uint Unknown1 { get; set; }
    public required uint Unknown2 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)HitInfo.Inner, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Attacker, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Target, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TotalDamage, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Overkill, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)DamageInfos.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in DamageInfos) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        if (HitInfo.AllAbsorb is {} hitInfoAllAbsorb) {
            await w.WriteUInt(hitInfoAllAbsorb.Absorb, cancellationToken).ConfigureAwait(false);

        }

        if (HitInfo.AllResist is {} hitInfoAllResist) {
            await w.WriteUInt(hitInfoAllResist.Resist, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteByte((byte)VictimState, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Unknown2, cancellationToken).ConfigureAwait(false);

        if (HitInfo.Block is {} hitInfoBlock) {
            await w.WriteUInt(hitInfoBlock.BlockedAmount, cancellationToken).ConfigureAwait(false);

        }

        if (HitInfo.Unk19 is {} hitInfoUnk19) {
            await w.WriteUInt(hitInfoUnk19.Unknown3, cancellationToken).ConfigureAwait(false);

        }

        if (HitInfo.Unk1 is {} hitInfoUnk1) {
            await w.WriteUInt(hitInfoUnk1.Unknown4, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown5, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown6, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown7, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown8, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown9, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown10, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown11, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown12, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown13, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(hitInfoUnk1.Unknown14, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(hitInfoUnk1.Unknown15, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 330, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 330, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ATTACKERSTATEUPDATE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var hitInfo = new HitInfoType {
            Inner = (HitInfo)await r.ReadUInt(cancellationToken).ConfigureAwait(false),
        };

        var attacker = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var target = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var totalDamage = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var overkill = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfDamages = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var damageInfos = new List<DamageInfo>();
        for (var i = 0; i < amountOfDamages; ++i) {
            damageInfos.Add(await Wrath.DamageInfo.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        if (hitInfo.Inner.HasFlag(Wrath.HitInfo.AllAbsorb)) {
            var absorb = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            hitInfo.AllAbsorb = new HitInfoAllAbsorb {
                Absorb = absorb,
            };
        }

        if (hitInfo.Inner.HasFlag(Wrath.HitInfo.AllResist)) {
            var resist = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            hitInfo.AllResist = new HitInfoAllResist {
                Resist = resist,
            };
        }

        var victimState = (VictimState)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (hitInfo.Inner.HasFlag(Wrath.HitInfo.Block)) {
            var blockedAmount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            hitInfo.Block = new HitInfoBlock {
                BlockedAmount = blockedAmount,
            };
        }

        if (hitInfo.Inner.HasFlag(Wrath.HitInfo.Unk19)) {
            var unknown3 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            hitInfo.Unk19 = new HitInfoUnk19 {
                Unknown3 = unknown3,
            };
        }

        if (hitInfo.Inner.HasFlag(Wrath.HitInfo.Unk1)) {
            var unknown4 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown5 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown6 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown7 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown8 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown9 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown10 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown11 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown12 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown13 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown14 = await r.ReadFloat(cancellationToken).ConfigureAwait(false);

            var unknown15 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            hitInfo.Unk1 = new HitInfoUnk1 {
                Unknown10 = unknown10,
                Unknown11 = unknown11,
                Unknown12 = unknown12,
                Unknown13 = unknown13,
                Unknown14 = unknown14,
                Unknown15 = unknown15,
                Unknown4 = unknown4,
                Unknown5 = unknown5,
                Unknown6 = unknown6,
                Unknown7 = unknown7,
                Unknown8 = unknown8,
                Unknown9 = unknown9,
            };
        }

        return new SMSG_ATTACKERSTATEUPDATE {
            HitInfo = hitInfo,
            Attacker = attacker,
            Target = target,
            TotalDamage = totalDamage,
            Overkill = overkill,
            DamageInfos = damageInfos,
            VictimState = victimState,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
        };
    }

    internal int Size() {
        var size = 0;

        // hit_info: Generator.Generated.DataTypeFlag
        size += 4;

        // attacker: Generator.Generated.DataTypePackedGuid
        size += Attacker.PackedGuidLength();

        // target: Generator.Generated.DataTypePackedGuid
        size += Target.PackedGuidLength();

        // total_damage: Generator.Generated.DataTypeInteger
        size += 4;

        // overkill: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_damages: Generator.Generated.DataTypeInteger
        size += 1;

        // damage_infos: Generator.Generated.DataTypeArray
        size += DamageInfos.Sum(e => 12);

        if (HitInfo.AllAbsorb is {} hitInfoAllAbsorb) {
            // absorb: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (HitInfo.AllResist is {} hitInfoAllResist) {
            // resist: Generator.Generated.DataTypeInteger
            size += 4;

        }

        // victim_state: Generator.Generated.DataTypeFlag
        size += 1;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 4;

        if (HitInfo.Block is {} hitInfoBlock) {
            // blocked_amount: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (HitInfo.Unk19 is {} hitInfoUnk19) {
            // unknown3: Generator.Generated.DataTypeInteger
            size += 4;

        }

        if (HitInfo.Unk1 is {} hitInfoUnk1) {
            // unknown4: Generator.Generated.DataTypeInteger
            size += 4;

            // unknown5: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown6: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown7: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown8: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown9: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown10: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown11: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown12: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown13: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown14: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // unknown15: Generator.Generated.DataTypeInteger
            size += 4;

        }

        return size;
    }

}

