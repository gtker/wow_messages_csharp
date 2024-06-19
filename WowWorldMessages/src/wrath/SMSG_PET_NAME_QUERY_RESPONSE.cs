using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using PetQueryDisabledNamesType = OneOf.OneOf<SMSG_PET_NAME_QUERY_RESPONSE.PetQueryDisabledNamesPresent, PetQueryDisabledNames>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_PET_NAME_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public class PetQueryDisabledNamesPresent {
        public const int DeclinedNamesLength = 5;
        public required string[] DeclinedNames { get; set; }
    }
    public required uint PetNumber { get; set; }
    public required string Name { get; set; }
    public required uint PetNameTimestamp { get; set; }
    public required PetQueryDisabledNamesType Names { get; set; }
    internal PetQueryDisabledNames NamesValue => Names.Match(
        _ => Wrath.PetQueryDisabledNames.Present,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(PetNumber, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PetNameTimestamp, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)NamesValue, cancellationToken).ConfigureAwait(false);

        if (Names.Value is SMSG_PET_NAME_QUERY_RESPONSE.PetQueryDisabledNamesPresent petQueryDisabledNamesPresent) {
            foreach (var v in petQueryDisabledNamesPresent.DeclinedNames) {
                await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 83, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 83, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_PET_NAME_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var petNumber = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var petNameTimestamp = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        PetQueryDisabledNamesType names = (Wrath.PetQueryDisabledNames)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (names.Value is Wrath.PetQueryDisabledNames.Present) {
            var declinedNames = new string[PetQueryDisabledNamesPresent.DeclinedNamesLength];
            for (var i = 0; i < PetQueryDisabledNamesPresent.DeclinedNamesLength; ++i) {
                declinedNames[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            }

            names = new PetQueryDisabledNamesPresent {
                DeclinedNames = declinedNames,
            };
        }

        return new SMSG_PET_NAME_QUERY_RESPONSE {
            PetNumber = petNumber,
            Name = name,
            PetNameTimestamp = petNameTimestamp,
            Names = names,
        };
    }

    internal int Size() {
        var size = 0;

        // pet_number: Generator.Generated.DataTypeInteger
        size += 4;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // pet_name_timestamp: Generator.Generated.DataTypeInteger
        size += 4;

        // names: Generator.Generated.DataTypeEnum
        size += 1;

        if (Names.Value is SMSG_PET_NAME_QUERY_RESPONSE.PetQueryDisabledNamesPresent petQueryDisabledNamesPresent) {
            // declined_names: Generator.Generated.DataTypeArray
            size += petQueryDisabledNamesPresent.DeclinedNames.Sum(e => e.Length + 1);

        }

        return size;
    }

}

