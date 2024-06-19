using WowSrp.Header;

namespace WowWorldMessages.Tbc;

using WorldResultType = OneOf.OneOf<SMSG_AUTH_RESPONSE.WorldResultAuthOk, SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue, WorldResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUTH_RESPONSE: TbcServerMessage, IWorldMessage {
    public class WorldResultAuthOk {
        public required Tbc.BillingPlanFlags BillingFlags { get; set; }
        public required uint BillingRested { get; set; }
        public required uint BillingTime { get; set; }
        public required Tbc.Expansion Expansion { get; set; }
    }
    public class WorldResultAuthWaitQueue {
        public required uint QueuePosition { get; set; }
    }
    public required WorldResultType Result { get; set; }
    internal WorldResult ResultValue => Result.Match(
        _ => Tbc.WorldResult.AuthOk,
        _ => Tbc.WorldResult.AuthWaitQueue,
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

        }


    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 494, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 494, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_AUTH_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        WorldResultType result = (Tbc.WorldResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Tbc.WorldResult.AuthOk) {
            var billingTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var billingFlags = (BillingPlanFlags)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var billingRested = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var expansion = (Tbc.Expansion)await r.ReadByte(cancellationToken).ConfigureAwait(false);

            result = new WorldResultAuthOk {
                BillingFlags = billingFlags,
                BillingRested = billingRested,
                BillingTime = billingTime,
                Expansion = expansion,
            };
        }
        else if (result.Value is Tbc.WorldResult.AuthWaitQueue) {
            var queuePosition = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new WorldResultAuthWaitQueue {
                QueuePosition = queuePosition,
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

        }


        return size;
    }

}
