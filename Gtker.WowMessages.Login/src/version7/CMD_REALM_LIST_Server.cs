namespace Gtker.WowMessages.Login.Version7;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Server: Version7ServerMessage, ILoginMessage {
    public required List<Realm> Realms { get; set; }

    public static async Task<CMD_REALM_LIST_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r, cancellationToken);

        // ReSharper disable once UnusedVariable.Compiler
        var headerPadding = await ReadUtils.ReadUInt(r, cancellationToken);

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfRealms = await ReadUtils.ReadUShort(r, cancellationToken);

        var realms = new List<Realm>();
        for (var i = 0; i < numberOfRealms; ++i) {
            realms.Add(await Realm.ReadAsync(r, cancellationToken));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var footerPadding = await ReadUtils.ReadUShort(r, cancellationToken);

        return new CMD_REALM_LIST_Server {
            Realms = realms,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 16, cancellationToken);

        await WriteUtils.WriteUShort(w, (ushort)Size(), cancellationToken);

        await WriteUtils.WriteUInt(w, 0, cancellationToken);

        await WriteUtils.WriteUShort(w, (ushort)Realms.Count, cancellationToken);

        foreach (var v in Realms) {
            await v.WriteAsync(w, cancellationToken);
        }

        await WriteUtils.WriteUShort(w, 0, cancellationToken);

    }

    public int Size() {
        var size = 0;

        // size: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        // header_padding: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // number_of_realms: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        // realms: Gtker.WowMessages.Generator.Generated.DataTypeArray
        size += Realms.Sum(e => e.Size());

        // footer_padding: Gtker.WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        return size - 2;
    }

}

