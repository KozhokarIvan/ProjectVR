using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectVR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usersinfo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Avatar = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastSeen = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usersinfo", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "VrSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Usersinfo_FromUserGuid",
                        column: x => x.FromUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Usersinfo_ToUserGuid",
                        column: x => x.ToUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    AcceptedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Usersinfo_FromUserGuid",
                        column: x => x.FromUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Usersinfo_ToUserGuid",
                        column: x => x.ToUserGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Usersinfo_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVrSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    VrSetId = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVrSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVrSets_Usersinfo_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "Usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVrSets_VrSets_VrSetId",
                        column: x => x.VrSetId,
                        principalTable: "VrSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("2f5598a2-a160-47d0-a36a-09c54f29aa28"), "https://avatars.akamai.steamstatic.com/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5116), new TimeSpan(0, 3, 0, 0, 0)), "questproenjoyer" },
                    { new Guid("309f1f3c-39a7-4701-b38e-aa68dafff1d7"), "https://yt3.ggpht.com/ytc/AKedOLT2-arf4z54qiWMx3T8WXuP7BKT6iMEIzBrU4uG=s900-c-k-c0x00ffffff-no-rj", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 3, 0, 0, 0)), "skyrimenjoyer" },
                    { new Guid("31ed4b17-5e00-4d84-9189-425eb242d893"), "https://avatars.akamai.steamstatic.com/fc13bb1f59388dc6070a14f9224b6f697e08a4d3_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5127), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5128), new TimeSpan(0, 3, 0, 0, 0)), "vive2enjoyer" },
                    { new Guid("385f17c9-46b2-49f8-9425-9824369f6e84"), "https://avatars.akamai.steamstatic.com/e49df9e19ca580ebd13d8d6b69c43a6c9bad8ac0_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5105), new TimeSpan(0, 3, 0, 0, 0)), "forestenjoyer" },
                    { new Guid("407898b1-cf14-42a1-9b74-775587f878da"), "https://media.forgecdn.net/avatars/479/187/637776165451218467.jpeg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5054), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 3, 0, 0, 0)), "vrenjoyer" },
                    { new Guid("4ebe0fb3-d0c2-4474-8ffa-d1640bff6de4"), "https://avatars.akamai.steamstatic.com/07a8f40c65079d2a6caf4af91a5e466517cd7a19_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5112), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5113), new TimeSpan(0, 3, 0, 0, 0)), "quest3enjoyer" },
                    { new Guid("83331ccb-485a-4dd3-b77f-8d4f7d812505"), "https://avatars.akamai.steamstatic.com/3388c1a9ff4cb271d0794154ff5e3405fae7b661_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5124), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 3, 0, 0, 0)), "viveenjoyer" },
                    { new Guid("999c5da3-c747-44a1-b56d-416d403bb6c6"), "https://cdn4.iconfinder.com/data/icons/vr-avatars/512/VR8-1024.png", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5109), new TimeSpan(0, 3, 0, 0, 0)), "quest2enjoyer" },
                    { new Guid("a646f675-bafc-4a9e-a162-ca132316db3c"), "https://avatars.akamai.steamstatic.com/b3c041f3eb316e0edf16e6ba36f426b433e16cee_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5119), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 3, 0, 0, 0)), "valveindexenjoyer" },
                    { new Guid("ca7a6018-0cf2-45da-a54c-0de1e7401bb4"), "https://modelsaber.com/files/saber/1607719628/original.png", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 3, 0, 0, 0)), "beatsaberenjoyer" },
                    { new Guid("fbfa8300-e0fd-410b-a7be-4357eb0fc6bc"), "https://avatars.akamai.steamstatic.com/6a991cedbf9caf7e0dfd32c5f17f13820c818bf8_medium.jpg", new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 7, 25, 19, 1, 19, 45, DateTimeKind.Unspecified).AddTicks(5099), new TimeSpan(0, 3, 0, 0, 0)), "falloutenjoyer" }
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

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FromUserGuid",
                table: "FriendRequests",
                column: "FromUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ToUserGuid",
                table: "FriendRequests",
                column: "ToUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FromUserGuid",
                table: "Friends",
                column: "FromUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ToUserGuid",
                table: "Friends",
                column: "ToUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_OwnerGuid",
                table: "UserGames",
                column: "OwnerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserVrSets_OwnerGuid",
                table: "UserVrSets",
                column: "OwnerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserVrSets_VrSetId",
                table: "UserVrSets",
                column: "VrSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "UserVrSets");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Usersinfo");

            migrationBuilder.DropTable(
                name: "VrSets");
        }
    }
}
