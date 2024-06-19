using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ReferAFriendErrorType = OneOf.OneOf<SMSG_REFER_A_FRIEND_FAILURE.ReferAFriendErrorNotInGroup, ReferAFriendError>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_REFER_A_FRIEND_FAILURE: WrathServerMessage, IWorldMessage {
    public class ReferAFriendErrorNotInGroup {
        public required string TargetName { get; set; }
    }
    public required ReferAFriendErrorType Error { get; set; }
    internal ReferAFriendError ErrorValue => Error.Match(
        _ => Wrath.ReferAFriendError.NotInGroup,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)ErrorValue, cancellationToken).ConfigureAwait(false);

        if (Error.Value is SMSG_REFER_A_FRIEND_FAILURE.ReferAFriendErrorNotInGroup referAFriendErrorNotInGroup) {
            await w.WriteCString(referAFriendErrorNotInGroup.TargetName, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1057, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1057, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_REFER_A_FRIEND_FAILURE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        ReferAFriendErrorType error = (Wrath.ReferAFriendError)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        if (error.Value is Wrath.ReferAFriendError.NotInGroup) {
            var targetName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            error = new ReferAFriendErrorNotInGroup {
                TargetName = targetName,
            };
        }

        return new SMSG_REFER_A_FRIEND_FAILURE {
            Error = error,
        };
    }

    internal int Size() {
        var size = 0;

        // error: Generator.Generated.DataTypeEnum
        size += 4;

        if (Error.Value is SMSG_REFER_A_FRIEND_FAILURE.ReferAFriendErrorNotInGroup referAFriendErrorNotInGroup) {
            // target_name: Generator.Generated.DataTypeCstring
            size += referAFriendErrorNotInGroup.TargetName.Length + 1;

        }

        return size;
    }

}

