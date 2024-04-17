using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.DataSeeding;

internal class SeedingData
{
    internal SeedingData()
    {
        VrSets = new List<VrSet>
        {
            new ()
            {
                Id = 1, Name = "Meta Quest 2", Icon = "https://cdn.mos.cms.futurecdn.net/3tHJyGRakZSUbsQSgpqj3B.jpg"
            },
            new ()
            {
                Id = 2, Name = "Meta Quest Pro",
                Icon = "https://wavypack.com/wp-content/uploads/2022/10/meta1-732x732.jpg"
            },
            new ()
            {
                Id = 3, Name = "Meta Quest 3",
                Icon = "https://preview.free3d.com/img/2019/02/2188275829300004551/7br30t7k-900.jpg"
            },
            new ()
            {
                Id = 4, Name = "Valve Index VR Kit",
                Icon = "https://cf.shopee.co.th/file/e56de62ec3d3a8fc90192786bb5d45a2"
            },
            new ()
            {
                Id = 5, Name = "Htc Vive Pro",
                Icon =
                    "https://cdn.shopify.com/s/files/1/0570/6563/6015/products/vive-pro-full-kit-side_1445x.jpg?v=1622601723"
            },
            new ()
            {
                Id = 6, Name = "Htc Vive Pro 2",
                Icon = "https://www.robotistan.com/htc-vive-pro2-full-kit-38659-10-B.jpg"
            }
        };

        Games = new List<Game>
        {
            new ()
            {
                Id = 1, Name = "Beat Saber",
                Icon =
                    "https://steamuserimages-a.akamaihd.net/ugc/786352192200116789/D2244F357EC1456DEEB6F4AB15F8553C10F9F8DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"
            },
            new () { Id = 2, Name = "VR Chat", Icon = "https://i.gyazo.com/b54996dbec36d72cb1e5fe944a4b23da.png" },
            new ()
            {
                Id = 3, Name = "Skyrim VR",
                Icon =
                    "https://steamuserimages-a.akamaihd.net/ugc/1043093962826688663/4E945777E1822C8979CD679DDCCCD44C822A8BCB/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"
            },
            new ()
            {
                Id = 4, Name = "Fallout 4 VR",
                Icon =
                    "https://steamuserimages-a.akamaihd.net/ugc/2057618192240916199/8F24AAC05F4485CA8C49D4064362BB6B91960D16/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"
            },
            new ()
            {
                Id = 5, Name = "Half-Life: Alyx",
                Icon =
                    "https://steamuserimages-a.akamaihd.net/ugc/1670238751987019701/F499E283EDE967EDF91BA4C204086D56C1F96C7F/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"
            },
            new ()
            {
                Id = 6, Name = "Blade and Sorcery",
                Icon = "https://www.giantbomb.com/a/uploads/original/36/362334/3059196-bladeandsorcery.png"
            },
            new ()
            {
                Id = 7, Name = "PAYDAY 2 VR",
                Icon =
                    "https://steamuserimages-a.akamaihd.net/ugc/490148340904984238/DD10B711A4378D7BF3D48F10E3535F29BEC3FB80/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true"
            },
            new ()
            {
                Id = 8, Name = "The Forest",
                Icon =
                    "https://images.discordapp.net/icons/556971445897396224/866ab404fa90cb84066fd06903c7c692.png?size=512"
            }
        };

        Users = new List<Users>
        {
            new ()
            {
                Guid = Guid.Parse("407898b1-cf14-42a1-9b74-775587f878da"),
                Username = "vrenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://media.forgecdn.net/avatars/479/187/637776165451218467.jpeg"
            },
            new ()
            {
                Guid = Guid.Parse("309f1f3c-39a7-4701-b38e-aa68dafff1d7"),
                Username = "skyrimenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar =
                    "https://yt3.ggpht.com/ytc/AKedOLT2-arf4z54qiWMx3T8WXuP7BKT6iMEIzBrU4uG=s900-c-k-c0x00ffffff-no-rj"
            },
            new ()
            {
                Guid = Guid.Parse("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"),
                Username = "falloutenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/6a991cedbf9caf7e0dfd32c5f17f13820c818bf8_medium.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"),
                Username = "beatsaberenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://modelsaber.com/files/saber/1607719628/original.png"
            },
            new ()
            {
                Guid = Guid.Parse("385f17c9-46b2-49f8-9425-9824369f6e84"),
                Username = "forestenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/e49df9e19ca580ebd13d8d6b69c43a6c9bad8ac0_medium.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("999c5da3-c747-44a1-b56d-416d403bb6c6"),
                Username = "quest2enjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://cdn4.iconfinder.com/data/icons/vr-avatars/512/VR8-1024.png"
            },
            new ()
            {
                Guid = Guid.Parse("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"),
                Username = "quest3enjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/07a8f40c65079d2a6caf4af91a5e466517cd7a19_medium.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("2f5598a2-a160-47d0-a36a-09c54f29aa28"),
                Username = "questproenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("a646f675-bafc-4a9e-a162-ca132316db3c"),
                Username = "valveindexenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/b3c041f3eb316e0edf16e6ba36f426b433e16cee_medium.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("83331ccb-485a-4dd3-b77f-8d4f7d812505"),
                Username = "viveenjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/3388c1a9ff4cb271d0794154ff5e3405fae7b661_medium.jpg"
            },
            new ()
            {
                Guid = Guid.Parse("31ed4b17-5e00-4d84-9189-425eb242d893"),
                Username = "vive2enjoyer",
                CreatedAt = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LastSeen = DateTimeOffset.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Avatar = "https://avatars.akamai.steamstatic.com/fc13bb1f59388dc6070a14f9224b6f697e08a4d3_medium.jpg"
            }
        };

        UserGames = new List<UserGame>
        {
            new ()
            {
                Id = 1, OwnerGuid = Users[0].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 2, OwnerGuid = Users[0].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 3, OwnerGuid = Users[0].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 4, OwnerGuid = Users[0].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 95
            },

            new ()
            {
                Id = 5, OwnerGuid = Users[1].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },

            new ()
            {
                Id = 6, OwnerGuid = Users[2].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },

            new ()
            {
                Id = 7, OwnerGuid = Users[3].Guid,
                GameId = Games.First(g => g.Name.Contains("beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },

            new ()
            {
                Id = 8, OwnerGuid = Users[4].Guid,
                GameId = Games.First(g => g.Name.Contains("forest", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },

            new ()
            {
                Id = 9, OwnerGuid = Users[5].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 98
            },
            new ()
            {
                Id = 10, OwnerGuid = Users[5].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 87
            },
            new ()
            {
                Id = 11, OwnerGuid = Users[5].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 90
            },
            new ()
            {
                Id = 12, OwnerGuid = Users[5].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 65
            },

            new ()
            {
                Id = 13, OwnerGuid = Users[6].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 14, OwnerGuid = Users[6].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 15, OwnerGuid = Users[6].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 16, OwnerGuid = Users[6].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 77
            },

            new ()
            {
                Id = 17, OwnerGuid = Users[7].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 63
            },
            new ()
            {
                Id = 18, OwnerGuid = Users[7].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 55
            },
            new ()
            {
                Id = 19, OwnerGuid = Users[7].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 59
            },
            new ()
            {
                Id = 20, OwnerGuid = Users[7].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 50
            },

            new ()
            {
                Id = 21, OwnerGuid = Users[8].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 22, OwnerGuid = Users[8].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 23, OwnerGuid = Users[8].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 24, OwnerGuid = Users[8].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },

            new ()
            {
                Id = 25, OwnerGuid = Users[9].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 26, OwnerGuid = Users[9].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 74
            },
            new ()
            {
                Id = 27, OwnerGuid = Users[9].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 69
            },
            new ()
            {
                Id = 28, OwnerGuid = Users[9].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 62
            },

            new ()
            {
                Id = 29, OwnerGuid = Users[10].Guid,
                GameId = Games.First(g => g.Name.Contains("Skyrim", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 73
            },
            new ()
            {
                Id = 30, OwnerGuid = Users[10].Guid,
                GameId = Games.First(g => g.Name.Contains("Fallout", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 64
            },
            new ()
            {
                Id = 31, OwnerGuid = Users[10].Guid,
                GameId = Games.First(g => g.Name.Contains("Beat", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true, Rating = 100
            },
            new ()
            {
                Id = 32, OwnerGuid = Users[10].Guid,
                GameId = Games.First(g => g.Name.Contains("Blade", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = false, Rating = 47
            }
        };

        UserVrSets = new List<UserVrSet>
        {
            new ()
            {
                Id = 1, OwnerGuid = Users[0].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },
            new ()
            {
                Id = 2, OwnerGuid = Users[0].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },
            new ()
            {
                Id = 3, OwnerGuid = Users[0].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 4, OwnerGuid = Users[1].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id
            },

            new ()
            {
                Id = 5, OwnerGuid = Users[2].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id
            },

            new ()
            {
                Id = 6, OwnerGuid = Users[3].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id
            },

            new ()
            {
                Id = 7, OwnerGuid = Users[4].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id
            },

            new ()
            {
                Id = 8, OwnerGuid = Users[5].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 2", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 9, OwnerGuid = Users[6].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest 3", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 10, OwnerGuid = Users[7].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("quest pro", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 11, OwnerGuid = Users[8].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("index", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 12, OwnerGuid = Users[9].Guid, VrSetId = VrSets.First(
                    vs => vs.Name.Contains("vive pro", StringComparison.OrdinalIgnoreCase)
                          && !vs.Name.Contains('2')).Id,
                IsFavorite = true
            },

            new ()
            {
                Id = 13, OwnerGuid = Users[10].Guid,
                VrSetId = VrSets.First(vs => vs.Name.Contains("vive pro 2", StringComparison.OrdinalIgnoreCase)).Id,
                IsFavorite = true
            }
        };
    }

    internal List<Game> Games { get; }

    internal List<UserGame> UserGames { get; }

    internal List<Users> Users { get; }

    internal List<UserVrSet> UserVrSets { get; }

    internal List<VrSet> VrSets { get; }
}