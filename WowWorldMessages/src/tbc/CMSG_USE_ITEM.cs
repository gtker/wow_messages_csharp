using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_USE_ITEM: TbcClientMessage, IWorldMessage {
    public required byte BagIndex { get; set; }
    public required byte BagSlot { get; set; }
    public required byte SpellIndex { get; set; }
    /// <summary>
    /// mangosone: next cast if exists (single or not)
    /// </summary>
    public required byte CastCount { get; set; }
    public required ulong Item { get; set; }
    public required SpellCastTargets Targets { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(BagIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(BagSlot, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(SpellIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(CastCount, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(Item, cancellationToken).ConfigureAwait(false);

        await Targets.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 171, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 171, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_USE_ITEM> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var bagIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var bagSlot = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var spellIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var castCount = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var targets = await SpellCastTargets.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);

        return new CMSG_USE_ITEM {
            BagIndex = bagIndex,
            BagSlot = bagSlot,
            SpellIndex = spellIndex,
            CastCount = castCount,
            Item = item,
            Targets = targets,
        };
    }

    internal int Size() {
        var size = 0;

        // bag_index: Generator.Generated.DataTypeInteger
        size += 1;

        // bag_slot: Generator.Generated.DataTypeInteger
        size += 1;

        // spell_index: Generator.Generated.DataTypeInteger
        size += 1;

        // cast_count: Generator.Generated.DataTypeInteger
        size += 1;

        // item: Generator.Generated.DataTypeGuid
        size += 8;

        // targets: Generator.Generated.DataTypeStruct
        size += Targets.Size();

        return size;
    }

}

