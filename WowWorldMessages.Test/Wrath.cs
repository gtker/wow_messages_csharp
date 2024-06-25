using WowWorldMessages.Wrath;

namespace WowWorldMessages.Test;

public class Wrath {
    [Test]
    [Timeout(1000)]
    public async Task CMSG_WORLD_TELEPORT0() {
        var r = new MemoryStream([0, 36, 8, 0, 0, 0, 239, 190, 173, 222, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64, ]);

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
        var r = new MemoryStream([0, 36, 8, 0, 0, 0, 154, 61, 9, 2, 213, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 67, 0, 176, 201, 69, 0, 128, 30, 69, 219, 15, 73, 64, ]);

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
    public async Task SMSG_UPDATE_OBJECT0() {
        var r = new MemoryStream([0, 115, 169, 0, 1, 0, 0, 0, 3, 1, 8, 4, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 205, 215, 11, 198, 53, 126, 4, 195, 249, 15, 167, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128, 63, 0, 0, 140, 66, 0, 0, 144, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 208, 15, 73, 64, 0, 0, 0, 0, 3, 7, 0, 0, 0, 0, 0, 128, 0, 24, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 1, 0, 0, 0, 12, 77, 0, 0, 12, 77, 0, 0, ]);

        var c = (SMSG_UPDATE_OBJECT)await ServerOpcodeReader.ReadUnencryptedAsync(r);
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

    [Test]
    [Timeout(1000)]
    public async Task SMSG_MOTD0() {
        var r = new MemoryStream([0, 116, 61, 3, 2, 0, 0, 0, 87, 101, 108, 99, 111, 109, 101, 32, 116, 111, 32, 97, 110, 32, 65, 122, 101, 114, 111, 116, 104, 67, 111, 114, 101, 32, 115, 101, 114, 118, 101, 114, 46, 0, 124, 99, 102, 102, 70, 70, 52, 65, 50, 68, 84, 104, 105, 115, 32, 115, 101, 114, 118, 101, 114, 32, 114, 117, 110, 115, 32, 111, 110, 32, 65, 122, 101, 114, 111, 116, 104, 67, 111, 114, 101, 124, 114, 32, 124, 99, 102, 102, 51, 67, 69, 55, 70, 70, 119, 119, 119, 46, 97, 122, 101, 114, 111, 116, 104, 99, 111, 114, 101, 46, 111, 114, 103, 124, 114, 0, ]);

        var c = (SMSG_MOTD)await ServerOpcodeReader.ReadUnencryptedAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteUnencryptedServerAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

}
