using System;
using System.Collections.Generic;
using System.Linq;
using ProjectVR.DataAccess.Models;

namespace ProjectVR.WebAPI.StaticData
{
    internal class SeedingData
    {

        internal readonly List<UserInfo> Users;
        internal readonly List<VrSet> VrSets;
        internal readonly List<Game> Games;
        internal readonly List<UserGame> UserGames;
        internal readonly List<UserVrSet> UserVrSets;
        internal SeedingData()
        {
            VrSets = new List<VrSet>()
            {
                new VrSet { Id = 1, Name = "Meta Quest 2" },
                new VrSet { Id = 2, Name = "Meta Quest Pro" },
                new VrSet { Id = 3, Name = "Meta Quest 3" },
                new VrSet { Id = 4, Name = "Valve Index VR Kit"},
                new VrSet { Id = 5, Name = "Htc Vive Pro"},
                new VrSet { Id = 6, Name = "Htc Vive Pro 2"}
            };

            Games = new List<Game>
            {
                new Game { Id = 1, Name = "Beat Saber"},
                new Game { Id = 2, Name = "VR Chat"},
                new Game { Id = 3, Name = "Skyrim VR"},
                new Game { Id = 4, Name = "Fallout 4 VR"},
                new Game { Id = 5, Name = "Half-Life: Alyx"},
                new Game { Id = 6, Name = "Blade and Sorcery"},
                new Game { Id = 7, Name = "PAYDAY 2 VR"},
                new Game { Id = 8, Name = "The Forest"}
            };

            Users = new List<UserInfo>()
            {
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vrenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "skyrimenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "falloutenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "beatsaberenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "forestenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest3enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "questproenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "valveindexenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "viveenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vive2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now
                }
            };

            UserGames = new List<UserGame>
                    {
                        new UserGame{Id = 1, OwnerGuid = Users[0].Guid, GameId = Games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 2, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100 },
                        new UserGame{Id = 3, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100 },
                        new UserGame{Id = 4, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 95 },



                        new UserGame{Id = 5, OwnerGuid = Users[1].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 100},


                        new UserGame{Id = 6, OwnerGuid = Users[2].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},


                        new UserGame{Id = 7, OwnerGuid = Users[3].Guid, GameId = Games.First(g => g.Name.Contains("beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},


                        new UserGame{Id = 8, OwnerGuid = Users[4].Guid, GameId = Games.First(g => g.Name.Contains("forest", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},


                        new UserGame{Id = 9, OwnerGuid = Users[5].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 98},
                        new UserGame{Id = 10, OwnerGuid = Users[5].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 87},
                        new UserGame{Id = 11, OwnerGuid = Users[5].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 90},
                        new UserGame{Id = 12, OwnerGuid = Users[5].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 65},


                        new UserGame{Id = 13, OwnerGuid = Users[6].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 14, OwnerGuid = Users[6].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 15, OwnerGuid = Users[6].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 16, OwnerGuid = Users[6].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 77},


                        new UserGame{Id = 17, OwnerGuid = Users[7].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 63},
                        new UserGame{Id = 18, OwnerGuid = Users[7].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 55},
                        new UserGame{Id = 19, OwnerGuid = Users[7].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 59},
                        new UserGame{Id = 20, OwnerGuid = Users[7].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 50},


                        new UserGame{Id = 21, OwnerGuid = Users[8].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 22, OwnerGuid = Users[8].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 23, OwnerGuid = Users[8].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 24, OwnerGuid = Users[8].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},


                        new UserGame{Id = 25, OwnerGuid = Users[9].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 26, OwnerGuid = Users[9].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 74},
                        new UserGame{Id = 27, OwnerGuid = Users[9].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 69},
                        new UserGame{Id = 28, OwnerGuid = Users[9].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 62},


                        new UserGame{Id = 29, OwnerGuid = Users[10].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 73},
                        new UserGame{Id = 30, OwnerGuid = Users[10].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 64},
                        new UserGame{Id = 31, OwnerGuid = Users[10].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 32, OwnerGuid = Users[10].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 47}

                    };

            UserVrSets = new List<UserVrSet>
            {
                new UserVrSet{Id = 1, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id },
                new UserVrSet{Id = 2, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id },
                new UserVrSet{Id = 3, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id },


                new UserVrSet{Id = 4, OwnerGuid = Users[1].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id },


                new UserVrSet{Id = 5, OwnerGuid = Users[2].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 6, OwnerGuid = Users[3].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 7, OwnerGuid = Users[4].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 8, OwnerGuid = Users[5].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 2", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 9, OwnerGuid = Users[6].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 10, OwnerGuid = Users[7].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest pro", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 11, OwnerGuid = Users[8].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 12, OwnerGuid = Users[9].Guid, VrSetId = VrSets.First(
                    vs=>vs.Name.Contains("vive pro", StringComparison.OrdinalIgnoreCase)
                    && !vs.Name.Contains("2")).Id },


                new UserVrSet{Id = 13, OwnerGuid = Users[10].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id }
            };
        }
    }
}
