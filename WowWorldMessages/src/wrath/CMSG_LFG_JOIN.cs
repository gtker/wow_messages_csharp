using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LFG_JOIN: WrathClientMessage, IWorldMessage {
    public required uint Roles { get; set; }
    public required bool NoPartialClear { get; set; }
    public required bool Achievements { get; set; }
    public required List<uint> Slots { get; set; }
    public required List<byte> Needs { get; set; }
    public required string Comment { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Roles, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(NoPartialClear, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Achievements, cancellationToken).ConfigureAwait(false);

        await w.WriteByte((byte)Slots.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Slots) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteByte((byte)Needs.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Needs) {
            await w.WriteByte(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteCString(Comment, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 860, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, (uint)Size() + 4, 860, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LFG_JOIN> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var roles = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var noPartialClear = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var achievements = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfSlots = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var slots = new List<uint>();
        for (var i = 0; i < amountOfSlots; ++i) {
            slots.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfNeeds = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var needs = new List<byte>();
        for (var i = 0; i < amountOfNeeds; ++i) {
            needs.Add(await r.ReadByte(cancellationToken).ConfigureAwait(false));
        }

        var comment = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new CMSG_LFG_JOIN {
            Roles = roles,
            NoPartialClear = noPartialClear,
            Achievements = achievements,
            Slots = slots,
            Needs = needs,
            Comment = comment,
        };
    }

    internal int Size() {
        var size = 0;

        // roles: Generator.Generated.DataTypeInteger
        size += 4;

        // no_partial_clear: Generator.Generated.DataTypeBool
        size += 1;

        // achievements: Generator.Generated.DataTypeBool
        size += 1;

        // amount_of_slots: Generator.Generated.DataTypeInteger
        size += 1;

        // slots: Generator.Generated.DataTypeArray
        size += Slots.Sum(e => 4);

        // amount_of_needs: Generator.Generated.DataTypeInteger
        size += 1;

        // needs: Generator.Generated.DataTypeArray
        size += Needs.Sum(e => 1);

        // comment: Generator.Generated.DataTypeCstring
        size += Comment.Length + 1;

        return size;
    }

}

