using Gtker.WowMessages.Login.Version8;

namespace Gtker.WowMessages.LoginTest;

public class Version8 {
    [Test]
    [Timeout(500)]
    public async Task CMD_AUTH_RECONNECT_PROOF_Client0() {
        var r = new MemoryStream([3, 234, 250, 185, 198, 24, 21, 11, 242, 249, 50, 206, 39, 98, 121, 150, 153, 107, 109, 26, 13, 243, 165, 158, 106, 56, 2, 231, 11, 225, 47, 5, 113, 186, 71, 140, 163, 40, 167, 158, 154, 36, 40, 230, 130, 237, 236, 199, 201, 232, 110, 241, 59, 123, 225, 224, 245, 0, ]);

        var c = (CMD_AUTH_RECONNECT_PROOF_Client)await ClientOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(500)]
    public async Task CMD_AUTH_RECONNECT_PROOF_Server0() {
        var r = new MemoryStream([3, 0, 0, 0, ]);

        var c = (CMD_AUTH_RECONNECT_PROOF_Server)await ServerOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(500)]
    public async Task CMD_AUTH_RECONNECT_PROOF_Server1() {
        var r = new MemoryStream([3, 16, 0, 0, ]);

        var c = (CMD_AUTH_RECONNECT_PROOF_Server)await ServerOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(500)]
    public async Task CMD_REALM_LIST_Client0() {
        var r = new MemoryStream([16, 0, 0, 0, 0, ]);

        var c = (CMD_REALM_LIST_Client)await ClientOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(500)]
    public async Task CMD_REALM_LIST_Server0() {
        var r = new MemoryStream([16, 22, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 65, 0, 65, 0, 0, 0, 200, 67, 1, 0, 2, 0, 0, ]);

        var c = (CMD_REALM_LIST_Server)await ServerOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(500)]
    public async Task CMD_REALM_LIST_Server1() {
        var r = new MemoryStream([16, 27, 0, 0, 0, 0, 0, 1, 0, 0, 0, 4, 65, 0, 65, 0, 0, 0, 200, 67, 1, 0, 2, 1, 12, 1, 243, 22, 0, 0, ]);

        var c = (CMD_REALM_LIST_Server)await ServerOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

}
