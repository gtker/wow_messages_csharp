namespace Gtker.WowMessages.Login.Version2;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Server: ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerPublicKey { get; set; }
    public byte GeneratorLength { get; set; }
    public List<byte> Generator { get; set; }
    public byte LargeSafePrimeLength { get; set; }
    public List<byte> LargeSafePrime { get; set; }
    public List<byte> Salt { get; set; }
    public List<byte> CrcSalt { get; set; }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Server> ReadAsync(Stream r) {
        var serverPublicKey = default(List<byte>);
        var generatorLength = default(byte);
        var generator = default(List<byte>);
        var largeSafePrimeLength = default(byte);
        var largeSafePrime = default(List<byte>);
        var salt = default(List<byte>);
        var crcSalt = default(List<byte>);

        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await ReadUtils.ReadByte(r);

        var result = (LoginResult)await ReadUtils.ReadByte(r);

        if (result == LoginResult.Success) {
            serverPublicKey = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                serverPublicKey.Add(await ReadUtils.ReadByte(r));
            }

            // ReSharper disable once UnusedVariable.Compiler
            generatorLength = await ReadUtils.ReadByte(r);

            generator = new List<byte>();
            for (var i = 0; i < generatorLength; ++i) {
                generator.Add(await ReadUtils.ReadByte(r));
            }

            // ReSharper disable once UnusedVariable.Compiler
            largeSafePrimeLength = await ReadUtils.ReadByte(r);

            largeSafePrime = new List<byte>();
            for (var i = 0; i < largeSafePrimeLength; ++i) {
                largeSafePrime.Add(await ReadUtils.ReadByte(r));
            }

            salt = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                salt.Add(await ReadUtils.ReadByte(r));
            }

            crcSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                crcSalt.Add(await ReadUtils.ReadByte(r));
            }

        }
        return new CMD_AUTH_LOGON_CHALLENGE_Server {
            Result = result,
            ServerPublicKey = serverPublicKey,
            GeneratorLength = generatorLength,
            Generator = generator,
            LargeSafePrimeLength = largeSafePrimeLength,
            LargeSafePrime = largeSafePrime,
            Salt = salt,
            CrcSalt = crcSalt,
        };
    }

    public async Task WriteAsync(Stream w) {
        await WriteUtils.WriteByte(w, 0);

        await WriteUtils.WriteByte(w, 0);

        await WriteUtils.WriteByte(w, (byte)Result);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerPublicKey) {
                await WriteUtils.WriteByte(w, v);
            }

            await WriteUtils.WriteByte(w, (byte)Generator.Count);

            foreach (var v in Generator) {
                await WriteUtils.WriteByte(w, v);
            }

            await WriteUtils.WriteByte(w, (byte)LargeSafePrime.Count);

            foreach (var v in LargeSafePrime) {
                await WriteUtils.WriteByte(w, v);
            }

            foreach (var v in Salt) {
                await WriteUtils.WriteByte(w, v);
            }

            foreach (var v in CrcSalt) {
                await WriteUtils.WriteByte(w, v);
            }

        }
    }

}

