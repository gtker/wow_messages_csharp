using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_DEFENSE_MESSAGE: WrathServerMessage, IWorldMessage {
    public required Wrath.Area Area { get; set; }
    public required string Message { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteSizedCString(Message, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 826, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 826, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_DEFENSE_MESSAGE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var message = await r.ReadSizedCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_DEFENSE_MESSAGE {
            Area = area,
            Message = message,
        };
    }

    internal int Size() {
        var size = 0;

        // area: Generator.Generated.DataTypeEnum
        size += 4;

        // message: Generator.Generated.DataTypeSizedCstring
        size += Message.Length + 5;

        return size;
    }

}

