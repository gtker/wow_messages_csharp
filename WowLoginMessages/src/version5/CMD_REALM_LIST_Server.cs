namespace WowLoginMessages.Version5;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Server: Version5ServerMessage, ILoginMessage {
    public required List<Realm> Realms { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 16, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUShort(w, (ushort)Size(), cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteUInt(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Realms.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Realms) {
            await v.WriteAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await WriteUtils.WriteUShort(w, 0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_REALM_LIST_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var headerPadding = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfRealms = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var realms = new List<Realm>();
        for (var i = 0; i < numberOfRealms; ++i) {
            realms.Add(await Version5.Realm.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var footerPadding = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);

        return new CMD_REALM_LIST_Server {
            Realms = realms,
        };
    }

    internal int Size() {
        var size = 0;

        // size: WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        // header_padding: WowMessages.Generator.Generated.DataTypeInteger
        size += 4;

        // number_of_realms: WowMessages.Generator.Generated.DataTypeInteger
        size += 1;

        // realms: WowMessages.Generator.Generated.DataTypeArray
        size += Realms.Sum(e => e.Size());

        // footer_padding: WowMessages.Generator.Generated.DataTypeInteger
        size += 2;

        return size - 2;
    }

}

