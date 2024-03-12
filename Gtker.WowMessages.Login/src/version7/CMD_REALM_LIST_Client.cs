namespace Gtker.WowMessages.Login.Version7;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Client: ILoginMessage {

    public static async Task<CMD_REALM_LIST_Client> ReadAsync(Stream r) {
        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUInt(r);

        return new CMD_REALM_LIST_Client {
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 16);

        await WriteUtils.WriteUInt(w, 0);

    }

}

