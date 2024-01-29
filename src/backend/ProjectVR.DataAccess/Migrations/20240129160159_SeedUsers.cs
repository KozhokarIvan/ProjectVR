using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectVR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "https://steamuserimages-a.akamaihd.net/ugc/786352192200116789/D2244F357EC1456DEEB6F4AB15F8553C10F9F8DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false", "Beat Saber" },
                    { 2, "https://i.gyazo.com/b54996dbec36d72cb1e5fe944a4b23da.png", "VR Chat" },
                    { 3, "https://steamuserimages-a.akamaihd.net/ugc/1043093962826688663/4E945777E1822C8979CD679DDCCCD44C822A8BCB/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false", "Skyrim VR" },
                    { 4, "https://steamuserimages-a.akamaihd.net/ugc/2057618192240916199/8F24AAC05F4485CA8C49D4064362BB6B91960D16/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true", "Fallout 4 VR" },
                    { 5, "https://steamuserimages-a.akamaihd.net/ugc/1670238751987019701/F499E283EDE967EDF91BA4C204086D56C1F96C7F/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true", "Half-Life: Alyx" },
                    { 6, "https://www.giantbomb.com/a/uploads/original/36/362334/3059196-bladeandsorcery.png", "Blade and Sorcery" },
                    { 7, "https://steamuserimages-a.akamaihd.net/ugc/490148340904984238/DD10B711A4378D7BF3D48F10E3535F29BEC3FB80/?imw=512&imh=512&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true", "PAYDAY 2 VR" },
                    { 8, "https://images.discordapp.net/icons/556971445897396224/866ab404fa90cb84066fd06903c7c692.png?size=512", "The Forest" }
                });

            migrationBuilder.InsertData(
                table: "Usersinfo",
                columns: new[] { "Guid", "Avatar", "CreatedAt", "LastSeen", "Username" },
                values: new object[,]
                {
                    { new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), "https://avatars.akamai.steamstatic.com/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "questproenjoyer" },
                    { new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"), "https://yt3.ggpht.com/ytc/AKedOLT2-arf4z54qiWMx3T8WXuP7BKT6iMEIzBrU4uG=s900-c-k-c0x00ffffff-no-rj", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "skyrimenjoyer" },
                    { new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), "https://avatars.akamai.steamstatic.com/fc13bb1f59388dc6070a14f9224b6f697e08a4d3_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "vive2enjoyer" },
                    { new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"), "https://avatars.akamai.steamstatic.com/e49df9e19ca580ebd13d8d6b69c43a6c9bad8ac0_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "forestenjoyer" },
                    { new Guid("407898b1-cf14-42a1-9b74-775587f878da"), "https://media.forgecdn.net/avatars/479/187/637776165451218467.jpeg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "vrenjoyer" },
                    { new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), "https://avatars.akamai.steamstatic.com/07a8f40c65079d2a6caf4af91a5e466517cd7a19_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "quest3enjoyer" },
                    { new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), "https://avatars.akamai.steamstatic.com/3388c1a9ff4cb271d0794154ff5e3405fae7b661_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "viveenjoyer" },
                    { new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), "https://cdn4.iconfinder.com/data/icons/vr-avatars/512/VR8-1024.png", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "quest2enjoyer" },
                    { new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), "https://avatars.akamai.steamstatic.com/b3c041f3eb316e0edf16e6ba36f426b433e16cee_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "valveindexenjoyer" },
                    { new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"), "https://modelsaber.com/files/saber/1607719628/original.png", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "beatsaberenjoyer" },
                    { new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"), "https://avatars.akamai.steamstatic.com/6a991cedbf9caf7e0dfd32c5f17f13820c818bf8_medium.jpg", new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "falloutenjoyer" }
                });

            migrationBuilder.InsertData(
                table: "VrSets",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn.mos.cms.futurecdn.net/3tHJyGRakZSUbsQSgpqj3B.jpg", "Meta Quest 2" },
                    { 2, "https://wavypack.com/wp-content/uploads/2022/10/meta1-732x732.jpg", "Meta Quest Pro" },
                    { 3, "https://preview.free3d.com/img/2019/02/2188275829300004551/7br30t7k-900.jpg", "Meta Quest 3" },
                    { 4, "https://cf.shopee.co.th/file/e56de62ec3d3a8fc90192786bb5d45a2", "Valve Index VR Kit" },
                    { 5, "https://cdn.shopify.com/s/files/1/0570/6563/6015/products/vive-pro-full-kit-side_1445x.jpg?v=1622601723", "Htc Vive Pro" },
                    { 6, "https://www.robotistan.com/htc-vive-pro2-full-kit-38659-10-B.jpg", "Htc Vive Pro 2" }
                });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "GameId", "IsFavorite", "OwnerGuid", "Rating" },
                values: new object[,]
                {
                    { 1, 3, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), (byte)100 },
                    { 2, 4, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), (byte)100 },
                    { 3, 1, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), (byte)100 },
                    { 4, 6, false, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), (byte)95 },
                    { 5, 3, true, new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"), (byte)100 },
                    { 6, 4, true, new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"), (byte)100 },
                    { 7, 1, true, new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"), (byte)100 },
                    { 8, 8, true, new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"), (byte)100 },
                    { 9, 3, true, new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), (byte)98 },
                    { 10, 4, true, new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), (byte)87 },
                    { 11, 1, true, new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), (byte)90 },
                    { 12, 6, false, new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), (byte)65 },
                    { 13, 3, true, new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), (byte)100 },
                    { 14, 4, true, new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), (byte)100 },
                    { 15, 1, true, new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), (byte)100 },
                    { 16, 6, false, new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), (byte)77 },
                    { 17, 3, false, new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), (byte)63 },
                    { 18, 4, false, new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), (byte)55 },
                    { 19, 1, false, new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), (byte)59 },
                    { 20, 6, false, new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), (byte)50 },
                    { 21, 3, true, new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), (byte)100 },
                    { 22, 4, true, new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), (byte)100 },
                    { 23, 1, true, new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), (byte)100 },
                    { 24, 6, true, new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), (byte)100 },
                    { 25, 3, true, new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), (byte)100 },
                    { 26, 4, false, new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), (byte)74 },
                    { 27, 1, false, new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), (byte)69 },
                    { 28, 6, false, new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), (byte)62 },
                    { 29, 3, false, new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), (byte)73 },
                    { 30, 4, false, new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), (byte)64 },
                    { 31, 1, true, new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), (byte)100 },
                    { 32, 6, false, new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), (byte)47 }
                });

            migrationBuilder.InsertData(
                table: "UserVrSets",
                columns: new[] { "Id", "IsFavorite", "OwnerGuid", "VrSetId" },
                values: new object[,]
                {
                    { 1, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), 3 },
                    { 2, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), 4 },
                    { 3, true, new Guid("407898b1-cf14-42a1-9b74-775587f878da"), 6 },
                    { 4, false, new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"), 3 },
                    { 5, false, new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"), 3 },
                    { 6, false, new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"), 3 },
                    { 7, false, new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"), 3 },
                    { 8, true, new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), 1 },
                    { 9, true, new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), 3 },
                    { 10, true, new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), 2 },
                    { 11, true, new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), 4 },
                    { 12, true, new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), 5 },
                    { 13, true, new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UserGames",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserVrSets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("407898b1-cf14-42a1-9b74-775587f878da"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"));

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Guid",
                keyValue: new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"));

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VrSets",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
