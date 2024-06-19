using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_COMMAND_RESULT: WrathServerMessage, IWorldMessage {
    /// <summary>
    /// All emus set to 0.
    /// </summary>
    public required uint Unknown1 { get; set; }
    /// <summary>
    /// All emus set to 0.
    /// </summary>
    public required byte Unknown2 { get; set; }
    public required string Name { get; set; }
    public required uint Result { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteCString(Name, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Result, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1085, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1085, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_COMMAND_RESULT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var unknown1 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var name = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        var result = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_COMMAND_RESULT {
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            Name = name,
            Result = result,
        };
    }

    internal int Size() {
        var size = 0;

        // unknown1: Generator.Generated.DataTypeInteger
        size += 4;

        // unknown2: Generator.Generated.DataTypeInteger
        size += 1;

        // name: Generator.Generated.DataTypeCstring
        size += Name.Length + 1;

        // result: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

