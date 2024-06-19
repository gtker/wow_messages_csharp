using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SPELL_COOLDOWN: TbcServerMessage, IWorldMessage {
    public required ulong Guid { get; set; }
    public required byte Flags { get; set; }
    public required List<SpellCooldownStatus> Cooldowns { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Flags, cancellationToken).ConfigureAwait(false);

        foreach (var v in Cooldowns) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 308, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 308, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SPELL_COOLDOWN> ReadBodyAsync(Stream r, uint bodySize, CancellationToken cancellationToken = default) {
        var size = 0;
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);
        size += 8;

        var flags = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        size += 1;

        var cooldowns = new List<SpellCooldownStatus>();
        while (size <= bodySize) {
            cooldowns.Add(await Tbc.SpellCooldownStatus.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
            size += 8;
        }

        return new SMSG_SPELL_COOLDOWN {
            Guid = guid,
            Flags = flags,
            Cooldowns = cooldowns,
        };
    }

    internal int Size() {
        var size = 0;

        // guid: Generator.Generated.DataTypeGuid
        size += 8;

        // flags: Generator.Generated.DataTypeInteger
        size += 1;

        // cooldowns: Generator.Generated.DataTypeArray
        size += Cooldowns.Sum(e => 8);

        return size;
    }

}

