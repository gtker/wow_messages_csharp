using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class BankTab {
    public required uint Flags { get; set; }
    public required uint StacksPerDay { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(StacksPerDay, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<BankTab> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var stacksPerDay = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new BankTab {
            Flags = flags,
            StacksPerDay = stacksPerDay,
        };
    }

}

