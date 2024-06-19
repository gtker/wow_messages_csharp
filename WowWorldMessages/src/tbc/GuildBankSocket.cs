using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class GuildBankSocket {
    public required byte SocketIndex { get; set; }
    public required uint Gem { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte(SocketIndex, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Gem, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<GuildBankSocket> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var socketIndex = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var gem = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new GuildBankSocket {
            SocketIndex = socketIndex,
            Gem = gem,
        };
    }

}

