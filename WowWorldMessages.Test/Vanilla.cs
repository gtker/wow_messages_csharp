using WowWorldMessages.Vanilla;

namespace WowWorldMessages.Test;

public class Vanilla {
    [Test]
    [Timeout(1000)]
    public async Task CMSG_WORLD_TELEPORT0() {
        var r = new MemoryStream([0, 28, 8, 0, 0, 0, 239, 190, 173, 222, 1, 0, 0, 0, 0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64, ]);

        var c = (CMSG_WORLD_TELEPORT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_WORLD_TELEPORT1() {
        var r = new MemoryStream([0, 28, 8, 0, 0, 0, 154, 61, 9, 2, 213, 1, 0, 0, 0, 0, 226, 67, 0, 176, 201, 69, 0, 128, 30, 69, 219, 15, 73, 64, ]);

        var c = (CMSG_WORLD_TELEPORT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_TELEPORT_TO_UNIT0() {
        var r = new MemoryStream([0, 11, 9, 0, 0, 0, 86, 117, 114, 116, 110, 101, 0, ]);

        var c = (CMSG_TELEPORT_TO_UNIT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CHAR_CREATE0() {
        var r = new MemoryStream([0, 22, 54, 0, 0, 0, 68, 101, 97, 100, 98, 101, 101, 102, 0, 1, 1, 1, 8, 0, 14, 2, 4, 0, ]);

        var c = (CMSG_CHAR_CREATE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CHAR_ENUM0() {
        var r = new MemoryStream([0, 4, 55, 0, 0, 0, ]);

        var c = (CMSG_CHAR_ENUM)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CHAR_DELETE0() {
        var r = new MemoryStream([0, 12, 56, 0, 0, 0, 239, 190, 173, 222, 0, 0, 0, 0, ]);

        var c = (CMSG_CHAR_DELETE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHAR_CREATE0() {
        var r = new MemoryStream([0, 3, 58, 0, 47, ]);

        var c = (SMSG_CHAR_CREATE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHAR_ENUM0() {
        var r = new MemoryStream([0, 3, 59, 0, 0, ]);

        var c = (SMSG_CHAR_ENUM)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHAR_DELETE0() {
        var r = new MemoryStream([0, 3, 60, 0, 57, ]);

        var c = (SMSG_CHAR_DELETE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_PLAYER_LOGIN0() {
        var r = new MemoryStream([0, 12, 61, 0, 0, 0, 239, 190, 173, 222, 0, 0, 0, 0, ]);

        var c = (CMSG_PLAYER_LOGIN)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_NEW_WORLD0() {
        var r = new MemoryStream([0, 22, 62, 0, 1, 0, 0, 0, 0, 160, 186, 68, 0, 236, 137, 197, 205, 204, 184, 65, 205, 204, 76, 62, ]);

        var c = (SMSG_NEW_WORLD)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_TRANSFER_PENDING0() {
        var r = new MemoryStream([0, 6, 63, 0, 1, 0, 0, 0, ]);

        var c = (SMSG_TRANSFER_PENDING)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHARACTER_LOGIN_FAILED0() {
        var r = new MemoryStream([0, 3, 65, 0, 65, ]);

        var c = (SMSG_CHARACTER_LOGIN_FAILED)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_LOGIN_SETTIMESPEED0() {
        var r = new MemoryStream([0, 10, 66, 0, 10, 50, 115, 22, 137, 136, 136, 60, ]);

        var c = (SMSG_LOGIN_SETTIMESPEED)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_PLAYER_LOGOUT0() {
        var r = new MemoryStream([0, 4, 74, 0, 0, 0, ]);

        var c = (CMSG_PLAYER_LOGOUT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_LOGOUT_REQUEST0() {
        var r = new MemoryStream([0, 4, 75, 0, 0, 0, ]);

        var c = (CMSG_LOGOUT_REQUEST)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_LOGOUT_RESPONSE0() {
        var r = new MemoryStream([0, 7, 76, 0, 0, 0, 0, 0, 1, ]);

        var c = (SMSG_LOGOUT_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_LOGOUT_COMPLETE0() {
        var r = new MemoryStream([0, 2, 77, 0, ]);

        var c = (SMSG_LOGOUT_COMPLETE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_NAME_QUERY_RESPONSE0() {
        var r = new MemoryStream([0, 28, 81, 0, 239, 190, 173, 222, 0, 0, 0, 0, 65, 115, 100, 102, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, ]);

        var c = (SMSG_NAME_QUERY_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_NAME_QUERY_RESPONSE1() {
        var r = new MemoryStream([0, 29, 81, 0, 239, 190, 173, 222, 0, 0, 0, 0, 65, 115, 100, 102, 0, 65, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, ]);

        var c = (SMSG_NAME_QUERY_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_PET_NAME_QUERY0() {
        var r = new MemoryStream([0, 16, 82, 0, 0, 0, 239, 190, 173, 222, 239, 190, 173, 222, 222, 202, 250, 0, ]);

        var c = (CMSG_PET_NAME_QUERY)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_PET_NAME_QUERY_RESPONSE0() {
        var r = new MemoryStream([0, 17, 83, 0, 239, 190, 173, 222, 65, 66, 67, 68, 69, 70, 0, 222, 202, 250, 0, ]);

        var c = (SMSG_PET_NAME_QUERY_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ITEM_QUERY_SINGLE_RESPONSE0() {
        var r = new MemoryStream([1, 224, 88, 0, 62, 28, 0, 0, 2, 0, 0, 0, 5, 0, 0, 0, 83, 109, 105, 116, 101, 39, 115, 32, 77, 105, 103, 104, 116, 121, 32, 72, 97, 109, 109, 101, 114, 0, 0, 0, 0, 154, 76, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 155, 60, 0, 0, 31, 12, 0, 0, 17, 0, 0, 0, 223, 5, 0, 0, 255, 1, 0, 0, 23, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 11, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 92, 66, 0, 0, 166, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_ITEM_QUERY_SINGLE_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CREATURE_QUERY_RESPONSE0() {
        var r = new MemoryStream([0, 46, 97, 0, 69, 0, 0, 0, 84, 104, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_CREATURE_QUERY_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_IGNORE_LIST0() {
        var r = new MemoryStream([0, 11, 107, 0, 1, 239, 190, 173, 222, 254, 15, 220, 186, ]);

        var c = (SMSG_IGNORE_LIST)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_IGNORE_LIST1() {
        var r = new MemoryStream([0, 19, 107, 0, 2, 239, 190, 173, 222, 254, 15, 220, 186, 239, 190, 173, 222, 0, 0, 0, 0, ]);

        var c = (SMSG_IGNORE_LIST)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_MESSAGECHAT0() {
        var r = new MemoryStream([0, 35, 149, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 84, 104, 105, 115, 32, 105, 115, 32, 97, 32, 115, 97, 121, 32, 109, 101, 115, 115, 97, 103, 101, 46, 0, ]);

        var c = (CMSG_MESSAGECHAT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_JOIN_CHANNEL0() {
        var r = new MemoryStream([0, 29, 151, 0, 0, 0, 71, 101, 110, 101, 114, 97, 108, 32, 45, 32, 69, 108, 119, 121, 110, 110, 32, 70, 111, 114, 101, 115, 116, 0, 0, ]);

        var c = (CMSG_JOIN_CHANNEL)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_JOIN_CHANNEL1() {
        var r = new MemoryStream([0, 34, 151, 0, 0, 0, 76, 111, 99, 97, 108, 68, 101, 102, 101, 110, 115, 101, 32, 45, 32, 69, 108, 119, 121, 110, 110, 32, 70, 111, 114, 101, 115, 116, 0, 0, ]);

        var c = (CMSG_JOIN_CHANNEL)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_DESTROY_OBJECT0() {
        var r = new MemoryStream([0, 10, 170, 0, 6, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_DESTROY_OBJECT)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_FORWARD_Client0() {
        var r = new MemoryStream([0, 32, 181, 0, 0, 0, 1, 0, 0, 0, 99, 42, 122, 1, 115, 186, 11, 198, 24, 227, 238, 194, 148, 168, 165, 66, 44, 231, 248, 62, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_FORWARD_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_FORWARD_Server0() {
        var r = new MemoryStream([0, 32, 181, 0, 1, 5, 1, 0, 0, 0, 99, 42, 122, 1, 115, 186, 11, 198, 24, 227, 238, 194, 148, 168, 165, 66, 44, 231, 248, 62, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_FORWARD_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_BACKWARD_Client0() {
        var r = new MemoryStream([0, 32, 182, 0, 0, 0, 2, 0, 0, 0, 16, 87, 91, 2, 117, 165, 11, 198, 111, 244, 244, 194, 189, 13, 165, 66, 107, 108, 146, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_BACKWARD_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_BACKWARD_Server0() {
        var r = new MemoryStream([0, 32, 182, 0, 1, 5, 2, 0, 0, 0, 16, 87, 91, 2, 117, 165, 11, 198, 111, 244, 244, 194, 189, 13, 165, 66, 107, 108, 146, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_BACKWARD_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_Client0() {
        var r = new MemoryStream([0, 32, 183, 0, 0, 0, 0, 0, 0, 0, 242, 49, 122, 1, 36, 203, 11, 198, 48, 32, 223, 194, 61, 23, 166, 66, 3, 81, 36, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_STOP_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_Server0() {
        var r = new MemoryStream([0, 32, 183, 0, 1, 5, 0, 0, 0, 0, 242, 49, 122, 1, 36, 203, 11, 198, 48, 32, 223, 194, 61, 23, 166, 66, 3, 81, 36, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_STOP_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_STRAFE_LEFT_Client0() {
        var r = new MemoryStream([0, 32, 184, 0, 0, 0, 5, 0, 0, 0, 159, 210, 121, 1, 238, 193, 11, 198, 253, 68, 8, 195, 36, 126, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_STRAFE_LEFT_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_STRAFE_LEFT_Server0() {
        var r = new MemoryStream([0, 32, 184, 0, 1, 5, 5, 0, 0, 0, 159, 210, 121, 1, 238, 193, 11, 198, 253, 68, 8, 195, 36, 126, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_STRAFE_LEFT_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_STRAFE_RIGHT_Client0() {
        var r = new MemoryStream([0, 32, 185, 0, 0, 0, 9, 0, 0, 0, 159, 210, 121, 1, 238, 193, 11, 198, 253, 68, 8, 195, 36, 126, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_STRAFE_RIGHT_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_STRAFE_RIGHT_Server0() {
        var r = new MemoryStream([0, 32, 185, 0, 1, 5, 9, 0, 0, 0, 159, 210, 121, 1, 238, 193, 11, 198, 253, 68, 8, 195, 36, 126, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_START_STRAFE_RIGHT_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_STRAFE_Client0() {
        var r = new MemoryStream([0, 32, 186, 0, 0, 0, 1, 0, 0, 0, 70, 211, 121, 1, 22, 192, 11, 198, 248, 49, 7, 195, 115, 127, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_STOP_STRAFE_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_STRAFE_Server0() {
        var r = new MemoryStream([0, 32, 186, 0, 1, 5, 1, 0, 0, 0, 70, 211, 121, 1, 22, 192, 11, 198, 248, 49, 7, 195, 115, 127, 167, 66, 184, 157, 194, 62, 127, 3, 0, 0, ]);

        var c = (MSG_MOVE_STOP_STRAFE_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_JUMP_Client0() {
        var r = new MemoryStream([0, 48, 187, 0, 0, 0, 1, 32, 0, 0, 32, 214, 121, 1, 27, 173, 11, 198, 157, 76, 5, 195, 209, 74, 167, 66, 184, 157, 194, 62, 0, 0, 0, 0, 216, 147, 254, 192, 77, 186, 109, 63, 159, 246, 189, 62, 0, 0, 224, 64, ]);

        var c = (MSG_MOVE_JUMP_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_JUMP_Server0() {
        var r = new MemoryStream([0, 48, 187, 0, 1, 5, 1, 32, 0, 0, 32, 214, 121, 1, 27, 173, 11, 198, 157, 76, 5, 195, 209, 74, 167, 66, 184, 157, 194, 62, 0, 0, 0, 0, 216, 147, 254, 192, 77, 186, 109, 63, 159, 246, 189, 62, 0, 0, 224, 64, ]);

        var c = (MSG_MOVE_JUMP_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_TURN_LEFT_Client0() {
        var r = new MemoryStream([0, 32, 188, 0, 0, 0, 16, 0, 0, 0, 251, 190, 121, 1, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_TURN_LEFT_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_TURN_LEFT_Server0() {
        var r = new MemoryStream([0, 32, 188, 0, 1, 5, 16, 0, 0, 0, 251, 190, 121, 1, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_TURN_LEFT_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_TURN_RIGHT_Client0() {
        var r = new MemoryStream([0, 32, 189, 0, 0, 0, 32, 0, 0, 0, 251, 190, 121, 1, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_TURN_RIGHT_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_START_TURN_RIGHT_Server0() {
        var r = new MemoryStream([0, 32, 189, 0, 1, 5, 32, 0, 0, 0, 251, 190, 121, 1, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_START_TURN_RIGHT_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_TURN_Client0() {
        var r = new MemoryStream([0, 32, 190, 0, 0, 0, 0, 0, 0, 0, 151, 166, 91, 2, 37, 162, 11, 198, 57, 130, 248, 194, 222, 72, 165, 66, 16, 19, 156, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_STOP_TURN_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_STOP_TURN_Server0() {
        var r = new MemoryStream([0, 32, 190, 0, 1, 5, 0, 0, 0, 0, 151, 166, 91, 2, 37, 162, 11, 198, 57, 130, 248, 194, 222, 72, 165, 66, 16, 19, 156, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_STOP_TURN_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_RUN_MODE_Client0() {
        var r = new MemoryStream([0, 32, 194, 0, 0, 0, 1, 0, 0, 0, 65, 27, 91, 2, 85, 185, 11, 198, 248, 132, 1, 195, 173, 49, 167, 66, 46, 14, 195, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_SET_RUN_MODE_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_RUN_MODE_Server0() {
        var r = new MemoryStream([0, 32, 194, 0, 1, 5, 1, 0, 0, 0, 65, 27, 91, 2, 85, 185, 11, 198, 248, 132, 1, 195, 173, 49, 167, 66, 46, 14, 195, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_SET_RUN_MODE_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_WALK_MODE_Client0() {
        var r = new MemoryStream([0, 32, 195, 0, 0, 0, 1, 1, 0, 0, 154, 23, 91, 2, 2, 189, 11, 198, 78, 88, 1, 195, 38, 41, 167, 66, 46, 14, 195, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_SET_WALK_MODE_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_WALK_MODE_Server0() {
        var r = new MemoryStream([0, 32, 195, 0, 1, 5, 1, 1, 0, 0, 154, 23, 91, 2, 2, 189, 11, 198, 78, 88, 1, 195, 38, 41, 167, 66, 46, 14, 195, 64, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_SET_WALK_MODE_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_TELEPORT_ACK_Client0() {
        var r = new MemoryStream([0, 13, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, ]);

        var c = (MSG_MOVE_TELEPORT_ACK_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_TELEPORT_ACK_Server0() {
        var r = new MemoryStream([0, 36, 199, 0, 1, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 135, 69, 0, 160, 37, 197, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (MSG_MOVE_TELEPORT_ACK_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_FALL_LAND_Client0() {
        var r = new MemoryStream([0, 32, 201, 0, 0, 0, 0, 0, 0, 0, 165, 217, 121, 1, 173, 149, 11, 198, 120, 245, 2, 195, 241, 246, 165, 66, 75, 71, 175, 61, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_FALL_LAND_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_FALL_LAND_Server0() {
        var r = new MemoryStream([0, 32, 201, 0, 1, 5, 0, 0, 0, 0, 165, 217, 121, 1, 173, 149, 11, 198, 120, 245, 2, 195, 241, 246, 165, 66, 75, 71, 175, 61, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_FALL_LAND_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_FACING_Client0() {
        var r = new MemoryStream([0, 32, 218, 0, 0, 0, 1, 0, 0, 0, 94, 45, 122, 1, 151, 175, 11, 198, 66, 10, 232, 194, 227, 37, 165, 66, 167, 79, 35, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_SET_FACING_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_SET_FACING_Server0() {
        var r = new MemoryStream([0, 32, 218, 0, 1, 5, 1, 0, 0, 0, 94, 45, 122, 1, 151, 175, 11, 198, 66, 10, 232, 194, 227, 37, 165, 66, 167, 79, 35, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_SET_FACING_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_FORCE_RUN_SPEED_CHANGE0() {
        var r = new MemoryStream([0, 12, 226, 0, 1, 6, 0, 0, 0, 0, 0, 0, 224, 64, ]);

        var c = (SMSG_FORCE_RUN_SPEED_CHANGE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_FORCE_RUN_SPEED_CHANGE_ACK0() {
        var r = new MemoryStream([0, 48, 227, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 64, 23, 246, 1, 203, 171, 11, 198, 7, 134, 248, 194, 142, 209, 165, 66, 237, 153, 127, 64, 57, 3, 0, 0, 0, 0, 224, 64, ]);

        var c = (CMSG_FORCE_RUN_SPEED_CHANGE_ACK)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_HEARTBEAT_Client0() {
        var r = new MemoryStream([0, 32, 238, 0, 0, 0, 1, 0, 0, 0, 70, 49, 122, 1, 25, 199, 11, 198, 254, 110, 224, 194, 26, 245, 165, 66, 3, 81, 36, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_HEARTBEAT_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_MOVE_HEARTBEAT_Server0() {
        var r = new MemoryStream([0, 32, 238, 0, 1, 5, 1, 0, 0, 0, 70, 49, 122, 1, 25, 199, 11, 198, 254, 110, 224, 194, 26, 245, 165, 66, 3, 81, 36, 64, 133, 3, 0, 0, ]);

        var c = (MSG_MOVE_HEARTBEAT_Server)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_TUTORIAL_FLAGS0() {
        var r = new MemoryStream([0, 34, 253, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, ]);

        var c = (SMSG_TUTORIAL_FLAGS)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_STANDSTATECHANGE0() {
        var r = new MemoryStream([0, 8, 1, 1, 0, 0, 1, 0, 0, 0, ]);

        var c = (CMSG_STANDSTATECHANGE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_TEXT_EMOTE0() {
        var r = new MemoryStream([0, 20, 4, 1, 0, 0, 34, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_TEXT_EMOTE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_AUTOEQUIP_ITEM0() {
        var r = new MemoryStream([0, 6, 10, 1, 0, 0, 255, 24, ]);

        var c = (CMSG_AUTOEQUIP_ITEM)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_INITIATE_TRADE0() {
        var r = new MemoryStream([0, 12, 22, 1, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_INITIATE_TRADE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CANCEL_TRADE0() {
        var r = new MemoryStream([0, 4, 28, 1, 0, 0, ]);

        var c = (CMSG_CANCEL_TRADE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_INITIAL_SPELLS0() {
        var r = new MemoryStream([0, 167, 42, 1, 0, 40, 0, 78, 0, 0, 0, 81, 0, 0, 0, 107, 0, 0, 0, 196, 0, 0, 0, 198, 0, 0, 0, 201, 0, 0, 0, 203, 0, 0, 0, 204, 0, 0, 0, 10, 2, 0, 0, 156, 2, 0, 0, 78, 9, 0, 0, 153, 9, 0, 0, 175, 9, 0, 0, 234, 11, 0, 0, 37, 13, 0, 0, 181, 20, 0, 0, 89, 24, 0, 0, 102, 24, 0, 0, 103, 24, 0, 0, 77, 25, 0, 0, 78, 25, 0, 0, 203, 25, 0, 0, 98, 28, 0, 0, 99, 28, 0, 0, 187, 28, 0, 0, 194, 32, 0, 0, 33, 34, 0, 0, 117, 35, 0, 0, 118, 35, 0, 0, 156, 35, 0, 0, 165, 35, 0, 0, 117, 80, 0, 0, 118, 80, 0, 0, 119, 80, 0, 0, 120, 80, 0, 0, 128, 81, 0, 0, 147, 84, 0, 0, 148, 84, 0, 0, 11, 86, 0, 0, 26, 89, 0, 0, 0, 0, ]);

        var c = (SMSG_INITIAL_SPELLS)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CANCEL_CAST0() {
        var r = new MemoryStream([0, 8, 47, 1, 0, 0, 120, 80, 0, 0, ]);

        var c = (CMSG_CANCEL_CAST)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CANCEL_CAST1() {
        var r = new MemoryStream([0, 8, 47, 1, 0, 0, 242, 33, 0, 0, ]);

        var c = (CMSG_CANCEL_CAST)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_SET_SELECTION0() {
        var r = new MemoryStream([0, 12, 61, 1, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_SET_SELECTION)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_ATTACKSWING0() {
        var r = new MemoryStream([0, 12, 65, 1, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_ATTACKSWING)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ATTACKSTART0() {
        var r = new MemoryStream([0, 18, 67, 1, 23, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_ATTACKSTART)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ATTACKSTOP0() {
        var r = new MemoryStream([0, 10, 68, 1, 1, 23, 1, 100, 0, 0, 0, 0, ]);

        var c = (SMSG_ATTACKSTOP)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ATTACKERSTATEUPDATE0() {
        var r = new MemoryStream([0, 51, 74, 1, 128, 0, 0, 0, 1, 23, 1, 100, 57, 5, 0, 0, 1, 0, 0, 0, 0, 0, 128, 166, 68, 52, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_ATTACKERSTATEUPDATE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ITEM_PUSH_RESULT0() {
        var r = new MemoryStream([0, 43, 102, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 255, 24, 0, 0, 0, 96, 49, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, ]);

        var c = (SMSG_ITEM_PUSH_RESULT)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_QUERY_TIME0() {
        var r = new MemoryStream([0, 4, 206, 1, 0, 0, ]);

        var c = (CMSG_QUERY_TIME)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_QUERY_TIME_RESPONSE0() {
        var r = new MemoryStream([0, 6, 207, 1, 148, 152, 80, 97, ]);

        var c = (SMSG_QUERY_TIME_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_PING0() {
        var r = new MemoryStream([0, 12, 220, 1, 0, 0, 239, 190, 173, 222, 222, 202, 250, 0, ]);

        var c = (CMSG_PING)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_PONG0() {
        var r = new MemoryStream([0, 6, 221, 1, 239, 190, 173, 222, ]);

        var c = (SMSG_PONG)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_SETSHEATHED0() {
        var r = new MemoryStream([0, 8, 224, 1, 0, 0, 1, 0, 0, 0, ]);

        var c = (CMSG_SETSHEATHED)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_AUTH_CHALLENGE0() {
        var r = new MemoryStream([0, 6, 236, 1, 239, 190, 173, 222, ]);

        var c = (SMSG_AUTH_CHALLENGE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_AUTH_SESSION0() {
        var r = new MemoryStream([0, 172, 237, 1, 0, 0, 243, 22, 0, 0, 0, 0, 0, 0, 65, 0, 136, 2, 216, 73, 136, 157, 239, 5, 37, 187, 193, 171, 167, 138, 219, 164, 251, 163, 231, 126, 103, 172, 234, 198, 86, 1, 0, 0, 120, 156, 117, 204, 189, 14, 194, 48, 12, 4, 224, 242, 30, 188, 12, 97, 64, 149, 200, 66, 195, 140, 76, 226, 34, 11, 199, 169, 140, 203, 79, 159, 30, 22, 36, 6, 115, 235, 119, 119, 129, 105, 89, 64, 203, 105, 51, 103, 163, 38, 199, 190, 91, 213, 199, 122, 223, 125, 18, 190, 22, 192, 140, 113, 36, 228, 18, 73, 168, 194, 228, 149, 72, 10, 201, 197, 61, 216, 182, 122, 6, 75, 248, 52, 15, 21, 70, 115, 103, 187, 56, 204, 122, 199, 151, 139, 189, 220, 38, 204, 254, 48, 66, 214, 230, 202, 1, 168, 184, 144, 128, 81, 252, 183, 164, 80, 112, 184, 18, 243, 63, 38, 65, 253, 181, 55, 144, 25, 102, 143, ]);

        var c = (CMSG_AUTH_SESSION)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        w.Seek(0, SeekOrigin.Begin);
        var s = (CMSG_AUTH_SESSION)await ClientOpcodeReader.ReadUnencryptedAsync(w);
        var cJson = System.Text.Json.JsonSerializer.Serialize(c);
        var sJson = System.Text.Json.JsonSerializer.Serialize(s);
        Assert.That(cJson, Is.EqualTo(sJson));
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_AUTH_RESPONSE0() {
        var r = new MemoryStream([0, 3, 238, 1, 13, ]);

        var c = (SMSG_AUTH_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_AUTH_RESPONSE1() {
        var r = new MemoryStream([0, 7, 238, 1, 27, 239, 190, 173, 222, ]);

        var c = (SMSG_AUTH_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_AUTH_RESPONSE2() {
        var r = new MemoryStream([0, 12, 238, 1, 12, 239, 190, 173, 222, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_AUTH_RESPONSE)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_ZONEUPDATE0() {
        var r = new MemoryStream([0, 8, 244, 1, 0, 0, 101, 6, 0, 0, ]);

        var c = (CMSG_ZONEUPDATE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_ZONEUPDATE1() {
        var r = new MemoryStream([0, 8, 244, 1, 0, 0, 12, 0, 0, 0, ]);

        var c = (CMSG_ZONEUPDATE)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_ACCOUNT_DATA_TIMES0() {
        var r = new MemoryStream([0, 130, 9, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (SMSG_ACCOUNT_DATA_TIMES)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_REQUEST_ACCOUNT_DATA0() {
        var r = new MemoryStream([0, 8, 10, 2, 0, 0, 6, 0, 0, 0, ]);

        var c = (CMSG_REQUEST_ACCOUNT_DATA)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_UPDATE_ACCOUNT_DATA0() {
        var r = new MemoryStream([0, 12, 11, 2, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_UPDATE_ACCOUNT_DATA)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        w.Seek(0, SeekOrigin.Begin);
        var s = (CMSG_UPDATE_ACCOUNT_DATA)await ClientOpcodeReader.ReadUnencryptedAsync(w);
        var cJson = System.Text.Json.JsonSerializer.Serialize(c);
        var sJson = System.Text.Json.JsonSerializer.Serialize(s);
        Assert.That(cJson, Is.EqualTo(sJson));
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_UPDATE_ACCOUNT_DATA1() {
        var r = new MemoryStream([4, 160, 11, 2, 0, 0, 7, 0, 0, 0, 24, 20, 0, 0, 120, 1, 189, 87, 219, 150, 171, 40, 16, 125, 231, 43, 252, 4, 181, 147, 182, 243, 72, 20, 35, 211, 68, 178, 4, 59, 39, 231, 133, 255, 255, 139, 41, 174, 130, 74, 39, 15, 51, 89, 221, 174, 104, 93, 54, 80, 84, 21, 155, 31, 50, 9, 202, 199, 162, 70, 8, 119, 29, 233, 126, 150, 111, 126, 147, 160, 81, 151, 153, 178, 78, 77, 164, 157, 102, 42, 175, 100, 148, 170, 29, 240, 56, 18, 86, 224, 89, 114, 132, 220, 151, 64, 100, 236, 16, 250, 203, 71, 226, 37, 69, 93, 158, 154, 234, 120, 4, 27, 206, 248, 36, 144, 192, 143, 162, 62, 30, 253, 131, 110, 120, 146, 143, 162, 106, 74, 243, 128, 6, 77, 152, 118, 70, 93, 213, 77, 81, 34, 51, 118, 241, 121, 48, 162, 207, 3, 226, 125, 79, 91, 50, 105, 73, 117, 170, 225, 7, 61, 8, 99, 78, 171, 63, 239, 3, 21, 55, 48, 208, 163, 84, 245, 151, 254, 245, 50, 69, 199, 158, 79, 215, 68, 69, 174, 92, 146, 32, 1, 127, 73, 254, 72, 181, 145, 138, 135, 144, 196, 122, 106, 224, 18, 93, 249, 8, 146, 73, 197, 11, 170, 142, 167, 32, 95, 205, 202, 155, 111, 128, 125, 36, 205, 116, 97, 65, 176, 40, 31, 79, 245, 15, 167, 163, 89, 165, 94, 7, 60, 65, 193, 8, 254, 33, 251, 26, 42, 228, 174, 98, 228, 18, 226, 102, 85, 171, 97, 172, 74, 205, 2, 162, 166, 99, 234, 30, 132, 251, 239, 16, 24, 29, 197, 110, 244, 27, 99, 163, 74, 47, 35, 159, 136, 149, 149, 16, 18, 241, 77, 97, 39, 190, 142, 250, 95, 219, 51, 206, 101, 97, 55, 182, 132, 253, 191, 158, 177, 84, 87, 42, 90, 179, 13, 102, 111, 252, 254, 248, 232, 248, 189, 171, 154, 19, 228, 131, 121, 188, 163, 32, 172, 87, 3, 149, 194, 76, 73, 71, 75, 15, 225, 80, 141, 18, 160, 5, 217, 85, 223, 136, 204, 186, 106, 221, 47, 158, 58, 61, 243, 190, 70, 155, 247, 238, 39, 10, 21, 193, 30, 55, 134, 31, 144, 42, 185, 217, 175, 204, 242, 120, 3, 23, 146, 50, 242, 4, 46, 181, 202, 163, 181, 19, 193, 114, 158, 136, 250, 17, 42, 141, 238, 161, 41, 14, 141, 143, 237, 198, 44, 66, 204, 26, 154, 178, 206, 46, 56, 134, 180, 150, 17, 230, 106, 107, 99, 219, 240, 158, 139, 100, 48, 128, 37, 133, 247, 60, 182, 15, 188, 234, 32, 18, 195, 94, 98, 185, 88, 230, 13, 254, 220, 212, 5, 235, 42, 173, 42, 243, 232, 164, 132, 246, 195, 152, 13, 105, 135, 175, 248, 98, 219, 139, 94, 23, 212, 200, 162, 59, 207, 125, 31, 198, 244, 26, 157, 142, 43, 167, 5, 82, 43, 19, 175, 72, 101, 82, 49, 239, 105, 212, 25, 95, 31, 6, 151, 87, 89, 144, 149, 93, 6, 45, 77, 191, 44, 88, 106, 150, 193, 10, 123, 232, 83, 212, 195, 149, 117, 209, 124, 22, 117, 213, 184, 128, 110, 12, 95, 0, 180, 153, 231, 17, 109, 67, 49, 77, 197, 238, 81, 12, 105, 77, 95, 192, 12, 78, 47, 193, 6, 235, 12, 178, 156, 112, 71, 76, 87, 77, 219, 154, 157, 160, 29, 66, 12, 148, 176, 78, 40, 56, 166, 117, 17, 135, 132, 90, 82, 99, 99, 199, 229, 0, 71, 252, 142, 37, 158, 39, 172, 46, 112, 124, 231, 160, 22, 3, 19, 145, 95, 33, 204, 40, 59, 22, 20, 206, 81, 69, 70, 125, 238, 25, 46, 177, 55, 145, 51, 180, 166, 111, 165, 71, 219, 1, 128, 195, 157, 242, 142, 182, 187, 21, 182, 44, 59, 53, 211, 17, 222, 27, 41, 88, 61, 201, 134, 149, 221, 83, 184, 85, 173, 100, 211, 33, 224, 174, 28, 158, 14, 144, 214, 207, 115, 252, 212, 254, 41, 124, 72, 205, 231, 200, 193, 52, 7, 218, 99, 56, 180, 58, 197, 120, 139, 153, 237, 49, 201, 174, 186, 51, 124, 224, 192, 38, 108, 51, 173, 107, 160, 123, 80, 226, 85, 137, 206, 23, 101, 169, 151, 26, 201, 12, 245, 96, 153, 94, 85, 3, 173, 136, 149, 152, 49, 138, 71, 224, 55, 154, 110, 128, 243, 199, 41, 242, 28, 248, 212, 217, 30, 172, 89, 138, 27, 174, 199, 173, 225, 182, 58, 15, 161, 67, 59, 134, 165, 39, 166, 41, 28, 89, 88, 106, 105, 24, 169, 2, 202, 213, 57, 86, 89, 87, 192, 76, 190, 62, 172, 252, 142, 167, 145, 142, 23, 187, 34, 167, 0, 146, 73, 128, 28, 41, 233, 153, 169, 231, 57, 154, 219, 170, 51, 23, 34, 34, 152, 30, 173, 167, 12, 248, 100, 68, 167, 128, 46, 73, 70, 46, 19, 159, 3, 239, 210, 132, 56, 22, 239, 205, 202, 17, 202, 202, 204, 200, 83, 57, 39, 172, 247, 132, 31, 123, 66, 203, 183, 87, 238, 150, 182, 175, 132, 208, 134, 161, 119, 174, 132, 205, 158, 208, 176, 198, 181, 229, 105, 207, 178, 42, 19, 169, 185, 86, 220, 233, 216, 241, 123, 81, 33, 65, 255, 194, 62, 195, 62, 194, 133, 2, 246, 219, 252, 1, 215, 108, 191, 33, 118, 21, 234, 252, 139, 24, 248, 29, 206, 101, 132, 174, 68, 8, 56, 132, 225, 238, 97, 56, 188, 190, 130, 152, 59, 131, 191, 21, 216, 59, 136, 189, 104, 32, 159, 204, 158, 106, 91, 82, 107, 168, 172, 189, 221, 184, 72, 254, 122, 215, 137, 231, 91, 191, 54, 95, 48, 51, 243, 45, 163, 249, 174, 41, 179, 79, 221, 64, 214, 18, 129, 165, 57, 94, 228, 41, 111, 252, 157, 90, 164, 13, 65, 51, 42, 111, 155, 106, 82, 47, 31, 159, 132, 52, 122, 199, 141, 50, 245, 245, 45, 206, 178, 41, 239, 228, 70, 75, 133, 142, 86, 197, 116, 201, 54, 162, 88, 162, 251, 141, 251, 94, 104, 83, 36, 136, 244, 233, 146, 18, 168, 84, 21, 249, 108, 86, 147, 184, 109, 180, 145, 103, 116, 110, 187, 233, 88, 215, 213, 89, 237, 116, 203, 161, 170, 55, 214, 9, 55, 167, 164, 147, 47, 39, 163, 19, 132, 3, 196, 100, 69, 50, 197, 84, 165, 231, 7, 53, 96, 248, 103, 208, 164, 139, 223, 247, 78, 109, 118, 97, 66, 48, 246, 17, 130, 218, 58, 111, 26, 190, 79, 133, 180, 39, 219, 62, 252, 180, 234, 160, 98, 226, 122, 251, 120, 173, 222, 128, 111, 111, 234, 205, 192, 252, 82, 223, 171, 145, 14, 111, 27, 9, 174, 20, 175, 244, 188, 255, 96, 77, 159, 111, 27, 9, 152, 251, 155, 214, 244, 245, 182, 145, 78, 111, 27, 9, 200, 207, 255, 30, 190, 127, 1, 52, 153, 2, 36, ]);

        var c = (CMSG_UPDATE_ACCOUNT_DATA)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        w.Seek(0, SeekOrigin.Begin);
        var s = (CMSG_UPDATE_ACCOUNT_DATA)await ClientOpcodeReader.ReadUnencryptedAsync(w);
        var cJson = System.Text.Json.JsonSerializer.Serialize(c);
        var sJson = System.Text.Json.JsonSerializer.Serialize(s);
        Assert.That(cJson, Is.EqualTo(sJson));
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_GMTICKET_GETTICKET0() {
        var r = new MemoryStream([0, 4, 17, 2, 0, 0, ]);

        var c = (CMSG_GMTICKET_GETTICKET)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_LOGIN_VERIFY_WORLD0() {
        var r = new MemoryStream([0, 22, 54, 2, 0, 0, 0, 0, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, ]);

        var c = (SMSG_LOGIN_VERIFY_WORLD)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_LEARN_TALENT0() {
        var r = new MemoryStream([0, 12, 81, 2, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_LEARN_TALENT)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_AUCTION_HELLO_Client0() {
        var r = new MemoryStream([0, 12, 85, 2, 0, 0, 239, 190, 173, 222, 0, 0, 0, 0, ]);

        var c = (MSG_AUCTION_HELLO_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_SET_ACTIVE_MOVER0() {
        var r = new MemoryStream([0, 12, 106, 2, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, ]);

        var c = (CMSG_SET_ACTIVE_MOVER)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task MSG_QUERY_NEXT_MAIL_TIME_Client0() {
        var r = new MemoryStream([0, 4, 132, 2, 0, 0, ]);

        var c = (MSG_QUERY_NEXT_MAIL_TIME_Client)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_MEETINGSTONE_INFO0() {
        var r = new MemoryStream([0, 4, 150, 2, 0, 0, ]);

        var c = (CMSG_MEETINGSTONE_INFO)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_CHAR_RENAME0() {
        var r = new MemoryStream([0, 21, 199, 2, 0, 0, 239, 190, 173, 222, 0, 0, 0, 0, 68, 101, 97, 100, 98, 101, 101, 102, 0, ]);

        var c = (CMSG_CHAR_RENAME)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHAR_RENAME0() {
        var r = new MemoryStream([0, 3, 200, 2, 71, ]);

        var c = (SMSG_CHAR_RENAME)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_CHAR_RENAME1() {
        var r = new MemoryStream([0, 20, 200, 2, 0, 239, 190, 173, 222, 0, 0, 0, 0, 68, 101, 97, 100, 98, 101, 101, 102, 0, ]);

        var c = (SMSG_CHAR_RENAME)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_REQUEST_RAID_INFO0() {
        var r = new MemoryStream([0, 4, 205, 2, 0, 0, ]);

        var c = (CMSG_REQUEST_RAID_INFO)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_MOVE_TIME_SKIPPED0() {
        var r = new MemoryStream([0, 16, 206, 2, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 32, 0, 0, 0, ]);

        var c = (CMSG_MOVE_TIME_SKIPPED)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMSG_BATTLEFIELD_STATUS0() {
        var r = new MemoryStream([0, 4, 211, 2, 0, 0, ]);

        var c = (CMSG_BATTLEFIELD_STATUS)await ClientOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedClientAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_COMPRESSED_MOVES0() {
        var r = new MemoryStream([0, 50, 251, 2, 46, 0, 0, 0, 120, 1, 211, 189, 203, 192, 40, 145, 183, 154, 251, 216, 186, 88, 230, 195, 43, 212, 151, 59, 49, 32, 3, 70, 32, 167, 100, 57, 247, 177, 245, 239, 95, 29, 58, 121, 102, 137, 19, 0, 38, 30, 14, 73, ]);

        var c = (SMSG_COMPRESSED_MOVES)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_COMPRESSED_MOVES1() {
        var r = new MemoryStream([0, 70, 251, 2, 59, 0, 0, 0, 120, 1, 179, 186, 203, 112, 59, 95, 198, 65, 220, 224, 99, 245, 27, 177, 35, 215, 23, 55, 31, 109, 80, 148, 113, 210, 87, 100, 0, 2, 70, 6, 134, 99, 28, 12, 12, 204, 64, 102, 235, 107, 177, 35, 92, 229, 205, 71, 21, 183, 203, 58, 49, 20, 0, 5, 12, 24, 24, 0, 88, 227, 17, 4, ]);

        var c = (SMSG_COMPRESSED_MOVES)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task SMSG_SPLINE_SET_RUN_SPEED0() {
        var r = new MemoryStream([0, 8, 254, 2, 1, 6, 0, 0, 224, 64, ]);

        var c = (SMSG_SPLINE_SET_RUN_SPEED)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

}
