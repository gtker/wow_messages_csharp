using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_GMRESPONSE_RECEIVED: WrathServerMessage, IWorldMessage {
    public required uint ResponseId { get; set; }
    public required uint TicketId { get; set; }
    public required string Message { get; set; }
    public const int ResponseLength = 4;
    public required string[] Response { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ResponseId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TicketId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Message, cancellationToken).ConfigureAwait(false);

        foreach (var v in Response) {
            await w.WriteCString(v, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1263, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1263, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_GMRESPONSE_RECEIVED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var responseId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var ticketId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var message = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var response = new string[ResponseLength];
        for (var i = 0; i < ResponseLength; ++i) {
            response[i] = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        }

        return new SMSG_GMRESPONSE_RECEIVED {
            ResponseId = responseId,
            TicketId = ticketId,
            Message = message,
            Response = response,
        };
    }

    internal int Size() {
        var size = 0;

        // response_id: Generator.Generated.DataTypeInteger
        size += 4;

        // ticket_id: Generator.Generated.DataTypeInteger
        size += 4;

        // message: Generator.Generated.DataTypeCstring
        size += Message.Length + 1;

        // response: Generator.Generated.DataTypeArray
        size += Response.Sum(e => e.Length + 1);

        return size;
    }

}

