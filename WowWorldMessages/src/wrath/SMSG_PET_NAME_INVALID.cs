using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using DeclinedPetNameIncludedType = OneOf.OneOf<SMSG_PET_NAME_INVALID.DeclinedPetNameIncludedIncluded, DeclinedPetNameIncluded>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_NAME_INVALID: WrathServerMessage, IWorldMessage {
    public class DeclinedPetNameIncludedIncluded {
        public const int DeclinedNamesLength = 5;
        public required string[] DeclinedNames { get; set; }
    }
    public required Wrath.PetNameInvalidReason Reason { get; set; }
    public required string Name { get; set; }
    public required DeclinedPetNameIncludedType Included { get; set; }
    internal DeclinedPetNameIncluded IncludedValue => Included.Match(
        _ => Wrath.DeclinedPetNameIncluded.Included,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Reason, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)IncludedValue, cancellationToken).ConfigureAwait(false);

        if (Included.Value is SMSG_PET_NAME_INVALID.DeclinedPetNameIncludedIncluded declinedPetNameIncludedIncluded) {
            foreach (var v in declinedPetNameIncludedIncluded.DeclinedNames) {
                await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 376, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 376, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_NAME_INVALID> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var reason = (Wrath.PetNameInvalidReason)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        DeclinedPetNameIncludedType included = (Wrath.DeclinedPetNameIncluded)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (included.Value is Wrath.DeclinedPetNameIncluded.Included) {
            var declinedNames = new string[DeclinedPetNameIncludedIncluded.DeclinedNamesLength];
            for (var i = 0; i < DeclinedPetNameIncludedIncluded.DeclinedNamesLength; ++i) {
                declinedNames[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            }

            included = new DeclinedPetNameIncludedIncluded {
                DeclinedNames = declinedNames,
            };
        }

        return new SMSG_PET_NAME_INVALID {
            Reason = reason,
            Name = name,
            Included = included,
        };
    }

    internal int Size() {
        var size = 0;

        // reason: Generator.Generated.DataTypeEnum
        size += 4;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // included: Generator.Generated.DataTypeEnum
        size += 1;

        if (Included.Value is SMSG_PET_NAME_INVALID.DeclinedPetNameIncludedIncluded declinedPetNameIncludedIncluded) {
            // declined_names: Generator.Generated.DataTypeArray
            size += declinedPetNameIncludedIncluded.DeclinedNames.Sum(e => e.Length + 1);

        }

        return size;
    }

}

