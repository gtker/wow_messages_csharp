using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using DeclinedNamesType = OneOf.OneOf<SMSG_NAME_QUERY_RESPONSE.DeclinedNamesYes, DeclinedNames>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_NAME_QUERY_RESPONSE: TbcServerMessage, IWorldMessage {
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
    public required Tbc.Race Race { get; set; }
    public required Tbc.Gender Gender { get; set; }
    public required Tbc.Class ClassType { get; set; }
    public required DeclinedNamesType HasDeclinedNames { get; set; }
    internal DeclinedNames HasDeclinedNamesValue => HasDeclinedNames.Match(
        _ => Tbc.DeclinedNames.Yes,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WritePackedGuid(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(CharacterName, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(RealmName, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Race, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Gender, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)ClassType, cancellationToken).ConfigureAwait(false);

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
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 81, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_NAME_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var characterName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var realmName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var race = (Tbc.Race)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var gender = (Tbc.Gender)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var classType = (Tbc.Class)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        DeclinedNamesType hasDeclinedNames = (Tbc.DeclinedNames)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (hasDeclinedNames.Value is Tbc.DeclinedNames.Yes) {
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

        // character_name: Generator.Generated.DataTypeCstring
        size += CharacterName.Length + 1;

        // realm_name: Generator.Generated.DataTypeCstring
        size += RealmName.Length + 1;

        // race: Generator.Generated.DataTypeEnum
        size += 4;

        // gender: Generator.Generated.DataTypeEnum
        size += 4;

        // class_type: Generator.Generated.DataTypeEnum
        size += 4;

        // has_declined_names: Generator.Generated.DataTypeEnum
        size += 1;

        if (HasDeclinedNames.Value is SMSG_NAME_QUERY_RESPONSE.DeclinedNamesYes declinedNamesYes) {
            // declined_names: Generator.Generated.DataTypeArray
            size += declinedNamesYes.DeclinedNames.Sum(e => e.Length + 1);

        }

        return size;
    }

}

