using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_QUERY_NEXT_MAIL_TIME_Server: WrathServerMessage, IWorldMessage {
    public required uint FloatValue { get; set; }
    public required List<ReceivedMail> Mails { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(FloatValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Mails.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Mails) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 644, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 644, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_QUERY_NEXT_MAIL_TIME_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var floatValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfMails = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var mails = new List<ReceivedMail>();
        for (var i = 0; i < amountOfMails; ++i) {
            mails.Add(await Wrath.ReceivedMail.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new MSG_QUERY_NEXT_MAIL_TIME_Server {
            FloatValue = floatValue,
            Mails = mails,
        };
    }

    internal int Size() {
        var size = 0;

        // float_value: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_mails: Generator.Generated.DataTypeInteger
        size += 4;

        // mails: Generator.Generated.DataTypeArray
        size += Mails.Sum(e => 24);

        return size;
    }

}

