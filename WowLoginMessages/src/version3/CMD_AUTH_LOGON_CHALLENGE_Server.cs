namespace WowLoginMessages.Version3;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Server: Version3ServerMessage, ILoginMessage {
    public required LoginResult Result { get; set; }
    public List<byte> ServerPublicKey { get; set; }
    public List<byte> Generator { get; set; }
    public List<byte> LargeSafePrime { get; set; }
    public List<byte> Salt { get; set; }
    /// <summary>
    /// Used for the `crc_hash` in [CMD_AUTH_LOGON_PROOF_Client].
    /// </summary>
    public List<byte> CrcSalt { get; set; }
    public SecurityFlag SecurityFlag { get; set; }
    /// <summary>
    /// Used to randomize the layout of the PIN keypad.
    /// </summary>
    public uint PinGridSeed { get; set; }
    public List<byte> PinSalt { get; set; }

    public static async Task<CMD_AUTH_LOGON_CHALLENGE_Server> ReadAsync(Stream r, CancellationToken cancellationToken = default) {
        var serverPublicKey = default(List<byte>);
        var generatorLength = default(byte);
        var generator = default(List<byte>);
        var largeSafePrimeLength = default(byte);
        var largeSafePrime = default(List<byte>);
        var salt = default(List<byte>);
        var crcSalt = default(List<byte>);
        var securityFlag = default(SecurityFlag);
        var pinGridSeed = default(uint);
        var pinSalt = default(List<byte>);

        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

        if (result == LoginResult.Success) {
            serverPublicKey = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                serverPublicKey.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            // ReSharper disable once UnusedVariable.Compiler
            generatorLength = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            generator = new List<byte>();
            for (var i = 0; i < generatorLength; ++i) {
                generator.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            // ReSharper disable once UnusedVariable.Compiler
            largeSafePrimeLength = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            largeSafePrime = new List<byte>();
            for (var i = 0; i < largeSafePrimeLength; ++i) {
                largeSafePrime.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            salt = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                salt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            crcSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                crcSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
            }

            securityFlag = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);

            if (securityFlag == SecurityFlag.Pin) {
                pinGridSeed = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);

                pinSalt = new List<byte>();
                for (var i = 0; i < 16; ++i) {
                    pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false));
                }

            }

        }

        return new CMD_AUTH_LOGON_CHALLENGE_Server {
            Result = result,
            ServerPublicKey = serverPublicKey,
            Generator = generator,
            LargeSafePrime = largeSafePrime,
            Salt = salt,
            CrcSalt = crcSalt,
            SecurityFlag = securityFlag,
            PinGridSeed = pinGridSeed,
            PinSalt = pinSalt,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, 0, cancellationToken).ConfigureAwait(false);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken).ConfigureAwait(false);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerPublicKey) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)Generator.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in Generator) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)LargeSafePrime.Count, cancellationToken).ConfigureAwait(false);

            foreach (var v in LargeSafePrime) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in Salt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            foreach (var v in CrcSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
            }

            await WriteUtils.WriteByte(w, (byte)SecurityFlag, cancellationToken).ConfigureAwait(false);

            if (SecurityFlag == SecurityFlag.Pin) {
                await WriteUtils.WriteUInt(w, PinGridSeed, cancellationToken).ConfigureAwait(false);

                foreach (var v in PinSalt) {
                    await WriteUtils.WriteByte(w, v, cancellationToken).ConfigureAwait(false);
                }

            }

        }

    }

}

