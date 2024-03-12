using Gtker.WowMessages.Login.Version3;

namespace Gtker.WowMessages.LoginTest;

public class Version3 {
    [Test]
    [Timeout(1000)]
    public async Task CMD_SURVEY_RESULT0() {
        var r = new MemoryStream([4, 222, 250, 0, 0, 0, 1, 0, 255, ]);

        var c = (CMD_SURVEY_RESULT)await ClientOpcodeReader.ReadAsync(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.WriteAsync(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

    [Test]
    [Timeout(1000)]
    public async Task CMD_REALM_LIST_Server0() {
        var r = new MemoryStream([16, 23, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 65, 0, 65, 0, 0, 0, 200, 67, 1, 0, 2, 0, 0, ]);

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
    [Timeout(1000)]
    public async Task CMD_REALM_LIST_Server1() {
        var r = new MemoryStream([16, 23, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 3, 65, 0, 65, 0, 0, 0, 200, 67, 1, 0, 2, 0, 0, ]);

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
    [Timeout(1000)]
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

}
