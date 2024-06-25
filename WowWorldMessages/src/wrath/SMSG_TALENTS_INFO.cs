using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using TalentInfoTypeType = OneOf.OneOf<SMSG_TALENTS_INFO.TalentInfoTypePet, SMSG_TALENTS_INFO.TalentInfoTypePlayer, TalentInfoType>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_TALENTS_INFO: WrathServerMessage, IWorldMessage {
    public class TalentInfoTypePet {
        public required List<InspectTalent> Talents { get; set; }
    }
    public class TalentInfoTypePlayer {
        public required byte ActiveSpec { get; set; }
        public required List<TalentInfoSpec> Specs { get; set; }
    }
    public required TalentInfoTypeType TalentType { get; set; }
    internal TalentInfoType TalentTypeValue => TalentType.Match(
        _ => Wrath.TalentInfoType.Pet,
        _ => Wrath.TalentInfoType.Player,
        v => v
    );
    public required uint PointsLeft { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)TalentTypeValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PointsLeft, cancellationToken).ConfigureAwait(false);

        if (TalentType.Value is SMSG_TALENTS_INFO.TalentInfoTypePet talentInfoTypePet) {
            await w.WriteByte((byte)talentInfoTypePet.Talents.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in talentInfoTypePet.Talents) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }
        else if (TalentType.Value is SMSG_TALENTS_INFO.TalentInfoTypePlayer talentInfoTypePlayer) {
            await w.WriteByte((byte)talentInfoTypePlayer.Specs.Count, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(talentInfoTypePlayer.ActiveSpec, cancellationToken).ConfigureAwait(false);

            foreach (var v in talentInfoTypePlayer.Specs) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1216, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1216, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_TALENTS_INFO> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        TalentInfoTypeType talentType = (Wrath.TalentInfoType)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var pointsLeft = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (talentType.Value is Wrath.TalentInfoType.Pet) {
            // ReSharper disable once UnusedVariable.Compiler
            var amountOfTalents = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var talents = new List<InspectTalent>();
            for (var i = 0; i < amountOfTalents; ++i) {
                talents.Add(await Wrath.InspectTalent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            }

            talentType = new TalentInfoTypePet {
                Talents = talents,
            };
        }
        else if (talentType.Value is Wrath.TalentInfoType.Player) {
            // ReSharper disable once UnusedVariable.Compiler
            var amountOfSpecs = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var activeSpec = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var specs = new List<TalentInfoSpec>();
            for (var i = 0; i < amountOfSpecs; ++i) {
                specs.Add(await Wrath.TalentInfoSpec.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            }

            talentType = new TalentInfoTypePlayer {
                ActiveSpec = activeSpec,
                Specs = specs,
            };
        }

        return new SMSG_TALENTS_INFO {
            TalentType = talentType,
            PointsLeft = pointsLeft,
        };
    }

    internal int Size() {
        var size = 0;

        // talent_type: Generator.Generated.DataTypeEnum
        size += 1;

        // points_left: Generator.Generated.DataTypeInteger
        size += 4;

        if (TalentType.Value is SMSG_TALENTS_INFO.TalentInfoTypePet talentInfoTypePet) {
            // amount_of_talents: Generator.Generated.DataTypeInteger
            size += 1;

            // talents: Generator.Generated.DataTypeArray
            size += talentInfoTypePet.Talents.Sum(e => 5);

        }
        else if (TalentType.Value is SMSG_TALENTS_INFO.TalentInfoTypePlayer talentInfoTypePlayer) {
            // amount_of_specs: Generator.Generated.DataTypeInteger
            size += 1;

            // active_spec: Generator.Generated.DataTypeInteger
            size += 1;

            // specs: Generator.Generated.DataTypeArray
            size += talentInfoTypePlayer.Specs.Sum(e => e.Size());

        }

        return size;
    }

}

