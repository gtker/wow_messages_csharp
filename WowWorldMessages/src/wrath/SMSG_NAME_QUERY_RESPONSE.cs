using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using DeclinedNamesType = OneOf.OneOf<SMSG_NAME_QUERY_RESPONSE.DeclinedNamesYes, DeclinedNames>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_NAME_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public class DeclinedNamesYes {
        public const int DeclinedNamesLength = 5;
        public required string[] DeclinedNames { get; set; }
    }
    public required ulong Guid { get; set; }
    public required string CharacterName { get; set; }
    /// <summary>
    /// Used for showing cross realm realm names. If this is an empty string it is shown like a regular player on the same realm.
    /// </summary>
    public required string RealmName { get; set; }
    public required Wrath.Race Race { get; set; }
    public required Wrath.Gender Gender { get; set; }
    public required Wrath.Class ClassType { get; set; }
    public required DeclinedNamesType HasDeclinedNames { get; set; }
    internal DeclinedNames HasDeclinedNamesValue => HasDeclinedNames.Match(
        _ => Wrath.DeclinedNames.Yes,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(0, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(CharacterName, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(RealmName, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Race, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ClassType, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)HasDeclinedNamesValue, cancellationToken).ConfigureAwait(false);

        if (HasDeclinedNames.Value is SMSG_NAME_QUERY_RESPONSE.DeclinedNamesYes declinedNamesYes) {
            foreach (var v in declinedNamesYes.DeclinedNames) {
                await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 81, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 81, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_NAME_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var earlyTerminate = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var characterName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var realmName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var race = (Wrath.Race)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gender = (Wrath.Gender)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var classType = (Wrath.Class)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        DeclinedNamesType hasDeclinedNames = (Wrath.DeclinedNames)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (hasDeclinedNames.Value is Wrath.DeclinedNames.Yes) {
            var declinedNames = new string[DeclinedNamesYes.DeclinedNamesLength];
            for (var i = 0; i < DeclinedNamesYes.DeclinedNamesLength; ++i) {
                declinedNames[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
            }

            hasDeclinedNames = new DeclinedNamesYes {
                DeclinedNames = declinedNames,
            };
        }

        return new SMSG_NAME_QUERY_RESPONSE {
            Guid = guid,
            CharacterName = characterName,
            RealmName = realmName,
            Race = race,
            Gender = gender,
            ClassType = classType,
            HasDeclinedNames = hasDeclinedNames,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypePackedGuid
        size += Guid.PackedGuidLength();

        // early_terminate: Generator.Generated.DataTypeInteger
        size += 1;

        // character_name: Generator.Generated.DataTypeCstring
        size += CharacterName.Length + 1;

        // realm_name: Generator.Generated.DataTypeCstring
        size += RealmName.Length + 1;

        // race: Generator.Generated.DataTypeEnum
        size += 1;

        // gender: Generator.Generated.DataTypeEnum
        size += 1;

        // class_type: Generator.Generated.DataTypeEnum
        size += 1;

        // has_declined_names: Generator.Generated.DataTypeEnum
        size += 1;

        if (HasDeclinedNames.Value is SMSG_NAME_QUERY_RESPONSE.DeclinedNamesYes declinedNamesYes) {
            // declined_names: Generator.Generated.DataTypeArray
            size += declinedNamesYes.DeclinedNames.Sum(e => e.Length + 1);

        }

        return size;
    }

}

