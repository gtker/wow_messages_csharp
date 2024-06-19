using WowSrp.Header;
using WowWorldMessages.All;

namespace WowWorldMessages.Wrath;

using CorpseQueryResultType = OneOf.OneOf<MSG_CORPSE_QUERY_Server.CorpseQueryResultFound, CorpseQueryResult>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class MSG_CORPSE_QUERY_Server: WrathServerMessage, IWorldMessage {
    public class CorpseQueryResultFound {
        public required Wrath.Map CorpseMap { get; set; }
        public required Wrath.Map Map { get; set; }
        public required Vector3d Position { get; set; }
    }
    public required CorpseQueryResultType Result { get; set; }
    internal CorpseQueryResult ResultValue => Result.Match(
        _ => Wrath.CorpseQueryResult.Found,
        v => v
    );
    public required uint Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)ResultValue, cancellationToken).ConfigureAwait(false);

        if (Result.Value is MSG_CORPSE_QUERY_Server.CorpseQueryResultFound corpseQueryResultFound) {
            await w.WriteUInt((uint)corpseQueryResultFound.Map, cancellationToken).ConfigureAwait(false);

            await corpseQueryResultFound.Position.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

            await w.WriteUInt((uint)corpseQueryResultFound.CorpseMap, cancellationToken).ConfigureAwait(false);

        }

        await w.WriteUInt(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 534, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 534, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MSG_CORPSE_QUERY_Server> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        CorpseQueryResultType result = (Wrath.CorpseQueryResult)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (result.Value is Wrath.CorpseQueryResult.Found) {
            var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            var position = await Vector3d.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

            var corpseMap = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

            result = new CorpseQueryResultFound {
                CorpseMap = corpseMap,
                Map = map,
                Position = position,
            };
        }

        var unknown = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new MSG_CORPSE_QUERY_Server {
            Result = result,
            Unknown = unknown,
        };
    }

    internal int Size() {
        var size = 0;

        // result: Generator.Generated.DataTypeEnum
        size += 1;

        if (Result.Value is MSG_CORPSE_QUERY_Server.CorpseQueryResultFound corpseQueryResultFound) {
            // map: Generator.Generated.DataTypeEnum
            size += 4;

            // position: Generator.Generated.DataTypeStruct
            size += 12;

            // corpse_map: Generator.Generated.DataTypeEnum
            size += 4;

        }

        // unknown: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

