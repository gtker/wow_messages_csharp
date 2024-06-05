using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

using CorpseQueryResultType = OneOf.OneOf<MSG_CORPSE_QUERY_Server.CorpseQueryResultFound, CorpseQueryResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_CORPSE_QUERY_Server: VanillaServerMessage, IWorldMessage {
    public class CorpseQueryResultFound {
        public required Map CorpseMap { get; set; }
        public required Map Map { get; set; }
        public required Vector3d Position { get; set; }
    }
    public required CorpseQueryResultType Result { get; set; }
    internal CorpseQueryResult ResultValue => Result.Match(
        _ => Vanilla.CorpseQueryResult.Found,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is MSG_CORPSE_QUERY_Server.CorpseQueryResultFound found) {
            await w.WriteUInt((uint)found.Map, cancellationToken).ConfigureAwait(false);

            await found.Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)found.CorpseMap, cancellationToken).ConfigureAwait(false);

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 534, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 534, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_CORPSE_QUERY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        CorpseQueryResultType result = (CorpseQueryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Vanilla.CorpseQueryResult.Found) {
            var map = (Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var corpseMap = (Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new CorpseQueryResultFound {
                CorpseMap = corpseMap,
                Map = map,
                Position = position,
            };
        }

        return new MSG_CORPSE_QUERY_Server {
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is MSG_CORPSE_QUERY_Server.CorpseQueryResultFound found) {
            // map: Generator.Generated.DataTypeEnum
            size += 4;

            // position: Generator.Generated.DataTypeStruct
            size += 12;

            // corpse_map: Generator.Generated.DataTypeEnum
            size += 4;

        }

        return size;
    }

}

