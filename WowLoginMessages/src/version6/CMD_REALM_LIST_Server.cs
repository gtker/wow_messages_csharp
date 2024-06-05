namespace WowLoginMessages.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Server: Version6ServerMessage, ILoginMessage {
    public required List<Realm> Realms { get; set; }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await w.WriteByte(16, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Size(), cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);

        await w.WriteUShort((ushort)Realms.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Realms) {
            await v.WriteAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUShort(0, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<CMD_REALM_LIST_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var size = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var headerPadding = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var numberOfRealms = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        var realms = new List<Realm>();
        for (var i = 0; i < numberOfRealms; ++i) {
            realms.Add(await Version6.Realm.ReadAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var footerPadding = await r.ReadUShort(cancellationToken).ConfigureAwait(false);

        return new CMD_REALM_LIST_Server {
            Realms = realms,
        };
    }

    internal int Size() {
        var size = 0;

        // size: Generator.Generated.DataTypeInteger
        size += 2;

        // header_padding: Generator.Generated.DataTypeInteger
        size += 4;

        // number_of_realms: Generator.Generated.DataTypeInteger
        size += 2;

        // realms: Generator.Generated.DataTypeArray
        size += Realms.Sum(e => e.Size());

        // footer_padding: Generator.Generated.DataTypeInteger
        size += 2;

        return size - 2;
    }

}

