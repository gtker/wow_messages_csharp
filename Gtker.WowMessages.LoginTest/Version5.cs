using Gtker.WowMessages.Login.Version5;

namespace Gtker.WowMessages.LoginTest;

public class Version5 {
    [Test]
    [Timeout(500)]
    public async Task CMD_REALM_LIST_Client0() {
        var r = new MemoryStream([16, 0, 0, 0, 0, ]);

        var c = await CMD_REALM_LIST_Client.Read(r);
        Assert.That(r.Position, Is.EqualTo(r.Length));

        var w = new MemoryStream();
        await c.Write(w);
        Assert.Multiple(() => {
            Assert.That(w.Position, Is.EqualTo(r.Position));
            Assert.That(r, Is.EqualTo(w));
        });
    }

}
