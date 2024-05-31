using WowWorldMessages.Vanilla;

namespace WowWorldMessages.Test;

public class Vanilla {
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

}
