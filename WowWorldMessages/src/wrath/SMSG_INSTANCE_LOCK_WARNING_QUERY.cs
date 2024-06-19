using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_INSTANCE_LOCK_WARNING_QUERY: WrathServerMessage, IWorldMessage {
    public required uint Time { get; set; }
    public required uint EncounterMask { get; set; }
    public required byte Unknown { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(EncounterMask, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 11, 327, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 11, 327, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_INSTANCE_LOCK_WARNING_QUERY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var encounterMask = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_INSTANCE_LOCK_WARNING_QUERY {
            Time = time,
            EncounterMask = encounterMask,
            Unknown = unknown,
        };
    }

}

