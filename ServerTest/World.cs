using System.Net.Sockets;
using WowSrp;
using WowSrp.Header;
using WowWorldMessages.All;
using WowWorldMessages.Vanilla;

namespace ServerTest;

public static class World
{
    public static async Task RunClient(TcpClient client, IDictionary<string, byte[]> sessionKeys)
    {
        Console.WriteLine("Connected to world");
        var cts = new CancellationTokenSource();
        cts.CancelAfter(3500);
        try
        {
            using (client)
            {
                await new SMSG_AUTH_CHALLENGE
                {
                    ServerSeed = 0
                }.WriteUnencryptedServerAsync(client.GetStream(), cts.Token);
                Console.WriteLine("Sent auth challenge");

                var c = await ClientOpcodeReader.ExpectUnencryptedOpcode<CMSG_AUTH_SESSION>(client.GetStream(),
                    cts.Token);
                if (c is null)
                {
                    return;
                }

                Console.WriteLine("Received non null auth session");

                if (sessionKeys[c.Username] is not { } sessionKey)
                {
                    return;
                }

                Console.WriteLine("Found sessionKey");

                var proof = WorldProof.CalculateProof(c.Username, c.ClientSeed, 0, sessionKey);
                if (!proof.SequenceEqual(c.ClientProof))
                {
                    return;
                }

                Console.WriteLine("Proof matches");

                var encrypter = new VanillaEncryption(sessionKey);
                var decrypter = new VanillaDecryption(sessionKey);

                await new SMSG_AUTH_RESPONSE
                {
                    Result = default
                }.WriteEncryptedServerAsync(client.GetStream(), encrypter, cts.Token);
                Console.WriteLine("Sent auth response");


                if (await ClientOpcodeReader.ExpectEncryptedOpcode<CMSG_CHAR_ENUM>(client.GetStream(), decrypter,
                        cts.Token) is null)
                {
                    return;
                }

                Console.WriteLine("Got char enum");
                await new SMSG_CHAR_ENUM
                {
                    Characters =
                    [
                        new Character
                        {
                            Guid = 0,
                            Name = "Name",
                            Race = Race.Human,
                            ClassType = Class.Warrior,
                            Gender = Gender.Male,
                            Skin = 0,
                            Face = 0,
                            HairStyle = 0,
                            HairColor = 0,
                            FacialHair = 0,
                            Level = 1,
                            Area = Area.None,
                            Map = Map.EasternKingdoms,
                            Position = new Vector3d
                            {
                                X = 0,
                                Y = 0,
                                Z = 0
                            },
                            GuildId = 0,
                            Flags = CharacterFlags.None,
                            FirstLogin = false,
                            PetDisplayId = 0,
                            PetLevel = 0,
                            PetFamily = CreatureFamily.None,
                            Equipment =
                            [
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                },
                                new CharacterGear
                                {
                                    EquipmentDisplayId = 0,
                                    InventoryType = InventoryType.NonEquip
                                }
                            ]
                        }
                    ]
                }.WriteEncryptedServerAsync(client.GetStream(), encrypter, cts.Token);

                Console.WriteLine("Sent char enum");

                while (await ClientOpcodeReader.ReadEncryptedAsync(client.GetStream(), decrypter) is not null)
                {
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}