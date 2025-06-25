using System.Collections.Generic;

namespace TunicVanillaChecklist {
    public class GameData {
        public struct Location {
            public string LocationId;
            public string Position;
            public int SceneId;
            public string SceneName;
            public string SaveFlag;
            public int SaveFlagValue;

            public Location(string locationId, string position, int sceneId, string sceneName, string saveFlag = "", int saveFlagValue = 1) {
                LocationId = locationId;
                Position = position;
                SceneId = sceneId;
                SceneName = sceneName;
                SaveFlag = saveFlag;
                SaveFlagValue = saveFlagValue;
            }

            public Location(Location location) {
                LocationId = location.LocationId;
                Position = location.Position;
                SceneId = location.SceneId;
                SceneName = location.SceneName;
                SaveFlag = location.SaveFlag;
                SaveFlagValue = location.SaveFlagValue;
            }
        }
        public struct Reward {
            public int Amount;
            public string Name;
            public string Type;

            public Reward(int amount, string name, string type) {
                Amount = amount;
                Name = name;
                Type = type;
            }

            public Reward(Reward reward) {
                this.Amount = reward.Amount;
                this.Name = reward.Name;
                this.Type = reward.Type;
            }
        }
        public class Check {
            public Location Location;
            public Reward Reward;
            public string CheckId {
                get => $"{Location.LocationId} [{Location.SceneName}]";
            }

            public Check() { }

            public Check(Check check) {
                Location = new Location(check.Location);
                Reward = new Reward(check.Reward);
            }

            public Check(Location location, Reward reward) {
                Location = location;
                Reward = reward;
            }
            public Check(Reward reward, Location location) {
                Location = location;
                Reward = reward;
            }
        }

        public struct Fairy {
            public string Flag;
            public string Translation;

            public Fairy(string flag, string translation) {
                Flag = flag;
                Translation = translation;
            }
        }

        public struct HeroRelic {
            public string Flag;
            public string ItemPresentedOnCollection;
            public string CollectionMessage;
            public string OriginalPickupLocation;
            public string CorrespondingStat;

            public HeroRelic(string flag, string itemPresentedOnCollection, string collectionMessage, string originalPickupLocation, string correspondingStat) {
                Flag = flag;
                ItemPresentedOnCollection = itemPresentedOnCollection;
                CollectionMessage = collectionMessage;
                OriginalPickupLocation = originalPickupLocation;
                CorrespondingStat = correspondingStat;
            }
        }

        public static List<string> BossStateVars = new List<string>() {
            "SV_Forest Boss Room_Skuladot redux Big",
            "SV_Archipelagos Redux TUNIC Knight is Dead",
            "SV_Fortress Arena_Spidertank Is Dead",
            "Librarian Dead Forever",
            "SV_ScavengerBossesDead"
        };

        public static Dictionary<string, List<string>> MainAreasToSubAreas = new Dictionary<string, List<string>>() {
            {
                "Overworld",
                new List<string>() {
                    "Waterfall",
                    "Overworld Cave",
                    "Furnace",
                    "Windmill",
                    "ShopSpecial",
                    "CubeRoom",
                    "PatrolCave",
                    "Maze Room",
                    "Sword Cave",
                    "Ruined Shop",
                    "Town Basement",
                    "Ruins Passage",
                    "EastFiligreeCache",
                    "Temple",
                    "Overworld Redux",
                    "Overworld Interiors",
                    "Town_FiligreeRoom",
                    "Changing Room",
                    "Posterity",
                    "Purgatory",
                }
            },
            {
                "East Forest",
                new List<string>() {
                    "Forest Belltower",
                    "East Forest Redux",
                    "East Forest Redux Interior",
                    "East Forest Redux Laddercave",
                    "Sword Access",
                    "Forest Boss Room"
                }
            },
            {
                "West Garden",
                new List<string>() {
                    "Archipelagos Redux",
                    "archipelagos_house"
                }
            },
            {
                "Eastern Vault Fortress",
                new List<string>() {
                    "Fortress Basement",
                    "Fortress Main",
                    "Fortress Courtyard",
                    "Fortress Arena",
                    "Fortress East",
                    "Fortress Reliquary",
                    "Dusty"
                }
            },
            {
                "Ruined Atoll",
                new List<string>() {
                    "Atoll Redux"
                }
            },
            {
                "Library",
                new List<string>() {
                    "Library Lab",
                    "Library Hall",
                    "Library Rotunda",
                    "Library Arena",
                    "Library Exterior"
                }
            },
            {
                "Quarry/Mountain",
                new List<string>() {
                    "Quarry Redux",
                    "Monastery",
                    "Darkwoods Tunnel",
                    "Mountain",
                    "Mountaintop",
                }
            },
            {
                "Rooted Ziggurat",
                new List<string>() {
                    "ziggurat2020_2",
                    "ziggurat2020_1",
                    "ziggurat2020_3",
                    "ziggurat2020_0",
                    "ziggurat2020_FTRoom"
                }
            },
            {
                "Swamp",
                new List<string>() {
                    "Swamp Redux 2"
                }
            },
            {
                "Cathedral",
                new List<string>() {
                    "Cathedral Arena",
                    "Cathedral Redux"
                }
            },
            {
                "Dark Tomb",
                new List<string>() {
                    "Crypt Redux"
                }
            },
            {
                "Beneath the Well",
                new List<string>() {
                    "Sewer",
                    "Sewer_Boss"
                }
            },
            {
                "Frog's Domain",
                new List<string>() {
                    "Frog Stairs",
                    "frog cave main"
                }
            },
            {
                "Far Shore/Hero's Grave",
                new List<string>() {
                    "Resurrection",
                    "Transit",
                    "RelicVoid",
                    "Playable Intro",
                    "Spirit Arena",
                    "g_elements"
                }
            },
            {
                "Shop/Coin Wells",
                new List<string>() {
                    "Shop",
                    "Trinket Well"
                }
            },
        };

        public static Dictionary<string, int> ChecksPerScene = new Dictionary<string, int>();

        public static Dictionary<string, Check> ItemList = new Dictionary<string, Check>() {
                        {
                "55 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Trinket - BTSR", "INVENTORY"),
                    new Location("55", "(-156.9, 4.0, 138.7)", 31, "Archipelagos Redux", "chest open 55")
                )
            },
            {
                "217 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Sword", "INVENTORY"),
                    new Location("217", "(-235.7, 5.0, 152.5)", 31, "Archipelagos Redux", "chest open 217")
                )
            },
            {
                "west_garden [Archipelagos Redux]",
                new Check(
                    new Reward(1, "13", "PAGE"),
                    new Location("west_garden", "(-297.4, 4.0, 148.8)", 31, "Archipelagos Redux", "unlocked page 13")
                )
            },
            {
                "256 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("256", "(-297.4, 4.0, 164.3)", 31, "Archipelagos Redux", "chest open 256")
                )
            },
            {
                "280 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("280", "(-356.5, 0.5, 66.5)", 31, "Archipelagos Redux", "chest open 280")
                )
            },
            {
                "283 [Archipelagos Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("283", "(-335.5, 4.0, 100.5)", 31, "Archipelagos Redux", "chest open 283")
                )
            },
            {
                "57 [Archipelagos Redux]",
                new Check(
                    new Reward(4, "Firecracker", "INVENTORY"),
                    new Location("57", "(-261.0, 8.0, 99.8)", 31, "Archipelagos Redux", "chest open 57")
                )
            },
            {
                "253 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("253", "(-195.0, 1.0, 107.9)", 31, "Archipelagos Redux", "chest open 253")
                )
            },
            {
                "56 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Berry_MP", "INVENTORY"),
                    new Location("56", "(-244.0, 4.0, 118.5)", 31, "Archipelagos Redux", "chest open 56")
                )
            },
            {
                "Archipelagos Redux-(-396.3, 1.4, 42.3) [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Archipelagos Redux-(-396.3, 1.4, 42.3)", "FAIRY"),
                    new Location("Archipelagos Redux-(-396.3, 1.4, 42.3)", "(-396.3, 1.4, 42.3)", 31, "Archipelagos Redux", "SV_Fairy_17_GardenTree_Opened")
                )
            },
            {
                "58 [Archipelagos Redux]",
                new Check(
                    new Reward(2, "Pepper", "INVENTORY"),
                    new Location("58", "(-241.0, 1.0, 0.0)", 31, "Archipelagos Redux", "chest open 58")
                )
            },
            {
                "206 [Archipelagos Redux]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("206", "(-257.9, 2.0, 6.6)", 31, "Archipelagos Redux", "chest open 206")
                )
            },
            {
                "94 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("94", "(-240.3, 8.0, -24.9)", 31, "Archipelagos Redux", "chest open 94")
                )
            },
            {
                "111 [Archipelagos Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("111", "(-197.8, 1.0, 20.0)", 31, "Archipelagos Redux", "chest open 111")
                )
            },
            {
                "archipelagos_night [Archipelagos Redux]",
                new Check(
                    new Reward(1, "23", "PAGE"),
                    new Location("archipelagos_night", "(-182.3, 1.0, 26.9)", 31, "Archipelagos Redux", "unlocked page 23")
                )
            },
            {
                "257 [Archipelagos Redux]",
                new Check(
                    new Reward(32, "money", "MONEY"),
                    new Location("257", "(-246.5, 1.8, 61.7)", 31, "Archipelagos Redux", "chest open 257")
                )
            },
            {
                "59 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Stamina SP - Feather", "INVENTORY"),
                    new Location("59", "(-193.2, 8.0, 83.9)", 31, "Archipelagos Redux", "chest open 59")
                )
            },
            {
                "Archipelagos Redux-(-236.0, 8.0, 86.3) [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Archipelagos Redux-(-236.0, 8.0, 86.3)", "FAIRY"),
                    new Location("Archipelagos Redux-(-236.0, 8.0, 86.3)", "(-236.0, 8.0, 86.3)", 31, "Archipelagos Redux", "SV_Fairy_18_GardenCourtyard_Opened")
                )
            },
            {
                "223 [Archipelagos Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Attack - Tooth", "INVENTORY"),
                    new Location("223", "(-221.8, 20.0, 92.3)", 31, "Archipelagos Redux", "chest open 223")
                )
            },
            {
                "93 [Archipelagos Redux]",
                new Check(
                    new Reward(200, "money", "MONEY"),
                    new Location("93", "(-166.0, 20.0, 165.0)", 31, "Archipelagos Redux", "chest open 93")
                )
            },
            {
                "Stundagger [archipelagos_house]",
                new Check(
                    new Reward(1, "Stundagger", "INVENTORY"),
                    new Location("Stundagger", "(-190.9, 4.2, 34.6)", 41, "archipelagos_house", "SV_GotDagger")
                )
            },
            {
                "72 [Atoll Redux]",
                new Check(
                    new Reward(1, "Trinket - Block Plus", "INVENTORY"),
                    new Location("72", "(51.5, 1.0, 78.0)", 32, "Atoll Redux", "chest open 72")
                )
            },
            {
                "67 [Atoll Redux]",
                new Check(
                    new Reward(1, "Trinket - Bloodstain MP", "INVENTORY"),
                    new Location("67", "(-7.0, 16.9, -72.3)", 32, "Atoll Redux", "chest open 67")
                )
            },
            {
                "218 [Atoll Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("218", "(38.0, 16.0, -72.0)", 32, "Atoll Redux", "chest open 218")
                )
            },
            {
                "219 [Atoll Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("219", "(-7.3, 2.2, -110.7)", 32, "Atoll Redux", "chest open 219")
                )
            },
            {
                "76 [Atoll Redux]",
                new Check(
                    new Reward(100, "money", "MONEY"),
                    new Location("76", "(71.8, 13.0, -44.3)", 32, "Atoll Redux", "chest open 76")
                )
            },
            {
                "66 [Atoll Redux]",
                new Check(
                    new Reward(2, "Ice Bomb", "INVENTORY"),
                    new Location("66", "(5.8, 0.3, 33.1)", 32, "Atoll Redux", "chest open 66")
                )
            },
            {
                "220 [Atoll Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Magic MP - Mushroom", "INVENTORY"),
                    new Location("220", "(0.0, 4.0, 33.0)", 32, "Atoll Redux", "chest open 220")
                )
            },
            {
                "287 [Atoll Redux]",
                new Check(
                    new Reward(1, "Trinket - IFrames", "INVENTORY"),
                    new Location("287", "(-77.0, 3.5, 40.5)", 32, "Atoll Redux", "chest open 287")
                )
            },
            {
                "69 [Atoll Redux]",
                new Check(
                    new Reward(1, "Trinket - Attack Up Defense Down", "INVENTORY"),
                    new Location("69", "(-55.5, 2.0, 17.0)", 32, "Atoll Redux", "chest open 69")
                )
            },
            {
                "1010 [Atoll Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_10", "INVENTORY"),
                    new Location("1010", "(-134.7, 1.4, 2.9)", 32, "Atoll Redux", "chest open 1010")
                )
            },
            {
                "70 [Atoll Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("70", "(-40.3, 1.0, -40.3)", 32, "Atoll Redux", "chest open 70")
                )
            },
            {
                "68 [Atoll Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("68", "(-38.0, 2.3, -106.3)", 32, "Atoll Redux", "chest open 68")
                )
            },
            {
                "Key [Atoll Redux]",
                new Check(
                    new Reward(1, "Key", "INVENTORY"),
                    new Location("Key", "(78.1, 6.3, 84.2)", 32, "Atoll Redux", "SV_Atoll Redux_key pickup")
                )
            },
            {
                "73 [Atoll Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("73", "(71.0, 4.0, 18.0)", 32, "Atoll Redux", "chest open 73")
                )
            },
            {
                "71 [Atoll Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("71", "(77.0, 16.0, 2.5)", 32, "Atoll Redux", "chest open 71")
                )
            },
            {
                "221 [Atoll Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("221", "(73.1, 4.0, 56.6)", 32, "Atoll Redux", "chest open 221")
                )
            },
            {
                "75 [Atoll Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - DamageResist - Effigy", "INVENTORY"),
                    new Location("75", "(73.0, 14.0, 29.5)", 32, "Atoll Redux", "chest open 75")
                )
            },
            {
                "999 [Cathedral Arena]",
                new Check(
                    new Reward(1, "Hyperdash", "INVENTORY"),
                    new Location("999", "(0.0, 0.0, 0.0)", 61, "Cathedral Arena", "chest open 999")
                )
            },
            {
                "1002 [Cathedral Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_2", "INVENTORY"),
                    new Location("1002", "(-53.5, -20.0, 30.0)", 69, "Cathedral Redux", "chest open 1002")
                )
            },
            {
                "240 [Cathedral Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("240", "(-21.6, 0.0, -71.4)", 69, "Cathedral Redux", "chest open 240")
                )
            },
            {
                "244 [Cathedral Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("244", "(-17.5, 0.0, -47.5)", 69, "Cathedral Redux", "chest open 244")
                )
            },
            {
                "236 [Cathedral Redux]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("236", "(89.1, 0.0, -71.7)", 69, "Cathedral Redux", "chest open 236")
                )
            },
            {
                "237 [Cathedral Redux]",
                new Check(
                    new Reward(2, "Pepper", "INVENTORY"),
                    new Location("237", "(44.5, -0.1, -27.5)", 69, "Cathedral Redux", "chest open 237")
                )
            },
            {
                "243 [Cathedral Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("243", "(63.8, 20.0, -71.9)", 69, "Cathedral Redux", "chest open 243")
                )
            },
            {
                "238 [Cathedral Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("238", "(55.8, 20.0, -63.3)", 69, "Cathedral Redux", "chest open 238")
                )
            },
            {
                "239 [Cathedral Redux]",
                new Check(
                    new Reward(2, "Berry_MP", "INVENTORY"),
                    new Location("239", "(31.5, 20.5, -49.8)", 69, "Cathedral Redux", "chest open 239")
                )
            },
            {
                "241 [Cathedral Redux]",
                new Check(
                    new Reward(2, "Firecracker", "INVENTORY"),
                    new Location("241", "(-26.3, 20.0, -63.6)", 69, "Cathedral Redux", "chest open 241")
                )
            },
            {
                "242 [Cathedral Redux]",
                new Check(
                    new Reward(2, "Berry_HP", "INVENTORY"),
                    new Location("242", "(-20.5, 20.0, 30.9)", 69, "Cathedral Redux", "chest open 242")
                )
            },
            {
                "60 [Changing Room]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("60", "(33.0, 8.0, 27.0)", 70, "Changing Room", "chest open 60")
                )
            },
            {
                "52 [Crypt Redux]",
                new Check(
                    new Reward(1, "Trinket - RTSR", "INVENTORY"),
                    new Location("52", "(-79.0, 61.0, 82.0)", 64, "Crypt Redux", "chest open 52")
                )
            },
            {
                "213 [Crypt Redux]",
                new Check(
                    new Reward(3, "Firebomb", "INVENTORY"),
                    new Location("213", "(-120.0, 25.0, 45.0)", 64, "Crypt Redux", "chest open 213")
                )
            },
            {
                "53 [Crypt Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("53", "(-119.0, 17.0, 90.0)", 64, "Crypt Redux", "chest open 53")
                )
            },
            {
                "210 [Crypt Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("210", "(-119.0, 17.0, 51.0)", 64, "Crypt Redux", "chest open 210")
                )
            },
            {
                "54 [Crypt Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("54", "(-23.0, 17.0, 65.0)", 64, "Crypt Redux", "chest open 54")
                )
            },
            {
                "212 [Crypt Redux]",
                new Check(
                    new Reward(40, "money", "MONEY"),
                    new Location("212", "(-63.0, 17.0, 54.0)", 64, "Crypt Redux", "chest open 212")
                )
            },
            {
                "211 [Crypt Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("211", "(-60.0, 17.0, 13.0)", 64, "Crypt Redux", "chest open 211")
                )
            },
            {
                "CubeRoom-(321.1, 3.0, 217.0) [CubeRoom]",
                new Check(
                    new Reward(1, "CubeRoom-(321.1, 3.0, 217.0)", "FAIRY"),
                    new Location("CubeRoom-(321.1, 3.0, 217.0)", "(321.1, 3.0, 217.0)", 66, "CubeRoom", "SV_Fairy_14_Cube_Opened")
                )
            },
            {
                "1011 [Dusty]",
                new Check(
                    new Reward(1, "GoldenTrophy_11", "INVENTORY"),
                    new Location("1011", "(57.5, 26.0, 43.8)", 83, "Dusty", "chest open 1011")
                )
            },
            {
                "286 [East Forest Redux]",
                new Check(
                    new Reward(100, "money", "MONEY"),
                    new Location("286", "(91.0, 8.0, 67.5)", 53, "East Forest Redux", "chest open 286")
                )
            },
            {
                "25 [East Forest Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("25", "(85.0, 4.0, 6.5)", 53, "East Forest Redux", "chest open 25")
                )
            },
            {
                "24 [East Forest Redux]",
                new Check(
                    new Reward(1, "Berry_HP", "INVENTORY"),
                    new Location("24", "(109.7, 0.0, 10.1)", 53, "East Forest Redux", "chest open 24")
                )
            },
            {
                "forest [East Forest Redux]",
                new Check(
                    new Reward(1, "7", "PAGE"),
                    new Location("forest", "(124.0, 1.4, -16.2)", 53, "East Forest Redux", "unlocked page 7")
                )
            },
            {
                "23 [East Forest Redux]",
                new Check(
                    new Reward(1, "Flask Container", "INVENTORY"),
                    new Location("23", "(92.0, 17.0, 70.5)", 53, "East Forest Redux", "chest open 23")
                )
            },
            {
                "East Forest Redux-(104.0, 16.0, 61.0) [East Forest Redux]",
                new Check(
                    new Reward(1, "East Forest Redux-(104.0, 16.0, 61.0)", "FAIRY"),
                    new Location("East Forest Redux-(104.0, 16.0, 61.0)", "(104.0, 16.0, 61.0)", 53, "East Forest Redux", "SV_Fairy_8_Dancer_Opened")
                )
            },
            {
                "26 [East Forest Redux]",
                new Check(
                    new Reward(6, "Firecracker", "INVENTORY"),
                    new Location("26", "(91.0, -26.0, -58.0)", 53, "East Forest Redux", "chest open 26")
                )
            },
            {
                "248 [East Forest Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("248", "(88.0, -30.5, -59.0)", 53, "East Forest Redux", "chest open 248")
                )
            },
            {
                "East Forest Redux-(164.0, -25.0, -56.0) [East Forest Redux]",
                new Check(
                    new Reward(1, "East Forest Redux-(164.0, -25.0, -56.0)", "FAIRY"),
                    new Location("East Forest Redux-(164.0, -25.0, -56.0)", "(164.0, -25.0, -56.0)", 53, "East Forest Redux", "SV_Fairy_20_ForestMonolith_Opened")
                )
            },
            {
                "284 [East Forest Redux]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("284", "(139.0, -26.0, -92.0)", 53, "East Forest Redux", "chest open 284")
                )
            },
            {
                "281 [East Forest Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("281", "(138.0, -26.0, -107.0)", 53, "East Forest Redux", "chest open 281")
                )
            },
            {
                "1006 [East Forest Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_6", "INVENTORY"),
                    new Location("1006", "(104.0, -16.0, -23.8)", 53, "East Forest Redux", "chest open 1006")
                )
            },
            {
                "21 [East Forest Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("21", "(154.0, 8.0, 4.0)", 53, "East Forest Redux", "chest open 21")
                )
            },
            {
                "22 [East Forest Redux]",
                new Check(
                    new Reward(40, "money", "MONEY"),
                    new Location("22", "(173.0, 8.0, -1.0)", 53, "East Forest Redux", "chest open 22")
                )
            },
            {
                "29 [East Forest Redux Interior]",
                new Check(
                    new Reward(2, "Firebomb", "INVENTORY"),
                    new Location("29", "(162.2, 0.1, -8.5)", 54, "East Forest Redux Interior", "chest open 29")
                )
            },
            {
                "30 [East Forest Redux Interior]",
                new Check(
                    new Reward(2, "Ice Bomb", "INVENTORY"),
                    new Location("30", "(193.9, -32.0, -23.8)", 54, "East Forest Redux Interior", "chest open 30")
                )
            },
            {
                "27 [East Forest Redux Laddercave]",
                new Check(
                    new Reward(30, "money", "MONEY"),
                    new Location("27", "(166.5, 16.0, 62.5)", 55, "East Forest Redux Laddercave", "chest open 27")
                )
            },
            {
                "28 [East Forest Redux Laddercave]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("28", "(147.0, 16.0, 77.0)", 55, "East Forest Redux Laddercave", "chest open 28")
                )
            },
            {
                "270 [EastFiligreeCache]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("270", "(12.0, 0.0, -4.0)", 82, "EastFiligreeCache", "chest open 270")
                )
            },
            {
                "271 [EastFiligreeCache]",
                new Check(
                    new Reward(1, "Trinket - Glass Cannon", "INVENTORY"),
                    new Location("271", "(7.0, 0.0, -5.0)", 82, "EastFiligreeCache", "chest open 271")
                )
            },
            {
                "272 [EastFiligreeCache]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("272", "(2.0, 0.0, -5.0)", 82, "EastFiligreeCache", "chest open 272")
                )
            },
            {
                "forest shortcut [Forest Belltower]",
                new Check(
                    new Reward(1, "6", "PAGE"),
                    new Location("forest shortcut", "(480.8, 40.0, 104.0)", 36, "Forest Belltower", "unlocked page 6")
                )
            },
            {
                "205 [Forest Belltower]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("205", "(501.5, 38.0, 114.5)", 36, "Forest Belltower", "chest open 205")
                )
            },
            {
                "20 [Forest Belltower]",
                new Check(
                    new Reward(1, "Flask Container", "INVENTORY"),
                    new Location("20", "(582.0, 14.0, 86.5)", 36, "Forest Belltower", "chest open 20")
                )
            },
            {
                "204 [Forest Belltower]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("204", "(495.5, 59.0, 110.0)", 36, "Forest Belltower", "chest open 204")
                )
            },
            {
                "19 [Forest Belltower]",
                new Check(
                    new Reward(1, "Dath Stone", "SPECIAL"),
                    new Location("19", "(512.6, 14.0, 51.9)", 36, "Forest Belltower", "chest open 19")
                )
            },
            {
                "Vault Key (Red) [Fortress Arena]",
                new Check(
                    new Reward(1, "Vault Key (Red)", "INVENTORY"),
                    new Location("Vault Key (Red)", "(-1.0, 8.4, 181.5)", 16, "Fortress Arena", "SV_Fortress vault key GOT")
                )
            },
            {
                "Hexagon Red [Fortress Arena]",
                new Check(
                    new Reward(1, "Hexagon Red", "INVENTORY"),
                    new Location("Hexagon Red", "(0.0, 1.0, 117.0)", 16, "Fortress Arena", "Got Hexagon 1 Red")
                )
            },
            {
                "63 [Fortress Basement]",
                new Check(
                    new Reward(1, "Trinket - Sneaky", "INVENTORY"),
                    new Location("63", "(-91.3, -4.0, 16.2)", 14, "Fortress Basement", "chest open 63")
                )
            },
            {
                "61 [Fortress Basement]",
                new Check(
                    new Reward(1, "Upgrade Offering - Magic MP - Mushroom", "INVENTORY"),
                    new Location("61", "(-101.0, 5.0, 27.0)", 14, "Fortress Basement", "chest open 61")
                )
            },
            {
                "62 [Fortress Basement]",
                new Check(
                    new Reward(3, "Berry_HP", "INVENTORY"),
                    new Location("62", "(7.8, 0.0, -6.9)", 14, "Fortress Basement", "chest open 62")
                )
            },
            {
                "65 [Fortress Basement]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("65", "(26.3, 0.0, 5.1)", 14, "Fortress Basement", "chest open 65")
                )
            },
            {
                "64 [Fortress Basement]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("64", "(17.2, 0.0, 72.5)", 14, "Fortress Basement", "chest open 64")
                )
            },
            {
                "86 [Fortress Courtyard]",
                new Check(
                    new Reward(1, "Upgrade Offering - PotionEfficiency Swig - Ash", "INVENTORY"),
                    new Location("86", "(-13.0, -4.0, -143.5)", 15, "Fortress Courtyard", "chest open 86")
                )
            },
            {
                "96 [Fortress Courtyard]",
                new Check(
                    new Reward(1, "Bait", "INVENTORY"),
                    new Location("96", "(-18.0, -4.5, -130.0)", 15, "Fortress Courtyard", "chest open 96")
                )
            },
            {
                "88 [Fortress Courtyard]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("88", "(6.4, 0.3, -123.8)", 15, "Fortress Courtyard", "chest open 88")
                )
            },
            {
                "87 [Fortress Courtyard]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("87", "(-53.7, 0.0, -49.0)", 15, "Fortress Courtyard", "chest open 87")
                )
            },
            {
                "spidercave [Fortress Courtyard]",
                new Check(
                    new Reward(1, "3", "PAGE"),
                    new Location("spidercave", "(-43.1, 0.0, -44.6)", 15, "Fortress Courtyard", "unlocked page 3")
                )
            },
            {
                "112 [Fortress East]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("112", "(77.0, -1.0, 36.0)", 47, "Fortress East", "chest open 112")
                )
            },
            {
                "fortress [Fortress Main]",
                new Check(
                    new Reward(1, "18", "PAGE"),
                    new Location("fortress", "(-88.7, 7.6, 25.8)", 13, "Fortress Main", "unlocked page 18")
                )
            },
            {
                "83 [Fortress Main]",
                new Check(
                    new Reward(5, "Ice Bomb", "INVENTORY"),
                    new Location("83", "(-89.0, 7.0, 56.3)", 13, "Fortress Main", "chest open 83")
                )
            },
            {
                "84 [Fortress Main]",
                new Check(
                    new Reward(1, "Upgrade Offering - Stamina SP - Feather", "INVENTORY"),
                    new Location("84", "(-82.6, 7.0, 48.6)", 13, "Fortress Main", "chest open 84")
                )
            },
            {
                "Fortress Main-(-75.0, -1.0, 17.0) [Fortress Main]",
                new Check(
                    new Reward(1, "Fortress Main-(-75.0, -1.0, 17.0)", "FAIRY"),
                    new Location("Fortress Main-(-75.0, -1.0, 17.0)", "(-75.0, -1.0, 17.0)", 13, "Fortress Main", "SV_Fairy_19_FortressCandles_Opened")
                )
            },
            {
                "85 [Fortress Main]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("85", "(31.0, 11.0, 50.7)", 13, "Fortress Main", "chest open 85")
                )
            },
            {
                "113 [Fortress Reliquary]",
                new Check(
                    new Reward(1, "Berry_MP", "INVENTORY"),
                    new Location("113", "(127.2, 8.0, -27.0)", 48, "Fortress Reliquary", "chest open 113")
                )
            },
            {
                "114 [Fortress Reliquary]",
                new Check(
                    new Reward(128, "money", "MONEY"),
                    new Location("114", "(199.5, 0.0, -45.0)", 48, "Fortress Reliquary", "chest open 114")
                )
            },
            {
                "115 [Fortress Reliquary]",
                new Check(
                    new Reward(1, "Trinket - Walk Speed Plus", "INVENTORY"),
                    new Location("115", "(199.5, 0.0, -35.0)", 48, "Fortress Reliquary", "chest open 115")
                )
            },
            {
                "Wand [frog cave main]",
                new Check(
                    new Reward(1, "Wand", "INVENTORY"),
                    new Location("Wand", "(50.8, 22.3, -11.0)", 52, "frog cave main", "SV_frog cave got wand")
                )
            },
            {
                "77 [frog cave main]",
                new Check(
                    new Reward(3, "Firecracker", "INVENTORY"),
                    new Location("77", "(-20.3, 28.0, -9.0)", 52, "frog cave main", "chest open 77")
                )
            },
            {
                "82 [frog cave main]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("82", "(26.0, 36.0, 18.5)", 52, "frog cave main", "chest open 82")
                )
            },
            {
                "81 [frog cave main]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("81", "(60.5, 36.0, 4.0)", 52, "frog cave main", "chest open 81")
                )
            },
            {
                "80 [frog cave main]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("80", "(69.0, 36.0, -3.0)", 52, "frog cave main", "chest open 80")
                )
            },
            {
                "78 [frog cave main]",
                new Check(
                    new Reward(2, "Berry_HP", "INVENTORY"),
                    new Location("78", "(-114.5, 28.0, 10.5)", 52, "frog cave main", "chest open 78")
                )
            },
            {
                "279 [frog cave main]",
                new Check(
                    new Reward(1, "Berry_MP", "INVENTORY"),
                    new Location("279", "(4.5, 44.0, 2.0)", 52, "frog cave main", "chest open 279")
                )
            },
            {
                "79 [frog cave main]",
                new Check(
                    new Reward(100, "money", "MONEY"),
                    new Location("79", "(-75.0, 9.8, -25.0)", 52, "frog cave main", "chest open 79")
                )
            },
            {
                "222 [frog cave main]",
                new Check(
                    new Reward(1, "Upgrade Offering - Attack - Tooth", "INVENTORY"),
                    new Location("222", "(-8.5, 8.0, -43.2)", 52, "frog cave main", "chest open 222")
                )
            },
            {
                "259 [frog cave main]",
                new Check(
                    new Reward(3, "Firecracker", "INVENTORY"),
                    new Location("259", "(13.6, -2.0, -77.1)", 52, "frog cave main", "chest open 259")
                )
            },
            {
                "276 [frog cave main]",
                new Check(
                    new Reward(32, "money", "MONEY"),
                    new Location("276", "(121.8, 29.8, -51.5)", 52, "frog cave main", "chest open 276")
                )
            },
            {
                "Lantern [Furnace]",
                new Check(
                    new Reward(1, "Lantern", "INVENTORY"),
                    new Location("Lantern", "(-135.2, 34.1, -43.2)", 57, "Furnace", "SV_Got Lantern")
                )
            },
            {
                "92 [Furnace]",
                new Check(
                    new Reward(1, "Upgrade Offering - DamageResist - Effigy", "INVENTORY"),
                    new Location("92", "(-142.0, 12.0, -40.0)", 57, "Furnace", "chest open 92")
                )
            },
            {
                "Hexagon Green [Library Arena]",
                new Check(
                    new Reward(1, "Hexagon Green", "INVENTORY"),
                    new Location("Hexagon Green", "(0.2, 1.3, 0.4)", 28, "Library Arena", "Got Hexagon 2 Green")
                )
            },
            {
                "Library Hall-(133.3, 10.0, -43.2) [Library Hall]",
                new Check(
                    new Reward(1, "Library Hall-(133.3, 10.0, -43.2)", "FAIRY"),
                    new Location("Library Hall-(133.3, 10.0, -43.2)", "(133.3, 10.0, -43.2)", 19, "Library Hall", "SV_Fairy_9_Library_Rug_Opened")
                )
            },
            {
                "library_2 [Library Lab]",
                new Check(
                    new Reward(1, "20", "PAGE"),
                    new Location("library_2", "(119.7, 92.8, -84.0)", 18, "Library Lab", "unlocked page 20")
                )
            },
            {
                "library_3 [Library Lab]",
                new Check(
                    new Reward(1, "25", "PAGE"),
                    new Location("library_3", "(129.1, 92.8, -68.7)", 18, "Library Lab", "unlocked page 25")
                )
            },
            {
                "library_1 [Library Lab]",
                new Check(
                    new Reward(1, "19", "PAGE"),
                    new Location("library_1", "(160.1, 92.8, -74.9)", 18, "Library Lab", "unlocked page 19")
                )
            },
            {
                "226 [Library Lab]",
                new Check(
                    new Reward(64, "money", "MONEY"),
                    new Location("226", "(163.9, 95.0, -41.8)", 18, "Library Lab", "chest open 226")
                )
            },
            {
                "225 [Library Lab]",
                new Check(
                    new Reward(32, "money", "MONEY"),
                    new Location("225", "(155.3, 95.0, -31.3)", 18, "Library Lab", "chest open 225")
                )
            },
            {
                "227 [Library Lab]",
                new Check(
                    new Reward(128, "money", "MONEY"),
                    new Location("227", "(153.8, 95.0, -29.3)", 18, "Library Lab", "chest open 227")
                )
            },
            {
                "228 [Library Lab]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("228", "(114.5, 95.0, -36.0)", 18, "Library Lab", "chest open 228")
                )
            },
            {
                "216 [Maze Room]",
                new Check(
                    new Reward(255, "money", "MONEY"),
                    new Location("216", "(1.0, 0.0, 16.0)", 68, "Maze Room", "chest open 216")
                )
            },
            {
                "Maze Room-(1.0, 0.0, -1.0) [Maze Room]",
                new Check(
                    new Reward(1, "Maze Room-(1.0, 0.0, -1.0)", "FAIRY"),
                    new Location("Maze Room-(1.0, 0.0, -1.0)", "(1.0, 0.0, -1.0)", 68, "Maze Room", "SV_Fairy_15_Maze_Opened")
                )
            },
            {
                "200 [Monastery]",
                new Check(
                    new Reward(1, "Mask", "INVENTORY"),
                    new Location("200", "(0.2, 25.0, 175.4)", 22, "Monastery", "chest open 200")
                )
            },
            {
                "mountain [Mountain]",
                new Check(
                    new Reward(1, "10", "PAGE"),
                    new Location("mountain", "(49.0, 41.2, 3.7)", 9, "Mountain", "unlocked page 10")
                )
            },
            {
                "final [Mountaintop]",
                new Check(
                    new Reward(1, "0", "PAGE"),
                    new Location("final", "(-11.0, 42.0, 15.0)", 10, "Mountaintop", "unlocked page 0")
                )
            },
            {
                "Overworld Cave-(-90.4, 515.0, -738.9) [Overworld Cave]",
                new Check(
                    new Reward(1, "Overworld Cave-(-90.4, 515.0, -738.9)", "FAIRY"),
                    new Location("Overworld Cave-(-90.4, 515.0, -738.9)", "(-90.4, 515.0, -738.9)", 50, "Overworld Cave", "SV_Fairy_4_Caustics_Opened")
                )
            },
            {
                "89 [Overworld Interiors]",
                new Check(
                    new Reward(1, "money", "MONEY"),
                    new Location("89", "(-24.4, 27.0, -50.2)", 26, "Overworld Interiors", "chest open 89")
                )
            },
            {
                "Overworld Interiors-(-28.0, 27.0, -50.5) [Overworld Interiors]",
                new Check(
                    new Reward(1, "Overworld Interiors-(-28.0, 27.0, -50.5)", "FAIRY"),
                    new Location("Overworld Interiors-(-28.0, 27.0, -50.5)", "(-28.0, 27.0, -50.5)", 26, "Overworld Interiors", "SV_Fairy_12_House_Opened")
                )
            },
            {
                "Shield [Overworld Interiors]",
                new Check(
                    new Reward(1, "Shield", "INVENTORY"),
                    new Location("Shield", "(7.0, 29.2, -30.0)", 26, "Overworld Interiors", "Got Shield")
                )
            },
            {
                "under_overworld [Overworld Interiors]",
                new Check(
                    new Reward(1, "26", "PAGE"),
                    new Location("under_overworld", "(7.0, 30.0, 37.0)", 26, "Overworld Interiors", "unlocked page 26")
                )
            },
            {
                "1013 [Overworld Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_9", "INVENTORY"),
                    new Location("1013", "(-4.3, 11.9, -206.4)", 25, "Overworld Redux", "chest open 1013")
                )
            },
            {
                "8 [Overworld Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("8", "(-19.0, 28.0, -89.0)", 25, "Overworld Redux", "chest open 8")
                )
            },
            {
                "11 [Overworld Redux]",
                new Check(
                    new Reward(2, "Firecracker", "INVENTORY"),
                    new Location("11", "(-51.0, 28.0, -87.5)", 25, "Overworld Redux", "chest open 11")
                )
            },
            {
                "1 [Overworld Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("1", "(-68.0, 40.0, -29.5)", 25, "Overworld Redux", "chest open 1")
                )
            },
            {
                "1003 [Overworld Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_3", "INVENTORY"),
                    new Location("1003", "(-62.0, 40.0, -40.5)", 25, "Overworld Redux", "chest open 1003")
                )
            },
            {
                "Key [Overworld Redux]",
                new Check(
                    new Reward(1, "Key", "INVENTORY"),
                    new Location("Key", "(-31.5, 40.3, -39.2)", 25, "Overworld Redux", "SV_got first key")
                )
            },
            {
                "12 [Overworld Redux]",
                new Check(
                    new Reward(2, "Pepper", "INVENTORY"),
                    new Location("12", "(25.0, 36.0, -110.0)", 25, "Overworld Redux", "chest open 12")
                )
            },
            {
                "90 [Overworld Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("90", "(26.0, 28.0, -116.0)", 25, "Overworld Redux", "chest open 90")
                )
            },
            {
                "255 [Overworld Redux]",
                new Check(
                    new Reward(48, "money", "MONEY"),
                    new Location("255", "(79.3, 2.5, -173.0)", 25, "Overworld Redux", "chest open 255")
                )
            },
            {
                "15 [Overworld Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("15", "(96.5, 28.0, -137.0)", 25, "Overworld Redux", "chest open 15")
                )
            },
            {
                "Overworld Redux-(90.4, 36.0, -122.1) [Overworld Redux]",
                new Check(
                    new Reward(1, "Overworld Redux-(90.4, 36.0, -122.1)", "FAIRY"),
                    new Location("Overworld Redux-(90.4, 36.0, -122.1)", "(90.4, 36.0, -122.1)", 25, "Overworld Redux", "SV_Fairy_11_WeatherVane_Opened")
                )
            },
            {
                "overworld post-forest [Overworld Redux]",
                new Check(
                    new Reward(1, "14", "PAGE"),
                    new Location("overworld post-forest", "(54.0, 48.8, -90.0)", 25, "Overworld Redux", "unlocked page 14")
                )
            },
            {
                "Overworld Redux-(64.5, 44.0, -40.0) [Overworld Redux]",
                new Check(
                    new Reward(1, "Overworld Redux-(64.5, 44.0, -40.0)", "FAIRY"),
                    new Location("Overworld Redux-(64.5, 44.0, -40.0)", "(64.5, 44.0, -40.0)", 25, "Overworld Redux", "SV_Fairy_1_Overworld_Flowers_Upper_Opened")
                )
            },
            {
                "6 [Overworld Redux]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("6", "(67.0, 66.0, 22.0)", 25, "Overworld Redux", "chest open 6")
                )
            },
            {
                "Techbow [Overworld Redux]",
                new Check(
                    new Reward(1, "Techbow", "INVENTORY"),
                    new Location("Techbow", "(-95.0, 73.0, 46.2)", 25, "Overworld Redux", "SV_Overworld Redux_Wand Pickup")
                )
            },
            {
                "stonehenge_reward [Overworld Redux]",
                new Check(
                    new Reward(1, "24", "PAGE"),
                    new Location("stonehenge_reward", "(-95.0, 72.0, 47.2)", 25, "Overworld Redux", "unlocked page 24")
                )
            },
            {
                "16 [Overworld Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("16", "(-111.7, 66.0, 38.2)", 25, "Overworld Redux", "chest open 16")
                )
            },
            {
                "9 [Overworld Redux]",
                new Check(
                    new Reward(2, "Pepper", "INVENTORY"),
                    new Location("9", "(-142.0, 40.0, 29.0)", 25, "Overworld Redux", "chest open 9")
                )
            },
            {
                "13 [Overworld Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("13", "(-73.0, 40.0, -4.0)", 25, "Overworld Redux", "chest open 13")
                )
            },
            {
                "207 [Overworld Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Attack - Tooth", "INVENTORY"),
                    new Location("207", "(-19.3, 43.0, 21.7)", 25, "Overworld Redux", "chest open 207")
                )
            },
            {
                "1008 [Overworld Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_8", "INVENTORY"),
                    new Location("1008", "(-37.2, 28.0, -63.6)", 25, "Overworld Redux", "chest open 1008")
                )
            },
            {
                "town_upper [Overworld Redux]",
                new Check(
                    new Reward(1, "8", "PAGE"),
                    new Location("town_upper", "(-70.0, 30.5, -70.0)", 25, "Overworld Redux", "unlocked page 8")
                )
            },
            {
                "Overworld Redux-(-132.0, 28.0, -55.5) [Overworld Redux]",
                new Check(
                    new Reward(1, "Overworld Redux-(-132.0, 28.0, -55.5)", "FAIRY"),
                    new Location("Overworld Redux-(-132.0, 28.0, -55.5)", "(-132.0, 28.0, -55.5)", 25, "Overworld Redux", "SV_Fairy_3_Overworld_Moss_Opened")
                )
            },
            {
                "91 [Overworld Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("91", "(-118.0, 28.0, -46.5)", 25, "Overworld Redux", "chest open 91")
                )
            },
            {
                "overworld_dash [Overworld Redux]",
                new Check(
                    new Reward(1, "21", "PAGE"),
                    new Location("overworld_dash", "(-83.0, 21.0, -108.0)", 25, "Overworld Redux", "unlocked page 21")
                )
            },
            {
                "Overworld Redux-(-83.0, 20.0, -117.5) [Overworld Redux]",
                new Check(
                    new Reward(1, "Overworld Redux-(-83.0, 20.0, -117.5)", "FAIRY"),
                    new Location("Overworld Redux-(-83.0, 20.0, -117.5)", "(-83.0, 20.0, -117.5)", 25, "Overworld Redux", "SV_Fairy_16_Fountain_Opened")
                )
            },
            {
                "2 [Overworld Redux]",
                new Check(
                    new Reward(1, "Trinket - Heartdrops", "INVENTORY"),
                    new Location("2", "(-119.5, 16.0, -111.0)", 25, "Overworld Redux", "chest open 2")
                )
            },
            {
                "209 [Overworld Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("209", "(-129.0, 20.0, -111.5)", 25, "Overworld Redux", "chest open 209")
                )
            },
            {
                "Key (House) [Overworld Redux]",
                new Check(
                    new Reward(1, "Key (House)", "INVENTORY"),
                    new Location("Key (House)", "(-65.0, 12.3, -138.0)", 25, "Overworld Redux", "SV_Housekey from beach")
                )
            },
            {
                "17 [Overworld Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("17", "(-83.0, 12.0, -174.0)", 25, "Overworld Redux", "chest open 17")
                )
            },
            {
                "208 [Overworld Redux]",
                new Check(
                    new Reward(3, "Ivy", "INVENTORY"),
                    new Location("208", "(-60.0, 9.0, -119.0)", 25, "Overworld Redux", "chest open 208")
                )
            },
            {
                "273 [Overworld Redux]",
                new Check(
                    new Reward(16, "money", "MONEY"),
                    new Location("273", "(-33.3, 0.3, -169.8)", 25, "Overworld Redux", "chest open 273")
                )
            },
            {
                "Overworld Redux-(-52.0, 2.0, -174.8) [Overworld Redux]",
                new Check(
                    new Reward(1, "Overworld Redux-(-52.0, 2.0, -174.8)", "FAIRY"),
                    new Location("Overworld Redux-(-52.0, 2.0, -174.8)", "(-52.0, 2.0, -174.8)", 25, "Overworld Redux", "SV_Fairy_2_Overworld_Flowers_Lower_Opened")
                )
            },
            {
                "1004 [Overworld Redux]",
                new Check(
                    new Reward(1, "GoldenTrophy_4", "INVENTORY"),
                    new Location("1004", "(-34.0, -0.5, -178.5)", 25, "Overworld Redux", "chest open 1004")
                )
            },
            {
                "7 [Overworld Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - PotionEfficiency Swig - Ash", "INVENTORY"),
                    new Location("7", "(-83.2, 4.0, -177.1)", 25, "Overworld Redux", "chest open 7")
                )
            },
            {
                "4 [Overworld Redux]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("4", "(-130.0, 12.0, -119.0)", 25, "Overworld Redux", "chest open 4")
                )
            },
            {
                "18 [Overworld Redux]",
                new Check(
                    new Reward(1, "Bait", "INVENTORY"),
                    new Location("18", "(-161.0, 1.0, -72.0)", 25, "Overworld Redux", "chest open 18")
                )
            },
            {
                "267 [Overworld Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("267", "(-178.5, 1.0, -78.5)", 25, "Overworld Redux", "chest open 267")
                )
            },
            {
                "beach [Overworld Redux]",
                new Check(
                    new Reward(1, "16", "PAGE"),
                    new Location("beach", "(-3.0, 1.5, -152.0)", 25, "Overworld Redux", "unlocked page 16")
                )
            },
            {
                "285 [Overworld Redux]",
                new Check(
                    new Reward(4, "Firecracker", "INVENTORY"),
                    new Location("285", "(-56.0, 24.0, -95.2)", 25, "Overworld Redux", "chest open 285")
                )
            },
            {
                "10 [Overworld Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("10", "(15.5, 1.0, -147.5)", 25, "Overworld Redux", "chest open 10")
                )
            },
            {
                "cathedral [Overworld Redux]",
                new Check(
                    new Reward(1, "4", "PAGE"),
                    new Location("cathedral", "(69.0, 10.0, -197.4)", 25, "Overworld Redux", "unlocked page 4")
                )
            },
            {
                "tablet [Overworld Redux]",
                new Check(
                    new Reward(1, "2", "PAGE"),
                    new Location("tablet", "(-95.0, 40.0, 3.5)", 25, "Overworld Redux", "unlocked page 2")
                )
            },
            {
                "town_well [Overworld Redux]",
                new Check(
                    new Reward(1, "9", "PAGE"),
                    new Location("town_well", "(-36.0, 40.0, -13.0)", 25, "Overworld Redux", "unlocked page 9")
                )
            },
            {
                "245 [Overworld Redux]",
                new Check(
                    new Reward(1, "Trinket - MP Flasks", "INVENTORY"),
                    new Location("245", "(-138.2, 28.0, 10.0)", 25, "Overworld Redux", "chest open 245")
                )
            },
            {
                "14 [Overworld Redux]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("14", "(-138.0, 12.0, -64.0)", 25, "Overworld Redux", "chest open 14")
                )
            },
            {
                "258 [Overworld Redux]",
                new Check(
                    new Reward(32, "money", "MONEY"),
                    new Location("258", "(-159.0, 3.0, -113.5)", 25, "Overworld Redux", "chest open 258")
                )
            },
            {
                "3 [Overworld Redux]",
                new Check(
                    new Reward(1, "Berry_MP", "INVENTORY"),
                    new Location("3", "(-102.0, 40.0, -40.0)", 25, "Overworld Redux", "chest open 3")
                )
            },
            {
                "266 [Overworld Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("266", "(48.0, 54.1, -12.0)", 25, "Overworld Redux", "chest open 266")
                )
            },
            {
                "214 [PatrolCave]",
                new Check(
                    new Reward(30, "money", "MONEY"),
                    new Location("214", "(86.0, 46.0, -51.0)", 67, "PatrolCave", "chest open 214")
                )
            },
            {
                "PatrolCave-(74.0, 46.0, 24.0) [PatrolCave]",
                new Check(
                    new Reward(1, "PatrolCave-(74.0, 46.0, 24.0)", "FAIRY"),
                    new Location("PatrolCave-(74.0, 46.0, 24.0)", "(74.0, 46.0, 24.0)", 67, "PatrolCave", "SV_Fairy_13_Patrol_Opened")
                )
            },
            {
                "Quarry Redux-(0.7, 68.0, 84.7) [Quarry Redux]",
                new Check(
                    new Reward(1, "Quarry Redux-(0.7, 68.0, 84.7)", "FAIRY"),
                    new Location("Quarry Redux-(0.7, 68.0, 84.7)", "(0.7, 68.0, 84.7)", 60, "Quarry Redux", "SV_Fairy_7_Quarry_Opened")
                )
            },
            {
                "126 [Quarry Redux]",
                new Check(
                    new Reward(2, "Berry_HP", "INVENTORY"),
                    new Location("126", "(80.0, 16.0, 13.0)", 60, "Quarry Redux", "chest open 126")
                )
            },
            {
                "133 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("133", "(3.4, -8.0, -21.0)", 60, "Quarry Redux", "chest open 133")
                )
            },
            {
                "116 [Quarry Redux]",
                new Check(
                    new Reward(10, "money", "MONEY"),
                    new Location("116", "(-55.0, 22.0, 48.0)", 60, "Quarry Redux", "chest open 116")
                )
            },
            {
                "128 [Quarry Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("128", "(-56.0, 0.0, 43.0)", 60, "Quarry Redux", "chest open 128")
                )
            },
            {
                "288 [Quarry Redux]",
                new Check(
                    new Reward(2, "Bait", "INVENTORY"),
                    new Location("288", "(-49.5, -12.0, 21.0)", 60, "Quarry Redux", "chest open 288")
                )
            },
            {
                "127 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("127", "(-71.0, -20.0, 40.0)", 60, "Quarry Redux", "chest open 127")
                )
            },
            {
                "120 [Quarry Redux]",
                new Check(
                    new Reward(1, "Shotgun", "INVENTORY"),
                    new Location("120", "(-149.7, -39.7, 8.0)", 60, "Quarry Redux", "chest open 120")
                )
            },
            {
                "265 [Quarry Redux]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("265", "(-78.9, -40.0, 38.8)", 60, "Quarry Redux", "chest open 265")
                )
            },
            {
                "121 [Quarry Redux]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("121", "(-140.0, -48.0, -6.0)", 60, "Quarry Redux", "chest open 121")
                )
            },
            {
                "130 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("130", "(-80.0, -56.0, -57.0)", 60, "Quarry Redux", "chest open 130")
                )
            },
            {
                "131 [Quarry Redux]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("131", "(1.0, -47.6, -78.0)", 60, "Quarry Redux", "chest open 131")
                )
            },
            {
                "262 [Quarry Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - DamageResist - Effigy", "INVENTORY"),
                    new Location("262", "(-88.0, -43.5, -66.5)", 60, "Quarry Redux", "chest open 262")
                )
            },
            {
                "122 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("122", "(-131.0, -77.0, -103.0)", 60, "Quarry Redux", "chest open 122")
                )
            },
            {
                "129 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("129", "(-100.0, -69.0, -153.0)", 60, "Quarry Redux", "chest open 129")
                )
            },
            {
                "132 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("132", "(-7.4, -80.3, -77.3)", 60, "Quarry Redux", "chest open 132")
                )
            },
            {
                "123 [Quarry Redux]",
                new Check(
                    new Reward(3, "Firecracker", "INVENTORY"),
                    new Location("123", "(-9.0, -12.0, -64.7)", 60, "Quarry Redux", "chest open 123")
                )
            },
            {
                "117 [Quarry Redux]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("117", "(-23.0, 0.0, 7.0)", 60, "Quarry Redux", "chest open 117")
                )
            },
            {
                "224 [Quarry Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Attack - Tooth", "INVENTORY"),
                    new Location("224", "(28.5, 0.0, -3.0)", 60, "Quarry Redux", "chest open 224")
                )
            },
            {
                "289 [Quarry Redux]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("289", "(52.0, 0.0, 2.5)", 60, "Quarry Redux", "chest open 289")
                )
            },
            {
                "118 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("118", "(125.4, 16.0, 14.8)", 60, "Quarry Redux", "chest open 118")
                )
            },
            {
                "268 [Quarry Redux]",
                new Check(
                    new Reward(1, "Bait", "INVENTORY"),
                    new Location("268", "(-13.0, 8.0, 21.6)", 60, "Quarry Redux", "chest open 268")
                )
            },
            {
                "125 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("125", "(38.7, 24.5, 28.6)", 60, "Quarry Redux", "chest open 125")
                )
            },
            {
                "124 [Quarry Redux]",
                new Check(
                    new Reward(3, "Ivy", "INVENTORY"),
                    new Location("124", "(62.0, 8.0, 15.0)", 60, "Quarry Redux", "chest open 124")
                )
            },
            {
                "119 [Quarry Redux]",
                new Check(
                    new Reward(1, "Trinket - Parry Window", "INVENTORY"),
                    new Location("119", "(81.0, 56.0, 25.0)", 60, "Quarry Redux", "chest open 119")
                )
            },
            {
                "250 [Quarry Redux]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("250", "(21.8, 63.0, 51.4)", 60, "Quarry Redux", "chest open 250")
                )
            },
            {
                "282 [Quarry Redux]",
                new Check(
                    new Reward(1, "Upgrade Offering - Magic MP - Mushroom", "INVENTORY"),
                    new Location("282", "(20.9, 63.0, 66.7)", 60, "Quarry Redux", "chest open 282")
                )
            },
            {
                "134 [Quarry Redux]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("134", "(1.0, 40.0, -19.0)", 60, "Quarry Redux", "chest open 134")
                )
            },
            {
                "Relic PIckup (6) Sword) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Sword", "RELIC"),
                    new Location("Relic PIckup (6) Sword)", "(-18.5, 2.0, -11.0)", 62, "RelicVoid", "SV_RelicVoid_Got_Sword_ATT")
                )
            },
            {
                "Relic PIckup (5) (MP) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Pendant MP", "RELIC"),
                    new Location("Relic PIckup (5) (MP)", "(-18.7, 2.0, 10.8)", 62, "RelicVoid", "SV_RelicVoid_Got_Pendant_MP")
                )
            },
            {
                "Relic PIckup (4) (water) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Water", "RELIC"),
                    new Location("Relic PIckup (4) (water)", "(0.0, 2.0, 21.5)", 62, "RelicVoid", "SV_RelicVoid_Got_Water_POT")
                )
            },
            {
                "Relic PIckup (3) (HP) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Pendant HP", "RELIC"),
                    new Location("Relic PIckup (3) (HP)", "(18.5, 2.0, 10.5)", 62, "RelicVoid", "SV_RelicVoid_Got_Pendant_HP")
                )
            },
            {
                "Relic PIckup (2) (Crown) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Crown", "RELIC"),
                    new Location("Relic PIckup (2) (Crown)", "(18.5, 2.0, -11.0)", 62, "RelicVoid", "SV_RelicVoid_Got_Crown_DEF")
                )
            },
            {
                "Relic PIckup (1) (SP) [RelicVoid]",
                new Check(
                    new Reward(1, "Relic - Hero Pendant SP", "RELIC"),
                    new Location("Relic PIckup (1) (SP)", "(0.0, 2.0, -21.5)", 62, "RelicVoid", "SV_RelicVoid_Got_Pendant_SP")
                )
            },
            {
                "35 [Ruined Shop]",
                new Check(
                    new Reward(1, "Upgrade Offering - Health HP - Flower", "INVENTORY"),
                    new Location("35", "(27.9, 8.0, -34.7)", 6, "Ruined Shop", "chest open 35")
                )
            },
            {
                "36 [Ruined Shop]",
                new Check(
                    new Reward(40, "money", "MONEY"),
                    new Location("36", "(25.1, 8.0, -25.3)", 6, "Ruined Shop", "chest open 36")
                )
            },
            {
                "37 [Ruined Shop]",
                new Check(
                    new Reward(2, "Firecracker", "INVENTORY"),
                    new Location("37", "(22.4, 8.0, -24.7)", 6, "Ruined Shop", "chest open 37")
                )
            },
            {
                "first [Ruins Passage]",
                new Check(
                    new Reward(1, "5", "PAGE"),
                    new Location("first", "(176.0, 16.0, 39.0)", 8, "Ruins Passage", "unlocked page 5")
                )
            },
            {
                "1001 [Ruins Passage]",
                new Check(
                    new Reward(1, "GoldenTrophy_1", "INVENTORY"),
                    new Location("1001", "(176.0, 16.0, 113.5)", 8, "Ruins Passage", "chest open 1001")
                )
            },
            {
                "40 [Sewer]",
                new Check(
                    new Reward(1, "Upgrade Offering - PotionEfficiency Swig - Ash", "INVENTORY"),
                    new Location("40", "(359.9, 0.5, 34.0)", 27, "Sewer", "chest open 40")
                )
            },
            {
                "43 [Sewer]",
                new Check(
                    new Reward(1, "Berry_HP", "INVENTORY"),
                    new Location("43", "(368.9, -1.0, 21.0)", 27, "Sewer", "chest open 43")
                )
            },
            {
                "sewer [Sewer]",
                new Check(
                    new Reward(1, "17", "PAGE"),
                    new Location("sewer", "(351.0, 1.0, 97.0)", 27, "Sewer", "unlocked page 17")
                )
            },
            {
                "49 [Sewer]",
                new Check(
                    new Reward(30, "money", "MONEY"),
                    new Location("49", "(405.6, 2.0, 107.0)", 27, "Sewer", "chest open 49")
                )
            },
            {
                "47 [Sewer]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("47", "(406.0, 3.1, 174.0)", 27, "Sewer", "chest open 47")
                )
            },
            {
                "48 [Sewer]",
                new Check(
                    new Reward(1, "Trinket - Bloodstain Plus", "INVENTORY"),
                    new Location("48", "(321.0, 3.0, 201.0)", 27, "Sewer", "chest open 48")
                )
            },
            {
                "41 [Sewer]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("41", "(286.3, -0.1, 133.1)", 27, "Sewer", "chest open 41")
                )
            },
            {
                "42 [Sewer]",
                new Check(
                    new Reward(15, "money", "MONEY"),
                    new Location("42", "(340.9, 1.3, 137.9)", 27, "Sewer", "chest open 42")
                )
            },
            {
                "46 [Sewer]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("46", "(347.4, -1.0, 115.9)", 27, "Sewer", "chest open 46")
                )
            },
            {
                "50 [Sewer]",
                new Check(
                    new Reward(1, "Upgrade Offering - DamageResist - Effigy", "INVENTORY"),
                    new Location("50", "(324.0, 11.0, 89.0)", 27, "Sewer", "chest open 50")
                )
            },
            {
                "44 [Sewer]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("44", "(343.5, 11.0, 69.5)", 27, "Sewer", "chest open 44")
                )
            },
            {
                "45 [Sewer]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("45", "(374.0, 7.0, 74.0)", 27, "Sewer", "chest open 45")
                )
            },
            {
                "51 [Sewer]",
                new Check(
                    new Reward(3, "Ice Bomb", "INVENTORY"),
                    new Location("51", "(296.1, 11.0, 89.3)", 27, "Sewer", "chest open 51")
                )
            },
            {
                "264 [Sewer]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("264", "(294.5, 11.0, 109.5)", 27, "Sewer", "chest open 264")
                )
            },
            {
                "below_crypt [Sewer_Boss]",
                new Check(
                    new Reward(1, "15", "PAGE"),
                    new Location("below_crypt", "(57.0, 9.4, -10.0)", 51, "Sewer_Boss", "unlocked page 15")
                )
            },
            {
                "Potion (First) [Shop]",
                new Check(
                    new Reward(1, "Flask Container", "INVENTORY"),
                    new Location("Potion (First)", "(-1.9, 1.2, -2.0)", 56, "Shop", "Potion (First)")
                )
            },
            {
                "Potion (West Garden) [Shop]",
                new Check(
                    new Reward(1, "Flask Container", "INVENTORY"),
                    new Location("Potion (West Garden)", "(0.4, 1.2, -2.0)", 56, "Shop", "Potion (West Garden)")
                )
            },
            {
                "Trinket Coin 1 (day) [Shop]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("Trinket Coin 1 (day)", "(0.0, 2.0, -21.5)", 56, "Shop", "Trinket Coin 1 (day)")
                )
            },
            {
                "Trinket Coin 2 (night) [Shop]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("Trinket Coin 2 (night)", "(0.0, 2.0, -21.5)", 56, "Shop", "Trinket Coin 2 (night)")
                )
            },
            {
                "skullcave [ShopSpecial]",
                new Check(
                    new Reward(1, "11", "PAGE"),
                    new Location("skullcave", "(11.9, 0.2, -16.2)", 65, "ShopSpecial", "unlocked page 11")
                )
            },
            {
                "105 [Swamp Redux 2]",
                new Check(
                    new Reward(100, "money", "MONEY"),
                    new Location("105", "(-96.0, 11.0, 48.0)", 59, "Swamp Redux 2", "chest open 105")
                )
            },
            {
                "235 [Swamp Redux 2]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("235", "(-47.7, -1.5, -33.3)", 59, "Swamp Redux 2", "chest open 235")
                )
            },
            {
                "254 [Swamp Redux 2]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("254", "(-41.6, -0.6, 55.4)", 59, "Swamp Redux 2", "chest open 254")
                )
            },
            {
                "246 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket - Fast Icedagger", "INVENTORY"),
                    new Location("246", "(14.5, 0.0, -73.5)", 59, "Swamp Redux 2", "chest open 246")
                )
            },
            {
                "249 [Swamp Redux 2]",
                new Check(
                    new Reward(128, "money", "MONEY"),
                    new Location("249", "(39.2, -0.1, -85.3)", 59, "Swamp Redux 2", "chest open 249")
                )
            },
            {
                "247 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("247", "(83.7, 0.0, -73.8)", 59, "Swamp Redux 2", "chest open 247")
                )
            },
            {
                "108 [Swamp Redux 2]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("108", "(166.0, 0.0, -82.0)", 59, "Swamp Redux 2", "chest open 108")
                )
            },
            {
                "104 [Swamp Redux 2]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("104", "(147.0, 5.8, -33.0)", 59, "Swamp Redux 2", "chest open 104")
                )
            },
            {
                "98 [Swamp Redux 2]",
                new Check(
                    new Reward(50, "money", "MONEY"),
                    new Location("98", "(100.0, 4.0, -70.0)", 59, "Swamp Redux 2", "chest open 98")
                )
            },
            {
                "107 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket - Stamina Recharge Plus", "INVENTORY"),
                    new Location("107", "(38.0, 12.8, -29.8)", 59, "Swamp Redux 2", "chest open 107")
                )
            },
            {
                "97 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("97", "(36.0, 8.0, -62.0)", 59, "Swamp Redux 2", "chest open 97")
                )
            },
            {
                "1005 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "GoldenTrophy_5", "INVENTORY"),
                    new Location("1005", "(59.8, 0.0, -70.6)", 59, "Swamp Redux 2", "chest open 1005")
                )
            },
            {
                "103 [Swamp Redux 2]",
                new Check(
                    new Reward(4, "Firecracker", "INVENTORY"),
                    new Location("103", "(102.0, 6.0, -40.0)", 59, "Swamp Redux 2", "chest open 103")
                )
            },
            {
                "278 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("278", "(47.0, -1.0, 42.0)", 59, "Swamp Redux 2", "chest open 278")
                )
            },
            {
                "99 [Swamp Redux 2]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("99", "(85.0, 0.0, 85.0)", 59, "Swamp Redux 2", "chest open 99")
                )
            },
            {
                "101 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Flask Shard", "INVENTORY"),
                    new Location("101", "(145.0, 4.0, 23.3)", 59, "Swamp Redux 2", "chest open 101")
                )
            },
            {
                "106 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("106", "(160.5, 4.0, -63.0)", 59, "Swamp Redux 2", "chest open 106")
                )
            },
            {
                "109 [Swamp Redux 2]",
                new Check(
                    new Reward(1, "Trinket Coin", "INVENTORY"),
                    new Location("109", "(153.0, 16.0, -55.0)", 59, "Swamp Redux 2", "chest open 109")
                )
            },
            {
                "100 [Swamp Redux 2]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("100", "(184.8, 15.0, 51.0)", 59, "Swamp Redux 2", "chest open 100")
                )
            },
            {
                "102 [Swamp Redux 2]",
                new Check(
                    new Reward(2, "Berry_HP", "INVENTORY"),
                    new Location("102", "(160.5, 12.0, 22.0)", 59, "Swamp Redux 2", "chest open 102")
                )
            },
            {
                "277 [Swamp Redux 2]",
                new Check(
                    new Reward(25, "money", "MONEY"),
                    new Location("277", "(102.1, 6.0, 112.8)", 59, "Swamp Redux 2", "chest open 277")
                )
            },
            {
                "110 [Swamp Redux 2]",
                new Check(
                    new Reward(100, "money", "MONEY"),
                    new Location("110", "(75.0, 14.0, 172.6)", 59, "Swamp Redux 2", "chest open 110")
                )
            },
            {
                "32 [Sword Access]",
                new Check(
                    new Reward(1, "Piggybank L1", "INVENTORY"),
                    new Location("32", "(-48.0, 0.0, -172.5)", 12, "Sword Access", "chest open 32")
                )
            },
            {
                "31 [Sword Access]",
                new Check(
                    new Reward(20, "money", "MONEY"),
                    new Location("31", "(-25.0, 8.0, -172.0)", 12, "Sword Access", "chest open 31")
                )
            },
            {
                "Sword [Sword Access]",
                new Check(
                    new Reward(1, "Sword", "INVENTORY"),
                    new Location("Sword", "(28.2, 6.1, -190.0)", 12, "Sword Access", "Got Sword")
                )
            },
            {
                "1009 [Sword Access]",
                new Check(
                    new Reward(1, "money", "MONEY"),
                    new Location("1009", "(19.0, 4.0, -186.0)", 12, "Sword Access", "chest open 1009")
                )
            },
            {
                "33 [Sword Access]",
                new Check(
                    new Reward(2, "Firebomb", "INVENTORY"),
                    new Location("33", "(-46.0, 8.0, -171.0)", 12, "Sword Access", "chest open 33")
                )
            },
            {
                "19 [Sword Cave]",
                new Check(
                    new Reward(1, "Stick", "INVENTORY"),
                    new Location("19", "(8.8, 0.0, 9.9)", 5, "Sword Cave", "chest open 19")
                )
            },
            {
                "Temple-(14.0, 0.1, 42.4) [Temple]",
                new Check(
                    new Reward(1, "Temple-(14.0, 0.1, 42.4)", "FAIRY"),
                    new Location("Temple-(14.0, 0.1, 42.4)", "(14.0, 0.1, 42.4)", 24, "Temple", "SV_Fairy_6_Temple_Opened")
                )
            },
            {
                "temple [Temple]",
                new Check(
                    new Reward(1, "12", "PAGE"),
                    new Location("temple", "(27.5, 16.0, 60.0)", 24, "Temple", "unlocked page 12")
                )
            },
            {
                "95 [Town Basement]",
                new Check(
                    new Reward(1, "SlowmoItem", "INVENTORY"),
                    new Location("95", "(-202.0, 3.0, 74.5)", 7, "Town Basement", "chest open 95")
                )
            },
            {
                "Town Basement-(-202.0, 28.0, 150.0) [Town Basement]",
                new Check(
                    new Reward(1, "Town Basement-(-202.0, 28.0, 150.0)", "FAIRY"),
                    new Location("Town Basement-(-202.0, 28.0, 150.0)", "(-202.0, 28.0, 150.0)", 7, "Town Basement", "SV_Fairy_10_3DPillar_Opened")
                )
            },
            {
                "town_filigree [Town_FiligreeRoom]",
                new Check(
                    new Reward(1, "22", "PAGE"),
                    new Location("town_filigree", "(-80.0, 23.0, -64.0)", 30, "Town_FiligreeRoom", "unlocked page 22")
                )
            },
            {
                "FT_Island [Transit]",
                new Check(
                    new Reward(1, "1", "PAGE"),
                    new Location("FT_Island", "(-11.0, 8.0, -68.0)", 39, "Transit", "unlocked page 1")
                )
            },
            {
                "1012 [Transit]",
                new Check(
                    new Reward(1, "GoldenTrophy_12", "INVENTORY"),
                    new Location("1012", "(-68.0, 8.0, -40.0)", 39, "Transit", "chest open 1012")
                )
            },
            {
                "Well Reward (3 Coins) [Trinket Well]",
                new Check(
                    new Reward(1, "Trinket Slot", "INVENTORY"),
                    new Location("Well Reward (3 Coins)", "", 0, "Trinket Well", "Trinket Coins Tossed", 3)
                )
            },
            {
                "Well Reward (6 Coins) [Trinket Well]",
                new Check(
                    new Reward(1, "Trinket Slot", "INVENTORY"),
                    new Location("Well Reward (6 Coins)", "", 0, "Trinket Well", "Trinket Coins Tossed", 6)
                )
            },
            {
                "Well Reward (10 Coins) [Trinket Well]",
                new Check(
                    new Reward(1, "Trinket Slot", "INVENTORY"),
                    new Location("Well Reward (10 Coins)", "", 0, "Trinket Well", "Trinket Coins Tossed", 10)
                )
            },
            {
                "Well Reward (15 Coins) [Trinket Well]",
                new Check(
                    new Reward(1, "Trinket Slot", "INVENTORY"),
                    new Location("Well Reward (15 Coins)", "", 0, "Trinket Well", "Trinket Coins Tossed", 15)
                )
            },
            {
                "Waterfall-(-47.0, 45.0, 10.0) [Waterfall]",
                new Check(
                    new Reward(1, "Waterfall-(-47.0, 45.0, 10.0)", "FAIRY"),
                    new Location("Waterfall-(-47.0, 45.0, 10.0)", "(-47.0, 45.0, 10.0)", 49, "Waterfall", "SV_Fairy_5_Waterfall_Opened")
                )
            },
            {
                "waterfall [Waterfall]",
                new Check(
                    new Reward(1, "27", "PAGE"),
                    new Location("waterfall", "(-47.4, 46.9, 3.0)", 49, "Waterfall", "unlocked page 27")
                )
            },
            {
                "1007 [Waterfall]",
                new Check(
                    new Reward(1, "GoldenTrophy_7", "INVENTORY"),
                    new Location("1007", "(-47.5, 45.0, -0.5)", 49, "Waterfall", "chest open 1007")
                )
            },
            {
                "274 [ziggurat2020_1]",
                new Check(
                    new Reward(30, "money", "MONEY"),
                    new Location("274", "(135.0, 138.0, -58.0)", 43, "ziggurat2020_1", "chest open 274")
                )
            },
            {
                "275 [ziggurat2020_1]",
                new Check(
                    new Reward(2, "Berry_MP", "INVENTORY"),
                    new Location("275", "(130.0, 106.0, -129.0)", 43, "ziggurat2020_1", "chest open 275")
                )
            },
            {
                "229 [ziggurat2020_2]",
                new Check(
                    new Reward(1, "Bait", "INVENTORY"),
                    new Location("229", "(149.9, 424.3, -42.6)", 42, "ziggurat2020_2", "chest open 229")
                )
            },
            {
                "230 [ziggurat2020_3]",
                new Check(
                    new Reward(5, "Firecracker", "INVENTORY"),
                    new Location("230", "(74.0, 4.0, 5.0)", 44, "ziggurat2020_3", "chest open 230")
                )
            },
            {
                "231 [ziggurat2020_3]",
                new Check(
                    new Reward(1, "money", "MONEY"),
                    new Location("231", "(-7.0, 4.0, -24.0)", 44, "ziggurat2020_3", "chest open 231")
                )
            },
            {
                "234 [ziggurat2020_3]",
                new Check(
                    new Reward(1, "Flask Container", "INVENTORY"),
                    new Location("234", "(67.6, 4.0, -38.0)", 44, "ziggurat2020_3", "chest open 234")
                )
            },
            {
                "261 [ziggurat2020_3]",
                new Check(
                    new Reward(3, "Ice Bomb", "INVENTORY"),
                    new Location("261", "(129.1, 4.1, -27.3)", 44, "ziggurat2020_3", "chest open 261")
                )
            },
            {
                "260 [ziggurat2020_3]",
                new Check(
                    new Reward(3, "Berry_MP", "INVENTORY"),
                    new Location("260", "(149.2, 4.0, -53.5)", 44, "ziggurat2020_3", "chest open 260")
                )
            },
            {
                "232 [ziggurat2020_3]",
                new Check(
                    new Reward(3, "Berry_HP", "INVENTORY"),
                    new Location("232", "(85.6, 4.0, -51.8)", 44, "ziggurat2020_3", "chest open 232")
                )
            },
            {
                "233 [ziggurat2020_3]",
                new Check(
                    new Reward(6, "Firecracker", "INVENTORY"),
                    new Location("233", "(153.0, 0.0, -61.0)", 44, "ziggurat2020_3", "chest open 233")
                )
            },
            {
                "Hexagon Blue [ziggurat2020_3]",
                new Check(
                    new Reward(1, "Hexagon Blue", "INVENTORY"),
                    new Location("Hexagon Blue", "(521.0, -32.9, -146.0)", 44, "ziggurat2020_3", "Got Hexagon 3 Blue")
                )
            },
        };
    }
}
