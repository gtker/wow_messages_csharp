namespace WowLoginMessages.Version8;

using LoginResultType = OneOf.OneOf<CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess, LoginResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_PROOF_Server: Version8ServerMessage, ILoginMessage {
    public class LoginResultSuccess {
        public required AccountFlag AccountFlag { get; set; }
        public required uint HardwareSurveyId { get; set; }
        public const int ServerProofLength = 20;
        public required byte[] ServerProof { get; set; }
        public required ushort Unknown { get; set; }
    }
    public required LoginResultType Result { get; set; }
    internal LoginResult ResultValue => Result.Match(
        _ => Version8.LoginResult.Success,
        v => v
    );

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is CMD_AUTH_LOGON_PROOF_Server.LoginResultSuccess loginResultSuccess) {
            foreach (var v in loginResultSuccess.ServerProof) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }

            await w.WriteUInt((uint)loginResultSuccess.AccountFlag, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt(loginResultSuccess.HardwareSurveyId, cancellationToken).ConfigureAwait(false);

            await w.WriteUShort(loginResultSuccess.Unknown, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailUnknown0) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailUnknown1) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailBanned) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailUnknownAccount) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailIncorrectPassword) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailAlreadyOnline) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailNoTime) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailDbBusy) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailVersionInvalid) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.LoginDownloadFile) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailInvalidServer) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailSuspended) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailNoAccess) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.SuccessSurvey) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailParentalcontrol) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }
        else if (Result.Value is Version8.LoginResult.FailLockedEnforced) {
            await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

        }


    }

    public static async Task<CMD_AUTH_LOGON_PROOF_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        LoginResultType result = (LoginResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Version8.LoginResult.Success) {
            var serverProof = new byte[LoginResultSuccess.ServerProofLength];
            for (var i = 0; i < LoginResultSuccess.ServerProofLength; ++i) {
                serverProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            }

            var accountFlag = (AccountFlag)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var hardwareSurveyId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var unknown = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

            result = new LoginResultSuccess {
                AccountFlag = accountFlag,
                HardwareSurveyId = hardwareSurveyId,
                ServerProof = serverProof,
                Unknown = unknown,
            };
        }
        else if (result.Value is Version8.LoginResult.FailUnknown0) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailUnknown1) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailBanned) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailUnknownAccount) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailIncorrectPassword) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailAlreadyOnline) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailNoTime) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailDbBusy) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailVersionInvalid) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.LoginDownloadFile) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailInvalidServer) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailSuspended) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailNoAccess) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.SuccessSurvey) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailParentalcontrol) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }
        else if (result.Value is Version8.LoginResult.FailLockedEnforced) {
            // ReSharper disable once UnusedVariable.Compiler
            var padding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        }


        return new CMD_AUTH_LOGON_PROOF_Server {
            Result = result,
        };
    }

}

