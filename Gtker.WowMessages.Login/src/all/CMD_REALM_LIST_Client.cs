namespace Gtker.WowMessages.Login.All;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_REALM_LIST_Client {

    public static async Task<CMD_REALM_LIST_Client> Read(Stream r) {
        // ReSharper disable once UnusedVariable.Compiler
        var padding = await ReadUtils.ReadUInt(r);

        return new CMD_REALM_LIST_Client {
        };
    }

    public async Task Write(Stream w) {
        await WriteUtils.WriteUInt(w, 0);

    }

}

