using Gtker.WowMessages.Login.Version2;

namespace Gtker.WowMessages.LoginTest;

public class Version2 {
    [Test]
    [Timeout(500)]
    public async Task CMD_AUTH_RECONNECT_PROOF_Server0() {
        var r = new MemoryStream([3, 0, ]);

        var c = await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r);
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
        var r = new MemoryStream([3, 14, ]);

        var c = await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r);
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
    public async Task CMD_AUTH_RECONNECT_PROOF_Server2() {
        var r = new MemoryStream([3, 14, ]);

        var c = await CMD_AUTH_RECONNECT_PROOF_Server.ReadAsync(r);
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

        var c = await CMD_REALM_LIST_Client.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

}
