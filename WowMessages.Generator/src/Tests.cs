using System.IO.Compression;
using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator;

public static class Tests
{
    public static void RunTests()
    {
        Versions();
        WorldCompression();
    }

    private static void WorldCompression()
    {
        byte[] compressed =
        [
            0x78, 0x9c, 0x75, 0xcc, 0xbd, 0x0e, 0xc2, 0x30, 0x0c,
            0x04, 0xe0, 0xf2, 0x1e, 0xbc, 0x0c, 0x61, 0x40, 0x95,
            0xc8, 0x42, 0xc3, 0x8c, 0x4c, 0xe2, 0x22, 0x0b, 0xc7,
            0xa9, 0x8c, 0xcb, 0x4f, 0x9f, 0x1e, 0x16, 0x24, 0x06,
            0x73, 0xeb, 0x77, 0x77, 0x81, 0x69, 0x59, 0x40, 0xcb,
            0x69, 0x33, 0x67, 0xa3, 0x26, 0xc7, 0xbe, 0x5b, 0xd5,
            0xc7, 0x7a, 0xdf, 0x7d, 0x12, 0xbe, 0x16, 0xc0, 0x8c,
            0x71, 0x24, 0xe4, 0x12, 0x49, 0xa8, 0xc2, 0xe4, 0x95,
            0x48, 0x0a, 0xc9, 0xc5, 0x3d, 0xd8, 0xb6, 0x7a, 0x06,
            0x4b, 0xf8, 0x34, 0x0f, 0x15, 0x46, 0x73, 0x67, 0xbb,
            0x38, 0xcc, 0x7a, 0xc7, 0x97, 0x8b, 0xbd, 0xdc, 0x26,
            0xcc, 0xfe, 0x30, 0x42, 0xd6, 0xe6, 0xca, 0x01, 0xa8,
            0xb8, 0x90, 0x80, 0x51, 0xfc, 0xb7, 0xa4, 0x50, 0x70,
            0xb8, 0x12, 0xf3, 0x3f, 0x26, 0x41, 0xfd, 0xb5, 0x37,
            0x90, 0x19, 0x66, 0x8f
        ];

        byte[] expected =
        [
            66, 108, 105, 122, 122, 97, 114, 100, 95, 65, 117, 99, 116, 105, 111, 110, 85, 73,
            0, // [0].AddonInfo.addon_name: CString
            1, // [0].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [0].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [0].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 66, 97, 116, 116, 108, 101, 102, 105, 101, 108, 100, 77, 105, 110,
            105, 109, 97, 112, 0, // [1].AddonInfo.addon_name: CString
            1, // [1].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [1].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [1].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 66, 105, 110, 100, 105, 110, 103, 85, 73,
            0, // [2].AddonInfo.addon_name: CString
            1, // [2].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [2].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [2].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 67, 111, 109, 98, 97, 116, 84, 101, 120, 116,
            0, // [3].AddonInfo.addon_name: CString
            1, // [3].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [3].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [3].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 67, 114, 97, 102, 116, 85, 73,
            0, // [4].AddonInfo.addon_name: CString
            1, // [4].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [4].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [4].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 71, 77, 83, 117, 114, 118, 101, 121, 85, 73,
            0, // [5].AddonInfo.addon_name: CString
            1, // [5].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [5].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [5].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 73, 110, 115, 112, 101, 99, 116, 85, 73,
            0, // [6].AddonInfo.addon_name: CString
            1, // [6].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [6].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [6].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 77, 97, 99, 114, 111, 85, 73,
            0, // [7].AddonInfo.addon_name: CString
            1, // [7].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [7].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [7].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 82, 97, 105, 100, 85, 73, 0, // [8].AddonInfo.addon_name: CString
            1, // [8].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [8].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [8].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 84, 97, 108, 101, 110, 116, 85, 73,
            0, // [9].AddonInfo.addon_name: CString
            1, // [9].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [9].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [9].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 84, 114, 97, 100, 101, 83, 107, 105, 108, 108, 85, 73,
            0, // [10].AddonInfo.addon_name: CString
            1, // [10].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [10].AddonInfo.addon_crc: u32
            0, 0, 0, 0, // [10].AddonInfo.addon_extra_crc: u32
            66, 108, 105, 122, 122, 97, 114, 100, 95, 84, 114, 97, 105, 110, 101, 114, 85, 73,
            0, // [11].AddonInfo.addon_name: CString
            1, // [11].AddonInfo.addon_has_signature: u8
            109, 119, 28, 76, // [11].AddonInfo.addon_crc: u32
            0, 0, 0, 0 // [11].AddonInfo.addon_extra_crc: u32
        ];

        var decompressed = new byte[expected.Length];
        using var z = new ZLibStream(new MemoryStream(compressed), CompressionMode.Decompress);

        z.ReadAtLeast(decompressed, expected.Length);

        if (!decompressed.SequenceEqual(expected))
        {
            throw new Exception("decompression fails");
        }

        var mem = new MemoryStream();
        using var compressStream = new ZLibStream(mem, CompressionMode.Compress);
        compressStream.Write(decompressed);
        var compressedActual = mem.ToArray();
    }

    private static void Versions()
    {
        var shouldNotPass = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 1
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 2
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 3
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 4
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 5
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 6
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 7
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 8
                    }
                ]
            }
        };

        if (shouldNotPass.ShouldWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Accepts messages that it shouldn't");
        }

        var shouldPass = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 12
                    }
                ]
            }
        };

        if (shouldPass.ShouldNotWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Rejects messages that it shouldn't");
        }

        var shouldNotPass2 = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 2,
                        Minor = 4,
                        Patch = 3
                    },
                    new WorldVersion
                    {
                        Major = 3
                    }
                ]
            }
        };

        if (shouldNotPass2.ShouldWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Accepts messages that it shouldn't 2");
        }
    }
}