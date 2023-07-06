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
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usersinfo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastSeen = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersinfo", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "vrsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vrsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usergames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usergames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usergames_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usergames_usersinfo_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uservrsets",
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
                    table.PrimaryKey("PK_uservrsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uservrsets_usersinfo_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "usersinfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uservrsets_vrsets_VrSetId",
                        column: x => x.VrSetId,
                        principalTable: "vrsets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "games",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beat Saber" },
                    { 2, "VR Chat" },
                    { 3, "Skyrim VR" },
                    { 4, "Fallout 4 VR" },
                    { 5, "Half-Life: Alyx" },
                    { 6, "Blade and Sorcery" },
                    { 7, "PAYDAY 2 VR" },
                    { 8, "The Forest" }
                });

            migrationBuilder.InsertData(
                table: "usersinfo",
                columns: new[] { "Guid", "Avatar", "CreatedAt", "LastSeen", "Username" },
                values: new object[,]
                {
                    { new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6889), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6889), new TimeSpan(0, 3, 0, 0, 0)), "questproenjoyer" },
                    { new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6873), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6874), new TimeSpan(0, 3, 0, 0, 0)), "quest2enjoyer" },
                    { new Guid("59cd92da-6b8f-40b3-ab08-a3cb1cab1532"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6862), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6864), new TimeSpan(0, 3, 0, 0, 0)), "skyrimenjoyer" },
                    { new Guid("5a560c3a-6d49-4442-a372-a51e99a27f74"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6870), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 3, 0, 0, 0)), "forestenjoyer" },
                    { new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6891), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6892), new TimeSpan(0, 3, 0, 0, 0)), "valveindexenjoyer" },
                    { new Guid("86628830-8827-4a4d-b7ed-fb5fff025f1a"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6868), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6869), new TimeSpan(0, 3, 0, 0, 0)), "beatsaberenjoyer" },
                    { new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 3, 0, 0, 0)), "vrenjoyer" },
                    { new Guid("a028785e-4dc5-434f-8cd1-828cbc2f1169"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 3, 0, 0, 0)), "falloutenjoyer" },
                    { new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6894), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 3, 0, 0, 0)), "viveenjoyer" },
                    { new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6896), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6897), new TimeSpan(0, 3, 0, 0, 0)), "vive2enjoyer" },
                    { new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), null, new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6876), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 15, 3, 43, 58, 14, DateTimeKind.Unspecified).AddTicks(6877), new TimeSpan(0, 3, 0, 0, 0)), "quest3enjoyer" }
                });

            migrationBuilder.InsertData(
                table: "vrsets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meta Quest 2" },
                    { 2, "Meta Quest Pro" },
                    { 3, "Meta Quest 3" },
                    { 4, "Valve Index VR Kit" },
                    { 5, "Htc Vive Pro" },
                    { 6, "Htc Vive Pro 2" }
                });

            migrationBuilder.InsertData(
                table: "usergames",
                columns: new[] { "Id", "GameId", "IsFavorite", "OwnerGuid", "Rating" },
                values: new object[,]
                {
                    { 1, 3, true, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 100 },
                    { 2, 4, true, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 100 },
                    { 3, 1, true, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 100 },
                    { 4, 6, false, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 95 },
                    { 5, 3, false, new Guid("59cd92da-6b8f-40b3-ab08-a3cb1cab1532"), 100 },
                    { 6, 4, true, new Guid("a028785e-4dc5-434f-8cd1-828cbc2f1169"), 100 },
                    { 7, 1, true, new Guid("86628830-8827-4a4d-b7ed-fb5fff025f1a"), 100 },
                    { 8, 8, true, new Guid("5a560c3a-6d49-4442-a372-a51e99a27f74"), 100 },
                    { 9, 3, true, new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), 98 },
                    { 10, 4, true, new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), 87 },
                    { 11, 1, true, new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), 90 },
                    { 12, 6, false, new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), 65 },
                    { 13, 3, true, new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), 100 },
                    { 14, 4, true, new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), 100 },
                    { 15, 1, true, new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), 100 },
                    { 16, 6, false, new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), 77 },
                    { 17, 3, false, new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), 63 },
                    { 18, 4, false, new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), 55 },
                    { 19, 1, false, new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), 59 },
                    { 20, 6, false, new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), 50 },
                    { 21, 3, true, new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), 100 },
                    { 22, 4, true, new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), 100 },
                    { 23, 1, true, new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), 100 },
                    { 24, 6, true, new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), 100 },
                    { 25, 3, true, new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), 100 },
                    { 26, 4, false, new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), 74 },
                    { 27, 1, false, new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), 69 },
                    { 28, 6, false, new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), 62 },
                    { 29, 3, false, new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), 73 },
                    { 30, 4, false, new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), 64 },
                    { 31, 1, true, new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), 100 },
                    { 32, 6, false, new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), 47 }
                });

            migrationBuilder.InsertData(
                table: "uservrsets",
                columns: new[] { "Id", "IsFavorite", "OwnerGuid", "VrSetId" },
                values: new object[,]
                {
                    { 1, false, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 3 },
                    { 2, false, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 4 },
                    { 3, false, new Guid("9b3365e0-f33e-4f6f-ada3-aa0649c4c6b8"), 6 },
                    { 4, false, new Guid("59cd92da-6b8f-40b3-ab08-a3cb1cab1532"), 3 },
                    { 5, false, new Guid("a028785e-4dc5-434f-8cd1-828cbc2f1169"), 3 },
                    { 6, false, new Guid("86628830-8827-4a4d-b7ed-fb5fff025f1a"), 3 },
                    { 7, false, new Guid("5a560c3a-6d49-4442-a372-a51e99a27f74"), 3 },
                    { 8, false, new Guid("4f9cf3d6-554d-4662-a896-7b8907688a6a"), 1 },
                    { 9, false, new Guid("fd26857b-9be1-47d3-a518-d834beedf746"), 3 },
                    { 10, false, new Guid("0d33e28a-69e7-400e-87d6-f161935de5c4"), 2 },
                    { 11, false, new Guid("7aea3171-5b7c-48ad-b68d-f191151bbc58"), 4 },
                    { 12, false, new Guid("a380dde9-9ea6-4cd5-8f71-0dd624a2a6f2"), 5 },
                    { 13, false, new Guid("d0f08641-b16c-45a2-a8e0-2af5b33aefd5"), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usergames_GameId",
                table: "usergames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_usergames_OwnerGuid",
                table: "usergames",
                column: "OwnerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_uservrsets_OwnerGuid",
                table: "uservrsets",
                column: "OwnerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_uservrsets_VrSetId",
                table: "uservrsets",
                column: "VrSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usergames");

            migrationBuilder.DropTable(
                name: "uservrsets");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "usersinfo");

            migrationBuilder.DropTable(
                name: "vrsets");
        }
    }
}
