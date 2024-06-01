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

}
