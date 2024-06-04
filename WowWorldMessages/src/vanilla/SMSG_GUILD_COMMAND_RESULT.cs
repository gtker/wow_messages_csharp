using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GUILD_COMMAND_RESULT: VanillaServerMessage, IWorldMessage {
    public required GuildCommand Command { get; set; }
    public required string StringValue { get; set; }
    public required GuildCommandResult Result { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Command, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(StringValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Result, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 147, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 147, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GUILD_COMMAND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var command = (GuildCommand)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var stringValue = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var result = (GuildCommandResult)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_GUILD_COMMAND_RESULT {
            Command = command,
            StringValue = stringValue,
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // command: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        // string_value: WowMessages.Generator.Generated.DataTypeCstring
        size += StringValue.Length + 1;

        // result: WowMessages.Generator.Generated.DataTypeEnum
        size += 4;

        return size;
    }

}

