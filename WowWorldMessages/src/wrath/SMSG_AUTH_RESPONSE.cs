using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using WorldResultType = OneOf.OneOf<SMSG_AUTH_RESPONSE.WorldResultAuthOk, SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue, WorldResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUTH_RESPONSE: WrathServerMessage, IWorldMessage {
    public class WorldResultAuthOk {
        public required Wrath.BillingPlanFlags BillingFlags { get; set; }
        public required uint BillingRested { get; set; }
        public required uint BillingTime { get; set; }
        public required Wrath.Expansion Expansion { get; set; }
    }
    public class WorldResultAuthWaitQueue {
        public required uint QueuePosition { get; set; }
        public required bool RealmHasFreeCharacterMigration { get; set; }
    }
    public required WorldResultType Result { get; set; }
    internal WorldResult ResultValue => Result.Match(
        _ => Wrath.WorldResult.AuthOk,
        _ => Wrath.WorldResult.AuthWaitQueue,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthOk worldResultAuthOk) {
            await w.WriteUInt(worldResultAuthOk.BillingTime, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)worldResultAuthOk.BillingFlags, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(worldResultAuthOk.BillingRested, cancellationToken).ConfigureAwait(false);

            await w.WriteByte((byte)worldResultAuthOk.Expansion, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue worldResultAuthWaitQueue) {
            await w.WriteUInt(worldResultAuthWaitQueue.QueuePosition, cancellationToken).ConfigureAwait(false);

            await w.WriteBool8(worldResultAuthWaitQueue.RealmHasFreeCharacterMigration, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 494, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 494, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUTH_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        WorldResultType result = (Wrath.WorldResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.WorldResult.AuthOk) {
            var billingTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var billingFlags = (BillingPlanFlags)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var billingRested = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var expansion = (Wrath.Expansion)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            result = new WorldResultAuthOk {
                BillingFlags = billingFlags,
                BillingRested = billingRested,
                BillingTime = billingTime,
                Expansion = expansion,
            };
        }
        else if (result.Value is Wrath.WorldResult.AuthWaitQueue) {
            var queuePosition = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var realmHasFreeCharacterMigration = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

            result = new WorldResultAuthWaitQueue {
                QueuePosition = queuePosition,
                RealmHasFreeCharacterMigration = realmHasFreeCharacterMigration,
            };
        }

        return new SMSG_AUTH_RESPONSE {
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthOk worldResultAuthOk) {
            // billing_time: Generator.Generated.DataTypeInteger
            size += 4;

            // billing_flags: Generator.Generated.DataTypeFlag
            size += 1;

            // billing_rested: Generator.Generated.DataTypeInteger
            size += 4;

            // expansion: Generator.Generated.DataTypeEnum
            size += 1;

        }
        else if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue worldResultAuthWaitQueue) {
            // queue_position: Generator.Generated.DataTypeInteger
            size += 4;

            // realm_has_free_character_migration: Generator.Generated.DataTypeBool
            size += 1;

        }

        return size;
    }

}

