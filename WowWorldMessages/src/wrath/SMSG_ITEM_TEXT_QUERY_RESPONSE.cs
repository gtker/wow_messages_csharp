using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ItemTextQueryType = OneOf.OneOf<SMSG_ITEM_TEXT_QUERY_RESPONSE.ItemTextQueryHasText, ItemTextQuery>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ITEM_TEXT_QUERY_RESPONSE: WrathServerMessage, IWorldMessage {
    public class ItemTextQueryHasText {
        public required ulong Item { get; set; }
        public required string Text { get; set; }
    }
    public required ItemTextQueryType Query { get; set; }
    internal ItemTextQuery QueryValue => Query.Match(
        _ => Wrath.ItemTextQuery.HasText,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)QueryValue, cancellationToken).ConfigureAwait(false);

        if (Query.Value is SMSG_ITEM_TEXT_QUERY_RESPONSE.ItemTextQueryHasText itemTextQueryHasText) {
            await w.WriteULong(itemTextQueryHasText.Item, cancellationToken).ConfigureAwait(false);

            await w.WriteCString(itemTextQueryHasText.Text, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 580, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 580, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ITEM_TEXT_QUERY_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        ItemTextQueryType query = (Wrath.ItemTextQuery)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (query.Value is Wrath.ItemTextQuery.HasText) {
            var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

            var text = await r.ReadCString(cancellationToken).ConfigureAwait(false);

            query = new ItemTextQueryHasText {
                Item = item,
                Text = text,
            };
        }

        return new SMSG_ITEM_TEXT_QUERY_RESPONSE {
            Query = query,
        };
    }

    internal int Size() {
        var size = 0;

        // query: Generator.Generated.DataTypeEnum
        size += 1;

        if (Query.Value is SMSG_ITEM_TEXT_QUERY_RESPONSE.ItemTextQueryHasText itemTextQueryHasText) {
            // item: Generator.Generated.DataTypeGuid
            size += 8;

            // text: Generator.Generated.DataTypeCstring
            size += itemTextQueryHasText.Text.Length + 1;

        }

        return size;
    }

}

