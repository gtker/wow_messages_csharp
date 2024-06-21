using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_AUTH_SESSION: WrathClientMessage, IWorldMessage {
    public required uint ClientBuild { get; set; }
    public required uint LoginServerId { get; set; }
    public required string Username { get; set; }
    public required uint LoginServerType { get; set; }
    public required uint ClientSeed { get; set; }
    public required uint RegionId { get; set; }
    public required uint BattlegroundId { get; set; }
    public required uint RealmId { get; set; }
    /// <summary>
    /// Purpose and exact meaning of name unknown.
    /// TrinityCore has this name but never uses the variable afterwards.
    /// </summary>
    public required ulong DosResponse { get; set; }
    public const int ClientProofLength = 20;
    public required byte[] ClientProof { get; set; }
    public required List<byte> AddonInfo { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(ClientBuild, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LoginServerId, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Username, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(LoginServerType, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ClientSeed, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RegionId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(BattlegroundId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RealmId, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(DosResponse, cancellationToken).ConfigureAwait(false);

        foreach (var v in ClientProof) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        if (AddonInfo.Count != 0) {
            var oldStream = w;
            w = new MemoryStream();
            foreach (var v in AddonInfo) {
                await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
            }
            var uncompressedLength = w.Position;

            var compressedOutput = new MemoryStream();
            var zlib = new System.IO.Compression.ZLibStream(compressedOutput, System.IO.Compression.CompressionMode.Compress);
            zlib.Write((w as MemoryStream)!.ToArray());
            zlib.Flush();

            w = oldStream;
            await w.WriteUInt((uint)uncompressedLength, cancellationToken).ConfigureAwait(false);
            await w.WriteAsync(compressedOutput.ToArray(), cancellationToken).ConfigureAwait(false);
        }
        else {
            await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 493, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 493, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_AUTH_SESSION> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        // ReSharper disable once InconsistentNaming
        var __size = 0;
        var clientBuild = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var loginServerId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var username = await r.ReadCString(cancellationToken).ConfigureAwait(false);
        __size += username.Length + 1;

        var loginServerType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var clientSeed = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var regionId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var battlegroundId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var realmId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var dosResponse = await r.ReadULong(cancellationToken).ConfigureAwait(false);
        __size += 8;

        var clientProof = new byte[ClientProofLength];
        for (var i = 0; i < ClientProofLength; ++i) {
            clientProof[i] = await r.ReadByte(cancellationToken).ConfigureAwait(false);
            __size += 1;
        }

        var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        __size += 4;

        var decompressed = new byte[decompressedLength];
        var remaining = new byte[bodySize - __size];
        await r.ReadExactlyAsync(remaining, cancellationToken).ConfigureAwait(false);

        var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);
        zlib.ReadAtLeast(decompressed, remaining.Length);

        r = new MemoryStream(decompressed);
        var addonInfo = new List<byte>();
        while (r.Position < r.Length) {
            addonInfo.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
            __size += 1;
        }

        return new CMSG_AUTH_SESSION {
            ClientBuild = clientBuild,
            LoginServerId = loginServerId,
            Username = username,
            LoginServerType = loginServerType,
            ClientSeed = clientSeed,
            RegionId = regionId,
            BattlegroundId = battlegroundId,
            RealmId = realmId,
            DosResponse = dosResponse,
            ClientProof = clientProof,
            AddonInfo = addonInfo,
        };
    }

    internal int Size() {
        var memory = new MemoryStream();
        Task.WaitAll(WriteBodyAsync(memory));
        return (int)memory.Position;
    }

}

