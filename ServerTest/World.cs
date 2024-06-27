using System.Net.Sockets;
using WowSrp;
using WowSrp.Header;
using WowWorldMessages.All;
using WowWorldMessages.Vanilla;
using Object = WowWorldMessages.Vanilla.Object;

namespace ServerTest;

public static class World
{
    public static async Task RunClient(TcpClient client, IDictionary<string, byte[]> sessionKeys)
    {
        Console.WriteLine("Connected to world");
        var cts = new CancellationTokenSource();
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
                            Guid = 4,
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


                if (await ClientOpcodeReader.ExpectEncryptedOpcode<CMSG_PLAYER_LOGIN>(client.GetStream(), decrypter,
                        cts.Token) is not { } login)
                {
                    return;
                }

                Console.WriteLine("Received login");

                await new SMSG_LOGIN_VERIFY_WORLD
                {
                    Map = Map.EasternKingdoms,
                    Position = new Vector3d
                    {
                        X = -8949.95f,
                        Y = -132.493f,
                        Z = 83.5312f
                    },
                    Orientation = 0
                }.WriteEncryptedServerAsync(client.GetStream(), encrypter, cts.Token);
                Console.WriteLine("Sent login verify world");

                var tutorialData = new uint[SMSG_TUTORIAL_FLAGS.TutorialDataLength];

                for (var i = 0; i < tutorialData.Length; i++)
                {
                    tutorialData[i] = 0xFF_FF_FF_FF;
                }

                await new SMSG_TUTORIAL_FLAGS
                {
                    TutorialData = tutorialData
                }.WriteEncryptedServerAsync(client.GetStream(), encrypter, cts.Token);

                Console.WriteLine("Sent tutorial data");

                var updateMask = new UpdateMask();
                updateMask.SetObjectGuid(login.Guid);
                updateMask.SetObjectType(25);
                updateMask.SetUnitHealth(100);
                updateMask.SetUnitBytes0(Race.Human, Class.Warrior, Gender.Male, Power.Rage);

                await new SMSG_UPDATE_OBJECT
                {
                    HasTransport = 0,
                    Objects =
                    [
                        new Object
                        {
                            UpdateType = new Object.UpdateTypeCreateObject2
                            {
                                Guid3 = login.Guid,
                                Mask2 = updateMask,
                                Movement2 = new MovementBlock
                                {
                                    UpdateFlag = new MovementBlock.UpdateFlagType
                                    {
                                        Inner = UpdateFlag.Living | UpdateFlag.All | UpdateFlag.Self,
                                        All = new MovementBlock.UpdateFlagAll
                                        {
                                            Unknown1 = 0
                                        },
                                        Living = new MovementBlock.UpdateFlagLiving
                                        {
                                            BackwardsRunningSpeed = 4.5f,
                                            BackwardsSwimmingSpeed = 0,
                                            FallTime = 0,
                                            Flags = new MovementBlock.MovementFlagsType
                                            {
                                                Inner = MovementFlags.None
                                            },
                                            LivingOrientation = 0,
                                            LivingPosition = new Vector3d
                                            {
                                                X = -8949.95f,
                                                Y = -132.493f,
                                                Z = 83.5312f
                                            },
                                            RunningSpeed = 7,
                                            SwimmingSpeed = 0,
                                            Timestamp = 0,
                                            TurnRate = (float)Math.PI,
                                            WalkingSpeed = 1
                                        }
                                    }
                                },
                                ObjectType = ObjectType.Player
                            }
                        }
                    ]
                }.WriteEncryptedServerAsync(client.GetStream(), encrypter, cts.Token);

                Console.WriteLine("Sent update object");

                while (true)
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