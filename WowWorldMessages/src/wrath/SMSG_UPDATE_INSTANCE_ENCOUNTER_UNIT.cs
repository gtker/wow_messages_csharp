using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using EncounterFrameType = OneOf.OneOf<SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameAddTimer, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisableObjective, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisengage, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEnableObjective, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEngage, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdateObjective, SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdatePriority, EncounterFrame>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT: WrathServerMessage, IWorldMessage {
    public class EncounterFrameAddTimer {
        public required byte Parameter2 { get; set; }
    }
    public class EncounterFrameDisableObjective {
        public required byte Parameter2 { get; set; }
    }
    public class EncounterFrameDisengage {
        public required ulong Guid { get; set; }
        public required byte Parameter1 { get; set; }
    }
    public class EncounterFrameEnableObjective {
        public required byte Parameter2 { get; set; }
    }
    public class EncounterFrameEngage {
        public required ulong Guid { get; set; }
        public required byte Parameter1 { get; set; }
    }
    public class EncounterFrameUpdateObjective {
        public required byte Parameter3 { get; set; }
        public required byte Parameter4 { get; set; }
    }
    public class EncounterFrameUpdatePriority {
        public required ulong Guid { get; set; }
        public required byte Parameter1 { get; set; }
    }
    public required EncounterFrameType Frame { get; set; }
    internal EncounterFrame FrameValue => Frame.Match(
        _ => Wrath.EncounterFrame.AddTimer,
        _ => Wrath.EncounterFrame.DisableObjective,
        _ => Wrath.EncounterFrame.Disengage,
        _ => Wrath.EncounterFrame.EnableObjective,
        _ => Wrath.EncounterFrame.Engage,
        _ => Wrath.EncounterFrame.UpdateObjective,
        _ => Wrath.EncounterFrame.UpdatePriority,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)FrameValue, cancellationToken).ConfigureAwait(false);

        if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEngage encounterFrameEngage) {
            await w.WritePackedGuid(encounterFrameEngage.Guid, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(encounterFrameEngage.Parameter1, cancellationToken).ConfigureAwait(false);

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisengage encounterFrameDisengage) {
            await w.WritePackedGuid(encounterFrameDisengage.Guid, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(encounterFrameDisengage.Parameter1, cancellationToken).ConfigureAwait(false);

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdatePriority encounterFrameUpdatePriority) {
            await w.WritePackedGuid(encounterFrameUpdatePriority.Guid, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(encounterFrameUpdatePriority.Parameter1, cancellationToken).ConfigureAwait(false);

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameAddTimer encounterFrameAddTimer) {
            await w.WriteByte(encounterFrameAddTimer.Parameter2, cancellationToken).ConfigureAwait(false);

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEnableObjective encounterFrameEnableObjective) {
            await w.WriteByte(encounterFrameEnableObjective.Parameter2, cancellationToken).ConfigureAwait(false);

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisableObjective encounterFrameDisableObjective) {
            await w.WriteByte(encounterFrameDisableObjective.Parameter2, cancellationToken).ConfigureAwait(false);

        }

        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdateObjective encounterFrameUpdateObjective) {
            await w.WriteByte(encounterFrameUpdateObjective.Parameter3, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(encounterFrameUpdateObjective.Parameter4, cancellationToken).ConfigureAwait(false);

        }


    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 532, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 532, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        EncounterFrameType frame = (Wrath.EncounterFrame)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (frame.Value is Wrath.EncounterFrame.Engage) {
            var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var parameter1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameEngage {
                Guid = guid,
                Parameter1 = parameter1,
            };
        }
        else if (frame.Value is Wrath.EncounterFrame.Disengage) {
            var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var parameter1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameDisengage {
                Guid = guid,
                Parameter1 = parameter1,
            };
        }
        else if (frame.Value is Wrath.EncounterFrame.UpdatePriority) {
            var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

            var parameter1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameUpdatePriority {
                Guid = guid,
                Parameter1 = parameter1,
            };
        }
        else if (frame.Value is Wrath.EncounterFrame.AddTimer) {
            var parameter2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameAddTimer {
                Parameter2 = parameter2,
            };
        }
        else if (frame.Value is Wrath.EncounterFrame.EnableObjective) {
            var parameter2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameEnableObjective {
                Parameter2 = parameter2,
            };
        }
        else if (frame.Value is Wrath.EncounterFrame.DisableObjective) {
            var parameter2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameDisableObjective {
                Parameter2 = parameter2,
            };
        }

        else if (frame.Value is Wrath.EncounterFrame.UpdateObjective) {
            var parameter3 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var parameter4 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            frame = new EncounterFrameUpdateObjective {
                Parameter3 = parameter3,
                Parameter4 = parameter4,
            };
        }


        return new SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT {
            Frame = frame,
        };
    }

    internal int Size() {
        var size = 0;

        // frame: Generator.Generated.DataTypeEnum
        size += 4;

        if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEngage encounterFrameEngage) {
            // guid: Generator.Generated.DataTypePackedGuid
            size += encounterFrameEngage.Guid.PackedGuidLength();

            // parameter1: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisengage encounterFrameDisengage) {
            // guid: Generator.Generated.DataTypePackedGuid
            size += encounterFrameDisengage.Guid.PackedGuidLength();

            // parameter1: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdatePriority encounterFrameUpdatePriority) {
            // guid: Generator.Generated.DataTypePackedGuid
            size += encounterFrameUpdatePriority.Guid.PackedGuidLength();

            // parameter1: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameAddTimer encounterFrameAddTimer) {
            // parameter2: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameEnableObjective encounterFrameEnableObjective) {
            // parameter2: Generator.Generated.DataTypeInteger
            size += 1;

        }
        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameDisableObjective encounterFrameDisableObjective) {
            // parameter2: Generator.Generated.DataTypeInteger
            size += 1;

        }

        else if (Frame.Value is SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT.EncounterFrameUpdateObjective encounterFrameUpdateObjective) {
            // parameter3: Generator.Generated.DataTypeInteger
            size += 1;

            // parameter4: Generator.Generated.DataTypeInteger
            size += 1;

        }


        return size;
    }

}

