using ProjectVR.WebAPI.Entities;

namespace ProjectVR.WebAPI.StaticData
{
    public class UsersData
    {
        public readonly List<Userinfo> Users;
        private readonly List<VrSet> _vrSets;
        private readonly List<Game> _games;
        public UsersData()
        {
            _vrSets = new List<VrSet>()
            {
                new VrSet { Id = 1, Name = "Meta Quest 2" },
                new VrSet { Id = 2, Name = "Meta Quest Pro" },
                new VrSet { Id = 3, Name = "Meta Quest 3" },
                new VrSet { Id = 4, Name = "Valve Index VR Kit"},
                new VrSet { Id = 5, Name = "Htc Vive Pro"},
                new VrSet { Id = 6, Name = "Htc Vive Pro 2"}
            };
            _games = new List<Game>
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
            Users = new List<Userinfo>()
            {
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vrenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)),
                        _vrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)),
                        _vrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)),
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "skyrimenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase))
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "falloutenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase))
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "beatsaberenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("beat", StringComparison.OrdinalIgnoreCase))
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "forestenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("forest", StringComparison.OrdinalIgnoreCase))
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 2", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest3enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "questproenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("quest pro", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "valveindexenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "viveenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(
                            vs=>vs.Name.Contains("vive pro", StringComparison.OrdinalIgnoreCase)
                        && !vs.Name.Contains("2"))
                    }
                },
                new Userinfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vive2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Games = new List<Game>
                    {
                        _games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)),
                        _games.First(g=> g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)),
                    },
                    VrSets = new List<VrSet>
                    {
                        _vrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase))
                    }
                }
            };
        }
    }
}
