using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ClientCastFlagsType = OneOf.OneOf<CMSG_CAST_SPELL.ClientCastFlagsExtra, ClientCastFlags>;
using ClientMovementDataType = OneOf.OneOf<CMSG_CAST_SPELL.ClientMovementDataPresent, ClientMovementData>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CAST_SPELL: WrathClientMessage, IWorldMessage {
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
    public required byte CastCount { get; set; }
    public required uint Spell { get; set; }
    public required ClientCastFlagsType CastFlags { get; set; }
    internal ClientCastFlags CastFlagsValue => CastFlags.Match(
        _ => Wrath.ClientCastFlags.Extra,
        v => v
    );
    public required SpellCastTargets Targets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(CastCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Spell, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)CastFlagsValue, cancellationToken).ConfigureAwait(false);

        await Targets.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

        if (CastFlags.Value is CMSG_CAST_SPELL.ClientCastFlagsExtra clientCastFlagsExtra) {
            await w.WriteFloat(clientCastFlagsExtra.Elevation, cancellationToken).ConfigureAwait(false);

            await w.WriteFloat(clientCastFlagsExtra.Speed, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)clientCastFlagsExtra.MovementDataValue, cancellationToken).ConfigureAwait(false);

            if (clientCastFlagsExtra.MovementData.Value is CMSG_CAST_SPELL.ClientMovementDataPresent clientMovementDataPresent) {
                await w.WriteUInt(clientMovementDataPresent.Opcode, cancellationToken).ConfigureAwait(false);

                await w.WritePackedGuid(clientMovementDataPresent.Guid, cancellationToken).ConfigureAwait(false);

                await clientMovementDataPresent.Info.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            }

        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 302, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 302, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CAST_SPELL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var castCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spell = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        ClientCastFlagsType castFlags = (Wrath.ClientCastFlags)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var targets = await SpellCastTargets.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

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

        return new CMSG_CAST_SPELL {
            CastCount = castCount,
            Spell = spell,
            CastFlags = castFlags,
            Targets = targets,
        };
    }

    internal int Size() {
        var size = 0;

        // cast_count: Generator.Generated.DataTypeInteger
        size += 1;

        // spell: Generator.Generated.DataTypeSpell
        size += 4;

        // cast_flags: Generator.Generated.DataTypeEnum
        size += 1;

        // targets: Generator.Generated.DataTypeStruct
        size += Targets.Size();

        if (CastFlags.Value is CMSG_CAST_SPELL.ClientCastFlagsExtra clientCastFlagsExtra) {
            // elevation: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // speed: Generator.Generated.DataTypeFloatingPoint
            size += 4;

            // movement_data: Generator.Generated.DataTypeEnum
            size += 1;

            if (clientCastFlagsExtra.MovementData.Value is CMSG_CAST_SPELL.ClientMovementDataPresent clientMovementDataPresent) {
                // opcode: Generator.Generated.DataTypeInteger
                size += 4;

                // guid: Generator.Generated.DataTypePackedGuid
                size += clientMovementDataPresent.Guid.PackedGuidLength();

                // info: Generator.Generated.DataTypeStruct
                size += clientMovementDataPresent.Info.Size();

            }

        }

        return size;
    }

}

