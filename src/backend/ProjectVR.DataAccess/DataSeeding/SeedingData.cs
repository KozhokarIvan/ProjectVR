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
                new VrSet { Id = 1, Name = "Meta Quest 2", Icon = "https://cdn.mos.cms.futurecdn.net/3tHJyGRakZSUbsQSgpqj3B.jpg" },
                new VrSet { Id = 2, Name = "Meta Quest Pro", Icon = "https://wavypack.com/wp-content/uploads/2022/10/meta1-732x732.jpg" },
                new VrSet { Id = 3, Name = "Meta Quest 3", Icon = "https://preview.free3d.com/img/2019/02/2188275829300004551/7br30t7k-900.jpg" },
                new VrSet { Id = 4, Name = "Valve Index VR Kit", Icon = "https://cf.shopee.co.th/file/e56de62ec3d3a8fc90192786bb5d45a2"},
                new VrSet { Id = 5, Name = "Htc Vive Pro", Icon = "https://cdn.shopify.com/s/files/1/0570/6563/6015/products/vive-pro-full-kit-side_1445x.jpg?v=1622601723"},
                new VrSet { Id = 6, Name = "Htc Vive Pro 2", Icon = "https://www.robotistan.com/htc-vive-pro2-full-kit-38659-10-B.jpg"}
            };

            Games = new List<Game>
            {
                new Game { Id = 1, Name = "Beat Saber", Icon = "https://steamuserimages-a.akamaihd.net/ugc/786352192200116789/D2244F357EC1456DEEB6F4AB15F8553C10F9F8DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"},
                new Game { Id = 2, Name = "VR Chat", Icon = "https://i.gyazo.com/b54996dbec36d72cb1e5fe944a4b23da.png"},
                new Game { Id = 3, Name = "Skyrim VR", Icon = "https://steamuserimages-a.akamaihd.net/ugc/1043093962826688663/4E945777E1822C8979CD679DDCCCD44C822A8BCB/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"},
                new Game { Id = 4, Name = "Fallout 4 VR", Icon = "https://steamuserimages-a.akamaihd.net/ugc/2057618192240916199/8F24AAC05F4485CA8C49D4064362BB6B91960D16/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"},
                new Game { Id = 5, Name = "Half-Life: Alyx", Icon = "https://steamuserimages-a.akamaihd.net/ugc/1670238751987019701/F499E283EDE967EDF91BA4C204086D56C1F96C7F/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"},
                new Game { Id = 6, Name = "Blade and Sorcery", Icon = "https://www.giantbomb.com/a/uploads/original/36/362334/3059196-bladeandsorcery.png"},
                new Game { Id = 7, Name = "PAYDAY 2 VR", Icon = "https://steamuserimages-a.akamaihd.net/ugc/490148340904984238/DD10B711A4378D7BF3D48F10E3535F29BEC3FB80/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"},
                new Game { Id = 8, Name = "The Forest", Icon = "https://images.discordapp.net/icons/556971445897396224/866ab404fa90cb84066fd06903c7c692.png?size=512"}
            };

            Users = new List<UserInfo>()
            {
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vrenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://media.forgecdn.net/avatars/479/187/637776165451218467.jpeg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "skyrimenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://yt3.ggpht.com/ytc/AKedOLT2-arf4z54qiWMx3T8WXuP7BKT6iMEIzBrU4uG=s900-c-k-c0x00ffffff-no-rj"

                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "falloutenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/6a991cedbf9caf7e0dfd32c5f17f13820c818bf8_medium.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "beatsaberenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://modelsaber.com/files/saber/1607719628/original.png"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "forestenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/e49df9e19ca580ebd13d8d6b69c43a6c9bad8ac0_medium.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://cdn4.iconfinder.com/data/icons/vr-avatars/512/VR8-1024.png"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "quest3enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/07a8f40c65079d2a6caf4af91a5e466517cd7a19_medium.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "questproenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "valveindexenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/b3c041f3eb316e0edf16e6ba36f426b433e16cee_medium.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "viveenjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/3388c1a9ff4cb271d0794154ff5e3405fae7b661_medium.jpg"
                },
                new UserInfo
                {
                    Guid = Guid.NewGuid(),
                    Username = "vive2enjoyer",
                    CreatedAt = DateTimeOffset.Now,
                    LastSeen = DateTimeOffset.Now,
                    Avatar = "https://avatars.akamai.steamstatic.com/fc13bb1f59388dc6070a14f9224b6f697e08a4d3_medium.jpg"
                }
            };

            UserGames = new List<UserGame>
                    {
                        new UserGame{Id = 1, OwnerGuid = Users[0].Guid, GameId = Games.First(g=> g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},
                        new UserGame{Id = 2, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100 },
                        new UserGame{Id = 3, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100 },
                        new UserGame{Id = 4, OwnerGuid = Users[0].Guid, GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = false, Rating = 95 },



                        new UserGame{Id = 5, OwnerGuid = Users[1].Guid, GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true, Rating = 100},


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
                new UserVrSet{Id = 1, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true },
                new UserVrSet{Id = 2, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true },
                new UserVrSet{Id = 3, OwnerGuid = Users[0].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true },


                new UserVrSet{Id = 4, OwnerGuid = Users[1].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id },


                new UserVrSet{Id = 5, OwnerGuid = Users[2].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 6, OwnerGuid = Users[3].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 7, OwnerGuid = Users[4].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id},


                new UserVrSet{Id = 8, OwnerGuid = Users[5].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 2", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true},


                new UserVrSet{Id = 9, OwnerGuid = Users[6].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true},


                new UserVrSet{Id = 10, OwnerGuid = Users[7].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("quest pro", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true},


                new UserVrSet{Id = 11, OwnerGuid = Users[8].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true},


                new UserVrSet{Id = 12, OwnerGuid = Users[9].Guid, VrSetId = VrSets.First(
                    vs=>vs.Name.Contains("vive pro", StringComparison.OrdinalIgnoreCase)
                    && !vs.Name.Contains("2")).Id, IsFavorite = true },


                new UserVrSet{Id = 13, OwnerGuid = Users[10].Guid, VrSetId = VrSets.First(vs=>vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id, IsFavorite = true }
            };
        }
    }
}
