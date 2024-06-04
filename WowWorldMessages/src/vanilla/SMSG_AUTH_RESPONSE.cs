using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using WorldResultType = OneOf.OneOf<SMSG_AUTH_RESPONSE.WorldResultAuthOk, SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue, WorldResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_AUTH_RESPONSE: VanillaServerMessage, IWorldMessage {
    public class WorldResultAuthOk {
        public required byte BillingFlags { get; set; }
        public required uint BillingRested { get; set; }
        public required uint BillingTime { get; set; }
    }
    public class WorldResultAuthWaitQueue {
        public required uint QueuePosition { get; set; }
    }
    public required WorldResultType Result { get; set; }
    internal WorldResult ResultValue => Result.Match(
        _ => Vanilla.WorldResult.AuthOk,
        _ => Vanilla.WorldResult.AuthWaitQueue,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthOk authOk) {
            await w.WriteUInt(authOk.BillingTime, cancellationToken).ConfigureAwait(false);

            await w.WriteByte(authOk.BillingFlags, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(authOk.BillingRested, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue authWaitQueue) {
            await w.WriteUInt(authWaitQueue.QueuePosition, cancellationToken).ConfigureAwait(false);

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
        WorldResultType result = (WorldResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Vanilla.WorldResult.AuthOk) {
            var billingTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var billingFlags = await r.ReadByte(cancellationToken).ConfigureAwait(false);

            var billingRested = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new WorldResultAuthOk {
                BillingFlags = billingFlags,
                BillingRested = billingRested,
                BillingTime = billingTime,
            };
        }
        else if (result.Value is Vanilla.WorldResult.AuthWaitQueue) {
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

        // result: WowMessages.Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthOk authOk) {
            // billing_time: WowMessages.Generator.Generated.DataTypeInteger
            size += 4;

            // billing_flags: WowMessages.Generator.Generated.DataTypeInteger
            size += 1;

            // billing_rested: WowMessages.Generator.Generated.DataTypeInteger
            size += 4;

        }
        else if (Result.Value is SMSG_AUTH_RESPONSE.WorldResultAuthWaitQueue authWaitQueue) {
            // queue_position: WowMessages.Generator.Generated.DataTypeInteger
            size += 4;

        }


        return size;
    }

}

