namespace Gtker.WowMessages.Login.Version6;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMD_AUTH_LOGON_CHALLENGE_Server: Version6ServerMessage, ILoginMessage {
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
    /// <summary>
    /// Number of columns to display.
    /// </summary>
    public byte Width { get; set; }
    /// <summary>
    /// Number of rows to display.
    /// </summary>
    public byte Height { get; set; }
    /// <summary>
    /// Number of digits to be entered for each cell.
    /// </summary>
    public byte DigitCount { get; set; }
    /// <summary>
    /// Number of cells to complete.
    /// </summary>
    public byte ChallengeCount { get; set; }
    /// <summary>
    /// Seed value used to randomize cell selection.
    /// </summary>
    public ulong Seed { get; set; }

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
        var width = default(byte);
        var height = default(byte);
        var digitCount = default(byte);
        var challengeCount = default(byte);
        var seed = default(ulong);

        // ReSharper disable once UnusedVariable.Compiler
        var protocolVersion = await ReadUtils.ReadByte(r, cancellationToken);

        var result = (LoginResult)await ReadUtils.ReadByte(r, cancellationToken);

        if (result == LoginResult.Success) {
            serverPublicKey = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                serverPublicKey.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            // ReSharper disable once UnusedVariable.Compiler
            generatorLength = await ReadUtils.ReadByte(r, cancellationToken);

            generator = new List<byte>();
            for (var i = 0; i < generatorLength; ++i) {
                generator.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            // ReSharper disable once UnusedVariable.Compiler
            largeSafePrimeLength = await ReadUtils.ReadByte(r, cancellationToken);

            largeSafePrime = new List<byte>();
            for (var i = 0; i < largeSafePrimeLength; ++i) {
                largeSafePrime.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            salt = new List<byte>();
            for (var i = 0; i < 32; ++i) {
                salt.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            crcSalt = new List<byte>();
            for (var i = 0; i < 16; ++i) {
                crcSalt.Add(await ReadUtils.ReadByte(r, cancellationToken));
            }

            securityFlag = (SecurityFlag)await ReadUtils.ReadByte(r, cancellationToken);

            if (securityFlag.HasFlag(SecurityFlag.Pin)) {
                pinGridSeed = await ReadUtils.ReadUInt(r, cancellationToken);

                pinSalt = new List<byte>();
                for (var i = 0; i < 16; ++i) {
                    pinSalt.Add(await ReadUtils.ReadByte(r, cancellationToken));
                }

            }

            if (securityFlag.HasFlag(SecurityFlag.MatrixCard)) {
                width = await ReadUtils.ReadByte(r, cancellationToken);

                height = await ReadUtils.ReadByte(r, cancellationToken);

                digitCount = await ReadUtils.ReadByte(r, cancellationToken);

                challengeCount = await ReadUtils.ReadByte(r, cancellationToken);

                seed = await ReadUtils.ReadULong(r, cancellationToken);

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
            Width = width,
            Height = height,
            DigitCount = digitCount,
            ChallengeCount = challengeCount,
            Seed = seed,
        };
    }

    public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default) {
        // opcode: u8
        await WriteUtils.WriteByte(w, 0, cancellationToken);

        await WriteUtils.WriteByte(w, 0, cancellationToken);

        await WriteUtils.WriteByte(w, (byte)Result, cancellationToken);

        if (Result == LoginResult.Success) {
            foreach (var v in ServerPublicKey) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            await WriteUtils.WriteByte(w, (byte)Generator.Count, cancellationToken);

            foreach (var v in Generator) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            await WriteUtils.WriteByte(w, (byte)LargeSafePrime.Count, cancellationToken);

            foreach (var v in LargeSafePrime) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            foreach (var v in Salt) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            foreach (var v in CrcSalt) {
                await WriteUtils.WriteByte(w, v, cancellationToken);
            }

            await WriteUtils.WriteByte(w, (byte)SecurityFlag, cancellationToken);

            if (SecurityFlag.HasFlag(SecurityFlag.Pin)) {
                await WriteUtils.WriteUInt(w, PinGridSeed, cancellationToken);

                foreach (var v in PinSalt) {
                    await WriteUtils.WriteByte(w, v, cancellationToken);
                }

            }

            if (SecurityFlag.HasFlag(SecurityFlag.MatrixCard)) {
                await WriteUtils.WriteByte(w, Width, cancellationToken);

                await WriteUtils.WriteByte(w, Height, cancellationToken);

                await WriteUtils.WriteByte(w, DigitCount, cancellationToken);

                await WriteUtils.WriteByte(w, ChallengeCount, cancellationToken);

                await WriteUtils.WriteULong(w, Seed, cancellationToken);

            }

        }

    }

}

